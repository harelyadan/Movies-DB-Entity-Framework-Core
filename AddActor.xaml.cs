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
    /// Interaction logic for AddActor.xaml
    /// </summary>
    public partial class AddActor : Window
    {
        public AddActor()
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

                if ((bool)!maleRadioButton.IsChecked && (bool)!femaleRadioButton.IsChecked)
                    throw new NotCompletedException("You must choose gender!");

                if (!name.IsMatch(firstNameTextBox.Text.Trim()))
                    throw new ValidationException("Illegal first name!");

                if (!name.IsMatch(lastNameTextBox.Text.Trim()))
                    throw new ValidationException("Illegal last name!");

                if (!int.TryParse(yearBornTextBox.Text.Trim(), out int temp))
                    throw new ValidationException("Illegal birth year!");

                if (int.Parse(yearBornTextBox.Text.Trim()) > 2020
                    || int.Parse(yearBornTextBox.Text.Trim()) < 1900)
                    throw new ValidationException("Birth year must be" +
                        "between 1900 and 2020!");

                using (var ctx = new MoviesDBContext()){

                    int gen;
                    if ( (bool)maleRadioButton.IsChecked)
                        gen = 1;
                    else gen = 0;

                    Actor actor = actor = new Actor
                    {
                        FirstName = firstNameTextBox.Text.Trim(),
                        LastName = lastNameTextBox.Text.Trim(),
                        YearBorn = int.Parse(yearBornTextBox.Text.Trim()),
                        Gender = gen
                    };

                    ctx.Actors.Add(actor);
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
            if (yearBornTextBox.Text == "") return false;
            return true;
        }
    }
}
