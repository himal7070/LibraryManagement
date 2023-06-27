using LibraryManagementFinalProjectVersion2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementFinalProjectVersion2
{

    internal class LibraryEntity
    {
        SqlDataHelper db = new SqlDataHelper();


        // --------------------------------- Add Books ----------------------------------- //
        public string AddBook(Book data)
        {
            try
            {
                string query = "INSERT INTO book(title,author,description,publication_date,pages,ISBN13,genre,quantity) VALUES ('" + data.Title + "','" + data.author + "','" + data.description + "','" + data.publication_date + "','" + data.pages + "','" + data.ISBN13 + "', '" + data.genre + "', '" + data.quantity + "') ";
                var message = db.Execute(query);

                MessageBox.Show($"Data has been added Succesfully {message}"); // Thanks Thijs:

                return query;

            }
            catch (Exception exp)
            {

                return exp.ToString();
            }

        }
        public string UpdateBook(Book data, int bookid)
        {
            try
            {
                string query = ("Update book set title ='" + data.Title + "', author = '" + data.author + "', description ='" + data.description + "', publication_date= '" + data.publication_date + "', pages= '" + data.pages + "', ISBN13= '" + data.ISBN13 + "',genre='" + data.genre + "',quantity ='" + data.quantity + "' WHERE bookId = " + bookid);
                var message = db.Execute(query);



                return query;
            }
            catch (Exception exp)
            {

                return exp.ToString();
            }
        }

        public string DeleteBook(int bookid)
        {
            try
            {
                string query = ("Delete book where bookId=" + bookid);
                var message = db.Execute(query);

                MessageBox.Show($"Data has been succesfully Deleted{message}");

                return query;
            }
            catch (Exception exp)
            {

                return exp.ToString();
            }

        }

        // --------------------------------- Add Members ----------------------------------- //

        public string AddMember(Member data)
        {
            try
            {
                string query = "INSERT INTO Members ( [full name], email, phone) VALUES ('" + data.Name + "','" + data.Email + "', '" + data.Phone + "')";
                var message = db.Execute(query);

                MessageBox.Show($"Data has been succesfully Added {message}");

                return query;
            }
            catch (Exception exp)
            {
                return exp.ToString();

            }
        }

        public string UpdateMember(Member data, int memberID)
        {
            try
            {
                string query = ("Update Members set [full name]= '" + data.Name + "', email='" + data.Email + "', phone='" + data.Phone + "'  where memberID = " + memberID);
                var message = db.Execute(query);

                MessageBox.Show($"Data has been succesfully Updated {message}");

                return query;
            }
            catch (Exception exp)
            {

                return exp.ToString();
            }
        }

        public string DeleteMember(int memberID)
        {
            try
            {
                string query = ("Delete Members where MemberID=" + memberID);
                var message = db.Execute(query);

                MessageBox.Show($"Data has been succesfully Deleted{message}");

                return query;
            }
            catch (Exception exp)
            {

                return exp.ToString();
            }
        }

        // --------------------------------- Borrow Books ----------------------------------- //

        public List<string> GetBookTitle()
        {
            List<string> list = new List<string>();

            try
            {
                var reader = new SqlDataHelper().select("select title from book where Quantity>0");


                while (reader.Read())
                    list.Add(reader["title"].ToString());
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public bool HowManyBooksBorrowed(int memberid)
        {
            try
            {
                var reader = new SqlDataHelper().select("select * from borrowandreturn where memberId='" + memberid + "'");
                int count = 0;

                while (reader.Read())
                {
                    if (reader["return_date"].ToString().Equals("0"))
                        count++;


                }
                if (count < 3)
                    return true;
                else
                    return false;

            }
            catch (Exception exp)
            {

                MessageBox.Show(exp.ToString());

            }
            return false;

        }

        public void BorrowBooks(Member bb)
        {
            Book bdatac = GetBookData(bb.Title);

            bdatac.quantity = bdatac.quantity - 1;

            UpdateBook(bdatac, bdatac.bookId);

            try
            {
                string query = "INSERT INTO borrowandreturn(memberId,[full name],title,borrow_date, return_date) VALUES('" + bb.Id + "','" + bb.Name + "','" + bb.Title + "','" + DateTime.Now + "','" + 0 + "') "; 
                var message = db.Execute(query);

                MessageBox.Show($"Book has been borrowed succesfully {message}");

               
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }


        private Book GetBookData(string title)
        {
            Book abd = new Book(title);

            try
            {
                var reader = new SqlDataHelper().select("SELECT * FROM book WHERE title = '" + title + "'");


                if (reader.Read())
                {
                    abd.bookId = int.Parse(reader["bookId"].ToString());

                    abd.Title = reader["title"].ToString();
                    abd.author = reader["author"].ToString();
                    abd.description = reader["description"].ToString();
                    abd.pages = int.Parse(reader["pages"].ToString());
                    abd.ISBN13 = Convert.ToInt64(reader["ISBN13"].ToString());
                    abd.publication_date = DateTime.Parse(reader["publication_date"].ToString());
                    abd.genre = reader["genre"].ToString();
                    abd.quantity = int.Parse(reader["quantity"].ToString());

                    return abd;
                }
                else
                {
                    MessageBox.Show("Something Wrong");
                }

            }
            catch (Exception)
            {

                throw;
            }
            return abd;
        }

        public void DeleteBorrowBook(int memberId, string title)
        {
            string query = ("delete borrowandreturn where memberid = '" + memberId + "' and title = '" + title + "'");
            var message = db.Execute(query);

            MessageBox.Show($"Data has been succesfully deleted{message}");


        }

        // --------------------------------- Return Books ----------------------------------- //

        public string ReturnBooks(string memberId, string title, string borrow)
        {
            Book abdc = GetBookData(title);
            abdc.quantity = abdc.quantity + 1;
            UpdateBook(abdc, abdc.bookId);

            try
            {
                string query = "update borrowandreturn set return_date='" + DateTime.Now + "' where memberId='" + memberId + "' and borrow_date='" + borrow + "' ";
                var message = db.Execute(query);

                MessageBox.Show($"Book returned{message}");

                return query;
            }
            catch (Exception exp)
            {

                return exp.ToString();
            }
        }
    }
}
