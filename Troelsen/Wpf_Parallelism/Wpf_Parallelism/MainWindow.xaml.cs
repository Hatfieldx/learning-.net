using System;
using System.Collections.Generic;
using System.IO;
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
using System.Drawing;
using System.Data;
using Path = System.IO.Path;
using System.Threading;

namespace Wpf_Parallelism
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void cmdProcess__Click(object sender, RoutedEventArgs e)
        {
            AlphabetPosition("The sunset sets at twelve o' clock.");

            TextEditor.Text += "\nsdgfsgdsfgsdfg";

            TextEditor.AppendText("\nzsdgasdfasdfasdf");

            ProcessFiles();
        }

        private void ProcessFiles()
        {
            string filepath = @".\files\";

            CancellationToken token = cancellationTokenSource.Token;

            Task<string[]> getfiles = new Task<string[]>(()=>{
                return GetFiles(filepath, token);
            });

            getfiles.Start();

            Task doMod = getfiles.ContinueWith((Task<string[]> t) => { ModFiles(t, token); });          
    
            //    (Task<string[]>)=>{
            //    ModFiles(getfiles, token);
            //});
        }

        private string[] GetFiles(string path, CancellationToken token)
        {
            this.Dispatcher.Invoke(()=> { this.TextEditor.AppendText($"\nfirst task"); });

            // DataTime c = Datatime.Datatime.Now

            Thread.Sleep(10000);

            if (token.IsCancellationRequested)
            {
                this.Dispatcher.Invoke(() => { this.TextEditor.AppendText($"\nfirst task canceled"); });
                return null;
            }

            this.Dispatcher.Invoke(() => { this.TextEditor.AppendText($"\nfirst task completed"); });

            return Directory.GetFiles(path, "*.jpg", SearchOption.AllDirectories);
        }

        private void ModFiles(Task<string[]> t, CancellationToken token)
        {
            string[] files = t.Result;

            this.Dispatcher.Invoke(() => { this.TextEditor.AppendText($"\nDO Modofications"); });

            string filename;

            string modfiles = @".\ModifledPictures";

            Directory.CreateDirectory(modfiles);

            if (token.IsCancellationRequested)
            {
                this.Dispatcher.Invoke(() => { this.TextEditor.AppendText($"\nDO Modofications canceled"); });
                return;
            }

            foreach (var file in files)
            {
                filename = Path.GetFileName(file);
                using (Bitmap bitmap = new Bitmap(file))
                {
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);

                    string newPath = Path.Combine(modfiles, filename);

                    bitmap.Save(newPath);
                }
            }
            Thread.Sleep(10000);

            this.Dispatcher.Invoke(() => { this.TextEditor.AppendText($"\nDO Modofications completed"); });
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            cancellationTokenSource.Cancel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        public static string AlphabetPosition(string text)
        {
            string res = "";

            string pattern = "abcdefghijklmnoqprstuvwxyz";

            foreach (char item in text.ToLower())
            {
                if (pattern.Contains(item))
                {
                    res += ((res.Length > 0) ? " " : "") + (Convert.ToInt32(Char.ToUpper(item)) - 64).ToString();
                }                
            }

            return res;
        }

        private void TestEditor_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
