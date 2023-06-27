using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementFinalProjectVersion2.Model
{
    public class Member
    {
        private List<Book> borrowedBooks;

        public int Id { get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }

        public string Title { get; set; }
       

        public Member(string name, string email, int phone)
        {
            borrowedBooks = new List<Book>();
            Name = name;
            Email = email;
            Phone = phone;
            
           
        }

        public Member(int memberId, string title)
        {
            borrowedBooks = new List<Book>();
            Id = memberId;
            Title = title;
        }

        public void BorrowBook(Book book)
        {
            try
            {
                borrowedBooks.Add(book);
            }
            catch (Exception exp)
            {

                MessageBox.Show(exp.Message);
            }
           
        }
    }
}
