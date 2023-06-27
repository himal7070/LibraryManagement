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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Reflection;

namespace LibraryManagementFinalProjectVersion2
{
    public partial class AddMembers : Form
    {

       
        LibraryEntity le = new LibraryEntity();
        

        public AddMembers()
        {
            InitializeComponent();
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Member md = new Member(tbFullName.Text, tbEmail.Text, int.Parse(tbPhoneNumber.Text));
            md.Name = tbFullName.Text;
            md.Email = tbEmail.Text;
            md.Phone = int.Parse(tbPhoneNumber.Text);

            le.AddMember(md);

            ViewGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Member md = new Member(tbFullName.Text, tbEmail.Text, int.Parse(tbPhoneNumber.Text));

            md.Name = tbFullName.Text;
            md.Email = tbEmail.Text;
            md.Phone = int.Parse(tbPhoneNumber.Text);

            le.UpdateMember(md, int.Parse(tbId.Text));

            ViewGrid();
        }

        public void ViewGrid()
        {
            var reader = new SqlDataHelper().select("SELECT * FROM Members");

            dataGridView1.Rows.Clear();

            while (reader.Read())
            {

                dataGridView1.Rows.Add(reader["MemberID"], reader["Full name"], reader["Email"], reader["Phone"], "Edit", "Delete");

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbId.Clear();
            tbFullName.Clear();
            tbEmail.Clear();
            tbPhoneNumber.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            le.DeleteMember(int.Parse(tbId.Text));

            ViewGrid();
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            var reader = new SqlDataHelper().select("SELECT * FROM Members WHERE MemberID = " + tbId.Text);

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex > -1)
            {
                tbId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            else if (e.ColumnIndex == 5 && e.RowIndex > -1)
            {
                tbId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                if (MessageBox.Show("Do you really want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnDelete_Click(sender, e);
                }
            }
        }

        private void AddMembers_Load(object sender, EventArgs e)
        {
            ViewGrid();
        }
    }
}
