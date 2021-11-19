using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace POS
{
    class Program
    {
        public static string newpassword;
        public static string defaultpass = ("password");
        public static bool adapt = false;
        public static bool newpass = false;
        public static List<Product> productList;
        public static List<Basket> basketlist;
        public static Decimal saleTotal = 0.00M;
        //Main Method 
        static void Main(string[] args)
        {
            productList = new List<Product>();

            welcome();
        }
        //Get User Input
        static void welcome()
        {
            Console.WriteLine("Welcome to the POS System");
            Console.WriteLine();
            Console.WriteLine("Press any key to proceed");
            Console.ReadKey();
            Menu();
        }
        static string GetInput()
        {
            // ask for input
            if (adapt == true)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (adapt == false)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.Write("Choose an option: ");
            return Console.ReadLine().ToLower();
        }
        
        static void Access()
        {
            
            Console.Clear();
            Console.WriteLine("Accesibility mode is now enabled");
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
            adapt = true;
            Menu();
        }
        static string PassInput()
        {
            if (adapt == true)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (adapt == false)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine("Please enter Admin password to enter this menu: ");
            if (adapt == true)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (adapt == false)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            return Console.ReadLine().ToLower();
        }
        static void passnewwiz()
        { 
            string userinput = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please enter a new password");
            newpassword = Console.ReadLine();
            Console.ReadKey();
            Console.WriteLine("If you are happy with your password press y to return to admin menu if not press n to try again");
            if (userinput== "y")
            {
                newpass = true;
                Admin();
            }
            else if (userinput== "n")
            {
                passnewwiz();
            }
        }
        static void Password()
        {
            Console.Clear();
            bool PassAgain = true;
            while (PassAgain)
            {
                string usercommand = PassInput();
                if (newpass == true)
                {
                    defaultpass = newpassword;
                }
                if (usercommand == defaultpass)
                {
                    if (adapt == true)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else if (adapt == false)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    PassAgain = false;
                    Console.WriteLine("Correct press any key to access admin menu");
                    Console.ReadKey();
                    Admin();
                }
                else
                {
                    if (adapt == true)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else if (adapt == false)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.WriteLine("Incorrect!!!!");
                    Console.WriteLine("Try Again");
                    Console.ReadKey();
                    PassAgain = true;
                }
            }
        }
        //Main Menu Method
        static void Menu()
        {
            Console.Clear();
            if (adapt == true)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (adapt == false)
            {
                Console.BackgroundColor= ConsoleColor.Black;
                Console.ForegroundColor= ConsoleColor.Red;
            }
            Console.WriteLine("POS System");
            Console.WriteLine("Main Menu");
            if (adapt == true)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (adapt == false)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("Your total takings for today are " + saleTotal + " so far");
            Console.WriteLine();
            if (adapt == true)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (adapt == false)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine("1: Admin Menu");
            Console.WriteLine("2: Create A Sale");
            Console.WriteLine("3: Exit");
            
            
            bool askagain = true;
            
            while (askagain)
            {
                string usercommand = GetInput();
                if (usercommand == "1")
                {
                    askagain = false;
                    Password();
                }
                else if (usercommand == "2")
                {
                    askagain = false;
                    Sale(true);
                }
                else if (usercommand == "3")
                {
                    askagain = false;
                    Exit();
                }
            }

        }
        //Add item method
        static void displayitems()
        {
            Console.WriteLine();
            if (productList.Count > 0)
            {
                foreach (Product item in productList)
                {
                    Console.WriteLine($"Product ID: {item.Id} - Product Name: {item.Name} - Product Price: {item.Price}.");
                }
            }
        }
        static public void Admin()
        {
            Console.Clear();
            if (adapt == true)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (adapt == false)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("POS System");
            Console.WriteLine("Admin Menu");
            Console.WriteLine();
            if (adapt == true)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (adapt == false)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }

            displayitems();
            Console.WriteLine();
            Console.WriteLine();
            if (adapt == true)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (adapt == false)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine("1: Add Products");
            Console.WriteLine("2: Change Password");
            Console.WriteLine("3: Accesibility Mode");
            Console.WriteLine("4: Main Menu");

            bool askagain = true;

            while (askagain)
            {

                string usercommand = GetInput();
                if (usercommand == "1")
                {
                    askagain = false;
                    AddProducts();
                    
                }
                else if (usercommand == "2")
                {
                    askagain = false;
                    passnewwiz();
                }
                else if (usercommand == "3")
                {
                    askagain=false;
                    Access();
                }
                else if (usercommand == "4")
                {
                    askagain = false;
                    Menu();
                }
            }
        }
        static void anotherprod()
        {
            
            string input = Console.ReadLine();
            Console.WriteLine("If you wish to ad more items press 'y' otherwise press 'n' to return to the admin menu!!!");
            if (input == "y")
            {
                AddProducts();
            }
            else if (input == "n")
            {
                Admin();
            }
        }
        static void AddProducts()
        {
            Console.Clear();
            var product = new Product();
            Console.WriteLine("Enter a Product ID: ");
            product.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a Product Name: ");
            product.Name = Console.ReadLine();
            Console.WriteLine("Enter a Product Price: ");
            product.Price = Convert.ToDecimal(Console.ReadLine());
            productList.Add(product);
            Console.WriteLine("If you wish to ad more items press 'y' otherwise press 'n' to return to the admin menu!!!");
            anotherprod();

        }
        //Sales menu allowing for selection of products
        static void Sale(bool NewSale = false)
        {
            if (NewSale)
            { 
                basketlist = new List<Basket>();
            }
            Console.Clear();
            if (adapt == true)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (adapt == false)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("POS System");
            Console.WriteLine("Start a Sale");
            Console.WriteLine();
            if (adapt == true)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (adapt == false)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }

            displayitems();
            Console.WriteLine();
            Console.WriteLine();
            if (adapt == true)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (adapt == false)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine("1: Begin New Sale");
            Console.WriteLine("2: Checkout");
            Console.WriteLine("3: Main Menu");
           

            bool askagain = true;
            while (askagain)
            {

                string usercommand = GetInput();
                if (usercommand == "1")
                {
                    askagain = false;
                    var basketitem = new Basket();
                    Console.WriteLine("Please enter the product Id you would like to purchase...");
                    basketitem.ProdID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter the quantity you would lke to purchase...");
                    basketitem.Quantity = Convert.ToInt32(Console.ReadLine());

                    var prodPrice = productList.Where(x => x.Id == basketitem.ProdID).FirstOrDefault().Price;

                    saleTotal += prodPrice * basketitem.Quantity;
                    
                    Sale();
                }
               
                else if (usercommand == "2")
                {
                    askagain = false;
                    EndSale();
                }
                else if (usercommand == "3")
                {
                    askagain = false;
                    Menu();
                }
            }
        }
        //End of sale method used when user types checkout and calculates final amount
        static void EndSale()
        {
            Console.Clear();
            if (adapt == true)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (adapt == false)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("POS System");
            Console.WriteLine("Checkout");
            Console.WriteLine();
            if (adapt == true)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (adapt == false)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            Console.WriteLine();
            var basketSum = 0.00M;
            Console.WriteLine("Here are the products you chose");
            foreach(Basket item in basketlist)
            {
                var product = productList.Where(x => x.Id == item.ProdID).FirstOrDefault();
                if (product != null)
                    Console.WriteLine($"Prod Id:{product.Id} - Product Name:{product.Name} - Price:{product.Price} - Qty:{item.Quantity} - LineTotal:{decimal.Round(product.Price * item.Quantity,2)}");
                basketSum += product.Price * item.Quantity;
            }   
            Console.WriteLine($"Your total is: {decimal.Round(basketSum,2)}");

            Console.WriteLine();
            Console.WriteLine();
            if (adapt == true)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (adapt == false)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine();
            Console.WriteLine("1: Return to main menu");
            Console.WriteLine("2: Exit Program");
            
            bool askagain = true;
            while (askagain)
            {
                string usercommand = GetInput();
                if (usercommand == "1")
                {
                    askagain = false;
                    Menu();
                }
                else if (usercommand == "2")
                {
                    askagain = false;
                    Exit();
                }
            }
        }
        
        //Exit the program
        static void Exit()
        {
            Console.Clear();
            if (adapt == true)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (adapt == false)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("Thank you for using my program");
            Console.WriteLine("Find more interesting projects at my GitHub Repository: bit.ly/2YDCMYQ ");
            Console.WriteLine();
            Console.WriteLine("Program Developed by Jordan W Sparkes");
            Console.WriteLine("Program Developed using Visual Studio 2022 Proffesional Edition");
            Console.WriteLine();
            Console.WriteLine();
            if (adapt == true)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (adapt == false)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}








