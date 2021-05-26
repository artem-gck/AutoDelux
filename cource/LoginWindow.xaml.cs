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
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using cource.Log_Reg;
using cource.Connection;
using System.Windows.Media.Animation;
using cource.Main;

namespace cource
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            LoginTextBox.Focus();
        }

        private void MouseLeftButtonDown_Drag(object sender, RoutedEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            DoubleAnimation anim = new DoubleAnimation();

            anim.From = this.Opacity;
            anim.To = 0;
            anim.Duration = TimeSpan.FromSeconds(0.4);
            anim.EasingFunction = new QuarticEase();

            anim.Completed += (s, a) =>
            {
                Environment.Exit(0);
            };

            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        private void Button_Click_Min(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(LoginTextBox.Text) || !string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                string mySQL = "SELECT * FROM LoginTable " +
                               "WHERE Login = '" + LoginTextBox.Text + "'";

                DataTable userData = ServerConnection.executeSQL(mySQL);

                if (userData.Rows.Count > 0)
                {
                    foreach (DataRow row in userData.Rows)
                    {
                        if (Hashing.ValidatePassword(PasswordTextBox.Text, (string)row[2]))
                        {
                            Data.admin = (bool)row[3];

                            MainWindow win = new MainWindow();
                            win.Opacity = 0;

                            DoubleAnimation anim = new DoubleAnimation();

                            anim.From = this.Opacity;
                            anim.To = 0;
                            anim.Duration = TimeSpan.FromSeconds(0.4);
                            anim.EasingFunction = new QuarticEase();

                            anim.Completed += (s, a) =>
                            {
                                DoubleAnimation anim1 = new DoubleAnimation();

                                win.Visibility = Visibility.Visible;

                                anim1.From = win.Opacity;
                                anim1.To = 1;
                                anim1.Duration = TimeSpan.FromSeconds(0.4);
                                anim1.EasingFunction = new QuarticEase();

                                win.BeginAnimation(UIElement.OpacityProperty, anim1);
                                this.Close();
                            };

                            this.BeginAnimation(UIElement.OpacityProperty, anim);

                            
                        }
                        else
                        {
                            RegLog.Content = "Wrong login or password";
                            Animation.CreateAnimOpen(RegLog);
                        }
                    }
                }
                else
                {
                    RegLog.Content = "Wrong login or password";
                    Animation.CreateAnimOpen(RegLog);
                }
            }
            else
            {
                RegLog.Content = "Enter login and password";
                Animation.CreateAnimOpen(RegLog);
            }
        }

        private void Button_Click_Registration(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(LoginTextBox.Text) || !string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                try
                {
                    string mySQL = "SELECT * FROM LoginTable " +
                               "WHERE Login = '" + LoginTextBox.Text + "'";

                    DataTable userData = ServerConnection.executeSQL(mySQL);

                    if (userData.Rows.Count == 0)
                    {
                        string stringConnection = "Data Source=DESKTOP-2IBEC2I\\SQLEXPRESS;Initial Catalog=LoginDataBase;Integrated Security=True";

                        SqlConnection connection = new SqlConnection();
                        connection.ConnectionString = stringConnection;
                        connection.Open();

                        SqlCommand command = connection.CreateCommand();

                        command.CommandText = "INSERT INTO LoginTable VALUES(@value1, @value2, @value3, @value4)";
                        command.Parameters.Add("@value1", SqlDbType.NVarChar, 50).Value = LoginTextBox.Text;
                        command.Parameters.Add("@value2", SqlDbType.NVarChar).Value = Hashing.HashPassword(PasswordTextBox.Text);
                        command.Parameters.Add("@value3", SqlDbType.Bit).Value = false;
                        command.Parameters.Add("@value4", SqlDbType.Bit).Value = false;

                        command.ExecuteNonQuery();
                        connection.Close();

                        RegLog.Content = "Successful registration";
                        Animation.CreateAnimOpen(RegLog);
                    }
                    else
                    {
                        RegLog.Content = "This user already exists";
                        Animation.CreateAnimOpen(RegLog);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("SQL Server Connection Failed", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                RegLog.Content = "Enter login and password";
                Animation.CreateAnimOpen(RegLog);
            }
        }

        private void LoginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Animation.CreateAnimClose(RegLog);
        }

        private void PasswordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Animation.CreateAnimClose(RegLog);
        }
    }
}
