using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovAssessment
{
    class CautiousInsurance
    {
        /*This console application will calculate insurance premiums
          
          Algorithm
          1.Print company name to screen
          2.Ask user to enter vehicle value - save to variable
          2a. Give user an exit option
          3.Ask user for gender - save to variable
          4.Ask user for age - save to variable
          5.Ask user for penalty points - save to variable
          6.Calculate basic insurance premium
          6a. Premium increase for certain driver categories
          7.Output quotation to screen
          8.Print 'press enter to continue' to screen                
        */

        static void Main(string[] args)
        {
            //Declare variables and constants needed
            int vehicleValue = 0;
            int age, penaltyPoints;
            string gender;
            double premiumQuotation; 
            double categoryPremiumIncrease = 0;
            bool quotePossible = true;
            int inputNumber = -1; // used when checking validity of input - ran out of time to think of a more elegant way

            const double BASIC_RATE = 0.03;
            const double YOUNG_MALE_RATE = 0.1;
            const double YOUNG_FEMALE_RATE = 0.06;

            do
            {
                //Clear console
                Console.Clear();

                //Print company name to screen
                Console.WriteLine("C A U T I O U S  I N S U R A N C E");
                Console.WriteLine("-----------------------------------");

                //Ask user to enter vehicle value - save to variable
                Console.Write("Please enter your Vehicle Value or -1 to exit >> ");
                string input = Console.ReadLine();


                if (!String.IsNullOrEmpty(input)) //Check user has actually entered something
                {
                    if (Int32.TryParse(input, out inputNumber)) //Check that user entered a valid input i.e. a number
                    {
                        inputNumber = Convert.ToInt32(input);
                    }
                    else
                    {
                        Console.WriteLine("Not a valid value");
                        break;
                    }
                }
                else //Not a valid input
                {
                    Console.WriteLine("Not a valid value");
                    break;
                }//end of validation for vehicle value - ran out of time to validate other inputs

                if (inputNumber == -1)
                {
                    break;//breaks out of do while loop if user has chosen to exit
                }
                else //continue through to do while loop
                {
                    vehicleValue = inputNumber;

                    //Ask user for gender - save to variable
                    Console.Write("Please enter your Gender <M/F> >> ");
                    gender = Console.ReadLine().ToUpper(); //To catch when user enters lowercase letters or a mixture

                    //To check if user has entered words rather than requested single letters
                    if (gender == "MALE")
                    {
                        gender = "M";
                    }
                    else if (gender == "FEMALE")
                    {
                        gender = "F";
                    }

                    //Ask user for age - save to variable
                    Console.Write("Please enter your Age >> ");
                    age = Convert.ToInt32(Console.ReadLine());

                    //Ask user for penalty points - save to variable
                    Console.Write("Please enter your Penalty Points >> ");
                    penaltyPoints = Convert.ToInt32(Console.ReadLine());

                    //Calculate insurance premium

                    //Basic rate
                    premiumQuotation = BASIC_RATE * vehicleValue;

                    //Male under 25 increase basic rate by given rate
                    if (gender == "M" && age < 25)
                    {
                        categoryPremiumIncrease = premiumQuotation * YOUNG_MALE_RATE;
                    }


                    //Female under 21 increase basic rate by given rate
                    
                    if (gender == "F" && age < 21)
                    {
                        categoryPremiumIncrease = premiumQuotation * YOUNG_FEMALE_RATE;
                    }

                    //Total of premium including any category increase
                    premiumQuotation += categoryPremiumIncrease;

                    //Extra charge for penalty points added to premium
                    if (penaltyPoints == 0)
                    {
                        //no extra charge
                    }
                    else if (penaltyPoints >= 1 && penaltyPoints < 5)
                    {
                        //Add €100 to premium
                        premiumQuotation += 100;
                    }
                    else if (penaltyPoints < 8)
                    {
                        //Add €200 to premium
                        premiumQuotation += 200;
                    }
                    else if (penaltyPoints < 11)
                    {
                        //Add €300 to premium
                        premiumQuotation += 300;
                    }
                    else if (penaltyPoints < 13)
                    {
                        //Add €400 to premium
                        premiumQuotation += 400;
                    }
                    else
                    {
                        quotePossible = false;
                    }

                    //Output quotation to screen
                    if (quotePossible)
                    {
                        Console.WriteLine("Your quote is EUR {0:F}", premiumQuotation);
                    }
                    else
                    {
                        Console.WriteLine("No Quote POSSIBLE");
                    }

                    //Print 'press enter to continue' to screen
                    Console.WriteLine("Press ENTER to continue");

                    //Pause program
                    Console.ReadLine();

                }//end of else

            }//end of do
            while (vehicleValue != -1);
            
            
            //Print 'press enter to continue' to screen
            Console.WriteLine("Press ENTER to continue");
            
            //Pause program
            Console.ReadLine();
        }
    }
}
