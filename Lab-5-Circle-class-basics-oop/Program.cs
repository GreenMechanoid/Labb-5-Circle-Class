using System;
// Daniel Svensson .Net22
namespace Lab_5_Circle_class_basics_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            string UserInput = "";
            int radius;
            int CustomCounter = 0;
            bool CustomRadius = false;
            Circle CalcTheCircle = new Circle();
            ConsoleKey UserChoice;
            Console.WriteLine("Hello and welcome to the Circle creator");

            Console.WriteLine("The Area of a Circle with the Radius of 5 is: " + CalcTheCircle.CalcCircle(5));
            Console.Write("\n");  // using Console.Write(New Line) for the fun of it, instead of using empty Console.WriteLine();
            Console.WriteLine("The Area of a Circle with the Radius of 6 is: " + CalcTheCircle.CalcCircle(6));
            Console.Write("\n");

            do // asks user if they want to calculate a circle with another radius
            {
                Console.WriteLine("Do you want to calculate a Circle with a diffrent radius? Y/N");
                UserChoice = Console.ReadKey(false).Key;

                if (UserChoice == ConsoleKey.Y) CustomRadius = true; // checks if it's true or not, and flips the bool flag if user wants to input their own radius

            } while (UserChoice != ConsoleKey.Y && UserChoice != ConsoleKey.N);

            
            if (CustomRadius == true) 
            {
                do
                {

                    while (int.TryParse(UserInput, out radius) is false && CustomRadius == true) // makes certain the number inputed is in fact a Integer
                    {
                        Console.Write("\n");
                        Console.WriteLine("Please enter a Radius for the circle in whole numbers");
                        UserInput = Console.ReadLine();
                    }
                    radius = Convert.ToInt32(UserInput);
                    Circle CalcTheCircleCustom = new Circle(radius);  // uses the overloaded constructor to assign a diffrent radius inside the class
                    Console.WriteLine("The Area of a Circle with the Radius of "+radius+" is: " + CalcTheCircle.CalcCircle(radius));
                    
                    Console.WriteLine("Do you want to calculate a Circle with a diffrent radius? Y/N");
                    UserChoice = Console.ReadKey(false).Key;
                    Console.Write("\n");
                    if (CustomRadius == true && UserChoice == ConsoleKey.N)
                    {
                        CustomRadius = false; // teminates the loop on user's request
                    }
                    else
                    {
                    UserInput = ""; // resetting string input to loop again if they chose to do another
                    CustomCounter++;
                        if (CustomCounter == 3)
                        {
                            Console.Clear(); // clears the screen clutter after 3 circles, then resets counter.
                            CustomCounter = 0;
                        }
                    }
                    
                } while (CustomRadius == true);
            }

            Console.WriteLine("Thanks for using this program, and good day to you.");

        }


        class Circle
        {
            float _Pi = 3.141f;
            int _Radius = 0;


            public Circle() // standard constructor with no changes to paramaters in the class
            {
                // empty opn purpose as we dont need to change anything in the class for the "forced" radius in the start of the code
            }
            public Circle(int radius)  // makeing a overload for injecting radius from user, to calc other than radius of 5 or 6
            {
                this._Radius = radius; // set's objects _Radius, to the inputed radius from user in the "Custom" mode
            }


            public float CalcCircle(int radius)   //declares a float method to save the value, then returns it to Main after calculating for printing 
            {
                float MadeCircle;
                MadeCircle = radius * radius * this._Pi; // using the saved _Pi variable from object creation
                return MadeCircle;
            }

        }
    }
}
