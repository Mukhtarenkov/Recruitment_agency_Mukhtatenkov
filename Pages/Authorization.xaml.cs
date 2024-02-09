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
using Recruitment_agency_Mukhtatenkov.Pages;

namespace Recruitment_agency_Mukhtatenkov.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void Regbtn_Click(object sender, RoutedEventArgs e)
        {
            Manager.MyFrame.Navigate(new Registration());
        }

        private void Vhod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var UserObj = recruitment_agencyEntities.GetContext().User.FirstOrDefault(x => x.Login == Login.Text && x.Password == Password.Text);
                if (UserObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (CaptchaInput.Text == "")
                {
                    MessageBox.Show("Введите капчу", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                else if (CaptchaInput.Text == "ABCDEF")
                {
                    MessageBox.Show("Капча верна", "Авторизация успешна", MessageBoxButton.OK, MessageBoxImage.Information);
                    Manager._currentUser = UserObj;

                    switch (UserObj.Role)
                    {
                        case 1:
                            MessageBox.Show("Вы вошли в качестве Соискателя " + UserObj.Login + "!", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.MyFrame.Navigate(new ListSelector());
                            break;
                        case 2:
                            MessageBox.Show("Вы вошли в качестве Работодателя " + UserObj.Login + "!", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.MyFrame.Navigate(new ListSelector());
                            break;
                        case 3:
                            MessageBox.Show("Вы вошли в качестве Менеджера " + UserObj.Login + "!", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.MyFrame.Navigate(new ListSelector());
                      
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены " + UserObj.Login + "!", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager.MyFrame.Navigate(new ListSelector());
                            
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message.ToString() + "Критическая ошибка приложения", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
