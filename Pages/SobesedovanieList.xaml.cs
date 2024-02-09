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
    /// Логика взаимодействия для SobesedovanieList.xaml
    /// </summary>
    public partial class SobesedovanieList : Page
    {
        public SobesedovanieList()
        {
            InitializeComponent();
            DataGridSobesedovanie.ItemsSource = recruitment_agencyEntities.GetContext().sobesedovanie.ToList();

            if (Manager._currentUser == null)
            {
                btnAdd.IsEnabled = false;
                btnAdd.ToolTip = "У вас нет прав";
                btnDelete.IsEnabled = false;
                btnDelete.ToolTip = "У вас нет прав";
                btnResume.IsEnabled = false;
                btnRVacancy.IsEnabled = false;
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
                            btnResume.IsEnabled = false;
                            btnRVacancy.IsEnabled = false;
                            break;
                        case 2:
                            btnAdd.IsEnabled = false;
                            btnAdd.ToolTip = "У вас нет прав";
                            btnDelete.IsEnabled = false;
                            btnDelete.ToolTip = "У вас нет прав";
                            btnResume.IsEnabled = false;
                            btnRVacancy.IsEnabled = false;
                            break;
                        case 3:
                            btnAdd.IsEnabled = true;
                            btnDelete.IsEnabled = true;
                            btnResume.IsEnabled = true;
                            btnRVacancy.IsEnabled = true;

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
            Manager.MyFrame.Navigate(new SobesedovanieADD());


        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var SobesedovanieRemoving = DataGridSobesedovanie.SelectedItems.Cast<sobesedovanie>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {SobesedovanieRemoving.Count()} элементов",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    recruitment_agencyEntities.GetContext().sobesedovanie.RemoveRange(SobesedovanieRemoving);
                    recruitment_agencyEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DataGridSobesedovanie.ItemsSource = recruitment_agencyEntities.GetContext().sobesedovanie.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnResume_Click(object sender, RoutedEventArgs e)
        {
            Window resume= (new ResumeWindow() );
            resume.Show();
        }

        private void btnRVacancy_Click(object sender, RoutedEventArgs e)
        {
            Window vacancy=  (new VacancyWindow());
            vacancy.Show();
        }
    }
}
