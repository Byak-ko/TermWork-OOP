using CourseWork.Arts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CourseWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string appliedArtsPath = "C:/Users/maxim/OneDrive/Робочий стіл/OOP CoureWork/CourseWork/CourseWork/ExhibitsInfo/AppliedArt.json";

        private string paintingPath = "C:/Users/maxim/OneDrive/Робочий стіл/OOP CoureWork/CourseWork/CourseWork/ExhibitsInfo/Painting.json";

        private string sculpurePath = "C:/Users/maxim/OneDrive/Робочий стіл/OOP CoureWork/CourseWork/CourseWork/ExhibitsInfo/Sculpture.json";

        private List<Exhibit> exhibits;
        private List<Exhibit> exhibitsToDisplay;

        private StringConverter stringConverter;
        public MainWindow()
        {
            exhibits = new List<Exhibit>();

            exhibits.AddRange(GetConcreteExhibit<AppliedArt>(appliedArtsPath));
            exhibits.AddRange(GetConcreteExhibit<Painting>(paintingPath));
            exhibits.AddRange(GetConcreteExhibit<Sculpture>(sculpurePath));
           
        
            InitializeComponent();
            AuthorComboBox.Items.Add(" ");
            stringConverter = new StringConverter();
            HashSet<string> hs = exhibits.Select(x => x.Author).ToHashSet();
            foreach (string s in hs) 
                AuthorComboBox.Items.Add(s);
        }

        private static List<T> GetConcreteExhibit<T>(string path) where T : Exhibit
        {
            try
            {
                string json = File.ReadAllText(path);
                
                return JsonSerializer.Deserialize<List<T>>(json);
            }
            catch (JsonException ex)
            {
                MessageBox.Show("Помилка при десеріалізації JSON: " + ex.Message);
                return new List<T>();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {          
            if (RandomRadioButton.IsChecked == true)
            {
                exhibitsToDisplay =  GetRandomlyExhibits();
            }
            else
            {
                exhibitsToDisplay = GetExhibitsByAttributes();
            }


            exhibitsToDisplay.Sort((x, y) => x.Date.CompareTo(y.Date));

            if (exhibitsToDisplay.Count == 0)
            {
                MessageBox.Show("Не вдалося знайти експонатів за задиними атрибутами, спробуйте інші");

            }

            else if (ListRadioButton.IsChecked == true)
            {
                ExhibitViewer exhibitViewer = new ExhibitViewer(exhibitsToDisplay);
                exhibitViewer.Show();
            }

            else
            {
                ExhibitViewerAuto exhibitViewerAuto = new ExhibitViewerAuto(exhibitsToDisplay);
                exhibitViewerAuto.Show();
            }
            
        }

        private List<Exhibit> GetRandomlyExhibits()
        {
            int amount = exhibits.Count/2;
            if (AmountRandom.Text != "")
            {
                try 
                {
                    amount = Convert.ToInt32(AmountRandom.Text);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Неправильний формат: " + ex.Message);
                }
            }
            if (amount > exhibits.Count) 
            { 
                amount = exhibits.Count;
            }
            Random random = new Random();
            Exhibit exhibit;
            List<Exhibit> newExibits = new List<Exhibit>(exhibits);
            int n = newExibits.Count;

            while (n > 1)
            {       
                n--;
                int k = random.Next(n + 1);
                exhibit = newExibits[k];
                newExibits[k] = newExibits[n];
                newExibits[n] = exhibit;
            }

            return newExibits.GetRange(0, amount);
        }

        private List<Exhibit> GetExhibitsByAttributes()
        {
            List<Exhibit> newExhibits = new List<Exhibit>(exhibits);

            if (AuthorComboBox.SelectedItem != null && AuthorComboBox.SelectedValue.ToString() != " ")
            {
                string authorName = AuthorComboBox.SelectedItem.ToString();
                newExhibits = newExhibits.Where(exhibit => exhibit.Author.Equals(authorName)).ToList();
            }
            if (MovementComboBox.SelectedItem != null && (MovementComboBox.SelectedItem as ComboBoxItem).Content.ToString() != " ")
            {
                string selectedItemMovement = (MovementComboBox.SelectedItem as ComboBoxItem).Content.ToString();
                ArtsMovement arts = (ArtsMovement)stringConverter.ConvertBack(selectedItemMovement, typeof(Exhibit), null, CultureInfo.CurrentCulture);
                newExhibits = newExhibits.Where(exhibit => exhibit.ArtMovement == arts).ToList();
            }
            if (TypeComboBox.SelectedItem != null && (TypeComboBox.SelectedItem as ComboBoxItem).Content.ToString() != " ")
            {
                string selectedItemType =
                    (TypeComboBox.SelectedItem as ComboBoxItem).Content.ToString();
                ExhibitType exhibitType = 
                    (ExhibitType)stringConverter.ConvertBackType
                        (selectedItemType, typeof(Exhibit), null, CultureInfo.CurrentCulture);
                newExhibits =
                    newExhibits.Where
                        (exhibit => exhibit.GetCategoryTypeOfExhibit() == exhibitType).ToList();
            }
            if (DateFrom.Text != "")
            {
                try
                {
                    int dateFrom = Convert.ToInt32(DateFrom.Text);
                    int dateTo = int.MaxValue;
                    if (DateTo.Text != "")
                        dateTo = Convert.ToInt32(DateTo.Text);
                    int difference = dateTo - dateFrom;
                    if (difference >= 0)
                        newExhibits = newExhibits.Where(exhibit => exhibit.Date >= dateFrom && exhibit.Date <= dateTo).ToList();
                }
                catch (FormatException ex)
                {
                    MessageBox.Show("Неправильний формат: " + ex.Message);
                }
            }

            return newExhibits;
        }

        private void CustomRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RandomStackPanel.Visibility = Visibility.Collapsed;
            CustomStackPanel.Visibility = Visibility.Visible;          

        }

        private void RandomRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            CustomStackPanel.Visibility = Visibility.Collapsed;
            RandomStackPanel.Visibility = Visibility.Visible;
        }


    }
}
