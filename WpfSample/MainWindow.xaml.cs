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

namespace WpfSample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        delegate void NotifyInput(string liine);

        ConsoleThread console;
        public MainWindow()
        {
            InitializeComponent();
            console = new ConsoleThread(this.Dispatcher, ChangeText);
        }

        void ChangeText(string line)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(new NotifyInput(ChangeText), new object[] { line });
                return;
            }
            TextBox1.Text = line;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (!console.IsActive)
            {
                console.ExecuteConsole();
            }
        }

    }
}
