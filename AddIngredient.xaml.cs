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

        static private int unit;
        static private int group;
        static private string ingredientName;
        static private double quantity;
        static private double numCalories;

        public static int totalNumIngredients = 0;
        public static int numIngredients;

        Ingredient ingredient;

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

        private void AddIngredient_Clicked(object sender, RoutedEventArgs e)
        {

        }
    }
}
