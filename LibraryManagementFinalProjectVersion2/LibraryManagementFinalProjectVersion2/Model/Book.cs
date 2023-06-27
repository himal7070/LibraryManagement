using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementFinalProjectVersion2.Model
{
    public class Book
    {

        public string Title { get; set; }
        public string author;
        public string description;
        public DateTime publication_date;
        public int pages;
        public long ISBN13;
        public string genre;
        public int quantity;
        

        public int bookId;

        public Book(string title, string author, string description, DateTime publication_date, int pages, long iSBN13, string genre, int quantity)
        {
            Title = title;
            this.author = author;
            this.description = description;
            this.publication_date = publication_date;
            this.pages = pages;
            ISBN13 = iSBN13;      
            this.genre = genre;
            this.quantity = quantity;

            
        }

        public Book(string title)
        {
            Title = title;
        }
    }
}
