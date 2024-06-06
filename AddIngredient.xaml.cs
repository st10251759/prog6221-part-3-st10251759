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
    /// Interaction logic for AddIngredient.xaml
    /// </summary>
    public partial class AddIngredient : Window
    {
        List<UnitOfMeasurement> units = new List<UnitOfMeasurement>();
        // list to store units in enum
        List<FoodGroup> groups = new List<FoodGroup>();
        // list to store food groups in enum

        

        public void populateComboBox()
        {
            units.Add(UnitOfMeasurement.SMALL);
            units.Add(UnitOfMeasurement .MEDIUM);
            units.Add(UnitOfMeasurement.LARGE);
            units.Add(UnitOfMeasurement.EXTRALARGE);
            units.Add(UnitOfMeasurement.TEASPOON);
            units.Add(UnitOfMeasurement.TEASPOONS);
            units.Add(UnitOfMeasurement.TABLESPOON);
            units.Add(UnitOfMeasurement.TABLESPOONS);
            units.Add(UnitOfMeasurement.CUP);
            units.Add(UnitOfMeasurement.CUPS);
            // add all enum values to units list

            for (int i = 0; i < units.Count(); i++)
            {
                cmbUnit.Items.Add(units[i]);
            }// add all enum values from the list to the correct combo box

            groups.Add(FoodGroup.CARBOHYDRATE);
            groups.Add(FoodGroup.PROTEIN);
            groups.Add(FoodGroup.FAT);
            groups.Add(FoodGroup.FRUIT);
            groups.Add(FoodGroup.VEGETABLE);
            groups.Add(FoodGroup.DAIRY);
            // add all enum values to groups list

            for (int i = 0; i < groups.Count(); i++)
            {
                cmbGroup.Items.Add(groups[i]);
            }// add all enum values from list to the correct combo box

        }//end populate method 

        public AddIngredient()
        {
            InitializeComponent();

            populateComboBox();// populate the combo boxes when the window is created
            totalNumIngredients = 0;
        }

        static private int unit;
        static private int group;
        static private string ingredientName;
        static private double quantity;
        static private double numCalories;

        public static int totalNumIngredients = 0;
        public static int numIngredients;

        Ingredient ingredient;

        private void AddIngredient_Clicked(object sender, RoutedEventArgs e)
        {
            // create new instance of addRecipe class to retrieve the number of ingredients in the recipe
            AddRecipe recipe = new AddRecipe();
            numIngredients = recipe.getNumIngredients();

            // get the unit of measurment and food group from user selection 
            unit = cmbUnit.SelectedIndex;
            group = cmbGroup.SelectedIndex;

            // get the name of ingredient from the user
            ingredientName = ingredientNametxt.Text;
            if (ingredientName == null)// check that the name of ingredient is not null
            { throw new Exception("Name of ingredient can not be null"); }

            // get the quantity of the ingredient from the user
            double? checkQuantity = double.Parse(quantitytxt.Text);
            if (checkQuantity == null) // check that the quantity of ingredient is not null
            { throw new Exception("Quantity of ingredients can not be null"); }

            quantity = checkQuantity.Value;
            if (quantity <= 0) // check that the ingredient quantity is greater than 0
            { throw new Exception("Quantity of ingredients must be greater than 0"); }

            // get the number of calories in the ingredient from the user
            double? checkNumCalories = double.Parse(numCaloriestxt.Text);
            if (checkNumCalories == null) // check that the number of calories is not null
            { throw new Exception("Quantity of ingredients can not be null"); }

            numCalories = checkNumCalories.Value;
            if (numCalories <= 0)// check that the number of calories is greater than 0
            { throw new Exception("Number of calories in ingredients must be greater than 0"); }


            // create new ingredient with user input
            ingredient = new Ingredient(ingredientName, quantity, unit, numCalories, group);
            ingredients.Add(ingredient);// add new ingredient to list of ingredients

            totalNumIngredients++; // increment the total number of ingredients

            // show window tho confirm that ingredient was added successfully
            SuccessfulAdd added = new SuccessfulAdd();
            added.Addedtxt.Text = "Ingredient Added Successfully";
            added.btnAddNewRecipe.IsEnabled = false;
            added.btnShowAll.IsEnabled = false;

            added.Show();

            AddIngredienttxt.Text = "Add Ingredient " + (totalNumIngredients + 1);
            quantitytxt.Text = "0";
            numCaloriestxt.Text = "0";
            ingredientNametxt.Clear();

            AddSteps step = new AddSteps();

            if (totalNumIngredients == numIngredients)
            // if the number of ingredients in the recipe is reached then close this window and display the add steps window
            {
                this.Hide();
                step.Show();
            }

        }// end add ingredient clicked method

        static List<Ingredient> ingredients = new List<Ingredient>();

        public List<Ingredient> GetIngredients()
        { return ingredients; }// getter method

    }// end add ingredient class
}// end namespace
