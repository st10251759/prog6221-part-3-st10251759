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
    /// Interaction logic for ViewRecipe.xaml
    /// </summary>
    public partial class ViewRecipe : Window
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

        public ViewRecipe()
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
            // create an instance of the allRecipes class to retrieve the list of recipes as well as selected recipe
            AllRecipes allRecipe = new AllRecipes();
            recipes = allRecipe.Recipes();
            name = allRecipe.GetName();

            recipe = null;

            for (int i = 0; i < recipes.Count(); i++)
            {
                if (recipes[i].getName().Equals(name))// if the name of the recipe on the list matches the selected recipe name 
                {
                    recipe = recipes[i]; // then selected recipe object = current recipe object
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
            // output the recipe name
            displaytxt.AppendText(recipeText);

            displayIngredients();
            displaySteps();
            // output the total number of calories  in the recipe
            recipeText = $"Total number of calories: {totalCalories}\n";

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

            // output all the steps in the recipe
            stepText += "Steps:\n";
            for (int i = 0; i < steps.Count; i++)
            {
                stepText += $" {i + 1}: {steps[i]}\n";
            }// end for loop

            displaytxt.FontSize = 15;
            displaytxt.AppendText(stepText);
        }// end display steps

        private void Back_Clicked(object sender, RoutedEventArgs e)
        {
            AllRecipes all = new AllRecipes();
            this.Hide();
            all.Show();
        }

        private void Half_Clicked(object sender, RoutedEventArgs e)
        {
            displaytxt.Document.Blocks.Clear();
            halfRecipe();
            displaySteps();
        }

        private void Double_Clicked(object sender, RoutedEventArgs e)
        {
            displaytxt.Document.Blocks.Clear();
            doubleRecipe();
            displaySteps();
        }

        private void Tripple_Clicked(object sender, RoutedEventArgs e)
        {
            displaytxt.Document.Blocks.Clear();
            trippleRecipe();
            displaySteps();
        }

        public void displayCalorieMessage(string message)
        { displaytxt.AppendText(message); }

        public void displayCalories(double totalCalories)
        {

            RecipeDelegate recipeDelegate = new RecipeDelegate(displayCalorieMessage);

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

        public void halfRecipe()
        {
            string halfText = "";
            string recipeName = recipe.getName();

            halfText += recipeName + "\n";
            halfText += "New Quantity of Ingredients for HALF the Recipe:\n";
            displaytxt.AppendText(halfText);

            for (int i = 0; i < ingredients.Count; i++)
            {
                double newQuantity = ingredients[i].Quantity() / 2;
                convert(ingredients[i], newQuantity);

            }// end loop

        }// end half recipe method 

        public void doubleRecipe()
        {
            string doubleText = "";
            string recipeName = recipe.getName();

            doubleText += recipeName + "\n";
            doubleText += "New Quantity of Ingredients for DOUBLE the Recipe:\n";
            displaytxt.AppendText(doubleText);

            for (int i = 0; i < ingredients.Count; i++)
            {
                double newQuantity = ingredients[i].Quantity() * 2;
                convert(ingredients[i], newQuantity);

            }// end loop

        }// end double recipe method

        public void trippleRecipe()
        {
            string trippleText = "";
            string recipeName = recipe.getName();

            trippleText += recipeName + "\n";
            trippleText += "New Quantity of Ingredients for TRIPPLE the Recipe:\n";
            displaytxt.AppendText(trippleText);


            for (int i = 0; i < ingredients.Count; i++)
            {
                double newQuantity = ingredients[i].Quantity() * 3;
                convert(ingredients[i], newQuantity);

            }// end loop


        }// end tripple recipe method

        public void convert(Ingredient ingredient, double newQuantity)
        {
            string convertText = "";
            string unit = ingredient.Unit();

            if (unit == "CUP" || unit == "CUPS")
            { convertCups(ingredient, newQuantity); }
            // if unit is cup/s call convert cups method

            else if (unit == "TABLESPOON" || unit == "TABLESPOONS")
            { convertTablespoons(ingredient, newQuantity); }
            // if unit is tablespoon/s call convert tablespoons method

            else if (unit == "TEASPOON" || unit == "TEASPOONS")
            { convertTeaspoons(ingredient, newQuantity); }
            // if unit is teaspoon/s call convert teaspoons method

            else
            {
                convertText = $"{newQuantity} {ingredient.Unit()} {ingredient.IngredientName()}\nFood Group: {ingredient.Group()}\n{ingredient.NumCalories()} calories\n";
                displaytxt.AppendText(convertText);
            }// output directly


        }// end convert method

        public void convertCups(Ingredient ingredient, double newQuantity)
        {
            string cupsText = "";

            if (newQuantity < 1) // if new quantity is less than 1 cupp >> eg 0.5 cups
            {
                double tbsp = Math.Truncate(newQuantity * 16);
                // multiply by 16 to convert to tablespoons
                if (tbsp > 1)
                { cupsText = $"{tbsp} {UnitOfMeasurement.TABLESPOONS} of {ingredient.IngredientName()}"; displaytxt.AppendText(cupsText); }
                else
                { cupsText = $"{tbsp} {UnitOfMeasurement.TABLESPOON} of {ingredient.IngredientName()}"; displaytxt.AppendText(cupsText); }

            }// end if satment

            else if (newQuantity == 1)// if new quantity is equal to exactly one cup
            { cupsText = $"1 {UnitOfMeasurement.TABLESPOON} of {ingredient.IngredientName()}"; displaytxt.AppendText(cupsText); }

            else
            { cupsText = $"{newQuantity} {ingredient.Unit()} of {ingredient.IngredientName()}"; displaytxt.AppendText(cupsText); }

        }// end convertCups method

        public void convertTablespoons(Ingredient ingredient, double newQuantity)
        {
            string tableText = "";

            if (newQuantity >= 16) // if new quantity greayer than or equal to 16 tablespoons convert to cups
            {
                double cup = Math.Truncate(newQuantity / 16);
                if (cup > 1) // if greater than 1 cup
                { tableText = $"{cup} {UnitOfMeasurement.CUPS} of {ingredient.IngredientName()}"; displaytxt.AppendText(tableText); }
                else
                { tableText = $"{cup} {UnitOfMeasurement.CUP} of {ingredient.IngredientName()}"; displaytxt.AppendText(tableText); }

                if ((newQuantity % 16) != 0) // if there is a remainder
                {
                    double tbsp = newQuantity % 16;
                    tableText = $" and {tbsp} {UnitOfMeasurement.TABLESPOONS}";
                    displaytxt.AppendText(tableText);
                }// end if
            }// end if 

            else if (newQuantity < 1) //if quantity is less than 1 tablespoons convert to teaspoons
            {
                double tspn = newQuantity * 3;
                tableText = $"{tspn} {UnitOfMeasurement.TEASPOONS} of {ingredient.IngredientName()}";
                displaytxt.AppendText(tableText);
            }// end else if

            else
            { tableText = $"{newQuantity} {ingredient.Unit()} of {ingredient.IngredientName()}"; displaytxt.AppendText(tableText); }

        }// end convert Tablespoons method

        public void convertTeaspoons(Ingredient ingredient, double newQuantity)
        {
            string teaspoonText = "";

            if (newQuantity >= 3)
            {
                double tbsp = Math.Truncate(newQuantity / 3);

                if (tbsp > 1)
                { teaspoonText = $"{tbsp} {UnitOfMeasurement.TABLESPOONS} of {ingredient.IngredientName()}"; displaytxt.AppendText(teaspoonText); }
                else
                { teaspoonText = $"{tbsp} {UnitOfMeasurement.TABLESPOON} of {ingredient.IngredientName()}"; displaytxt.AppendText(teaspoonText); }

                if ((newQuantity % 3) != 0)
                {
                    double tspn = newQuantity % 3;
                    teaspoonText = $" and {tspn} {UnitOfMeasurement.TEASPOONS}";
                    displaytxt.AppendText(teaspoonText);
                }// end if
            }// end if 

            else
            { teaspoonText = $"{newQuantity} {ingredient.Unit()} of {ingredient.IngredientName()}"; displaytxt.AppendText(teaspoonText); }

        }// end convert teaspoons method


    }
}

