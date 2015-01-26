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

using System.Data.SQLite;

using System.Data;

namespace StoreSide
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : UserControl
    {
        string dbConnectionString;

        public LoginPage()
        {
            InitializeComponent();

            dbConnectionString = @"Data Source = mainStore.db; Version = 3;";
        }

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString))
            {
                try
                {
                    sqliteCon.Open();
                    //if (sqliteCon.State == System.Data.ConnectionState.Open)
                    //{
                    //    MessageBox.Show("Connection is done...");
                    //}
                    //string query = "select * from users where userName='" + this.user_name.Text + "' and password='" + this.user_password.Password + "' ";
                    string query = "select userName,password from users ";

                    SQLiteCommand createCommand = new SQLiteCommand(query, sqliteCon);
                    createCommand.ExecuteNonQuery();

                    SQLiteDataReader dataReader = createCommand.ExecuteReader();

                    bool exists = false;
                    bool isCorrect = false;
                    bool isAdmin = false;

                    while (dataReader.Read())
                    {
                        if (dataReader.GetValue(0).ToString() == this.user_name.Text)
                        {
                            exists = true;
                            if (dataReader.GetValue(1).ToString() == this.user_password.Password)
                            {
                                if (this.user_name.Text == "admin")
                                {
                                    isAdmin = true;
                                }
                                isCorrect = true;
                            }
                        }
                    }

                    var mWindow = Application.Current.Windows[0] as MainWindow;

                    if (exists == true)
                    {
                        if (isCorrect == true)
                        {
                            if (isAdmin == true)
                            {
                                mWindow.Exists = true;
                                mWindow.IsCorrect = true;
                                mWindow.IsAdmin = true;
                                mWindow.changeContent();
                                sqliteCon.Close();
                            }
                            else
                            {
                                mWindow.Exists = true;
                                mWindow.IsCorrect = true;
                                mWindow.IsAdmin = false;
                                mWindow.changeContent();
                                sqliteCon.Close();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Паролата е грешна!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Потребителят не съществува!");
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }



        }
    }
}
