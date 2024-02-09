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
    /// Логика взаимодействия для ResumeList.xaml
    /// </summary>
    public partial class ResumeList : Page
    {
        public ResumeList()
        {
            InitializeComponent();
            DataGridResume.ItemsSource = recruitment_agencyEntities.GetContext().Resume.ToList();


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
                            btnAdd.IsEnabled = true;
                            btnDelete.IsEnabled = true;
                            break;
                        case 2:
                            btnAdd.IsEnabled = false;
                            btnAdd.ToolTip = "У вас нет прав";
                            btnDelete.IsEnabled = false;
                            btnDelete.ToolTip = "У вас нет прав";
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
            Manager.MyFrame.Navigate(new ResumeADD());
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var ResumeRemoving = DataGridResume.SelectedItems.Cast<Resume>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {ResumeRemoving.Count()} элементов",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    recruitment_agencyEntities.GetContext().Resume.RemoveRange(ResumeRemoving);
                    recruitment_agencyEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DataGridResume.ItemsSource = recruitment_agencyEntities.GetContext().Resume.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
