using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    public abstract class Articles
    {
        int price;

        public abstract int Examine();

        public virtual bool Use(List<string> list, string item)
        {
            return list.Remove(item);
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }
    }

    public class Fanta : Articles
    {
        const int fantaprice = 1;

        public Fanta()
        {
            Price = fantaprice;
        }

        public override int Examine()
        {
            Console.WriteLine($". Fanta is a soft drink with too much sugar and costs {Price}kr.");
            return Price;
        }
    }

    public class Popcorn : Articles
    {
        const int popcornprice = 3;

        public Popcorn()
        {
            Price = popcornprice;
        }

        public override int Examine()
        {
            Console.WriteLine($". Popcorn is slightly better for you but mostly air and costs {Price}kr.");
            return Price;
        }
    }

    public class Sandwich : Articles
    {
        const int sandwichprice = 6;

        public Sandwich()
        {
            Price = sandwichprice;
        }

        public override int Examine()
        {
            Price = 5;
            Console.WriteLine($". This sandwich will serve you with much needed energy for the modest price {Price}kr.");
            return Price;
        }
    }

    public class User
    {
        int sum;
        List<string> itemList = new List<string>();

        public User()
        {
            sum = 0;
        }

        public int Sum
        {
            get { return sum; }
            set { sum = value; }
        }

        public List<string> ItemList
        {
            get { return itemList; }
            set { itemList = value; }
        }

        public void Purchase(string item)
        {
            ItemList.Add(item);
        }

        public void AddToSum(int n)
        {
            if (sum + n >= 0)
            {
                sum += n;
            }
            else
            {
                Console.WriteLine("You don't have enough money to buy this item!");
            }
        }

        public bool Use(string item)
        {
            return ItemList.Remove(item);
        }
    }
}
