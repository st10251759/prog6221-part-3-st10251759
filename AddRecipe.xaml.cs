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
    /// Interaction logic for AddRecipe.xaml
    /// </summary>
    public partial class AddRecipe : Window
    {
        //Declare variables for the recipe Name, Number of Ingredients, Number of Steps
        private static string recipeName;
        private static int numIngredients;
        private static int numSteps;

        public AddRecipe()
        {
            InitializeComponent();
        }
        private void AddRecipe_Clicked(object sender, RoutedEventArgs e)
        {
            // Get the recipe name from user
            recipeName = recipeNametxt.Text;
            if (recipeName == null) { throw new Exception("Name of recipe can not be null"); }


            //Get the number of ingredients in the recipe
            int? checkNumIngredients = int.Parse(NumIngredientstxt.Text);
            if (checkNumIngredients == null)// check that the number of ingredients is not null
            { throw new Exception("Number of ingredients can not be null"); }

            numIngredients = checkNumIngredients.Value;
            if (numIngredients <= 0) // check that the number of ingredients is greater than 0
            { throw new Exception("Number of ingredients must be greater than 0"); }

            //Get the number of steps from the user
            int? checkNumSteps = int.Parse(NumStepstxt.Text);
            if (checkNumSteps == null) // check that the number of steps is not null
            { throw new Exception("Number of steps can not be null"); }

            numSteps = checkNumSteps.Value;
            if (numSteps <= 0) // check that the number of steps is greater than 0
            { throw new Exception("Number of steps must be greater than 0"); }

            // create a new instance of the ingredient class
            AddIngredient ingredient = new AddIngredient();

            // close this window and open the add ingredient window
            ingredient.Show();
            this.Hide();

        }// end add recipe clicked method

        // GETTER METHODS
        public string getRecipeName()
        { return recipeName; }
        public int GetNumSteps()
        { return numSteps; }
        public int getNumIngredients()
        { return numIngredients; }

    }// end add recipe class
}// end namespace

