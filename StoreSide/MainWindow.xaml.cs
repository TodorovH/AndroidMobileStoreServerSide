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

namespace StoreSide
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string dbConnectionString;

        public MainWindow()
        {
            InitializeComponent();

            dbConnectionString = @"Data Source = D:\Documents\Android Mobile Store Server Side\StoreSide\StoreSide\mainStore.db; Version = 3;";
        }

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            using(SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString))
            {
                try
                {
                    sqliteCon.Open();
                    if (sqliteCon.State == System.Data.ConnectionState.Open)
                    {
                        MessageBox.Show("Connection is done...");
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
