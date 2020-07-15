using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for SearchMovieByYear.xaml
    /// </summary>
    public partial class SearchMovieByYear : Window
    {
        public delegate void GetSearchInput2(int year1, int year2);
        public delegate void GetSearchInput1(int year);
        public GetSearchInput2 getValueCallBack2;
        public GetSearchInput1 getValueCallBack1;
        public SearchMovieByYear()
        {
            InitializeComponent();
        }

        private void search_click(object sender, RoutedEventArgs e)
        {
            if (year1TextBox.Text.Trim() == "" && year2TextBox.Text.Trim() == "")
            {
                MessageBox.Show("You must insert one box at least.", "Error",
                              MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if( year1TextBox.Text.Trim() != "")
            {
                if(!int.TryParse(year1TextBox.Text.Trim(), out int temp))
                {
                    MessageBox.Show("Illegal year1!", "Error",
                          MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                
                if( int.Parse(year1TextBox.Text.Trim()) < 1900 ||
                    int.Parse(year1TextBox.Text.Trim()) > 2020)
                {
                    MessageBox.Show("Year must be between 1900 and 2020!", "Error",
                          MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            if (year2TextBox.Text.Trim() != "")
            {
                if (!int.TryParse(year2TextBox.Text.Trim(), out int temp))
                {
                    MessageBox.Show("Illegal year2!", "Error",
                          MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (int.Parse(year2TextBox.Text.Trim()) < 1900 ||
                    int.Parse(year2TextBox.Text.Trim()) > 2020)
                {
                    MessageBox.Show("Year must be between 1900 and 2020!", "Error",
                          MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            

            if (year1TextBox.Text.Trim() != "" && year2TextBox.Text.Trim() != "")
            {
                if (int.Parse(year1TextBox.Text.Trim()) >
                    int.Parse(year2TextBox.Text.Trim()) )
                {
                    MessageBox.Show("Year1 must be earlier than year2!", "Error",
                          MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                getValueCallBack2(int.Parse(year1TextBox.Text.Trim()),
                    int.Parse(year2TextBox.Text.Trim()));
            }
            else
            {
                if( year1TextBox.Text.Trim() != "" )
                    getValueCallBack1(int.Parse(year1TextBox.Text.Trim()));
                else getValueCallBack1(int.Parse(year2TextBox.Text.Trim()));
            }
            Close();
        }
    } 
}
