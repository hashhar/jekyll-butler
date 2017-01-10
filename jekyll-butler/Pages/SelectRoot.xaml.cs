using jekyll_butler.Pages;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;

namespace jekyll_butler
{
    /// <summary>
    /// Interaction logic for SelectRoot.xaml
    /// </summary>
    public partial class SelectRoot : Page
    {
        public string JekyllRoot { get; set; }
        public bool ValidJekyllRoot { get; private set; }

        public SelectRoot()
        {
            InitializeComponent();
            SelectRootGrid.DataContext = this;
        }

        private void LoadJekyllRoot_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var files = Directory.GetFiles(JekyllRoot);
            ValidJekyllRoot = false;
            foreach (var file in files)
            {
                if (file.EndsWith(@"_config.yml"))
                {
                    ValidJekyllRoot = true;
                    break;
                }
            }
            if (ValidJekyllRoot)
            {
                NavigationService.Navigate(new JekyllButlerRoot());
            }
        }
    }
}
