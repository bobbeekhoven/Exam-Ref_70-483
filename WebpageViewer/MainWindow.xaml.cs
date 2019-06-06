using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace WebpageViewer
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

        private async Task<string> FetchWebPage(string url)
        {
            HttpClient httpclient = new HttpClient();
            return await httpclient.GetStringAsync(url);
        }

        // awaiting parallel tasks
        //static async Task<IEnumerable<string>> FetchWebPages(string [] urls)
        //{
        //    var tasks = new List<Task<string>>();

        //    foreach (string url in urls)
        //    {
        //        tasks.Add(FetchWebPages(url));
        //    }

        //    return await Task.WhenAll(tasks);
        //}

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ResultTextBlock.Text = await FetchWebPage(URLTextBox.Text);
                StatusTextBlock.Text = "Page Loaded";
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = ex.Message;
            }
        }
    }
}
