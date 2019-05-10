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

namespace loginPage2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Modals.PersonContext())
            {
                var res = db.Persons.Where(i => i.UserName == UserName.Text || i.Email == UserName.Text)
                    .Where(i => i.Password == Password.Password).FirstOrDefault();
                
                if (res != null)
                {
                    MessageBox.Show("Hi!");
                }else
                {
                    MessageBox.Show("this username or password is incorect");
                }
            }
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Modals.PersonContext())
            {
                db.Persons.Add(new Modals.Person() { UserName = UserNameNew.Text, FullName = this.FullName.Text, Email = this.Email.Text, Password = this.PasswordNew.Password, PhoneNumber = this.PhoneNumber.Text });
                db.SaveChanges();
                UserNameNew.Text = "";this.FullName.Text = "";this.Email.Text = "";this.PasswordNew.Password = "";this.PhoneNumber.Text = "";
            }
        }
    }
}
