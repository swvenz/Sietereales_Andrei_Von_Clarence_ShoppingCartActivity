using System;
using System.Collections.Generic;

class Product
{
    public int ID;
    public string Name;
    public string Author;
    public double Price;
    public int RemainingStock;

    public void DisplayProduct()
    {
        Console.WriteLine($"Book ID: {ID}, Title: {Name}");
        Console.WriteLine($"Price: ${Price}, Remaining Stock: {RemainingStock}");
    }

    public void HasEnoughStock()
    {
        if (RemainingStock > 20)
        {
            Console.WriteLine("Books have sufficient stock.");
        }
        else
        {
            Console.WriteLine("Book stock is currently low.");
        }
    }
}

class Cart
{
    public Product Item;
    public int Quantity;
    public double TotalPrice()
    {
        return Item.Price * Quantity;
    }
}


namespace ShoppingCart
{
    class Program
    {
        static void Main()
        {
            int loop = 0;
            while (loop >= 0)
            {
                Product[] books = new Product[]
                {
                        new Product { ID = 1, Name = "Beastars (Paperback)", Price = 585, RemainingStock = 45},
                        new Product { ID = 2, Name = "Fool Night (Paperback)", Price = 540, RemainingStock = 43},
                        new Product { ID = 3, Name = "Choujin X (Paperback)", Price = 550, RemainingStock = 47},
                        new Product { ID = 4, Name = "After God (Paperback)", Price = 580, RemainingStock = 50},
                        new Product { ID = 5, Name = "PPPPPP (Paperback)", Price = 520, RemainingStock = 35},
                        new Product { ID = 6, Name = "Soul Eater (Paperback)", Price = 600, RemainingStock = 39 },
                        new Product { ID = 7, Name = "Delicious in Dungeon (Paperback)", Price = 550, RemainingStock = 40 },
                        new Product { ID = 8, Name = "Sentenced to Be a Hero: The Prison Records of Penal Hero Unit 9004 (Light Novel)", Price = 670, RemainingStock = 50 },
                        new Product { ID = 9, Name = "86: Eighty Six (Light Novel)", Price = 640, RemainingStock = 45 },
                        new Product { ID = 10, Name = "Umamusume: Cinderalla Gray (Paperback)", Price = 530, RemainingStock = 40 },
                        new Product { ID = 11, Name = "Gachiakuta (Paperback)", Price = 520.25, RemainingStock = 40 },
                        new Product { ID = 12, Name = "Albus Changes The World (Paperback)", Price = 537, RemainingStock = 49 },
                        new Product { ID = 13, Name = "Go! Go! Loser Ranger! (Paperback)", Price = 530, RemainingStock = 40 },
                        new Product { ID = 14, Name = "Blue Lock (Paperback)", Price = 575, RemainingStock = 53 },
                        new Product { ID = 15, Name = "Chainsaw Man (Paperback)", Price = 554, RemainingStock = 45 },
                        new Product { ID = 16, Name = "Clevatess: The King of Magical Beasts, the Baby, and the Corpse Hero (Paperback)", Price = 524, RemainingStock = 35 },
                        new Product { ID = 17, Name = "Gleipnir (Paperback)", Price = 490, RemainingStock = 30 },
                        new Product { ID = 18, Name = "Kaiju No. 8 (Paperback)", Price = 540, RemainingStock = 45 },
                        new Product { ID = 19, Name = "Goodnight Punpun (Paperback)", Price = 600, RemainingStock = 31 },
                        new Product { ID = 20, Name = "Berserk (Omnibus)", Price = 650, RemainingStock = 37 },
                        new Product { ID = 21, Name = "Tokyo Ghoul (Paperback)", Price = 540.60, RemainingStock = 45 },
                        new Product { ID = 22, Name = "Tokyo Ghoul:re (Paperback)", Price = 554.25, RemainingStock = 47 },
                        new Product { ID = 23, Name = "The Promised Neverland (Paperback)", Price = 567.25, RemainingStock = 40 },
                        new Product { ID = 24, Name = "Orb: On the Movements of the Earth (Paperback)", Price = 590, RemainingStock = 40 },
                        new Product { ID = 25, Name = "The Ancient Magus' Bride (Paperback)", Price = 580, RemainingStock = 40 },
                };

                Console.WriteLine("----------SHOSEKI ARCHIVES----------");
                Console.WriteLine("1 - Browse");
                Console.WriteLine("2 - Shop Cart");
                Console.WriteLine("3 - Exit");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();
                int choice;
                int.TryParse(option, out choice);
                Console.WriteLine();

                switch (choice)
                {
                    //BROWSE option shows the available books with their details such as price and remaining stock.
                    case 1:
                        Console.WriteLine("----------BROWSING AVAILABLE BOOKS----------");

                        foreach (var book in books)
                        {
                            book.DisplayProduct();
                            book.HasEnoughStock();
                            Console.WriteLine();
                        }
                        break;
   
                    //SHOP CART option allows the user to add books to their cart.
                    case 2:
                        Console.WriteLine("----------SHOP CART----------");

                        //Ask the user how many books they want to add to their cart.
                        int fixedamount;
                        while (true)
                        {
                            Console.Write("How many books do you want to add?: ");
                            string fixedbook = Console.ReadLine();
                            if (int.TryParse(fixedbook, out fixedamount) && fixedamount > 0)
                            {          
                                break;
                            }

                            //If the number is invalid
                            Console.WriteLine("Invalid input. Enter a real number.\n");
                        }

                        //Array Cart with the size of the amount of books the user wants to add to their cart.
                        Cart[] fixedCart = new Cart[fixedamount];
                        int fixeditem = 0;

                        while (fixeditem < fixedamount)
                        {
                            Console.Write("Enter the ID of the book: ");
                            string bookID = Console.ReadLine();
                            int productID;
                            if (!int.TryParse(bookID, out productID))
                            {
                                Console.WriteLine("Invalid input. Enter a valid book ID.");
                                continue;
                            }

                            //Find the product with the given ID
                            Product selectbook = null;
                            foreach (var book in books)
                            {
                                if (book.ID == productID)
                                {
                                    selectbook = book;
                                }
                            }

                            //If the product with the given ID is not found
                            if (selectbook == null)
                            {
                                Console.WriteLine("Book ID does not match with any book. Choose a valid book ID.");
                                continue;
                            }

                            //Ask the user for the quantity of the book they want to add to their cart.
                            int quantitybook;
                            while (true)
                            {
                                Console.Write($"Enter the quantity for '{selectbook.Name}': ");
                                string bookquantity = Console.ReadLine();
                                if (!int.TryParse(bookquantity, out quantitybook) || quantitybook <= 0)
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid quantity.");
                                    continue;
                                }

                                if (quantitybook > selectbook.RemainingStock)
                                {
                                    Console.WriteLine($"Only {selectbook.RemainingStock} copies of '{selectbook.Name}' are available.");
                                    continue;
                                }
                                break;
                            }

                            //Add book to spree cart
                            //Checks if the Book already exists in the cart
                            Cart FixedBookinCart = null;
                            foreach (var item in fixedCart)
                            {
                                if (item != null && item.Item.ID == selectbook.ID)
                                {
                                    FixedBookinCart = item;
                                    break;
                                }
                            }

                            //Add quantity to existing Book in the cart
                            if (FixedBookinCart != null)
                            {

                                FixedBookinCart.Quantity += quantitybook;
                            }

                            //Add new Book to cart if there is no existing Book in the cart
                            else
                            {
                                for (int i = 0; i < fixedCart.Length; i++)
                                {
                                    if (fixedCart[i] == null)
                                    {
                                        fixedCart[i] = new Cart
                                        {
                                            Item = selectbook,
                                            Quantity = quantitybook,
                                        };
                                        break;
                                    }
                                }
                            }

                            //Reduce the stock of the book
                            selectbook.RemainingStock -= quantitybook;
                            Console.WriteLine($"Added {quantitybook}x copies of '{selectbook.Name}' to the cart.");

                            //Show the progress of adding books to the cart
                            fixeditem++;
                            Console.WriteLine($"Book: {fixeditem}/{fixedamount}\n");

                            if (fixeditem == fixedamount)
                            {
                                Console.WriteLine("Cart is full.\n");
                                Console.WriteLine("Proceeding to checkout...");
                            }

                        }

                        // Proceed to checkout only after cart is full
                        double totalPriceFixed = 0;
                        Console.WriteLine("\nYour Cart:");
                        Console.WriteLine();
                        Console.WriteLine("-----RECEIPT-----");
                        foreach (var item in fixedCart)
                        {
                            if (item == null) continue;
                            double totalitem = item.Item.Price * item.Quantity;
                            totalPriceFixed += totalitem;
                            Console.WriteLine($"{item.Quantity}x {item.Item.Name} {item.Item.Price} = ${totalitem}");
                        }

                        // Applies a 10% discount if the total price of the cart is 5000 or more.
                        if (totalPriceFixed >= 5000)
                        {
                            Console.WriteLine($"\nTotal Price: ${totalPriceFixed}");
                            Console.WriteLine("Congratulations! You have received a 10% discount for spending $5000 or more.");

                            double discountfixed = totalPriceFixed * 0.10;
                            double discountedPricefixed = totalPriceFixed - discountfixed;

                            Console.WriteLine($"\nDiscount: ${discountfixed}");
                            Console.WriteLine($"Discounted Price: ${discountedPricefixed}");
                        }

                        else
                        {
                            Console.WriteLine($"Total Price: ${totalPriceFixed}");
                        }

                        //Update the stock of the books after checkout and shows the remaining stock of each book.
                        Console.WriteLine("\nUpdated Stock of Books");
                        foreach (var book in books)
                        {
                            Console.WriteLine($"Book ID: {book.ID}, Title: {book.Name}, Remaining Stock: {book.RemainingStock}");
                        }

                        //Ask the user if they want to continue shopping or exit the program after checkout.
                        while (true)
                        {
                            Console.Write("\nContinue shopping? (Y/N): ");
                            string answer = Console.ReadLine();

                            if (answer == "Y" || answer == "y")
                            {
                                Console.WriteLine();
                                break;
                            }

                            else if (answer == "N" || answer == "n")
                            {
                                Console.WriteLine("Thank you. Come Again!");
                                loop = -1;
                                break;
                            }

                            else
                            {
                                Console.WriteLine("Invalid input. Only choose between 'Y' or 'N'.");
                                continue;
                            }
                        }
                        break;

                    //Exits the program
                    case 3:
                        Console.WriteLine("Come Again!");
                        loop = -1;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        break;
                }
            }
        }
    }

}