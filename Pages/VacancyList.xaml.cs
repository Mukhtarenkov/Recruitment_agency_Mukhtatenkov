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
    /// Логика взаимодействия для VacancyList.xaml
    /// </summary>
    public partial class VacancyList : Page
    {
        public VacancyList()
        {
            InitializeComponent();
            DataGridVacancy.ItemsSource = recruitment_agencyEntities.GetContext().Vacancies.ToList();
            if (Manager._currentUser == null)
            {
                btnAdd.IsEnabled = false;
                btnAdd.ToolTip = "У вас нет прав";
                btnDelete.IsEnabled = false;
                btnDelete.ToolTip = "У вас нет прав";
            }
            else
            {
                try
                {
                    switch (Manager._currentUser.Role)
                    {
                        case 1:
                            btnAdd.IsEnabled = false;
                            btnAdd.ToolTip = "У вас нет прав";
                            btnDelete.IsEnabled = false;
                            btnDelete.ToolTip = "У вас нет прав";
                            break;
                        case 2:
                            btnAdd.IsEnabled = true;
                            btnDelete.IsEnabled = true;
                            break;
                        case 3:
                            btnAdd.IsEnabled = true;
                            btnDelete.IsEnabled = true;

                            break;
                        default:
                            btnAdd.IsEnabled = false;
                            btnDelete.IsEnabled = false;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + ex.Message.ToString() + "Критическая ошибка приложения", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MyFrame.Navigate(new VacancyADD());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var Vacancyremoving = DataGridVacancy.SelectedItems.Cast<Vacancies>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {Vacancyremoving.Count()} элементов",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    recruitment_agencyEntities.GetContext().Vacancies.RemoveRange(Vacancyremoving);
                    recruitment_agencyEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DataGridVacancy.ItemsSource = recruitment_agencyEntities.GetContext().Vacancies.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
