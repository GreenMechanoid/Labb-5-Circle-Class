using System;
// Daniel Svensson .Net22
namespace Lab_5_Circle_class_basics_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            int SwitchyChoise = 0;
            string UserInput = "";
            int radius;
            int TriBase = 0;
            int TriSide1 = 0;
            int TriSide2 = 0;
            int CustomCounter = 0;
            bool CustomRadius = false; 
            Circle CalcTheCircle = new Circle(5);
            
            ConsoleKey UserChoice;


            Console.WriteLine("Greeting's User! \nDo you want to get the radius of Circles, or do you want to calculate the area of a Triangle?");

            do
            {
                Console.WriteLine("1:Circle\n2:Triangle");
                UserInput = Console.ReadLine();
            } while (int.TryParse(UserInput, out SwitchyChoise) is false && (SwitchyChoise != 1 || SwitchyChoise != 2 ));

            switch (SwitchyChoise)
            {
                case 1:
                    UserInput = ""; // emptying the choice prior to user choosing the radius
                    Console.WriteLine("Hello and welcome to the Circle Radius Calculator");

                    Console.WriteLine("The Area of a Circle with the Radius of 5 is: " + CalcTheCircle.GetArea());
                    CalcTheCircle = new Circle(6);
                    Console.Write("\n");  // using Console.Write(New Line) for the fun of it, instead of using empty Console.WriteLine();
                    Console.WriteLine("The Area of a Circle with the Radius of 6 is: " + CalcTheCircle.GetArea());
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
                    CalcTheCircle = new Circle(radius);  // uses the overloaded constructor to assign a diffrent radius inside the class
                    Console.WriteLine("The Area of a Circle with the Radius of "+radius+" is: " + CalcTheCircle.GetArea());
                    
                    Console.WriteLine("Do you want to calculate a Circle with a diffrent radius? Y/N");
                    UserChoice = Console.ReadKey(false).Key;
                    while (UserChoice != ConsoleKey.Y && UserChoice != ConsoleKey.N) // input Error handeling
                            {
                                Console.WriteLine("Wrong input Detected!, Try Again Y/N \n");
                                UserChoice = Console.ReadKey(false).Key;
                            }
                    Console.Write("\n");
                    if (CustomRadius == true && UserChoice == ConsoleKey.N)
                    {
                        CustomRadius = false; // teminates the loop on user's request
                    }
                    else if (UserChoice == ConsoleKey.Y)
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

                    break;
                case 2:
                    Console.WriteLine("Hello and welcome to the Triangle Area Calculator\n");
                    do // checks to see that it's a whole number
                    { 
                    Console.WriteLine("Please enter the Base of the Triangle");
                        UserInput = Console.ReadLine();
                    } while(int.TryParse(UserInput, out TriBase) is false);
                    UserInput = ""; // emptying the input string for use in the next input.
                    do // checks to see that it's a whole number
                    {
                        Console.WriteLine("Please enter the First side of the Triangle");
                        UserInput = Console.ReadLine();
                    } while (int.TryParse(UserInput, out TriSide1) is false);
                    UserInput = ""; // emptying the input string for use in the next input.
                    do // checks to see that it's a whole number
                    {
                        Console.WriteLine("Please enter the Second side of the Triangle");
                        UserInput = Console.ReadLine();
                    } while (int.TryParse(UserInput, out TriSide2) is false);
                    UserInput = ""; // emptying the input string for use in the next input.
                    TriangleCalc CalcTheTriangle = new TriangleCalc(TriBase, TriSide1, TriSide2);
                    Console.WriteLine("The area of your Triangle is: " + CalcTheTriangle.GetArea());
                    break;
            }
            Console.WriteLine("Thanks for using this program, and good day to you.");

        }


        class Circle
        {
            float _Pi = 3.141f;
            int _Radius = 0;

            public Circle(int radius)
            {
                this._Radius = radius; // set's objects _Radius, to the inputed radius from user in the "Custom" mode and also the "forced" in start of code
            }


            public float GetArea()   //declares a float method to save the value, then returns it to Main after calculating for printing 
            {
                float MadeCircle;
                MadeCircle = this._Radius * this._Radius * this._Pi; // using the saved _Pi variable from object creation
                return MadeCircle;
            }

        }

        class TriangleCalc
        {
            int _TriBase;
            int _TriSide1;
            int _TriSide2;
            public TriangleCalc(int TriBase,int Triside1, int Triside2) // skipping zero paramater constructor. User input sides
            {
                this._TriBase = TriBase;
                this._TriSide1 = Triside1;
                this._TriSide2 = Triside2;
            }


            public Double GetArea() // using Heron's Formula, Area = √s(s−a)(s−b)(s−c)   s = semi-perimeter which is: (a + b + c)/2
            {
                float SemiAreaOfTriangle = (this._TriBase + this._TriSide1 + this._TriSide2) / 2; // calculate the Semi-perimeter
                float AreaOfTriangle = SemiAreaOfTriangle*(SemiAreaOfTriangle - _TriBase)*(SemiAreaOfTriangle - _TriSide1)* (SemiAreaOfTriangle - _TriSide2); // calculate the full area
                return Math.Sqrt(AreaOfTriangle);
            }
        }
    }
}
