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
        TextDispViewModel textDispViewModel;

        public MainWindow()
        {
            InitializeComponent();

            textDispViewModel = new TextDispViewModel();

            // Window全体に所属させても、TextBox1に直接所属させても
            // 動作に変わりはなかった。
            //DataContext = textDispViewModel;
            TextBox1.DataContext = textDispViewModel;

            console = new ConsoleThread(this.Dispatcher, ChangeText);
        }

        void ChangeText(string line)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.BeginInvoke(new NotifyInput(ChangeText), new object[] { line });
                return;
            }
            textDispViewModel.Model.TextData = line;
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
