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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Recruitment_agency_Mukhtatenkov.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListSelector.xaml
    /// </summary>
    public partial class ListSelector : Page
    {
        public ListSelector()
        {
            InitializeComponent();
           
        }

        

        private void btnvacancylist_Click(object sender, RoutedEventArgs e)
        {
            Manager.MyFrame.Navigate(new VacancyList());
        }

        private void btnsobesedovaniyalist_Click(object sender, RoutedEventArgs e)
        {

            Manager.MyFrame.Navigate(new SobesedovanieList());

        }

        private void btnresumelist_Click(object sender, RoutedEventArgs e)
        {
            Manager.MyFrame.Navigate(new ResumeList());
        }
    }
}
