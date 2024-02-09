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
    /// Логика взаимодействия для VacancyADD.xaml
    /// </summary>
    public partial class VacancyADD : Page
    {
        public VacancyADD()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Vacancies userBDJ = new Vacancies()
                {
                    Vacancy = Vacancy.Text,
                    Employer = Employer.Text,
                    Specifications = Specifications.Text,
                    Affiliation = Affiliations.Text,
                    ContanctInfo = ContactInfo.Text

                };
                recruitment_agencyEntities.GetContext().Vacancies.Add(userBDJ);
                recruitment_agencyEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные добавлены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
