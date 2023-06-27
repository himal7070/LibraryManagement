using LibraryManagementFinalProjectVersion2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementFinalProjectVersion2
{
    public partial class BorrowBooks : Form
    {
        LibraryEntity le = new LibraryEntity();
        public BorrowBooks()
        {
            LibraryEntity le = new LibraryEntity();
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbMemberId.Clear();
            tbFullName.Clear();
            tbPhoneNumber.Clear();
            tbEmail.Clear();
            cbBookTitle.Text = string.Empty;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var reader = new SqlDataHelper().select("SELECT * FROM Members WHERE MemberID = " + tbMemberId.Text);

            if (reader.Read())
            {
                tbFullName.Text = reader["Full name"].ToString();
                tbEmail.Text = reader["Email"].ToString();
                tbPhoneNumber.Text = reader["Phone"].ToString();
            }
            else
            {
                MessageBox.Show("No record found");
            }
        }

        private void BorrowBooks_Load(object sender, EventArgs e)
        {
            LibraryEntity le = new LibraryEntity();
            List<string> list = le.GetBookTitle();
            foreach (string title in list)
                cbBookTitle.Items.Add(title);

            ViewGrid();
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (cbBookTitle.SelectedIndex != -1)
            {
                // new book
                Book book = new Book(cbBookTitle.Text.ToString());

                // get the member
                Member member = new Member(int.Parse(tbMemberId.Text), cbBookTitle.Text.ToString());
                member.Name = tbFullName.Text;


                // check how many book borrowed
                LibraryEntity le = new LibraryEntity();
                if (le.HowManyBooksBorrowed(member.Id))
                {
                    // save in db
                    le.BorrowBooks(member);
                    // add the book to member 
                    member.BorrowBook(book);

                }
                else
                {
                    MessageBox.Show("Sorry; Maximum 3 Books Can be borrowed by 1 Member");
                }

            }
            ViewGrid();
        }

        public void ViewGrid()
        {
            var reader = new SqlDataHelper().select("SELECT * FROM borrowandreturn where return_date = '" + 0 + "' ");

            dgvBorrowedBooks.Rows.Clear();

            while (reader.Read())
            {
                dgvBorrowedBooks.Rows.Add(reader["MemberID"], reader["full name"], reader["title"], reader["borrow_date"], reader["return_date"], "Delete");
            }

        }

        private void dgvBorrowedBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex > -1)
            {
                tbMemberId.Text = dgvBorrowedBooks.Rows[e.RowIndex].Cells[0].Value.ToString();
                cbBookTitle.Text = dgvBorrowedBooks.Rows[e.RowIndex].Cells[2].Value.ToString();

                if (MessageBox.Show("Do you really want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    le.DeleteBorrowBook(int.Parse(tbMemberId.Text), cbBookTitle.Text.ToString());
                }
            }
            ViewGrid();
        }


    }
}
