using System;
using Model;
using System.Collections.Generic;

namespace View
{
    public class ViewHTML
    {

        public void BooksHTML(IList<Book> books, Customer customer) {
            PrintHeader(customer);
            Print_books_table(books);
            PrintFooter();
        }

        public void BookDetailHTML(Book book, Customer customer){
            PrintHeader(customer);
            PrintBookDetail(book);
            PrintFooter();
        }

        public void CartContentsHTML(Customer customer, ModelStore store){
            PrintHeader(customer);
            PrintCartContent(customer, store);
            PrintFooter();
        }

        public void InvalidHTML(){
            Console.WriteLine("<!DOCTYPE html>");
            Console.WriteLine("<html lang=\"en\" xmlns=\"http://www.w3.org/1999/xhtml\">");
            Console.WriteLine("<head>");
            Console.WriteLine("\t<meta charset=\"utf-8\" />");
            Console.WriteLine("\t<title>Nezarka.net: Online Shopping for Books</title>");
            Console.WriteLine("</head>");
            Console.WriteLine("<body>");
            Console.WriteLine("<p>Invalid request.</p>");
            Console.WriteLine("</body>");
            Console.WriteLine("</html>");
            Console.WriteLine("====");
        }

        void PrintCartContent(Customer customer, ModelStore store){
            var cart = customer.ShoppingCart;

            if (cart.Items.Count != 0){
                Console.WriteLine("\tYour shopping cart:");
                Console.WriteLine("\t<table>");
                Console.WriteLine("\t\t<tr>");
                Console.WriteLine("\t\t\t<th>Title</th>");
                Console.WriteLine("\t\t\t<th>Count</th>");
                Console.WriteLine("\t\t\t<th>Price</th>");
                Console.WriteLine("\t\t\t<th>Actions</th>");
                Console.WriteLine("\t\t</tr>");

                decimal totalPrice = 0;
                foreach (var item in cart.Items){
                    var book = store.GetBook(item.BookId);
                    totalPrice += item.Count*book.Price;
                    string formula;

                    if (item.Count > 1) formula = $"{item.Count} * {book.Price} = {item.Count * book.Price}";
                    else formula = $"{book.Price}";

                    Console.WriteLine("\t\t<tr>");
                    Console.WriteLine($"\t\t\t<td><a href=\"/Books/Detail/{book.Id}\">{book.Title}</a></td>");
                    Console.WriteLine($"\t\t\t<td>{item.Count}</td>");
                    Console.WriteLine($"\t\t\t<td>{formula} EUR</td>");
                    Console.WriteLine($"\t\t\t<td>&lt;<a href=\"/ShoppingCart/Remove/{book.Id}\">Remove</a>&gt;</td>");
                    Console.WriteLine("\t\t</tr>");
                }
                Console.WriteLine("\t</table>");
                Console.WriteLine($"\tTotal price of all items: {cart.GetTotal(store)} EUR");
            }
            else {
                Console.WriteLine("\tYour shopping cart is EMPTY.");
            }
        }

        void PrintBookDetail(Book book){
            Console.WriteLine("\tBook details:");
            Console.WriteLine($"\t<h2>{book.Title}</h2>");
            Console.WriteLine("\t<p style=\"margin-left: 20px\">");
            Console.WriteLine($"\tAuthor: {book.Author}<br />");
            Console.WriteLine($"\tPrice: {book.Price} EUR<br />");
            Console.WriteLine("\t</p>");
            Console.WriteLine($"\t<h3>&lt;<a href=\"/ShoppingCart/Add/{book.Id}\">Buy this book</a>&gt;</h3>");
        }

        void PrintHeader(Customer customer){
            Console.WriteLine("<!DOCTYPE html>");
            Console.WriteLine("<html lang=\"en\" xmlns=\"http://www.w3.org/1999/xhtml\">");
            Console.WriteLine("<head>");
            Console.WriteLine("\t<meta charset=\"utf-8\" />");
            Console.WriteLine("\t<title>Nezarka.net: Online Shopping for Books</title>");
            Console.WriteLine("</head>");
            Console.WriteLine("<body>");
            Console.WriteLine("\t<style type=\"text/css\">");
            Console.WriteLine("\t\ttable, th, td {");
            Console.WriteLine("\t\t\tborder: 1px solid black;");
            Console.WriteLine("\t\t\tborder-collapse: collapse;");
            Console.WriteLine("\t\t}");
            Console.WriteLine("\t\ttable {");
            Console.WriteLine("\t\t\tmargin-bottom: 10px;");
            Console.WriteLine("\t\t}");
            Console.WriteLine("\t\tpre {");
            Console.WriteLine("\t\t\tline-height: 70%;");
            Console.WriteLine("\t\t}");
            Console.WriteLine("\t</style>");
            Console.WriteLine("\t<h1><pre>  v,<br />Nezarka.NET: Online Shopping for Books</pre></h1>");
            Console.WriteLine($"\t{customer.FirstName}, here is your menu:");
            Console.WriteLine("\t<table>");
            Console.WriteLine("\t\t<tr>");
            Console.WriteLine("\t\t\t<td><a href=\"/Books\">Books</a></td>");
            Console.WriteLine($"\t\t\t<td><a href=\"/ShoppingCart\">Cart ({customer.ShoppingCart.Items.Count})</a></td>");
            Console.WriteLine("\t\t</tr>");
            Console.WriteLine("\t</table>");
        }
        

        void PrintFooter(){
            Console.WriteLine("</body>");
            Console.WriteLine("</html>");
            Console.WriteLine("====");
        }

        void Print_books_table(IList<Book> books){
            Console.WriteLine("\tOur books for you:");
            Console.WriteLine("\t<table>");

            for (int row = 0; row < (int)Math.Ceiling((double)books.Count / (double)3); ++row){
                Console.WriteLine("\t\t<tr>");
                for (int i = 0; i < 3; i++){
                    int index = row * 3 + i;
                    if (books.Count > index){
                        Book book = books[index];
                        PrintBookCell(book);
                    }
                }
                Console.WriteLine("\t\t</tr>");
            }
            Console.WriteLine("\t</table>");
        }

        void PrintBookCell(Book book){
            Console.WriteLine("\t\t\t<td style=\"padding: 10px;\">");
            Console.WriteLine($"\t\t\t\t<a href=\"/Books/Detail/{book.Id}\">{book.Title}</a><br />");
            Console.WriteLine($"\t\t\t\tAuthor: {book.Author}<br />");
            Console.WriteLine($"\t\t\t\tPrice: {book.Price} EUR &lt;<a href=\"/ShoppingCart/Add/{book.Id}\">Buy</a>&gt;");
            Console.WriteLine("\t\t\t</td>");
        }
    }
}