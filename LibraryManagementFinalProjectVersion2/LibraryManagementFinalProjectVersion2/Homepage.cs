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
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }


        private void btnBooks_Click(object sender, EventArgs e)
        {
            this.Hide();

            AddBooks addBook = new AddBooks();
            addBook.ShowDialog();

            this.Show();
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            this.Hide();

            AddMembers addMembers = new AddMembers();
            addMembers.ShowDialog();

            this.Show();

            
        }

        private void btnBorrowBooks_Click(object sender, EventArgs e)
        {
            this.Hide();

            BorrowBooks borrowBooks = new BorrowBooks();
            borrowBooks.ShowDialog(); 
            
            this.Show();
        }

        private void btnReturnBooks_Click(object sender, EventArgs e)
        {
            this.Hide();

            ReturnBooks returnBooks = new ReturnBooks();
            returnBooks.ShowDialog();

            this.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
