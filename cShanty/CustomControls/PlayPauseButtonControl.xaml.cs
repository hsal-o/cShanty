using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace cShanty.CustomControls
{
    public partial class PlayPauseButtonControl : UserControl, INotifyPropertyChanged
    {
        private bool isPlaying = false;

        public bool IsPlaying
        {
            get { return isPlaying; }
            set
            {
                isPlaying = value;
                OnPropertyChanged("PlayPauseIcon");
            }
        }

        public string PlayPauseIcon => IsPlaying ? "RegularPause" : "RegularPlay";

        public PlayPauseButtonControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public event RoutedEventHandler Click
        {
            add { playPauseButton.Click += value; }
            remove { playPauseButton.Click -= value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
