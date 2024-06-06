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
    /// Interaction logic for ViewFilter.xaml
    /// </summary>
    public partial class ViewFilter : Window
    {
        public delegate void RecipeDelegate(string message);
        // use of generic collections
        // delegate created to display the calorie messages in application

        // Code Attribution
        // Author: Microsoft
        // Link: https://learn.microsoft.com/en-us/shows/csharp-101/csharp-arrays-list-and-collections

        List<Recipe> recipes = new List<Recipe>();
        private string name;
        public Recipe recipe;

        List<Ingredient> ingredients = new List<Ingredient>();
        List<string> steps = new List<string>();


        public ViewFilter()
        {
            InitializeComponent();
            // clear the rich text box before populating
            displaytxt.Document.Blocks.Clear();
            // display recipe once the window is created
            display();
        }

        public void display()
        {

            displaytxt.Document.Blocks.Clear();
            // create an instance of the Filter class to retrieve the selected recipe 
            Filter view = new Filter();
            name = view.Name();
            // create an instance of the AllRecipes class to retrieve the list of recipes
            AllRecipes allRecipe = new AllRecipes();
            recipes = allRecipe.Recipes();

            recipe = null;

            for (int i = 0; i < recipes.Count(); i++)
            {
                if (recipes[i].getName().Equals(name))// if the name of the recipe on the list matches the selected recipe name
                {
                    recipe = recipes[i];// then selected recipe object = current recipe object
                }// end if statment

            }// end loop

            displayRecipe();

        }// end display

        public void displayRecipe()
        {
            string recipeText = "";
            ingredients = null;
            ingredients = recipe.getIngredients();
            steps = recipe.getSteps();
            string recipeName = recipe.getName();
            double totalCalories = recipe.calculateTotalCalories();

            recipeText = recipeName + "\n";
            displaytxt.FontSize = 25;
            //output the recipe name
            displaytxt.AppendText(recipeText);

            displayIngredients();
            displaySteps();

            displaytxt.FontSize = 20;
            displaytxt.AppendText(recipeText);
            displayCalories(totalCalories);
        }


        public void displayIngredients()
        {
            string ingredientText = "";

            // output all the recipe ingredients and details
            ingredientText = "Ingredients:\n";
            for (int i = 0; i < ingredients.Count(); i++)
            {
                Ingredient ingredient = ingredients[i];
                ingredientText += $"{i + 1}: {ingredient.Quantity().ToString()} {ingredient.Unit().ToString()} of {ingredient.IngredientName().ToString()}\n";
                ingredientText += $"Food Group: {ingredient.Group().ToString()}\n{ingredient.NumCalories().ToString()} calories\n";
            }// end for loop

            displaytxt.FontSize = 15;
            displaytxt.AppendText(ingredientText);
        }// end display ingredients

        public void displaySteps()
        {
            string stepText = "";

            //output all the steps in the recipe
            stepText += "Steps:\n";
            for (int i = 0; i < steps.Count; i++)
            {
                stepText += $" {i + 1}: {steps[i]}\n";
            }// end for loop

            displaytxt.FontSize = 15;
            displaytxt.AppendText(stepText);
        }// end display steps

        private void Add_Clicked(object sender, RoutedEventArgs e)
        {
            AddRecipe recipe = new AddRecipe();
            recipe.Show();
            this.Hide();
        }

        private void Filter_Clicked(object sender, RoutedEventArgs e)
        {
            Filter filter = new Filter();
            filter.Show();
            this.Hide();
        }

        private void All_Clicked(object sender, RoutedEventArgs e)
        {
            AllRecipes allRecipes = new AllRecipes();
            allRecipes.Show();
            this.Hide();
        }

        public void displayCalorieMessage(string message)
        { displaytxt.AppendText(message); }

        public void displayCalories(double totalCalories)
        {

            RecipeDelegate recipeDelegate = new RecipeDelegate(displayCalorieMessage);

            // output the total number of calories
            string recipeText = $"Total number of calories: {totalCalories}\n";
            displaytxt.AppendText(recipeText);

            if (totalCalories > 300)
            { recipeDelegate("\nCALORIES EXCEED 300"); }// end if greater than 300

            if (totalCalories > 0 && totalCalories <= 200)
            { recipeDelegate("\nThis amount of calories is enough to satisfy you without interfering with your appetite, and is a good SNACK"); }
            else if (totalCalories > 200 && totalCalories <= 400)
            { recipeDelegate("\nThis amount of calories serves as a LOW CALORIE MEAL, aiding in weight loss"); }
            else if (totalCalories > 400 && totalCalories <= 700)
            { recipeDelegate("\nThis amount of calories is suitable for an AVERAGE MEAL"); }
            else if (totalCalories > 700)
            { recipeDelegate("\nThis meal is considered a HIGH CALORY MEAL, containing a large amount of calories, and should not be consumed frequently"); }

        }// end display
    }
}

