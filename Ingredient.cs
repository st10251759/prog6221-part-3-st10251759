using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ST10251759_PROG6221_POE_P3
{//namespace begin
    public class Ingredient
    {//Ingredient Class Begin
        List<UnitOfMeasurement> units = new List<UnitOfMeasurement>();
        List<FoodGroup> groups = new List<FoodGroup>();
        public void populateLists()
        {
            units.Add(UnitOfMeasurement.SMALL);
            units.Add(UnitOfMeasurement.MEDIUM);
            units.Add(UnitOfMeasurement.LARGE);
            units.Add(UnitOfMeasurement.EXTRALARGE);
            units.Add(UnitOfMeasurement.TEASPOON);
            units.Add(UnitOfMeasurement.TEASPOONS);
            units.Add(UnitOfMeasurement.TABLESPOON);
            units.Add(UnitOfMeasurement.TABLESPOONS);
            units.Add(UnitOfMeasurement.CUP);
            units.Add(UnitOfMeasurement.CUPS);


            groups.Add(FoodGroup.CARBOHYDRATE);
            groups.Add(FoodGroup.PROTEIN);
            groups.Add(FoodGroup.FAT);
            groups.Add(FoodGroup.FRUIT);
            groups.Add(FoodGroup.VEGETABLE);
            groups.Add(FoodGroup.DAIRY);

        }// 

        private string ingredientName;
        private double quantity;
        private UnitOfMeasurement unit;
        private double numCalories;
        private FoodGroup group;

        public Ingredient(string ingredientName, double quantity, int unit, double numCalories, int group)
        {
            populateLists();
            this.ingredientName = ingredientName;
            this.quantity = quantity;
            this.numCalories = numCalories;
            this.unit = units.ElementAt(unit);
            this.group = groups.ElementAt(group);

        }// end constructor

        public string display()
        {
            string display = "";
            display = $"{quantity} {unit} of {ingredientName}\nFood Group: {group}\n{numCalories} calories";
            return display;
        }

        //GETTERS
        public string IngredientName()
        { return ingredientName; }
        public double Quantity()
        { return quantity; }
        public double NumCalories()
        { return numCalories; }
        public string Unit()
        { return unit.ToString(); }
        public string Group()
        { return group.ToString(); }

    }// end ingredient class
}//namespace end
