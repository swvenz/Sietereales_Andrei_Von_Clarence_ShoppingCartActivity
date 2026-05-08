using System;
using System.Collections.Generic;

class Product
{
    public int ID;
    public string Name;
    public string Category;
    public string Genre;
    public double Price;
    public int RemainingStock;

    public void DisplayProduct()
    {
        Console.WriteLine($"Book ID: {ID}, Title: {Name}");
        Console.WriteLine($"Price: ${Price}, Remaining Stock: {RemainingStock}");
    }

    public void DisplayProductFull()
    {
        Console.WriteLine($"Book ID: {ID}, Title: {Name}");
        Console.WriteLine($"Price: ${Price}, Remaining Stock: {RemainingStock}");
        Console.WriteLine($"Category: {Category}, Genre: {Genre}");
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

    //Product Search 
    public static void BookSearch(Product[] books)
    {
        Console.Write("Search Name: ");
        string searchBook = Console.ReadLine().ToLower();
        Console.WriteLine();

        bool found = false;
        foreach (var book in books)
        {
            if (book.Name.ToLower().Contains(searchBook))
            {
                book.DisplayProduct();
                found = true;
                Console.WriteLine();
            }
        }

        if (!found)
        {
            Console.WriteLine("No books found.");
        }
    }

    //Category Search
    public static void CategorySearch(Product[] books)
    {
        Console.WriteLine("Category: Fiction");
        Console.WriteLine("Category: Non-Fiction");
        Console.Write("Choose Category: ");
        string searchCategory = Console.ReadLine().ToLower();
        Console.WriteLine();

        bool found = false;
        foreach (var book in books)
        {
            if (book.Category.ToLower() == searchCategory)
            {
                found = true;
                // Display the book for non-fiction or fiction (before genre filter)
                if (searchCategory != "fiction")
                {
                    book.DisplayProduct();
                    Console.WriteLine();
                }
            }
        }

        if (!found)
        {
            Console.WriteLine("Category not found.");
            return;
        }

        //If the user chooses fiction, they can also search for the genre of the book.
        if (searchCategory == "fiction")
        {
            Console.Write("Search Genre: ");
            string searchGenre = Console.ReadLine().ToLower();
            Console.WriteLine();

            bool Genrefound = false;
            foreach (var book in books)
            {
                //For now, nakalagay lang yung book.Genre != null kasi uunahin ko muna lahat nung quiz requirement bago ko ayusin yung genre update.
                if (book.Category.ToLower() == "fiction" && book.Genre != null)
                {
                    //this .Split()...
                    string[] genres = book.Genre.ToLower().Split(',');

                    foreach (var genre in genres)
                    {
                        //...and .Trim() are both life savers 'cuz I was having a hard time splitting the genres.
                        if (genre.Trim() == searchGenre)
                        {
                            book.DisplayProductFull();
                            Console.WriteLine();
                            Genrefound = true;
                            break;
                        }
                    }
                }
            }

            if (!Genrefound)
            {
                Console.WriteLine("Genre not found.");
            }
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

class TransactionHistory
{
    public int ReceiptNo;
    public double PreviousPrice;
}

namespace ShoppingCart
{
    class Program
    {
        static void Main()
        {
            int receiptNumber = 1;
            TransactionHistory[] history = new TransactionHistory[101];
            int historyIndex = 0;

            int loop = 0;
            while (loop >= 0)
            {
                Product[] books = new Product[]
                {
                    //FICTION
                        //Manga
                        new Product { ID = 1, Name = "Umamusume: Cinderalla Gray (Paperback)", Price = 530, RemainingStock = 40, Category = "Fiction", Genre = "Drama, Slice of Life, Sports" },
                        new Product { ID = 2, Name = "Umamusume: Pretty Derby - Star Blossom (Paperback)", Price = 530, RemainingStock = 40, Category = "Fiction", Genre = "Sports" },
                        new Product { ID = 3, Name = "Beastars (Paperback)", Price = 585, RemainingStock = 45, Category = "Fiction", Genre = "Drama, Slice of Life, Romance, Dark Fantasy, Suspense, Mystery" },
                        new Product { ID = 4, Name = "Fool Night (Paperback)", Price = 540, RemainingStock = 43, Category = "Fiction", Genre = "Drama, Dark Fantasy, Suspense, Mystery, Thriller" },
                        new Product { ID = 5, Name = "Choujin X (Paperback)", Price = 550, RemainingStock = 47, Category = "Fiction", Genre = "Action, Supernatural, Dark Fantasy, Thriller, Psychological" },
                        new Product { ID = 6, Name = "Delicious in Dungeon (Paperback)", Price = 550, RemainingStock = 40, Category = "Fiction", Genre = "Comedy, Fantasy, Gourmet"},
                        new Product { ID = 7, Name = "Soul Eater (Paperback)", Price = 600, RemainingStock = 39, Category = "Fiction", Genre = "Action, Supernatural, Dark Fantasy, Thriller, Psychological" },
                        new Product { ID = 8, Name = "The Ancient Magus' Bride (Paperback)", Price = 580, RemainingStock = 40, Category = "Fiction", Genre = "Fantasy, Romance, Supernatural" },
                        new Product { ID = 9, Name = "After God (Paperback)", Price = 580, RemainingStock = 50, Category = "Fiction", Genre = "Supernatural, Action, Mystery, Psychological, Thriller, Horror" },
                        new Product { ID = 10, Name = "PPPPPP (Paperback)", Price = 520, RemainingStock = 35, Category = "Fiction", Genre = "Music" },
                        new Product { ID = 11, Name = "Clevatess: The King of Magical Beasts, the Baby, and the Corpse Hero (Paperback)", Price = 524, RemainingStock = 35, Category = "Fiction", Genre = "Dark Fantasy, Action" },
                        new Product { ID = 12, Name = "Tokyo Ghoul (Paperback)", Price = 540.60, RemainingStock = 45, Category = "Fiction", Genre = "Dark Fantasy, Horror, Supernatural" },
                        new Product { ID = 13, Name = "Tokyo Ghoul:re (Paperback)", Price = 554.25, RemainingStock = 47, Category = "Fiction", Genre = "Dark Fantasy, Horror, Supernatural" },
                        new Product { ID = 14, Name = "Dorohedoro (Paperback)", Price = 550, RemainingStock = 60, Category = "Fiction", Genre = "Dark Fantasy, Action, Mystery" },
                        new Product { ID = 15, Name = "Made in Abyss (Paperback)", Price = 490, RemainingStock = 30, Category = "Fiction", Genre = "Adventure, Fantasy, Mystery" },

                        //Light Novel
                        new Product { ID = 16, Name = "Sentenced to Be a Hero: The Prison Records of Penal Hero Unit 9004 (Light Novel)", Price = 670, RemainingStock = 50, Category = "Fiction", Genre = "Dark Fantasy, Action, Mystery, Drama, Adventure" },
                        new Product { ID = 17, Name = "86: Eighty Six (Light Novel)", Price = 640, RemainingStock = 45, Category = "Fiction", Genre = "Science Fiction, Military, Drama"  },
                        new Product { ID = 18, Name = "ReZero, Re: Life in a different world from zero (Light Novel)", Price = 600, RemainingStock = 60, Category = "Fiction", Genre = "Fantasy, Adventure, Drama"  },
                        new Product { ID = 19, Name = "Bungou Stray Dogs (Light Novel)", Price = 630, RemainingStock = 66, Category = "Fiction", Genre = "Action, Mystery, Supernatural"  },
                        new Product { ID = 20, Name = "Baccano! (Light Novel)", Price = 580, RemainingStock = 50, Category = "Fiction", Genre = "Action, Supernatural, Mystery"  },
                        new Product { ID = 21, Name = "Fate/strange Fake (Light Novel)", Price = 618, RemainingStock = 55, Category = "Fiction", Genre = "Fantasy, Action, Drama"  },
                        new Product { ID = 22, Name = "Too Many Losing Heroines! (Light Novel)", Price = 580, RemainingStock = 55, Category = "Fiction", Genre = "Comedy, Romance"  },
                        new Product { ID = 23, Name = "No Game No Life (Light Novel)", Price = 585, RemainingStock = 57, Category = "Fiction", Genre = "Fantasy, Adventure, Comedy"  },
                        new Product { ID = 24, Name = "Grimoire Of Zero (Light Novel)", Price = 578, RemainingStock = 60, Category = "Fiction", Genre = "Fantasy, Adventure, Magic"  },
                        new Product { ID = 25, Name = "Konosuba: God's Blessing on This Wonderful World! (Light Novel)", Price = 570, RemainingStock = 60, Category = "Fiction", Genre = "Fantasy, Comedy, Adventure"  },
                        //Other Novel
                        new Product { ID = 26, Name = "The Shining ", Price = 690, RemainingStock = 50, Category = "Fiction", Genre = "Horror, Thriller"  },
                        new Product { ID = 27, Name = "Pet Sematary ", Price = 680, RemainingStock = 45, Category = "Fiction", Genre = "Horror, Supernatural"  },
                        new Product { ID = 28, Name = "Harry Potter and the Sorcerer's Stone", Price = 600, RemainingStock = 60, Category = "Fiction", Genre = "Fantasy, Adventure"  },
                        new Product { ID = 29, Name = "Lord of the Rings - Fellowship of the Ring", Price = 700, RemainingStock = 66, Category = "Fiction", Genre = "Fantasy, Adventure"  },
                        new Product { ID = 30, Name = "Lord of the Rings - The Two Towers", Price = 715, RemainingStock = 66, Category = "Fiction", Genre = "Fantasy, Adventure"  },
                        new Product { ID = 31, Name = "Lord of the Rings - The Return of the King", Price = 720, RemainingStock = 66, Category = "Fiction", Genre = "Fantasy, Adventure"  },
                        new Product { ID = 32, Name = "The Hobbit", Price = 705, RemainingStock = 66, Category = "Fiction", Genre = "Fantasy, Adventure"  },

                    //NON-FICTION
                        new Product { ID = 33, Name = "The Art of War", Price = 520.25, RemainingStock = 40, Category = "Non-Fiction" },
                        new Product { ID = 34, Name = "Wolfish: Wolf, Self, and the Stories We Tell About Fear ", Price = 537, RemainingStock = 49, Category = "Non-Fiction" },
                        new Product { ID = 35, Name = "The Merriam-Webster Dictionary", Price = 530, RemainingStock = 40, Category = "Non-Fiction" },
                        new Product { ID = 36, Name = "The Subtle Art of Not Giving a F*ck", Price = 575, RemainingStock = 53, Category = "Non-Fiction" },
                        new Product { ID = 37, Name = "A History of Western Philosophy", Price = 554, RemainingStock = 45, Category = "Non-Fiction" },
                };


                Console.WriteLine("----------SHOSEKI ARCHIVES----------");
                Console.WriteLine("1 - Browse");
                Console.WriteLine("2 - Shop Cart");
                Console.WriteLine("3 - Order History");
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
                        Console.WriteLine("----------BROWSE----------");
                        Console.WriteLine("1 - Show List");
                        Console.WriteLine("2 - Search Book");
                        Console.WriteLine("3 - Search Category");
                        Console.Write("Choose an option: ");
                        string browseoption = Console.ReadLine();
                        int browsechoice;
                        int.TryParse(browseoption, out browsechoice);
                        Console.WriteLine();

                        switch (browsechoice)
                        {
                            case 1:
                                Console.WriteLine("----------LIST OF AVAILABLE BOOKS----------");
                                foreach (var book in books)
                                {
                                    book.DisplayProduct();
                                    book.HasEnoughStock();
                                    Console.WriteLine();
                                }
                                break;

                            case 2:
                                Console.WriteLine("----------SEARCH BOOKS----------");
                                Product.BookSearch(books);
                                break;

                            case 3:
                                Console.WriteLine("----------SEARCH CATEGORY----------");
                                Product.CategorySearch(books);
                                break;
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
                                bool exitCartMenu = false;
                                while (!exitCartMenu)
                                {
                                    //Cart Management Menu
                                    Console.WriteLine("1 - View Cart");
                                    Console.WriteLine("2 - Remove Book");
                                    Console.WriteLine("3 - Update Book Quantity");
                                    Console.WriteLine("4 - Clear Cart ");
                                    Console.WriteLine("5 - Checkout");
                                    Console.Write("Choose an option: ");
                                    string optiontwo = Console.ReadLine();
                                    int choicetwo;
                                    int.TryParse(optiontwo, out choicetwo);
                                    Console.WriteLine();

                                    switch (choicetwo)
                                    {
                                        //View the books in the cart
                                        case 1:
                                            Console.WriteLine("Your Cart:");
                                            foreach (var item in fixedCart)
                                            {
                                                if (item != null)
                                                {
                                                    Console.WriteLine($"{item.Quantity}x || Book ID: {item.Item.ID} - {item.Item.Name} ${item.Item.Price} = ${item.TotalPrice()}");
                                                }
                                            }
                                            Console.WriteLine();
                                            break;

                                        //Remove a book from the cart 
                                        case 2:
                                            Console.Write("Enter the ID of the book you want to remove: ");
                                            string removeID = Console.ReadLine();
                                            int removeBookID;
                                            if (!int.TryParse(removeID, out removeBookID))
                                            {
                                                Console.WriteLine("Invalid input. Enter a valid book ID.");
                                                continue;
                                            }

                                            Cart bookToRemove = null;
                                            foreach (var item in fixedCart)
                                            {
                                                if (item != null && item.Item.ID == removeBookID)
                                                {
                                                    bookToRemove = item;
                                                    break;
                                                }
                                            }

                                            if (bookToRemove != null)
                                            {
                                                bookToRemove.Item.RemainingStock += bookToRemove.Quantity;
                                                for (int i = 0; i < fixedCart.Length; i++)
                                                {
                                                    if (fixedCart[i] == bookToRemove)
                                                    {
                                                        fixedCart[i] = null;
                                                        break;
                                                    }
                                                }
                                                Console.WriteLine($"Removed '{bookToRemove.Item.Name}' from the cart.\n");
                                            }

                                            else
                                            {
                                                Console.WriteLine("Book ID not found in the cart.\n");
                                            }

                                            break;

                                        //Allows the user to update the quantity of a book in the cart
                                        case 3:
                                            Console.Write("Enter the ID of the book you want to update: ");

                                            if (!int.TryParse(Console.ReadLine(), out int updateBookID))
                                            {
                                                Console.WriteLine("Invalid input. Enter a valid number.\n");
                                                break;
                                            }

                                            bool found = false;

                                            foreach (var item in fixedCart)
                                            {
                                                if (item != null && item.Item.ID == updateBookID)
                                                {
                                                    int newbookQTY;
                                                    while (true)
                                                    {
                                                        Console.Write($"Enter new quantity for '{item.Item.Name}': ");
                                                        if (!int.TryParse(Console.ReadLine(), out newbookQTY) || newbookQTY <= 0)
                                                        {
                                                            Console.WriteLine("Invalid quantity.\n");
                                                            continue;
                                                        }

                                                        // Check if enough stock is available (old quantity already deducted)
                                                        int availableStock = item.Item.RemainingStock + item.Quantity;
                                                        if (newbookQTY > availableStock)
                                                        {
                                                            Console.WriteLine($"Only {availableStock} copies available (including the {item.Quantity} already in cart).");
                                                            continue;
                                                        }
                                                        break;
                                                    }

                                                    // Adjust stock based on difference
                                                    int diff = newbookQTY - item.Quantity;
                                                    item.Item.RemainingStock -= diff;

                                                    item.Quantity = newbookQTY;
                                                    Console.WriteLine("Quantity updated.\n");

                                                    found = true;
                                                    break;
                                                }
                                            }

                                            if (!found)
                                            {
                                                Console.WriteLine("Book ID not found in cart.\n");
                                            }
                                            break;

                                        //Clears the cart fully
                                        case 4:

                                            Console.Write("Are you sure you want to empty the cart? (Y/N): ");
                                            string precaution = Console.ReadLine();

                                            if (precaution == "Y" || precaution == "y")
                                            {
                                                for (int i = 0; i < fixedCart.Length; i++)
                                                {
                                                    if (fixedCart[i] != null)
                                                    {
                                                        fixedCart[i].Item.RemainingStock += fixedCart[i].Quantity;
                                                        fixedCart[i] = null;
                                                    }
                                                }
                                                Console.WriteLine("Cart has been emptied.\n");
                                            }
                                            else if (precaution == "N" || precaution == "n")
                                            {
                                                Console.WriteLine();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid input. Only choose between 'Y' or 'N'.\n");
                                                continue;
                                            }
                                            break;

                                        case 5:
                                            // Proceed to checkout only after cart is full
                                            double grandTotal = 0;

                                            Console.WriteLine("\nYour Cart:");
                                            Console.WriteLine();
                                            Console.WriteLine("-----RECEIPT-----");

                                            foreach (var item in fixedCart)
                                            {
                                                if (item == null) continue;

                                                double totalitem = item.Item.Price * item.Quantity;
                                                grandTotal += totalitem;

                                                Console.WriteLine($"{item.Quantity}x {item.Item.Name} ${item.Item.Price} = ${totalitem}");
                                            }

                                            Console.WriteLine($"Grand Total: ${grandTotal}");

                                            // Applies a 10% discount if the total price of the cart is 5000 or more.
                                            double finalPrice;
                                            double discount = 0;

                                            if (grandTotal >= 5000)
                                            {
                                                discount = grandTotal * 0.10;
                                                finalPrice = grandTotal - discount;

                                                Console.WriteLine($"\nTotal Price: ${grandTotal}");
                                                Console.WriteLine($"Discount: ${discount}");
                                                Console.WriteLine($"Discounted Price: ${finalPrice}");
                                            }
                                            else
                                            {
                                                finalPrice = grandTotal;
                                                Console.WriteLine($"Total Price: ${grandTotal}");
                                            }

                                            //Checkout Payment Validation
                                            double payment;
                                            while (true)
                                            {
                                                Console.WriteLine();
                                                Console.Write("Enter payment amount: ");
                                                if (!double.TryParse(Console.ReadLine(), out payment) || payment <= 0)
                                                {
                                                    Console.WriteLine("Invalid payment. Enter a valid amount.");
                                                    continue;
                                                }

                                                if (payment < finalPrice)
                                                {
                                                    Console.WriteLine($"Insufficient payment.");
                                                    continue;
                                                }

                                                break;
                                            }

                                            //Use the final price of total books bought. If the total price is 5000 or more, the final price will be the discounted price. If not, the final price will just be the total price.
                                            double change = payment - finalPrice;

                                            //Shows the current date and time.
                                            DateTime current = DateTime.Now;

                                            //Final Receipt
                                            Console.WriteLine("\n----- PAYMENT RECEIPT -----");
                                            Console.WriteLine($"Receipt No: {receiptNumber}");
                                            Console.WriteLine($"Date: {current}");

                                            Console.WriteLine("Purchased Items:");
                                            foreach (var item in fixedCart)
                                            {
                                                if (item == null) continue;
                                                double totalitem = item.Item.Price * item.Quantity;
                                                Console.WriteLine($"{item.Quantity}x {item.Item.Name} ${item.Item.Price} = ${totalitem}");
                                            }

                                            Console.WriteLine($"Grand Total: ${grandTotal}");
                                            Console.WriteLine($"Discount: ${discount}");
                                            Console.WriteLine($"Final Total: ${finalPrice}");
                                            Console.WriteLine($"Paid: ${payment}");
                                            Console.WriteLine($"Change: ${change}");
                                            Console.WriteLine("Payment Successful. Thank you for shopping at Shoseki Archives!");

                                            //Makes a more ascending order of the receipt number.
                                            if (receiptNumber > 101)
                                            {
                                                receiptNumber = 1;
                                            }

                                            //Makes a more ascending order of the receipt number.
                                            if (historyIndex < history.Length)
                                            {
                                                history[historyIndex] = new TransactionHistory
                                                {
                                                    ReceiptNo = receiptNumber,
                                                    PreviousPrice = finalPrice
                                                };

                                                historyIndex++;
                                            }

                                            receiptNumber++;

                                            //Update the stock of the books after checkout and shows the remaining stock of each book.
                                            Console.WriteLine("\nUpdated Stock of Books");
                                            foreach (var book in books)
                                            {
                                                Console.WriteLine($"Book ID: {book.ID}, Title: {book.Name}, Remaining Stock: {book.RemainingStock}");
                                            }

                                            foreach (var book in books)
                                            {
                                                if (book.RemainingStock <= 5)
                                                {
                                                    Console.WriteLine();
                                                    Console.WriteLine("LOW STOCK ALERT");
                                                    Console.WriteLine($"{book.Name} has only {book.RemainingStock} remaining. Restock needed");
                                                }
                                            }

                                            // Clear the cart after successful checkout
                                            for (int i = 0; i < fixedCart.Length; i++)
                                            {
                                                fixedCart[i] = null;
                                            }

                                            ///Ask the user if they want to continue shopping or exit the program after checkout.
                                            while (true)
                                            {
                                                Console.Write("\nContinue shopping? (Y/N): ");
                                                string answer = Console.ReadLine();

                                                if (answer == "Y" || answer == "y")
                                                {
                                                    Console.WriteLine();
                                                    exitCartMenu = true;
                                                    break;
                                                }
                                                else if (answer == "N" || answer == "n")
                                                {
                                                    Console.WriteLine("Thank you. Come Again!");
                                                    Environment.Exit(0);
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid input. Only choose between 'Y' or 'N'.");
                                                    continue;
                                                }
                                            }
                                            break;

                                        default:
                                            Console.WriteLine("Invalid input. Please enter a valid option.\n");
                                            break;
                                    }
                                }
                            }
                        }
                        break;

                    //Shows order history of previous transactions
                    case 3:
                        Console.WriteLine("----- ORDER HISTORY -----");

                        if (historyIndex == 0)
                        {
                            Console.WriteLine("No transactions yet.\n");
                            break;
                        }

                        for (int i = 0; i < historyIndex; i++)
                        {
                            Console.WriteLine($"Receipt #{history[i].ReceiptNo:0000} - Final Total: PHP {history[i].PreviousPrice}\n");
                        }
                        break;

                    //Exits the program
                    case 4:
                        Console.WriteLine("Come Again!");
                        loop = -1;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.\n");
                        break;
                }
            }
        }
    }
}