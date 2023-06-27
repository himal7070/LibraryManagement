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
    public partial class ReturnBooks : Form
    {
        public ReturnBooks()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            LibraryEntity le = new LibraryEntity();
            le.ReturnBooks(lblMemberID.Text, lblBookTitle.Text, lblBorrowedDate.Text);


            ViewGrid1();
            ViewGrid2();

        }

        public void SerachMemberID()
        {
            var reader = new SqlDataHelper().select("SELECT * FROM borrowandreturn WHERE MemberID LIKE '%" + tbSearchMemberID.Text + "%'");
            dgvBorrowedBooks.Rows.Clear();

            while (reader.Read())
            {

                dgvBorrowedBooks.Rows.Add(reader["memberID"], reader["full name"], reader["title"], reader["borrow_date"], "Edit");

            }
        }

        private void tbSearchMemberID_TextChanged(object sender, EventArgs e)
        {
            SerachMemberID();
        }



        private void ReturnBooks_Load(object sender, EventArgs e)
        {
            ViewGrid1();
            ViewGrid2();

        }


        public void ViewGrid1()
        {
            var reader = new SqlDataHelper().select("SELECT * FROM borrowandreturn where return_date = '" + 0 + "' ");

            dgvBorrowedBooks.Rows.Clear();

            while (reader.Read())
            {
                dgvBorrowedBooks.Rows.Add(reader["memberId"], reader["full name"], reader["title"], reader["borrow_date"], "Edit");
            }

        }


        public void ViewGrid2()
        {
            var reader = new SqlDataHelper().select("SELECT * FROM borrowandreturn where return_date <> '" +0+"'");

            dgvReturnedBooks.Rows.Clear();

            while (reader.Read())
            {
                dgvReturnedBooks.Rows.Add(reader["memberId"], reader["full name"], reader["title"], reader["borrow_date"], reader["return_date"]);
            }

        }

        private void dgvBorrowedBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex > -1)
            {
                lblMemberID.Text = dgvBorrowedBooks.Rows[e.RowIndex].Cells[0].Value.ToString();
                lblUsername.Text = dgvBorrowedBooks.Rows[e.RowIndex].Cells[1].Value.ToString();
                lblBookTitle.Text = dgvBorrowedBooks.Rows[e.RowIndex].Cells[2].Value.ToString();
                lblBorrowedDate.Text = dgvBorrowedBooks.Rows[e.RowIndex].Cells[3].Value.ToString();

            }
           
        }
    }
}
