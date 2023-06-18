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
using System.Windows.Shapes;
using CourseWork.Arts;
using System.IO;
using System.Text.Json;
using System.Globalization;

namespace CourseWork
{
    /// <summary>
    /// Interaction logic for ExhibitViewer.xaml
    /// </summary>
    public partial class ExhibitViewer : Window
    {
        public ExhibitViewer(List<Exhibit> exhibits)
        {
            InitializeComponent();
            exhibitListView.ItemsSource = exhibits;
          
        }

        private void exhibitListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedExhibit = (sender as ListViewItem).Content as Exhibit;
            All_Information infWindow = new All_Information(selectedExhibit);
            infWindow.Show();
        }
    }
}
