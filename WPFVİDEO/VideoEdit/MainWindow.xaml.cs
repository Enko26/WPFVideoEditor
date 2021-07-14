using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace WPFVideoEdit
{
    /// <summary>
    /// MainWindow Sınıfı içinde kullanılacak olarak tanımlamalar.
    /// Dosyaları açtığımız formatları, seçim şeklinde kullanacak parametreleri tanımladık.
    /// </summary>
    public partial class MainWindow : Window
    {

        DispatcherTimer tempo=new DispatcherTimer();
        
        
        String Ses="Ses(mp3,wma,wav)|*.mp3;*.MP3;*.wma;*.wav";
        String Video = "Video(MP4,MPG,AVI,WMV,DAT)|*mp4;*,*.mpg,*.MPG,*.MP4;*avi;*.wmv;*.DAT";
        String Multi = "Multimedya(mp3,mp4,mpg)|*.mp3;*.MP3;*.mpg;*.MPG;*.wma;*.wav;*mp4;*.MP4;*avi;*.wmv;*.DAT";

        private Boolean MedyaPause= false;
        private Boolean coklusecim = false;
        private String Medya_tür = "";
        private bool fullscreen = false;
        private bool tekrar = false;
        private String türdosya = ""; 
        private bool mute = false;

        DispatcherTimer timer;
        bool isDragging; 
        ListBoxItem mevcutparca; 
        ListBoxItem Öncekiparca; 
        Brush parcarengi;

        /// <summary>
        /// Ana method
        /// onay her saniye tetikleniyor bunun için zamanlayıcımız(timer) mevcut.
        /// </summary>
        public MainWindow()
        {
           
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(timer_Tick);
            isDragging = false;
            parcarengi = Brushes.Gold;
            btPause.Visibility= Visibility.Collapsed;
            BorderMedyaControls.IsEnabled = false;

           
            tempo.Tick+=tempo_Tick;
            tempo.Interval = new TimeSpan(0, 0, 1);
          
        }

        int say = 0;
        private void tempo_Tick(object sender, EventArgs e)
        {
            say+=1;
            if(say==3)
            {
                BorderMedyaControls.Visibility = Visibility.Collapsed;
                tempo.Stop();
            }
        }
        /// <summary>
        /// Dosyaları açma ve listeye yükleme methodu .
        /// </summary>
        private void Dosyac()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = türdosya;
            dialog.Multiselect = coklusecim;
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            dialog.Title = "Bir Veya Birden Fazla Dosya Seçin";
            Nullable<bool> result = dialog.ShowDialog();
            try
            {

                if (result == true)
                {

                    coklusecim = false;
                    medya.IsExpanded = false;
                    Sess.IsExpanded = false;
                    video.IsExpanded = false;
                    videolist.Visibility = Visibility.Visible;
                    Stop();
                    medyacontrol.Source = null;
                    mevcutparca = null;
                    lbList.Items.Clear();
                    string[] selectedFiles = dialog.FileNames;
                    acilan(selectedFiles);
              
                }
                else
                    coklusecim = false;

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
        /// <summary>
        /// Açılan dosya tipleri istenilen gibiyse açıp listeye ekletiyor, istenilen gibi değil ise uyarı penceremiz çıkıyor.
        /// </summary>
        /// <param name="selecteds"></param>
        private void acilan(string[] selecteds)     
        {
            foreach (string file in selecteds)
            {
                if (System.IO.Path.GetExtension(file) == ".mp3" ||
                     System.IO.Path.GetExtension(file) == ".MP3" ||
                     System.IO.Path.GetExtension(file) == ".mpg" ||
                     System.IO.Path.GetExtension(file) == ".MPG" ||
                     System.IO.Path.GetExtension(file) == ".mp4" ||
                     System.IO.Path.GetExtension(file) == ".MP4" ||
                     System.IO.Path.GetExtension(file) == ".wma" ||
                     System.IO.Path.GetExtension(file) == ".wav" ||
                     System.IO.Path.GetExtension(file) == ".wmv" ||
                     System.IO.Path.GetExtension(file) == ".avi" ||
                     System.IO.Path.GetExtension(file) == ".DAT")
                {
                    ListBoxItem listaitem = new ListBoxItem();
                    listaitem.Content = System.IO.Path.GetFileNameWithoutExtension(file);
                    listaitem.Tag = file;
                    lbList.Items.Add(listaitem);
                    BorderMedyaControls.IsEnabled = true;
                   
                }
                else
                    MessageBox.Show("Dosya Türü Desteklenmiyor ", " Bilgi ");
            }
            if (mevcutparca == null)
            {
                lbList.SelectedIndex = 0;
                PlayPause();
            }

        }

        /// <summary>
        /// Method TürMedya() ne tür medyanın (ses veya video) oynatıldığını belirler.
        /// </summary>
        private void TürMedya()
        {
            if (Medya_tür == ".mp3"|| Medya_tür == ".MP3"|| Medya_tür == ".wma" || Medya_tür == ".wav")
            {
                var margin = videolist.Margin;
                margin.Left = 0;
                margin.Top = 22;
                margin.Right = 0;
                videolist.Margin = margin;
                videolist.Width = 1077;
                videolist.Height = 421;
                tempo.Stop();
                say = 0;
                BorderMedyaControls.Visibility = Visibility.Visible;
           
            }
            else
            {
                videolist.Margin = new Thickness(950, 22, 0, 0);
                videolist.Width = 127;
                videolist.Height = 486;
            }

        }


        /// <summary>
        /// Oynat veya Duraklat methodu.
        /// eğer listede eleman varsa oynat duraklat aktif.
        /// </summary>
        private void PlayPause()
        {
            
            if (lbList.HasItems)
            {
                if (btPlay.Visibility == Visibility.Visible)
                {
                    Play();
                }

                else if (btPause.Visibility == Visibility.Visible)
                {
                    Pause();
                }
            }   
          
        }

        /// <summary>
        /// Oynatma methodumuz.
        /// Daha önce bir parça çalıyorsa burada parça değişikliği yapılır.
        /// play pause butonlarının durumlarını ayarlar.
        /// </summary>
        private void Play()
        {
            if (lbList.HasItems)
            {
                if (!MedyaPause) 
                {
                    if (mevcutparca != null) 
                    {
                        Öncekiparca = mevcutparca;
                        Öncekiparca.Foreground = lbList.Foreground; 
                    }
                    mevcutparca = (ListBoxItem)lbList.SelectedItem;
                    mevcutparca.Foreground = parcarengi;
                    Medya_tür = System.IO.Path.GetExtension(mevcutparca.Tag.ToString());
                    medyacontrol.Source = new Uri(mevcutparca.Tag.ToString());              
                    slideravance.Value = 0;
                }
                TürMedya();
                medyacontrol.Play();
                MedyaPause = false;
                btPlay.Visibility = Visibility.Collapsed;
                btPause.Visibility = Visibility.Visible;
            }
          
        }
        /// <summary>
        /// Duraklatma methodu.
        /// </summary>
        private void Pause()
        {
            btPause.Visibility = Visibility.Collapsed;
            btPlay.Visibility = Visibility.Visible;
            medyacontrol.Pause();
            MedyaPause = true;       
        }
        //Fin metodo Play

        /// <summary>
        /// Bir sonraki parçaya geçiş yapma methodu.
        /// Listede sadece bir tane varsa kontrol etme aynısını tekrarla dedik.
        /// Bir sonraki parçada video mu yoksa ses mi olduğunu görmek için TürMedya'yı çağırdık.
        /// </summary>
        private void Sonraki()
        {
            if (lbList.HasItems)
            {

                if (tekrar)
                {
                    lbList.SelectedIndex = lbList.SelectedIndex;
                    MedyaPause = false;
                    Play();
                }
                else
                {
                    if (lbList.Items.IndexOf(mevcutparca) < lbList.Items.Count - 1)
                    {
                        lbList.SelectedIndex = lbList.Items.IndexOf(mevcutparca) + 1;
                        MedyaPause = false;
                        Play();
                        return;
                    }
                    else if (lbList.Items.IndexOf(mevcutparca) == lbList.Items.Count - 1)
                    {
                        lbList.SelectedIndex = 0;
                        MedyaPause = false;
                        Play();
                        return;
                    }
                }
            }
            else
                Stop();
          
        }
        /// <summary>
        /// Önceki parçada değişiklik yapan method Sonraki methoduyla aynı şekilde çalışır. 
        /// </summary>
        private void Önceki()
        {

            if (lbList.Items.IndexOf(mevcutparca) > 0)
            {
                lbList.SelectedIndex = lbList.Items.IndexOf(mevcutparca) - 1;
                MedyaPause = false;
                Play();
            }
            else if (lbList.Items.IndexOf(mevcutparca) == 0)
            {
                lbList.SelectedIndex = lbList.Items.Count - 1;
                MedyaPause = false;
                Play();
            }
         
        }

        /// <summary>
        ///  Stop methodu Liste boş olmadığı sürece oynatmayı durdurur
        /// </summary>
        private void Stop()
        {


            if (lbList.HasItems)
            {
                btPlay.Visibility = Visibility.Visible;
                btPause.Visibility = Visibility.Collapsed;
                medyacontrol.Stop();
                MedyaPause = false;
                medyacontrol.Source = null;
                

            }
        }   

        /// <summary>
        /// Açılan parça video olduğu sürece Tam Ekranı etkinleştirmemize yarayan method.
        /// </summary>
        private void FullEkran()
        {
            if (lbList.HasItems)
            {
                    if(Medya_tür != ".mp3"&& Medya_tür != ".MP3"&& Medya_tür != ".wma"&& Medya_tür != ".wav")
                    {

                        if (!fullscreen)
                        {
                            RootGrid.Children.Remove(bordercontrol);
                            RootGrid.Children.Remove(BorderMedyaControls);
                            gridmedya.Children.Remove(medyacontrol);
                            RootGrid.Children.Remove(gridmedya);
                            this.Content = medyacontrol;

                            this.WindowStyle = WindowStyle.None;
                            this.WindowState = WindowState.Maximized;

                        }

                        else
                        {
                            this.Content = RootGrid;
                            gridmedya.Children.Add(medyacontrol);
                            RootGrid.Children.Add(gridmedya);
                            RootGrid.Children.Add(bordercontrol);
                            RootGrid.Children.Add(BorderMedyaControls);



                            this.WindowStyle = WindowStyle.None;
                            this.WindowState = WindowState.Normal;

                        }

                        fullscreen = !fullscreen;
                   
                    
                    }
                    else
                    {
                        MessageBox.Show("Ses Oynatma", "Video Editor", MessageBoxButton.OK, MessageBoxImage.Information);
                    }              
            }
            else
                MessageBox.Show("Liste Şuan Boş", "Video Editor", MessageBoxButton.OK, MessageBoxImage.Information);
             
        }


        /// <summary>
        /// Mute methodu sesi kapatır ve sesi kapat düğmesine resmini yükler ve bunun tersi de aynı şekilde uygulanır.
        /// </summary>
        private void Mute()
        {

            if (!mute)
            {

               
                btVol.Source = new BitmapImage(new Uri(@"../../Resources/btn_mute_P.png", UriKind.Relative));
                medyacontrol.IsMuted = true;

            }
            else
            {
                medyacontrol.IsMuted = false;
                btVol.Source = new BitmapImage(new Uri(@"../../Resources/btn_volume_P.png", UriKind.Relative));
              
            }

            mute = !mute;
        
        }


        /// <summary>
        /// Tekrar oynatma methodu.
        /// </summary>

        private void Tekrar()
        {
            tekrar = !tekrar;

            if(tekrar)
            {
                btRepeat.Visibility = Visibility.Collapsed;
                btRepeatActivo.Visibility = Visibility.Visible;
            }
            else
            {
                btRepeatActivo.Visibility = Visibility.Collapsed;
                btRepeat.Visibility = Visibility.Visible;
            }

        }

        private void cikis_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ayarlar_Expanded(object sender, RoutedEventArgs e)
        {
            medya.IsExpanded = false;
            video.IsExpanded = false;
            Sess.IsExpanded = false;
        }

        private void sesart_Click(object sender, RoutedEventArgs e)
        {
            slidervol.Value = slidervol.Value + 0.1;
        }
        private void sesazal_Click(object sender, RoutedEventArgs e)
        {
            slidervol.Value = slidervol.Value - 0.1;
        }

        private void Sess_Expanded(object sender, RoutedEventArgs e)
        {
            medya.IsExpanded = false;
            ayarlar.IsExpanded = false;
            video.IsExpanded = false;
        }

        private void video_Expanded(object sender, RoutedEventArgs e)
        {
            medya.IsExpanded = false;
            ayarlar.IsExpanded = false;
            Sess.IsExpanded = false;
        }


        private void mediacontrol_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FullEkran();
        }

        /// <summary>
        /// // SliderTimeLine (Video süresi oynatma çizgisi) üzerinde sürükleme işlemi yoksa, konumu her saniye güncellenir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (!isDragging)
            {
                slideravance.Value=medyacontrol.Position.TotalSeconds;
                lbtime.Content = medyacontrol.Position.Minutes + ":" + medyacontrol.Position.Seconds;
                
            }
        }

        private void mediacontrol_MediaOpened(object sender, RoutedEventArgs e)
        {
                TimeSpan ts = medyacontrol.NaturalDuration.TimeSpan;
                slideravance.Maximum = ts.TotalSeconds;         
                timer.Start();
        }
        /// <summary>
        ///  Konum, kaydırıcının değerine göre güncellenir.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void slideravance_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            medyacontrol.Position = TimeSpan.FromSeconds(slideravance.Value); 

        }


        void lbLista_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {

            if (lbList.SelectedItem != null)
            {
                if (lbList.SelectedItem.ToString() != null)
                {
                    int index = lbList.SelectedIndex;
                    lbList.SelectedIndex = index;
                    MedyaPause = false;
                    Play();                 

                }

            }
               
        }

        private void mediacontrol_MediaEnded(object sender, RoutedEventArgs e)
        {        
            Sonraki();
        }

        private void parcalariac_Click(object sender, RoutedEventArgs e)
        {
            türdosya = Ses;
            coklusecim = !coklusecim;
            Dosyac();
        }
        private void parcayiac_Click(object sender, RoutedEventArgs e)
        {
            türdosya = Ses;
            Dosyac();
        }
        
        private void oynat_Click(object sender, RoutedEventArgs e)
        {
            Play();
            ayarlar.IsExpanded = false;
        }
        private void önceki_Click(object sender, RoutedEventArgs e)
        {
            Önceki();
            ayarlar.IsExpanded = false;
        }

        private void sonraki_Click(object sender, RoutedEventArgs e)
        {
            Sonraki();
            ayarlar.IsExpanded = false;
        }

        private void dur_Click(object sender, RoutedEventArgs e)
        {
            Stop();
            ayarlar.IsExpanded = false;
        }


        private void bordercontroles_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


        private void btkücül_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btcikis_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void RootWindow_Loaded(object sender, RoutedEventArgs e)
        {
                      
        }

        private void imarepeat_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tekrar();
        }

        private void btStop_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Stop();
        }

        private void btBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Önceki();
        }

        private void btPlay_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Play();
        }

        private void btNext_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Sonraki();
        }

        private void btVol_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Mute();
        }

        private void btScreen_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            FullEkran();
        }

        private void lbLista_Drop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            acilan(s);
        }

        private void mediacontrol_MouseMove(object sender, MouseEventArgs e)
        {
            tempo.Start();
            say = 0;
            BorderMedyaControls.Visibility = Visibility.Visible;
        }
     

        private void btPause_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            Pause();
        }

        private void Menupause_Click(object sender, RoutedEventArgs e)
        {
            Pause();
            ayarlar.IsExpanded = false;

        }
        private void meyda_Expanded(object sender, RoutedEventArgs e)
        {
            ayarlar.IsExpanded = false;
            video.IsExpanded = false;
            Sess.IsExpanded = false;
        }
        private void videoac_Click(object sender, RoutedEventArgs e)
        {
            türdosya = Video;
            coklusecim = !coklusecim;
            Dosyac();
        }

        private void fullekran_Click(object sender, RoutedEventArgs e)
        {
            FullEkran();
        }

        private void dosyac_Click(object sender, RoutedEventArgs e)
        {
            türdosya = Multi;
            Dosyac();

        }

        private void cokludosya_Click(object sender, RoutedEventArgs e)
        {
            coklusecim = !coklusecim;
            türdosya = Multi;
            Dosyac();

        }
    }
}
