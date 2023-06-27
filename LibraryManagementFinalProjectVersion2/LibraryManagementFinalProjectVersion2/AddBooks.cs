using LibraryManagementFinalProjectVersion2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementFinalProjectVersion2
{
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();

            cbGenre.DataSource = Enum.GetValues(typeof(Genre));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Book data = new Book(tbTitle.Text, tbAuthor.Text, tbDescription.Text, DateTime.Parse(dtpPublication.Text), int.Parse(tbPages.Text), Convert.ToInt64(tbISBN13.Text), tbQuantity.Text, cbGenre.SelectedIndex);

            data.Title = tbTitle.Text;
            data.author = tbAuthor.Text;
            data.description = tbDescription.Text;
            data.publication_date = DateTime.Parse(dtpPublication.Text);
            data.pages = int.Parse(tbPages.Text);
            data.ISBN13 = Convert.ToInt64(tbISBN13.Text);
            data.genre = cbGenre.SelectedItem.ToString();
            data.quantity = int.Parse(tbQuantity.Text);

            LibraryEntity le = new LibraryEntity();

            le.AddBook(data);

            ViewGrid();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Book data = new Book(tbTitle.Text, tbAuthor.Text, tbDescription.Text, DateTime.Parse(dtpPublication.Text), int.Parse(tbPages.Text), Convert.ToInt64(tbISBN13.Text), tbQuantity.Text, cbGenre.SelectedIndex);

            data.Title = tbTitle.Text;
            data.author = tbAuthor.Text;
            data.description = tbDescription.Text;
            data.publication_date = DateTime.Parse(dtpPublication.Text);
            data.pages = int.Parse(tbPages.Text);
            data.ISBN13 = Convert.ToInt64(tbISBN13.Text);
            data.genre = cbGenre.SelectedItem.ToString();
            data.quantity = int.Parse(tbQuantity.Text);

            LibraryEntity le = new LibraryEntity();
            le.UpdateBook(data, int.Parse(tbBookId.Text));

            MessageBox.Show("Data has been succesfully Updated");

            ViewGrid();
        }

        private void AddBooks_Load(object sender, EventArgs e)
        {
            ViewGrid();
        }

        public void ViewGrid()
        {

            var reader = new SqlDataHelper().select("SELECT * FROM book");

            dgvBook.Rows.Clear();

            while (reader.Read())
            {
                dgvBook.Rows.Add(reader["bookId"], reader["title"], reader["author"], reader["description"], reader["publication_date"], reader["pages"], reader["ISBN13"], reader["genre"], reader["quantity"], "Delete");
            }
        }



        private void btnFetch_Click(object sender, EventArgs e)
        {
            var reader = new SqlDataHelper().select("SELECT * FROM book WHERE bookId = " + tbBookId.Text);

            if (reader.Read())
            {
                tbTitle.Text = reader["title"].ToString();
                tbAuthor.Text = reader["author"].ToString();
                tbDescription.Text = reader["description"].ToString();
                tbPages.Text = reader["pages"].ToString();
                tbISBN13.Text = reader["ISBN13"].ToString();
                dtpPublication.Text = reader["publication_date"].ToString();
                cbGenre.Text = reader["genre"].ToString();
                tbQuantity.Text = reader["quantity"].ToString();
            }
            else
            {
                MessageBox.Show("No record found");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbBookId.Clear();
            tbTitle.Clear();
            tbAuthor.Clear();
            tbDescription.Clear();
            tbPages.Clear();
            tbISBN13.Clear();
            dtpPublication.Text = string.Empty;
            cbGenre.Text = string.Empty;
            tbQuantity.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            LibraryEntity le = new LibraryEntity();

            le.DeleteBook(int.Parse(tbBookId.Text));
        }

        private void dgvBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9 && e.RowIndex > -1)
            {
                tbBookId.Text = dgvBook.Rows[e.RowIndex].Cells[0].Value.ToString();

                if (MessageBox.Show("Do you really want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnDelete_Click(null,null);
                }
            }
            ViewGrid();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            var reader = new SqlDataHelper().select("SELECT * FROM book WHERE title LIKE '%" + tbSearch.Text + "%' or author LIKE '%" + tbSearch.Text + "%' or genre LIKE '%" + tbSearch.Text + "%'");
            dgvBook.Rows.Clear();

            while (reader.Read())
            {
                dgvBook.Rows.Add(reader["bookId"], reader["title"], reader["author"], reader["description"], reader["publication_date"], reader["pages"], reader["ISBN13"], reader["genre"], reader["quantity"], "Delete");
            }
        }
    }
}
