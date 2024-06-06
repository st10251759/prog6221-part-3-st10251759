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
        private string name;
        private List<Ingredient> ingredients = new List<Ingredient>();
        private List<string> steps = new List<string>();

        private double totalCalories;

        // CONSTRUCTOR METHOD
        public Recipe(string name, List<Ingredient> ingredients, List<string> steps)
        {
            this.name = name;
            this.steps = steps;
            this.ingredients = ingredients;
            calculateTotalCalories();

        }// end constructor

        public double calculateTotalCalories()
        {
            totalCalories = 0;
            for (int i = 0; i < ingredients.Count; i++)
            { totalCalories += ingredients[i].NumCalories(); }
            return totalCalories;

        }

        public string getName()
        { return name; }
        public List<Ingredient> getIngredients()
        { return ingredients; }

        public List<string> getSteps()
        { return steps; }

        public double TotoalCalories()
        { return totalCalories; }

    }//Reciepe Class Begin
}//namespace end
