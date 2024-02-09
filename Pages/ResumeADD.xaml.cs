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
    /// Логика взаимодействия для ResumeADD.xaml
    /// </summary>
    public partial class ResumeADD : Page
    {
        public ResumeADD()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Resume userBDJ = new Resume()
                {
                    Name = Name.Text,
                    FamilyName = FamilyName.Text,
                    DadsName = DadsName.Text,   
                    Education = Education.Text,
                    PhoneNumber = PhoneNumber.Text,
                    Proficiences = Proficiencies.Text,
                    Mail = Mail.Text
                };
                recruitment_agencyEntities.GetContext().Resume.Add(userBDJ);
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
