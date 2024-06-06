using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ST10251759_PROG6221_POE_P3
{
    /// <summary>
    /// Interaction logic for SuccessfulAdd.xaml
    /// </summary>
    public partial class SuccessfulAdd : Window
    {
        public SuccessfulAdd()
        {
            InitializeComponent();
        }

        private void Close_Clicked(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void AddNewRecipe_Clicked(object sender, RoutedEventArgs e)
        {
            AddRecipe recipe = new AddRecipe();
            recipe.Show();
            this.Hide();
        }

        private void ShowAll_Clicked(object sender, RoutedEventArgs e)
        {
            AllRecipes all = new AllRecipes();
            all.Show();
            this.Hide();
        }
    }
}
