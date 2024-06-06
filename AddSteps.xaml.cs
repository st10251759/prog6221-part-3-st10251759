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
    /// Interaction logic for AddSteps.xaml
    /// </summary>
    public partial class AddSteps : Window
    {
        List<string> steps = new List<string>();
        private string? step;
        List<Ingredient> ingredients = new List<Ingredient>();

        static List<Recipe> recipes = new List<Recipe>();

        public AddSteps()
        {
            InitializeComponent();
            totalNumSteps = 0;
        }

        public static int totalNumSteps = 0;
        public static int numSteps;

        private void AddStep_Clicked(object sender, RoutedEventArgs e)
        {
            // create new instance of addRecipe class to retrieve the number of steps in the recipe
            AddRecipe recipe = new AddRecipe();
            numSteps = recipe.GetNumSteps();

            step = Steptxt.Text;
            if (step == null) // check that step is not null
            { throw new Exception("Step can not be null"); }
            else
            { steps.Add(step); }

            totalNumSteps++;

            // show window tho confirm that the step was added successfully
            SuccessfulAdd added = new SuccessfulAdd();
            added.Addedtxt.Text = "Step Added Successfully";
            added.btnAddNewRecipe.IsEnabled = false;
            added.btnShowAll.IsEnabled = false;

            added.Show();

            Steptxt.Clear();
            AddStepstxt.Text = "Add Recipe Step " + (totalNumSteps + 1);

            if (totalNumSteps == numSteps)
            // if the number of steps in the recipe is reached then close this window and display the Successfully added window

            {

                AddIngredient ingredient = new AddIngredient();
                List<Ingredient> ingredients = ingredient.GetIngredients();

                AddRecipe addRecipe = new AddRecipe();
                string name = addRecipe.getRecipeName();

                // add new recipe to recipe list >recipes
                Recipe newRecipe = new Recipe(name, ingredients, steps);
                recipes.Add(newRecipe);


                this.Hide();
                added.btnShowAll.IsEnabled = true;
                added.btnAddNewRecipe.IsEnabled = true;
                added.Addedtxt.Text = "Recipe Added Successfully";
                added.Show();

            }// end if 
        }



        // GETTER METHODS
        public List<string> GetSteps()
        { return steps; }

        public List<Recipe> GetRecipes()
        { return recipes; }
    }
}
