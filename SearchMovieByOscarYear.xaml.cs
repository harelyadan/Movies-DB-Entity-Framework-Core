using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MoviesDB_Manager
{
    /// <summary>
    /// Interaction logic for SearchMovieByOscarYear.xaml
    /// </summary>
    public partial class SearchMovieByOscarYear : Window
    {
        public delegate void GetSearchInput(int year);
        public GetSearchInput getValueCallBack;
        public SearchMovieByOscarYear()
        {
            InitializeComponent();
        }

        private void search_click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.Trim() == "")
            {
                MessageBox.Show("You must insert an oscar year.", "Error",
                              MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(textBox.Text.Trim(), out int temp))
            {
                MessageBox.Show("Illegal year!", "Error",
                          MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (int.Parse(textBox.Text) < 1929 || int.Parse(textBox.Text) > 2020)
            {
                MessageBox.Show("Year must be between 1929 and 2020!", "Error",
                              MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            getValueCallBack(int.Parse(textBox.Text.Trim()));
            Close();
        }
    }
}
