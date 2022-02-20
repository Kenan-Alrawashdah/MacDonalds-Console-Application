using System;


namespace FinalProject2
{
    class Program
    {
        static bool IsNumber(string str)
        {
            int numericValue = 0;

            bool isNumber = int.TryParse(str, out numericValue);
            return isNumber;
        }
        static int GetInputFromUser(string discripation)
        {
            bool flag = true;
            string numString ="";

            while (flag) {
                Console.WriteLine($"{ discripation}");
                   numString = Console.ReadLine();
                if (IsNumber(numString))
                  flag = false;
                else
                  ERR();
            } 

            return Convert.ToInt32(numString);
        }
        static void ERR()
        {
            Console.WriteLine("Wrong input Please try again!\n");
        } 
        static void DisplayTitle()
        {
            Console.WriteLine("\n\t\t\t\t----------------\n\t\t\t\t|  MacDonalds  |");
            Console.WriteLine("\t\t\t\t---------------- \n\t\t\t\t\n\n\n");
        }
        static int DisplyCategorieAndGetNumberCateg()
        {
            Console.WriteLine("\tMenu Categories :\n" +
                "\t1 - Breakfast\n\t2 - Lunch\n\t3 - Drinks\n\n");

            int numCateg = GetInputFromUser("Choose categorie number : ");
               
            return numCateg;
        }
        static double OrderItem(int numCategorie)
        {
            double price = 0;
            double totlePrice = 0;
            
               while(price == 0) { 
             int  numItem = GetInputFromUser("Choose item number : ");
            switch (numCategorie)
            {
                case 1: price = (numItem == 1) ? 1.5 : (numItem == 2) ? 2.5 :(numItem == 3)? 2: 0; break;
                case 2: price = (numItem == 1) ? 3.5 : (numItem == 2) ? 4.00 :(numItem == 3)? 3: 0; break;
                case 3: price = (numItem == 1) ? 1.25 : (numItem == 2) ? 3.75 :(numItem == 3)? 1.5: 0; break;
            }
                if (price == 0)
                    ERR();
            }
            int quantity = GetInputFromUser("\nHow many dishes/cups would you like :");

            totlePrice = quantity * price;
            return totlePrice;
        }
        static void DisplyItems(int categorie)
        { 
                switch (categorie)
                {
                    case 1:
                        Console.WriteLine("\nMenu Breakfast :\n" +
                        "1 - Eggs Dish Price: 1.5JDs\n2 - Butter Dish Price: 2.5JDs\n3 - cheese Dish Price: 2JDs\n\n");
                        break;
                    case 2:
                        Console.WriteLine("\nMenu Lunch :\n" +
                       "1 - Shawarma meal Price: 3.5 JDs\n2 - Burger meal Price: 4.00JDs\n3 - Pizza meal Price: 3.00JDs\n\n");
                        break;
                    case 3:
                        Console.WriteLine("\nMenu Drinks :\n" +
                       "1 - Tea cup Price: 1.25 JDs\n2 - Cocktail cup Price: 3.75JDs\n3 - Pepsi cup Price: 1.5JDs\n\n");
                        break;
                }
            
        }
        static void Main(string[] args)
        {
            DisplayTitle();

            int terminationNumber = 1;
            double totalPrice = 0;
            int numCateg = DisplyCategorieAndGetNumberCateg();

            while (terminationNumber != 0)
            {
                switch (numCateg)
                {
                    case 1:
                        DisplyItems(numCateg);
                        totalPrice += OrderItem(numCateg); break;
                    case 2:
                        DisplyItems(numCateg);
                        totalPrice += OrderItem(numCateg); break;
                    case 3:
                        DisplyItems(numCateg);
                        totalPrice += OrderItem(numCateg); break;
                    default: ERR();
                       numCateg = DisplyCategorieAndGetNumberCateg();
                       continue; 
                       

                }
                terminationNumber = GetInputFromUser("\nIf you want to reorder from category choose, (5) or type (0) to finish : ");
               
                if (terminationNumber == 0)
                    continue;
                
                numCateg = DisplyCategorieAndGetNumberCateg();
            }


            double discountPrice = 0;

            if (totalPrice >= 15) { 
              discountPrice = totalPrice * 0.05;
              Console.WriteLine($"\nTotal Price : {totalPrice} You got 5% discount for buying more than 15JDs" +
                $"\nPrice after discount :{totalPrice - discountPrice}JDs\n");
            }
            else
            {
                Console.WriteLine($"\nTotal Price : {totalPrice}JDs\n");
            }
        }
    }
}
