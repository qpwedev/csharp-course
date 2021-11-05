using System;
using Model;
using System.IO;
using System.Text;

namespace nezarka
{
    class QueryParser
    {
        public Customer Customer { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public string Query { get; set; }
        public string[] Tokens { get; set; }


        public bool ParceQuery(string query, ModelStore store){
            var splitQuery = query.Split(' ');

            if (splitQuery.Length != 3 || splitQuery[0] != "GET"){
                return false;
            }
            int customerId;
            if (!int.TryParse(splitQuery[1], out customerId)){
                return false;
            }

            var customer = store.GetCustomer(customerId);
            if (customer == null){
                return false;
            }

            Customer = customer;
            string[] Tokens = splitQuery[2].Replace("http://www.nezarka.net/", "").Split('/');
            
            switch (Tokens[0]){
                case "Books":
                    if (Tokens.Length == 1){
                        Query = "Books";
                    }
                    else if (Tokens.Length == 3 && Tokens[1] == "Detail"){
                        int bookId;
                        if (!int.TryParse(Tokens[2], out bookId)){
                            return false;
                        }
                        Book book = store.GetBook(bookId);

                        if (book == null){
                            return false;
                        }
                        BookId = bookId;
                        Book = book;
                        Query = "BooksDetail";
                        
                    }
                    else {
                        return false;
                    }
                    break;

                case "ShoppingCart":
                    if (Tokens.Length == 1){
                        Query = "ShoppingCart";
                    }
                    else if (Tokens.Length == 3 && Tokens[1] == "Add"){
                        int bookId;
                        if (!int.TryParse(Tokens[2], out bookId)){
                            return false;
                        }

                        Book book = store.GetBook(bookId);

                        if (book == null){
                            return false;
                        }
                        BookId = bookId;
                        Book = book;
                        Query = "ShoppingCartAdd";
                    }
                    else if (Tokens.Length == 3 && Tokens[1] == "Remove"){
                        int bookId;
                        if (!int.TryParse(Tokens[2], out bookId)){
                            return false;
                        }

                        Book book = store.GetBook(bookId);

                        if (book == null){
                            return false;
                        }
                        if (Customer.ShoppingCart.GetItem(bookId) == null){
                            return false;
                        }
                        BookId = bookId;
                        Book = book;
                        Query = "ShoppingCartRemove";
                    }
                    else {
                        return false;
                    }
                    break;

                default:
                    return false;
            }
            return true;
        }
    }
}