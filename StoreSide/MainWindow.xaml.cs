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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool Exists { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsAdmin { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            this.contentControl.Content = new LoginPage();

        }

        public void changeContent()
        {
            if (Exists == true && IsCorrect == true && IsAdmin == true)
            {
                this.contentControl.Content = new AdminPage();
            }
            else if (Exists == true && IsCorrect == true && IsAdmin == false)
            {
                this.contentControl.Content = new UserPage();
            }
            
        }
    }
}
