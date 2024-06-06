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
    /// Interaction logic for Filter.xaml
    /// </summary>
    public partial class Filter : Window
    {
        private int filter;

        List<FoodGroup> groups = new List<FoodGroup>();
        static List<Recipe> recipes = new List<Recipe>();
        List<Ingredient> ingredients = new List<Ingredient>();

        private static string name;
        private static int group;
        public void populateComboBox()
        {
            groups.Add(FoodGroup.CARBOHYDRATE);
            groups.Add(FoodGroup.PROTEIN);
            groups.Add(FoodGroup.FAT);
            groups.Add(FoodGroup.FRUIT);
            groups.Add(FoodGroup.VEGETABLE);
            groups.Add(FoodGroup.DAIRY);
            // add all food group enum values to groups list

            for (int i = 0; i < groups.Count(); i++)
            {
                cmbGroup.Items.Add(groups[i]);
            }// add all list values to combo box
        }// end populate method

        public Filter()
        {
            InitializeComponent();
            populateComboBox();// populate combo box as soon as window is created
            AllRecipes allRecipe = new AllRecipes();
            recipes = allRecipe.Recipes();// retrieve recipes from AllRecipes class
        }

        private void Back_Clicked(object sender, RoutedEventArgs e)
        {
            AllRecipes all = new AllRecipes();
            all.Show();
            this.Hide();
        }

        private void NameFilter_Clicked(object sender, RoutedEventArgs e)
        {
            groupPanel.Visibility = Visibility.Hidden;
            caloriePanel.Visibility = Visibility.Hidden;
            // hide other filter options >> show filter by name only
            namePanel.Visibility = Visibility.Visible;
            filter = 1;
        }

        private void GroupFilter_Clicked(object sender, RoutedEventArgs e)
        {
            namePanel.Visibility = Visibility.Hidden;
            caloriePanel.Visibility = Visibility.Hidden;
            // hide other filter options >> show filter by food group only
            groupPanel.Visibility = Visibility.Visible;
            filter = 2;
        }

        private void CalorieFilter_Clicked(object sender, RoutedEventArgs e)
        {
            namePanel.Visibility = Visibility.Hidden;
            groupPanel.Visibility = Visibility.Hidden;
            // hide other filter options >> show filter by max calories only
            caloriePanel.Visibility = Visibility.Visible;
            filter = 3;
        }

        private void Apply_Clicked(object sender, RoutedEventArgs e)
        {
            if (filter == 1)// filter by name
            {
                lbxRecipes.Items.Clear();
                string recipeName = nametxt.Text;
                nameFilter(recipeName);

            }// end if filter by name
            else if (filter == 2)// filter by food group
            {
                lbxRecipes.Items.Clear();
                group = cmbGroup.SelectedIndex;
                groupFilter(group);

            }// end filter by food group
            else if (filter == 3)// filter by max calories
            {
                lbxRecipes.Items.Clear();
                double maxCalories = double.Parse(maxCaloriestxt.Text);
                calorieFilter(maxCalories);
            }// end filter by max calories
        }// end apply filter method

        public void groupFilter(int group)
        {
            string groupName = groups[group].ToString();

            for (int i = 0; i < recipes.Count; i++)
            {
                ingredients = new List<Ingredient>();
                ingredients = recipes[i].getIngredients();

                for (int j = 0; j < ingredients.Count; j++)
                {
                    if (ingredients[j].Group().Equals(groupName))
                    { lbxRecipes.Items.Add(recipes[i].getName()); }// end if statment
                }// end j loop
            }// end for loop
        }// end filter by group method

        public void calorieFilter(double maxCalories)
        {
            for (int i = 0; i < recipes.Count; i++)
            {
                double numCal = recipes[i].calculateTotalCalories();
                if (numCal <= maxCalories)
                { lbxRecipes.Items.Add(recipes[i].getName()); }
            }// end loop
        }// end filter by max calories filter



        public void nameFilter(string recipeName)
        {
            for (int i = 0; i < recipes.Count; i++)
            {
                recipeName.ToUpper();
                string currentName = recipes[i].getName().ToUpper();

                if (recipeName.Equals(currentName))
                { lbxRecipes.Items.Add(recipes[i].getName()); }
            }// end for loop
        }// end filter by name method

        private void View_Clicked(object sender, RoutedEventArgs e)
        {
            int selection = lbxRecipes.SelectedIndex;
            name = recipes[selection].getName();
            ViewFilter view = new ViewFilter();
            view.Show();
            this.Hide();
        }

        public string Name()
        { return name; }
    }// end filter class
}
