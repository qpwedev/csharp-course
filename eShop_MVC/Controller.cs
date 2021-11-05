using System;
using Model;
using View;
using System.IO;

namespace nezarka
{
    class Controller
    {
        static void Main(string[] args)
        {
            TextReader textReader = Console.In;
            var store = ModelStore.LoadFrom(textReader);
            if (store == null){
                System.Console.WriteLine("Data error.");
                return;
            }

            var view = new ViewHTML();

            while (true) {
                string line = textReader.ReadLine();
                if (line == null) return;
                
                QueryParser queryParser = new QueryParser();

                if (!queryParser.ParceQuery(line, store)){
                    view.InvalidHTML();
                    continue;
                }

                var customer = queryParser.Customer;
                var query = queryParser.Query;
                var bookId = queryParser.BookId;
                var book = queryParser.Book;
                    
                switch (query) {
                    case "Books":
                        view.BooksHTML(store.GetBooks(),customer);
                        break;
                    case "BooksDetail":
                        view.BookDetailHTML(book, customer);
                        break;
                    case "ShoppingCart":
                        view.CartContentsHTML(customer, store);
                        break;
                    case "ShoppingCartAdd":
                        customer.ShoppingCart.AddBook(bookId);
                        view.CartContentsHTML(customer, store);
                        break;
                    case "ShoppingCartRemove":
                        customer.ShoppingCart.RemoveBook(bookId);
                        view.CartContentsHTML(customer, store);
                        break;
                    default:
                        view.InvalidHTML();
                        break;
                }
			}
        }
    }
}
