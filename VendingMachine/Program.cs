using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] denominations = { 1, 5, 10, 20, 50, 100, 500, 1000 };
            int i;
            char choice = ' ', menuChoice = ' ';

            User user = new User();

            do
            {
                menuChoice = GetChoice(4, "\n\n1. Insert coins\n2. Purchase an item\n3. Consume an item\n4. End\n");

                switch (menuChoice)
                {
                    case '1':
                        Console.WriteLine("\n\nChoose 1 - 8 for 1, 5, 10, 20, 50, 100, 500 or 1000kr");
                        Console.WriteLine("End with an Enter");
                        do
                        {
                            choice = GetChoice(8, $"\rSum: {user.Sum}. Please add a coin into the slot: ");
                            if (choice != '\r')
                            {
                                i = choice - '1';
                                user.AddToSum(denominations[i]);
                            }
                        } while (choice != '\r');
                        break;
                    case '2':
                        Console.WriteLine("\n\nChoose 1. Fanta, 2. Popcorn, 3. Sandwich or 4. To End");
                        do
                        {
                            choice = GetChoice(4, $"\rSum: {user.Sum}. Please choose an item to purchase: ");
                            switch (choice)
                            {
                                case '1':
                                    Fanta fanta = new Fanta();
                                    Console.WriteLine($"\nYou chose a Fanta for {fanta.Price}kr");
                                    user.AddToSum(-fanta.Price);
                                    user.Purchase("Fanta");
                                    break;
                                case '2':
                                    Popcorn popcorn = new Popcorn();
                                    Console.WriteLine($"\nYou chose a Popcorn for {popcorn.Price}kr");
                                    user.AddToSum(-popcorn.Price);
                                    user.Purchase("Popcorn");
                                    break;
                                case '3':
                                    Sandwich sandwich = new Sandwich();
                                    Console.WriteLine($"\nYou chose a Sandwich for {sandwich.Price}kr");
                                    user.AddToSum(-sandwich.Price);
                                    user.Purchase("Sandwich");
                                    break;
                                default:
                                    Console.WriteLine("\n\nWill now show items purchased!");
                                    foreach (var item in user.ItemList)
                                    {
                                        Console.WriteLine(item);
                                    }
                                    break;
                            }
                        } while (user.Sum > 0 && choice != '4');
                        Console.WriteLine($"\nYou have {user.Sum} in change left.");
                        break;
                    case '3':
                        Console.WriteLine("You will now consume items you have bought.");
                        Console.WriteLine("\n\nChoose 1. Fanta, 2. Popcorn, 3. Sandwich or 4. To End");
                        do
                        {
                            choice = GetChoice(4, $"\rSum: {user.Sum}. Please choose an item to consume: ");
                            switch (choice)
                            {
                                case '1':
                                    user.Use("Fanta");
                                    break;
                                case '2':
                                    user.Use("Popcorn");
                                    break;
                                case '3':
                                    user.Use("Sandwich");
                                    break;
                                default:
                                    Console.WriteLine("\n\nRemaining items bought:");
                                    foreach(string item in user.ItemList)
                                    {
                                        Console.WriteLine(item);
                                    }
                                    break;
                            }
                        } while (choice != '4');
                        break;
                    default:
                        break;
                }
            } while (menuChoice != '3');
            Console.WriteLine($"\n\nHere you have your {user.Sum}kr back.");
        }

        private static char GetChoice(int n, string s)
        {
            int lim = n + '0';
            char choice;
            Console.Write(s);
            do
            {
                choice = Console.ReadKey().KeyChar;
                if (choice < '1' || choice > lim)
                {
                    Console.Write('\b');
                }
            } while ((choice < '1' || choice > lim) && choice != '\r');
            return choice;
        }
    }
}
