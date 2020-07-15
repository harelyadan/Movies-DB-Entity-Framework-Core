using Microsoft.EntityFrameworkCore;
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
using System.Linq;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace MoviesDB_Manager
{
    /// <summary>
    /// Interaction logic for AddDirector.xaml
    /// </summary>
    public partial class AddDirector : Window
    {
        public AddDirector()
        {
            InitializeComponent();
        }

        private void add_click(object sender, RoutedEventArgs e)
        {
            Regex name = new Regex(@"^[A-Z][A-Za-z]*(\s+[A-Z][A-Za-z]*){0,1}$");
            try
            {
                if (!IsAllTextBoxesAreFilled())
                    throw new NotCompletedException("You must fill all details!");

                if (!name.IsMatch(firstNameTextBox.Text.Trim()))
                    throw new ValidationException("Illegal first name!");

                if (!name.IsMatch(lastNameTextBox.Text.Trim()))
                    throw new ValidationException("Illegal last name!");

                using (var ctx = new MoviesDBContext())
                {

                    List<Director> directors = (from di in ctx.Directors
                                          select di).ToList();
                    Director director = new Director
                    {
                        FirstName = firstNameTextBox.Text.Trim(),
                        LastName = lastNameTextBox.Text.Trim()
                    };

                    ctx.Directors.Add(director);
                    ctx.SaveChanges();
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                          MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool IsAllTextBoxesAreFilled()
        {
            if (firstNameTextBox.Text == "") return false;
            if (lastNameTextBox.Text == "") return false;
            return true;
        }
    }
}
