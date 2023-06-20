using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CourseWork
{
    public class StringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ArtsMovement movement = (ArtsMovement)value;
            string artMovement="";
           switch (movement)
            {
                case ArtsMovement.Baroque:
                    artMovement = "Бароко";
                    break;
                case ArtsMovement.ContemporaryArt:
                    artMovement = "Сучасне мистецтво";
                    break;
                case ArtsMovement.GothicArt:
                    artMovement = "Готичне мистецтво";
                    break;
                case ArtsMovement.Impressionism:
                    artMovement = "Імпресіонізм";
                    break;
                case ArtsMovement.Renaissance:
                    artMovement = "Ренесанс";
                    break;
            }
            return artMovement;
        }

        public object ConvertType(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ExhibitType movement = (ExhibitType)value;
            string exhibitType = "";
            switch (movement)
            {
                case ExhibitType.Painting:
                    exhibitType = "Живопис";
                    break;
                case ExhibitType.AppliedArt:
                    exhibitType = "Прикладне мистецтво";
                    break;
                case ExhibitType.Sculpture:
                    exhibitType = "Скульптура";
                    break;
            }
            return exhibitType;
        }
        public object ConvertBackType(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string exhibitType = (string)value;
            ExhibitType type;
            switch (exhibitType)
            {
                case "Живопис":
                    type = ExhibitType.Painting;
                    break;
                case "Прикладне мистецтво":
                    type = ExhibitType.AppliedArt;
                    break;
                case "Скульптура":
                    type = ExhibitType.Sculpture;
                    break;
                default:
                    throw new ArgumentException("Невідомий тип експонату: " + exhibitType);
            }

            return type;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string artMovement = (string)value;
            ArtsMovement movement;

            switch (artMovement)
            {
                case "Бароко":
                    movement = ArtsMovement.Baroque;
                    break;
                case "Сучасне мистецтво":
                    movement = ArtsMovement.ContemporaryArt;
                    break;
                case "Готичне мистецтво":
                    movement = ArtsMovement.GothicArt;
                    break;
                case "Імпресіонізм":
                    movement = ArtsMovement.Impressionism;
                    break;
                case "Ренесанс":
                    movement = ArtsMovement.Renaissance;
                    break;
                default:
                    throw new ArgumentException("Невідомий рух мистецтва: " + artMovement);
            }

            return movement;
        }
    }
}