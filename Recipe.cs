using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Student Number: ST10251759
 Full Name: Cameron Chetty
 Course: PROG6221
 Assessment: POE Part 2
 Github Link for Part 1: https://github.com/VCDN-2024/prog6221-part-1-st10251759
 Github Link for Part 2: https://github.com/st10251759/prog6221-part-2-st10251759
 */

/*
=============Feedback==================== 
I obtained 100% and reciped no iplemented feedback. All work done was to address the requirements of PART 2 ONLY, and there  NO FEEDBACK to implement for part 1.  
*/

/*
=============Code Attribution====================
Author: Geeks for Geeks
Website: https://www.geeksforgeeks.org/console-class-in-c-sharp/
Date of Access: 06 April 2024

Author: Fatima Shaik 
Website: https://github.com/fb-shaik/PROG6221-Group1-2024/tree/main/Class_Objects_App
Date of Access: 23 March 2024      

Author: Fatima Shaik 
Website: https://github.com/fb-shaik/PROG6221-Group1-2024/tree/main/Array_Demo_App
Date of Access: 23 March 2024  

Author: Fatima Shaik 
Website: https://github.com/fb-shaik/PROG6221-Group1-2024/tree/main/ErrorHandling_App
Date of Access: 27 March 2024  

Author: Fatima Shaik 
Website: https://github.com/fb-shaik/PROG6221-Group1-2024/tree/main/EnumDemo_App
Date of Access: 09 April 2024 

Author: Fatima Shaik 
Website: https://github.com/fb-shaik/PROG6221-Group1-2024/tree/main/Generics_Library_App
Date of Access: 29 May 2024 

Author: Fatima Shaik 
Website: https://github.com/fb-shaik/PROG6221-Group1-2024/tree/main/Collection_Generics_LU3
Date of Access: 29 May 2024 

Author: Geeks for Geeks
Website: https://www.geeksforgeeks.org/c-sharp-delegates/
Date of Access: 29 May 2024 
=============Code Attribution====================
*/

namespace ST10251759_PROG6221_POE_P3
{//namespace begin
    public delegate void RecipeDelegate(string message);
    // use of generic collections
    // delegate created to display the calorie messages in application

    public class Recipe
    {//Reciepe Class Begin
        //Attribute - variable declaration
        public string Name { get; set; }
        //public Ingredient[] Ingredients { get; set; }
        public double[] OriginalQuantities { get; set; }

        public double[] OriginalCalories { get; set; }
        public UnitOfMeasurement[] OriginalUnits { get; set; }
        //public Step[] Steps { get; set; }

        //New variables for part 2
        private string message; // used for unit testing

        private List<Ingredient> ingredients = new List<Ingredient>();
        // use of generic collections
        // list create to store ingredient objects

        private List<string> steps = new List<string>();
        // use of generic collections
        // string list created to store each step in recipe

        private double totalCalories;
        // private double variable created to store the total number of calories in a recipe

        private int numIngredients;

        private int numSteps;

        // CONSTRUCTOR METHOD
        public Recipe(string name, int numIngredients, int numSteps)
        {
            Name = name;
            this.numIngredients = numIngredients;
            this.numSteps = numSteps;
        }// end constructor

        //method to get ingredients
        public void setIngredients()
        {//setIngredients begin
         // run a loop for the number of ingredients in the recipe

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("============================================");
            Console.WriteLine("Enter Ingredient Details:");
            Console.WriteLine("============================================");
            Console.ResetColor();

            for (int i = 0; i < numIngredients; i++)
            {
                // GET NAME FROM USER
                string ingredientName = GetNonEmptyStringInput($"\nPlease enter the name of ingredient number {i + 1}:");

                // GET QUANTITY FROM USER
                double quantity;//variable to hold quantity of ingredients
                                //do while loop to continue prompting user if they enter invalid integer ( zero or less)
                do
                {//do begin
                    Console.Write($"Please enter the quantity of {ingredientName}:");
                    quantity = GetDoubleInput();
                    if (quantity <= 0)
                    {//if begin
                        Console.WriteLine("Please enter a valid number (greater than zero).");
                    }//if end
                }//do end
                while (quantity <= 0); //while condition

                // GET UNIT OF MEASUREMENT FROM USER
                UnitOfMeasurement unit = GetUnitOfMeasurement($"Unit of measurement for {ingredientName}: ");

                // GET NUMBER OF CALORIES FROM USER
                double calories;//variable to hold quantity of ingredients
                                //do while loop to continue prompting user if they enter invalid integer ( zero or less)
                do
                {//do begin
                    Console.Write($"Please enter the calories for {ingredientName}:");
                    calories = GetDoubleInput();
                    if (calories <= 0)
                    {//if begin
                        Console.WriteLine("Please enter a valid number (greater than zero).");
                    }//if end
                }//do end
                while (calories <= 0); //while condition

                //  GET FOOD GROUP FROM USER
                Console.WriteLine("A Food Group is a collection of foods that share similar nutritional properties\nPlease enter the food group that this ingredient belongs to\nEnter the name of the Food Group. Choose from:\n1.Carbohydrate\n2.Protein\n3.Fat\n4.Fruit\n5.Vegetable\n6.Dairy");
                FoodGroup foodGroup = GetFoodGroup($"Please enter the food group for {ingredientName}: ");

                // create a new object with user input
                Ingredient ingredient = new Ingredient(ingredientName, quantity, unit, foodGroup, calories);
                // add ingredient object to list ingredients
                ingredients.Add(ingredient);

                Console.WriteLine("");
            }// end for loop
        }// setIngredients method

        //method to get recipe sets and store them in the list (generic collection for lists)
        public void setSteps()
        {//setSteps method begin
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("============================================");
            Console.WriteLine("Enter Step Directions:");
            Console.WriteLine("============================================");
            Console.ResetColor();

            //for loop to continuly prompting and capturing the user input for steps
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Please enter the directions for step {i + 1}:");
                // get the step from user >> if null then throw exception
                string step = Console.ReadLine();
                if (step == null) //validation to proevent no input entered by user
                { throw new ArgumentNullException("directions for step can not be null"); }

                // add step to array ateps
                steps.Add(step);

            }// end for loop
        }// end setSteps method

        //method to display ingredients by calling the methods avaliable for generic collections
        public void displayIngredients()
        {
            // for loop will run for the number of objects in the ingredients array
            for (int i = 0; i < ingredients.Count(); i++)
            {
                // display each object in the List
                Ingredient ingredient = (Ingredient)ingredients[i];
                ingredient.display();
            }// end for loop
        }// end displayIngredients method

        //method to display steps by calling the methods avaliable for generic collections
        public void displaySteps()
        {//displaySteps begin
            // run a loop for the number of elements in steps to display each step
            for (int i = 0; i < steps.Count; i++)
            { Console.WriteLine($"Step {i + 1}: {steps[i]}"); }

            Console.WriteLine();
        }// end displaySteps


        //Method to display the reciep in a neat format
        public void DisplayRecipe()
        {//DisplayRecipe begin

            //Display the Recipe Name in Yellow
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"============================================");
            Console.WriteLine($"{Name.ToUpper()}");
            Console.WriteLine($"============================================");
            Console.ResetColor();

            //Display Ingredient heading in green
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Ingredients");
            Console.ResetColor();

            //for each loop to access each element in the ingredient class
            displayIngredients();

            //Display the Step heading in blue
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Steps");
            Console.ResetColor();

            //for each loop to get the user input for steps
            displaySteps();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("");
            displayCalories();
            Console.ResetColor();

            Console.WriteLine("\n-----------------------------------------------------------");
        }//DisplayRecipe end

        //method to calulate the total calories for each recipe by adding the calories of each ingredient
        public double calculateTotalCalories()
        {//calculate total clories begin
            totalCalories = 0; //create variable to hold total calories

            // runs a loop to access each ingredient object in ingredients list
            // allowing system to retrieve the number of calories for each ingredient and add them together
            for (int i = 0; i < ingredients.Count(); i++)
            {
                totalCalories += ingredients[i].calories;
            }// end for loop

            return totalCalories;
        }// end calculate total calories method

        // delegate method created to dsplay a warning message to user once a recipe contains more than 300 calories
        public void displayCalorieMessage(string message)
        { Console.WriteLine(message); }
        // method also used to provide a message about the number of calories in the recipe to the uer

        //method to diplay total caloriesfor the recipe along with nutritional infor for the reipe based of the totalCalories value
        public void displayCalories()
        {//displayCalories begin
            RecipeDelegate recipeDelegate = new RecipeDelegate(displayCalorieMessage);
            // create instance of delegate

            recipeDelegate($"Total number of calories in recipe: {totalCalories}");
            // use of delegate to display the total number of calories in the recipe to the user
            //Use if statements to run through different senarios with the totalCalorie value - also make use of the delegate to notify user on the specif senarios based on totalCalories

            //if calories is greater than 300 notify user that calories exceeds 300
            if (totalCalories > 300)
            {//begin if
                Console.ForegroundColor = ConsoleColor.Red;
                recipeDelegate("CALORIES EXCEED 300");
                // delegate used to warn user that recipe calories is over 300
                Console.ForegroundColor = ConsoleColor.White;
            }// end if

            if (totalCalories > 0 && totalCalories <= 200)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                recipeDelegate("This amount of calories is enough to satisfy you without interfering with appetite and is a good SNACK");
                // delegate used to display to user that recipe calories is a snack
                Console.ForegroundColor = ConsoleColor.White;
                message = "Snack";
            }// end if snack
            else if (totalCalories > 200 && totalCalories <= 400)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                recipeDelegate("This amount of calories serves as a LOW CALORIE MEAL, aiding in weight loss");
                // delegate used to display to user that recipe calories is a low calorie meal
                Console.ForegroundColor = ConsoleColor.White;
                message = "Low Calorie Meal";
            }// end low calorie meal
            else if (totalCalories > 400 && totalCalories <= 700)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                recipeDelegate("This amount of calories is sutable for an AVERAGE MEAL ");
                // delegate used to display to user that calories are average
                Console.ForegroundColor = ConsoleColor.White;
                message = "Average Calorie Meal";
            }
            else if (totalCalories > 700)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                recipeDelegate("This meal is considered a HIGH CALORIE MEAL, containing a large amount of calories, and should not be consumed frequently");
                // delegate used to display to user that calories are high 
                Console.ForegroundColor = ConsoleColor.White;
                message = "High Calorie Meal";
            }

        }// end display calories method

        //Method to scale the reciepe ingreidents to make large quantiies 
        public void ScaleRecipe()
        {//ScaleRecipe begin

            //Display Scaling Heading in Yellow
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nScaling Options");
            Console.ResetColor();

            //Display options to keep user inbounds
            Console.WriteLine("0.5 - Decrease recipe size by half");
            Console.WriteLine("2   - Double recipe size");
            Console.WriteLine("3   - Triple recipe size");

            //Prompt user for the scaling factor
            Console.Write("Enter scaling factor (0.5, 2, or 3): ");
            //Call method to validate the user input
            double factor = GetDoubleScalingFactor();

            //get the total calories and store in a variable
            totalCalories = calculateTotalCalories() * factor;



            //foreach to alter each value of the array ingredients
            foreach (Ingredient ingredient in ingredients)
            {//for each begin
                //the scaled value equals the ingredients quantity multiplied by the factor
                double scaledQuantity = ingredient.Quantity * factor;

                //alter the calories for ingredient
                ingredient.CalculateScaledCalories(factor);

                //The switch statement is used to select one of many code blocks to be executed based on the value of a given expression.
                switch (ingredient.Unit)
                {//switch begin
                    //run through enum options
                    case UnitOfMeasurement.SMALL: ingredient.Quantity *= factor; break;
                    case UnitOfMeasurement.MEDIUM: ingredient.Quantity *= factor; break;
                    case UnitOfMeasurement.LARGE: ingredient.Quantity *= factor; break;
                    case UnitOfMeasurement.EXTRALARGE: ingredient.Quantity *= factor; break;
                    case UnitOfMeasurement.CUP:
                    case UnitOfMeasurement.CUPS:
                        ConvertCups(ingredient, scaledQuantity); //call method to covert cups back into tablespoons
                        break;
                    case UnitOfMeasurement.TABLESPOON:
                    case UnitOfMeasurement.TABLESPOONS:
                        ConvertTablespoons(ingredient, scaledQuantity); //call method that either converts the unit to cups or teaspoons
                        break;
                    case UnitOfMeasurement.TEASPOON:
                    case UnitOfMeasurement.TEASPOONS:
                        ConvertTeaspoons(ingredient, scaledQuantity); //call method toconvert the unit into tablespoons
                        break;
                    default:
                        //Don't need to add validation here because i have catered in another method to ensure user selects correct unit or measurement
                        break;
                }//switch end

                //alter the calories for ingredient
                //ingredient.calories *= factor;

            }//for each end

            //Display successful message in green
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nRecipe scaled by a factor of {factor} successfully!\n");
            Console.ResetColor();
        }//ScaleRecipe end



        //method to convert to cup as unit of measurement
        public void ConvertCups(Ingredient ingredient, double newQuantity)
        {//ConvertCups begin
         //convert to tablespoon quantity

            //if quantity is less than one, unit must be converted into tablespoons
            if (newQuantity < 1)
            {
                //1 cup = 16 tablespoons
                double tablespoons = newQuantity * 16;
                ingredient.Quantity = tablespoons;
                ingredient.Unit = UnitOfMeasurement.TABLESPOONS;
            }
            else if (newQuantity == 1) //if quantity is one unit is cup
            {
                ingredient.Quantity = newQuantity;
                ingredient.Unit = UnitOfMeasurement.CUP;
            }
            else //if unit is more han 1 uni is cups
            {
                ingredient.Quantity = newQuantity;
                ingredient.Unit = UnitOfMeasurement.CUPS;
            }
        }//ConvertCups end

        //method to convert to tablesoons as unit of measurement
        public void ConvertTablespoons(Ingredient ingredient, double newQuantity)
        {//ConvertTablespoons begin
            //16 tablespoons equals 1 cup
            //3 teaspoons equals 1 tablespoon
            if (newQuantity >= 16)
            {//if greater than or equal to 16 begin
                //if quantity is 16 unit is 1 cup
                if (newQuantity == 16)
                {//if equal to 16 begin
                    ingredient.Quantity = 1;
                    ingredient.Unit = UnitOfMeasurement.CUP;
                }//if equal to 16 end
                else
                {//else if quantity is greater than 16 convert to an amount of cups begin
                    //take the newQuantity and divide by 16 to get the number of cups
                    double cups = newQuantity / 16;
                    ingredient.Quantity = cups;
                    ingredient.Unit = UnitOfMeasurement.CUPS;
                }//else if quantity is greater than 16 convert to an amount of cups end
            }//if greater than or equal to 16 end
            else if (newQuantity < 1)
            {//else if quanity is less than one convert to teaspoons begin
                //1 tablespoon is equal to 3 teaspoons
                double teaspoons = newQuantity * 3;
                ingredient.Quantity = teaspoons;
                ingredient.Unit = UnitOfMeasurement.TEASPOONS;
            }//else if quanity is less than one convert to teaspoons end
            else
            {//else if quantity is not less than 1 or greater than or equal to 16 begin
                if (newQuantity == 1)
                {//if quantity is equal to 1 the unit is 1 tablespoon end
                    ingredient.Quantity = 1;
                    ingredient.Unit = UnitOfMeasurement.TABLESPOON;
                }//if quantity is equal to 1 the unit is 1 tablespoon end
                else
                {//else if the unit is between 1 and 16 unit will remain tablespoons begin
                    ingredient.Quantity = newQuantity;
                    ingredient.Unit = UnitOfMeasurement.TABLESPOONS;
                }
            }//else if quantity is not less than 1 or greater than or equal to 16 end
        }//ConvertTablespoons end

        //Method to convert the number of teaspoons into tablespoons
        public void ConvertTeaspoons(Ingredient ingredient, double newQuantity)
        {//ConvertTeaspoons begin
            if (newQuantity >= 3)
            {//if the quantity is greater than or equal to 3 the unit must be converted to tablespoons (begin)
                //3 teaspoons equals 1 tablespoons
                if (newQuantity == 3)
                {//if quantity equals 3 the unit is 1 tablespoon begin
                    ingredient.Quantity = 1;
                    ingredient.Unit = UnitOfMeasurement.TABLESPOON;
                }//if quantity equals 3 the unit is 1 tablespoon end
                else
                {//else if the quanity is greater than 3 the unit must be divided into 3 and converted into tablespoons begin
                    double tablespoons = newQuantity / 3;

                    ingredient.Quantity = tablespoons;
                    ingredient.Unit = UnitOfMeasurement.TABLESPOONS;

                }//else if the quanity is greater than 3 the unit must be divided into 3 and converted into tablespoons end
            }//if the quantity is greater than or equal to 3 the unit must be converted to tablespoons (end)
            else if (newQuantity <= 1)
            { //else if the quanity is less than or equal to 1 the unit must reamain teaspoon begin
                ingredient.Quantity = newQuantity;
                ingredient.Unit = UnitOfMeasurement.TEASPOON;
            } //else if the quanity is less than or equal to 1 the unit must reamain teaspoon end
            else
            { //else if the quanity is more than 1 and less than 3 the unit must be teaspoons begin
                ingredient.Quantity = newQuantity;
                ingredient.Unit = UnitOfMeasurement.TEASPOONS;
            }//else if the quanity is more than 1 and less than 3 the unit must be teaspoons end
        }//ConvertTeaspoons end

        //Method to reset the reciepes ingredient quanties to orginal values
        public void ResetRecipe()
        {//ResetRecipe begin

            //int i = 0;
            // Run a loop to access all elements of the list
            foreach (Ingredient ingredient in ingredients)
            {//foreach loop begin
                ingredient.Quantity = ingredient.OriginalQuantity;
                ingredient.Unit = ingredient.OriginalUnit;
                ingredient.calories = ingredient.originalCalories; // Reset the calories for each ingredient
                //i++;
            }//foreach loop end

            totalCalories = calculateTotalCalories();

            //Display succesful message in green
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nRecipe has been reset to its orgin state successfully!\n");
            Console.ResetColor();
        }//ResetRecipe end

        //method to validate the intger entered as user input
        private int GetIntegerInput()
        {//GetIntegerInput begin
            //while loop to continue prompting user until value is correct
            while (true)
            {//while begin
                //try catch for validation
                try
                {//try begin
                    return int.Parse(Console.ReadLine());
                }//try end
                catch (FormatException)
                {//catch begin
                    //error message and reprompt user
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter an integer.");
                    Console.ResetColor();
                }//catch end
            }//while end
        }//GetIntegerInput

        //method to validate the factor for scaling entered by user
        private double GetDoubleScalingFactor()
        {//GetDoubleScalingFactor() begin 
            //run while loop to continue loop
            while (true)
            {//while begin
                //try catch for validation
                try
                {//try begin
                    double factor = double.Parse(Console.ReadLine());
                    //if statement to check if user input is within the options
                    if (factor == 0.5 || factor == 2 || factor == 3)
                    {//if equal to one of the 3 options / if is in range begin
                        return factor;
                    }//if equal to one of the 3 options / if is in range end
                    else
                    {//else statement if the factor is not within the 3 options begin
                        //error message and reprompt user
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid scaling factor. Please enter 0.5, 2, or 3.");
                        Console.ResetColor();
                    }//else statement if the factor is not within the 3 options end
                }//try end
                catch (FormatException)
                {//catch begin
                    //error message and reprompt user
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.ResetColor();
                }//catch end
            }//while end
        }//GetDoubleScalingFactor() end

        //method to validate double user input
        private double GetDoubleInput()
        {//GetDoubleInput begin
            while (true)
            {//while loop begin
                //try-catch for validation
                try
                {//try begin
                    return double.Parse(Console.ReadLine());
                }//try end
                catch (FormatException)
                {//catch begin
                    //Display error message and reprompt user
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.ResetColor();
                }//catch end
            }//while loop end
        }//GetDoubleInput end

        //method to validate string input is not null
        public string GetNonEmptyStringInput(string prompt)
        {//GetNonEmptyStringInput begin
         //create a null variable to enter loop
            string input = "";
            //run while loop to continue prompting user until input is not null
            while (string.IsNullOrEmpty(input))
            {//while begin
                //prompt user for input
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();

                //if statement to check if the input is still null
                if (string.IsNullOrEmpty(input))
                {//if begin
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input cannot be empty. Please try again.");
                    Console.ResetColor();
                }//if end
            }//while end

            return input;
        }//GetNonEmptyStringInput end

        //Method to get unit of measurement from enum
        private UnitOfMeasurement GetUnitOfMeasurement(string prompt)
        {//GetUnitOfMeasurement begin
            //while loop to continuelly prompting user
            while (true)
            {//while loop begin
                Console.Write(prompt);
                string input = Console.ReadLine().ToUpper();

                //check if the user input is a valid option in enum
                if (Enum.TryParse<UnitOfMeasurement>(input, out UnitOfMeasurement unit))
                {//if valid begin
                    return unit;
                }//if valid end
                else //if not valid option
                {//else begin
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid unit of measurement. Valid options are:");
                    Console.ResetColor();
                    //Display the Options
                    foreach (UnitOfMeasurement option in Enum.GetValues(typeof(UnitOfMeasurement)))
                    {
                        Console.WriteLine(option.ToString());
                    }
                }//else end
            }//while loop end
        }//GetUnitOfMeasurement end

        //Method to get unit of measurement from enum
        private FoodGroup GetFoodGroup(string prompt)
        {//GetFoodGroup begin
            //while loop to continuelly prompting user
            while (true)
            {//while loop begin
                Console.Write(prompt);
                string input = Console.ReadLine().ToUpper();

                //check if the user input is a valid option in enum
                if (Enum.TryParse<FoodGroup>(input, out FoodGroup foodGroup))
                {//if valid begin
                    return foodGroup;
                }//if valid end
                else //if not valid option
                {//else begin
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Food Group. Valid options are:");
                    Console.ResetColor();
                    //Display the Options
                    foreach (FoodGroup option in Enum.GetValues(typeof(FoodGroup)))
                    {
                        Console.WriteLine(option.ToString());
                    }
                }//else end
            }//while loop end
        }//GetFoodGroup end

        //GETTERS AND SETTERS

        // CREATED FOR USE IN UNIT TESTING
        public void setTotalCalories(double totalCalories)
        { this.totalCalories = totalCalories; }

        public void setIngredients(List<Ingredient> ingredients)
        { this.ingredients = ingredients; }

        public string Message()
        { return message; }

    }//Reciepe Class Begin
}//namespace end
