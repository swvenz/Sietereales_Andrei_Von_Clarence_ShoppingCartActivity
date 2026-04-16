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
                Console.WriteLine("2 - Spree Cart");
                Console.WriteLine("3 - Fixed Cart");
                Console.WriteLine("4 - Exit");
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

                    //SPREE CART option allows the user to infinitily add products to their cart. 
                    case 2:
                        Console.WriteLine("----------SPREE CART----------");

                        List<Cart> spreeCart = new List<Cart>();
                        while (true)
                        {
                            Console.Write("Enter the ID of the book (or type '0' to finish): ");
                            string bookID = Console.ReadLine();
                            int productID;
                            if (!int.TryParse(bookID, out productID))
                            {
                                Console.WriteLine("Invalid input. Enter a valid book ID.");
                                continue;
                            }

                            if (productID == 0)
                            {
                                Console.WriteLine("Proceeding to checkout...");
                                break;
                            }

                            // Find the product with the given ID
                            Product selectbook = null;
                            foreach (var book in books)
                            {
                                if (book.ID == productID)
                                {
                                    selectbook = book;
                                }
                            }

                            if (selectbook == null)
                            {
                                Console.WriteLine("Book ID does not match with any book. Choose a valid book ID.");
                                continue;
                            }

                            int quantitybook;
                            while (true)
                            {
                                // Quantity of the book to add to the cart
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

                            //Add to cart
                            Cart cartItem = new Cart { Item = selectbook, Quantity = quantitybook };
                            spreeCart.Add(cartItem);

                            //Reduce the stock of the book
                            selectbook.RemainingStock -= quantitybook;
                            Console.WriteLine($"Added {quantitybook}x copies of '{selectbook.Name}' to the cart.");
                            Console.WriteLine();
                        }
                        //Shows the total price of the cart after each addition.
                        double totalPrice = 0;
                        Console.WriteLine("\nYour Spree Cart:");
                        Console.WriteLine();
                        Console.WriteLine("-----RECEIPT-----");
                        foreach (var item in spreeCart)
                        {
                            double totalitem = item.Item.Price * item.Quantity;
                            totalPrice += totalitem;
                            Console.WriteLine($"{item.Quantity}x {item.Item.Name} {item.Item.Price} = ${totalitem}");
                        }

                        // Applies a 10% discount if the total price of the cart is 5000 or more.
                        if (totalPrice >= 5000)
                        {
                            Console.WriteLine($"\nTotal Price: ${totalPrice}");
                            Console.WriteLine("Congratulations! You have received a 10% discount for spending $5000 above.");

                            double discount = totalPrice * 0.10;
                            double discountedPrice = totalPrice - discount;

                            Console.WriteLine($"\nDiscount: ${discount}");
                            Console.WriteLine($"Discounted Price: ${discountedPrice}");
                        }

                        else
                        {
                            Console.WriteLine($"Total Price: ${totalPrice}");
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
                            Console.Write("\nContinue shopping? ( y / n ): ");
                            string answer = Console.ReadLine();

                            if (answer == "y")
                            {
                                Console.WriteLine();
                                break;
                            }

                            else if (answer == "n")
                            {
                                Console.WriteLine("Thank you! Come Again!");
                                loop = -1;
                                break;
                            }

                            else
                            {
                                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                                continue;
                            }
                        }
                        break;

                    //FIXED CART option allows the user to add a fixed amount of products to their cart.
                    case 3:
                        Console.WriteLine("----------FIXED CART----------");
                        Console.Write("How many books do you want to add?: ");
                        string fixedbook = Console.ReadLine();
                        int fixedamount;
                        if (!int.TryParse(fixedbook, out fixedamount) || fixedamount <= 0)
                        {
                            Console.WriteLine("Invalid input. Enter a real number.");
                            break;
                        }

                        List<Cart> fixedCart = new List<Cart>();
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

                            // Find the product with the given ID
                            Product selectbook = null;
                            foreach (var book in books)
                            {
                                if (book.ID == productID)
                                {
                                    selectbook = book;
                                }
                            }

                            if (selectbook == null)
                            {
                                Console.WriteLine("Book ID does not match with any book. Choose a valid book ID.");
                                continue;
                            }

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

                            // Add to cart
                            Cart cartItem = new Cart { Item = selectbook, Quantity = quantitybook };
                            fixedCart.Add(cartItem);

                            // Reduce stock
                            selectbook.RemainingStock -= quantitybook;
                            Console.WriteLine($"Added {quantitybook}x copies of '{selectbook.Name}' to the cart.");

                            //Show the progress of adding books to the cart
                            fixeditem++;
                            Console.WriteLine($"Book: {fixeditem}/{fixedamount}");
                            Console.WriteLine();
                        }

                        // Proceed to checkout only after cart is full
                        double totalPriceFixed = 0;
                        Console.WriteLine("\nYour Fixed Cart:");
                        Console.WriteLine();
                        Console.WriteLine("-----RECEIPT-----");
                        foreach (var item in fixedCart)
                        {
                            double totalitem = item.Item.Price * item.Quantity;
                            totalPriceFixed += totalitem;
                            Console.WriteLine($"{item.Quantity}x {item.Item.Name} {item.Item.Price} = ${totalitem}");
                        }

                        // Applies a 10% discount if the total price of the cart is 5000 or more.
                        if (totalPriceFixed >= 5000)
                        {
                            Console.WriteLine($"\nTotal Price: ${totalPriceFixed}");
                            Console.WriteLine("Congratulations! You have received a 10% discount for spending $5000 above.");

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
                            Console.Write("\nContinue shopping? ( y / n ): ");
                            string answer = Console.ReadLine();

                            if (answer == "y")
                            {
                                Console.WriteLine();
                                break;
                            }

                            else if (answer == "n")
                            {
                                Console.WriteLine("Thank you. Come Again!");
                                loop = -1;
                            }

                            else
                            {
                                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                                continue;
                            }
                        }
                        break;

                    //Exits the program
                    case 4:
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