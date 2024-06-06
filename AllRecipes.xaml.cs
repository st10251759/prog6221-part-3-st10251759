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
    /// Interaction logic for AllRecipes.xaml
    /// </summary>
    /// 


    public partial class AllRecipes : Window
    {
        List<Recipe> recipes = new List<Recipe>();
        private int selection;
        private static string name = null;
        List<int> numIngredients = new List<int>();
        List<Ingredient> ingredients = new List<Ingredient>();

        public AllRecipes()
        {
            InitializeComponent();
            // create new instance of addSteps class to retrieve the list of recipes
            AddSteps recipe = new AddSteps();
            recipes = recipe.GetRecipes();

            AddRecipes();// call method to add recipes to list box
        }

        public void AddRecipes()
        {
            Recipe temp;

            // bubble sort list of recipes >> to display in alphabetical order
            for (int i = 0; i < recipes.Count; i++)
            {
                for (int j = 0; j < recipes.Count; j++)
                {

                    if (string.Compare(recipes[i].getName(), recipes[j].getName()) < 0)
                    {
                        temp = recipes[i];
                        recipes[i] = recipes[j];
                        recipes[j] = temp;

                    }// end if statment
                }// end j loop
            }// end i loop

            getNumIngredients();

            for (int k = 0; k < recipes.Count; k++)
            {
                lbxRecipes.Items.Add($"{recipes[k].getName()}\n{recipes[k].TotoalCalories()} total calories\nContains {numIngredients[k]} ingredients");
                // add each recipe to the list box
            }// end kloop
        }// end add recipe class

        public void getNumIngredients()
        {
            for (int i = 0; i < recipes.Count; i++)
            {
                ingredients = recipes[i].getIngredients();
                int num = ingredients.Count();
                numIngredients.Add(num);
            }// end for loop

            // display the totAL NUMBER OF INGREDIENTS IN EACH RECIPE
        }// end getNumIngredients method

        private void Add_Clicked(object sender, RoutedEventArgs e)
        {
            AddRecipe recipe = new AddRecipe();
            recipe.Show();
            this.Hide();
        }

        private void Exit_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Filter_Clicked(object sender, RoutedEventArgs e)
        {
            Filter filter = new Filter();
            filter.Show();
            this.Hide();
        }

        private void View_Clicked(object sender, RoutedEventArgs e)
        {
            selection = lbxRecipes.SelectedIndex;
            name = recipes[selection].getName();
            // allow the user to view the recipe that they have selected from the list box
            ViewRecipe view = new ViewRecipe();
            view.Show();
            this.Hide();
        }

        //GETTER METHODS
        public string GetName()
        { return name; }

        public List<Recipe> Recipes()
        { return recipes; }
    }
}

