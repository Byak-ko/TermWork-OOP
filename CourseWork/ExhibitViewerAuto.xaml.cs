using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Xml;
using System.Globalization;
using System.Windows.Automation;

namespace CourseWork
{
    /// <summary>
    /// Interaction logic for ExhibitViewerAuto.xaml
    /// </summary>
    public partial class ExhibitViewerAuto : Window
    {
        private List<Exhibit> exhibits;
        private Exhibit currentExhibit;
        private int currentIndex=0;
        private Timer timer;
        private string artMovement;
        private bool flag = false;
        private ImageBrush imageBrush = new ImageBrush();
        private ImageBrush imageStop = new ImageBrush();
        public ExhibitViewerAuto(List<Exhibit> previousExhibits)
        {
            imageStop.ImageSource = new BitmapImage(new Uri("ImageOther/pause.png", UriKind.RelativeOrAbsolute));
            exhibits = previousExhibits;
            InitializeComponent();
            InitializeTimer();
            UpdateInformation();
        }

        private void InitializeTimer()
        {          
            timer = new Timer();
            timer.Interval = 10000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateInformation();
            currentIndex = (currentIndex + 1) % exhibits.Count; 
        }
        private void UpdateInformation()
        {
            currentExhibit = exhibits[currentIndex];
            UpdateImage();
            NameLabel.Content = "Назва: " + currentExhibit.Name;
            AuthorLabel.Content = "Автор: " + currentExhibit.Author;
            StringConverter stringConverter = new StringConverter();
            artMovement = (string)stringConverter.Convert(currentExhibit.ArtMovement, typeof(Exhibit), null, CultureInfo.CurrentCulture);
            MovementLabel.Content = "Мистецька течія: " + artMovement;
            DateLabel.Content = "Час створення: " + currentExhibit.Date;
        }
        private void UpdateImage()
        {
            BitmapImage imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.UriSource = new Uri(currentExhibit.ImagePath, UriKind.RelativeOrAbsolute);
            imageSource.EndInit();
            ImageExhibit.Source = imageSource;
        }

        private void AdditionalInfoButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            All_Information all_Information = new All_Information(currentExhibit);
            all_Information.Show();
        }


        private void PlayStopButton_Click(object sender, RoutedEventArgs e)
        {
            flag = !flag;
            if (flag)
            {
                timer.Stop();
                imageBrush.ImageSource = new BitmapImage(new Uri("ImageOther/play.png", UriKind.RelativeOrAbsolute));
                PlayStopButton.Background= imageBrush;
            }
            else
            {

                timer.Start();
                imageBrush.ImageSource = new BitmapImage(new Uri("ImageOther/pause.png", UriKind.RelativeOrAbsolute));
                PlayStopButton.Background = imageBrush;
            }  
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            currentIndex = currentIndex <= 0 ? exhibits.Count - 1 : currentIndex - 1;
            UpdateInformation();
            timer.Start();
            PlayStopButton.Background = imageStop;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            currentIndex = (currentIndex + 1) % exhibits.Count;
            UpdateInformation();
            timer.Start();
            PlayStopButton.Background = imageStop;
        }
    }
}
