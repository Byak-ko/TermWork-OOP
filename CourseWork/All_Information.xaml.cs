using CourseWork.Arts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CourseWork
{
    /// <summary>
    /// Interaction logic for All_Information.xaml
    /// </summary>
    public partial class All_Information : Window
    {
        private Exhibit currentExhibit;
        private ExhibitType currentExhibitType;
        private string artMovement;
        private ImageBrush imageBrush = new ImageBrush();

        public All_Information(Exhibit exhibit)
        {
            InitializeComponent();
            currentExhibit = exhibit;
            currentExhibitType = exhibit.GetCategoryTypeOfExhibit();
            switch(currentExhibitType)
            {
                case ExhibitType.Sculpture:
                    {
                        imageBrush.ImageSource = UpdateImage("ImageOther/Sculpture001_1K_Color.jpg");
                        imageBrush.Opacity = 0.5;
                        GridAll.Background = imageBrush;

                    } 
                        break;
                case ExhibitType.Painting:
                    {
                        imageBrush.ImageSource = UpdateImage("ImageOther/Painting001_1K_Color.jpg");
                        imageBrush.Opacity= 0.5;
                        GridAll.Background = imageBrush;
                    }
                    break;
                case ExhibitType.AppliedArt:
                    {
                        imageBrush.ImageSource = UpdateImage("ImageOther/AppliedArt001_1K_Color.jpg");
                        imageBrush.Opacity = 0.5;
                        GridAll.Background = imageBrush;
                    }
                    break;
            }
            UpdateInformation();
        }

        private void UpdateAdditionalInfo()
        {
            string addInfo1 = "";
            string addInfo2= "";
            string type = "";
            currentExhibit.GetAdditionalInfoOfExhibit(ref addInfo1, ref addInfo2, ref type);
            AdditionalInfoLabel1.Content = addInfo1;
            AdditionalInfoLabel2.Content = addInfo2;
            TypeLabel.Content = type;
        }
        private void UpdateInformation()
        {       
            UpdateAdditionalInfo();
            ImageExhibit.Source = UpdateImage(currentExhibit.ImagePath);
            NameLabel.Content = "Назва: " + currentExhibit.Name;
            AuthorLabel.Content = "Автор: " + currentExhibit.Author;
            StringConverter stringConverter = new StringConverter();
            artMovement = (string)stringConverter.Convert(currentExhibit.ArtMovement, typeof(Exhibit), null, CultureInfo.CurrentCulture);
            MovementLabel.Content = "Мистецька течія: " + artMovement;
            DateLabel.Content = "Час створення: " + currentExhibit.Date;
            DescriptionBlock.Text = currentExhibit.Description;
        }
        
        private BitmapImage UpdateImage(string imagePath) 
        {
            BitmapImage imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.UriSource = new Uri(imagePath, UriKind.RelativeOrAbsolute);
            imageSource.EndInit();
            return  imageSource;
        }
    }
}
