using CommunityToolkit.Mvvm.Input;
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
        private bool isMediaPlaying = false; 
        public ICommand PlayPauseCommand => new RelayCommand(ExecutePlayPause);

        private void ExecutePlayPause()
        {
            isMediaPlaying = !isMediaPlaying;

            // Handle play/pause logic here
            if (isMediaPlaying)
            {
                playMedia();
            }
            else
            {
                pauseMedia();
            }
        }


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

            if (Directory.Exists(mediaFolderPath))
            {
                string[] mp3Files = Directory.GetFiles(mediaFolderPath, "*.mp3");

                foreach (string file in mp3Files)
                {
                    // Add each MP3 file name (without extension) to the ListBox
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    ListBoxItem item = new ListBoxItem
                    {
                        Content = fileName,
                        Tag = file // Store the full file path as the Tag property
                    };
                    mediaListBox.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("The 'Media' folder does not exist.");
            }
        }

        private void restartMedia()
        {
            mediaElement.Position = TimeSpan.Zero;
            mediaElement.Play();
        }

        private void playMedia()
        {
            mediaElement.Play();
        }

        private void pauseMedia()
        {
            mediaElement.Pause();
        }

        private void restartBtn_Click(object sender, RoutedEventArgs e)
        {
            restartMedia();
        }

        private void pauseBtn_Click(object sender, RoutedEventArgs e)
        { 
            pauseMedia();
        }

        private void playBtn_Click(object sender, RoutedEventArgs e)
        {
            playMedia();
        }

        private void mediaListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (mediaListBox.SelectedItem != null && mediaListBox.SelectedItem is ListBoxItem selectedItem)
            {
                string filePath = selectedItem.Tag as string;
                mediaElement.Source = new Uri(filePath);

                txt_selectedSong.Text = filePath;
            }
        }

        private void PlayPauseButtonControl_Click(object sender, RoutedEventArgs e)
        {
            //playPauseButton.IsPlaying = !playPauseButton.IsPlaying;
        }
    }
}
