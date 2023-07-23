using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace cShanty.CustomControls
{
    /// <summary>
    /// Interaction logic for NavigationButton.xaml
    /// </summary>
    public partial class NavigationCoreButton : RadioButton
    {
        public string Text { get; set; }
        public string Kind { get; set; }

        public NavigationCoreButton()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
