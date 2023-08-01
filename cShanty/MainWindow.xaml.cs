using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Path = System.IO.Path;

namespace cShanty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Call the method to populate the ListBox with the MP3 files from the "Media" folder
            PopulateMediaList();
        }

        private void PopulateMediaList()
        {
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            string mediaFolderPath = Path.Combine(currentDirectory, "Media");

            MessageBox.Show("mediaFolderPath: " + mediaFolderPath);
            Debug.WriteLine("mediaFolderPath: " + mediaFolderPath);

            if (Directory.Exists(mediaFolderPath))
            {
                string[] mp3Files = Directory.GetFiles(mediaFolderPath, "*.mp3");

                foreach (string file in mp3Files)
                {
                    // Add each MP3 file name to the ListBox
                    mediaListBox.Items.Add(Path.GetFileName(file));
                }
            }
            else
            {
                MessageBox.Show("The 'Media' folder does not exist.");
            }
        }
    }
}
