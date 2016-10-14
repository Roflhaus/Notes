using Microsoft.Win32;
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

namespace Notes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //This is supposed to be loading the notes at startup, but its shit, so it doesn't do it.

        string userDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        //void App_Startup(object sender, StartupEventArgs e)
        //{
        //    if (File.Exists(userDir + @"\.Scratch\scratch.not"))
        //    {
        //        string noteContents = File.ReadAllText(userDir + @"\.Scratch\scratch.not");
        //        NoteBody.Document.Blocks.Add(new Paragraph(new Run(noteContents)));
        //    }

        //}

        public MainWindow()
        {
            InitializeComponent();
        }


        private void buttonDir_click(object sender, RoutedEventArgs e)
        {
            if (NoteBody.Document.Blocks.Count > 0)
            {
                //make this actually do something.
                MessageBox.Show("Current contents will be cleared.  Continue?");
            }
            

            if (File.Exists(userDir + @"\.Scratch\scratch.not"))
            {
                string noteContents = File.ReadAllText(userDir + @"\.Scratch\scratch.not");
                NoteBody.Document.Blocks.Add(new Paragraph(new Run(noteContents)));
            }
        }


        private void buttonSave_click(object sender, RoutedEventArgs e)
        {
            if (!Directory.Exists(userDir + @"\.Scratch"))
            {
                Directory.CreateDirectory(userDir + @"\.Scratch");
            }

            string noteContents = new TextRange(NoteBody.Document.ContentStart, NoteBody.Document.ContentEnd).Text;

            using (StreamWriter outputFile = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\.Scratch\scratch.not"))
            {
                outputFile.WriteLine(noteContents);
            }
        }
    }
}
