using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DatabaseInWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;
        public MainWindow()
        {
            cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\CW4.accdb");
            InitializeComponent();
        }

        public void Do_assetsButton_Click(object sender, RoutedEventArgs e, OleDbConnection cq)
        {
            string query = "select *from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cq);
            cq.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read()) 
            {
                data += read[0].ToString() + "\n";
            }

            AssetsText.Text = data;
        }

        private void assetsButton_Click(object sender, RoutedEventArgs e)
        {
            Do_assetsButton_Click(sender, e, cn);
        }

    }
}
