using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace Weddingnote
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-N0NT6VT\\MSQLSERVER;initial Catalog=Wedding;Integrated Security=True;User ID=sa;Password=123456");
         
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'weddingDataSet.Weddingnote' table. You can move, or remove it, as needed.
            //this.weddingnoteTableAdapter.Fill(this.weddingDataSet.Weddingnote);
            //dataGridView1.RowHeadersVisible = false;
            //dataGridView1.ColumnHeadersVisible = false;
            bind_data();
        }
        private void bind_data()
        {
            try
            {
                conn.Open(); // Open the connection
                SqlCommand cmd = new SqlCommand("select ID,Name,Riel,Dollar,Address,Other from Weddingnote", conn);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                dt.Clear();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Khmer os siemreap", 10, FontStyle.Bold);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // Display the error message
            }
            finally
            {
                conn.Close(); // Close the connection
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("Insert into Weddingnote(ID,Name,Riel,Dollar,Address,Other)Values(@ID,@Name,@Riel,@Dollar,@Address,@Other)", conn);
            cmd2.Parameters.AddWithValue("ID", txtid.Text);
            cmd2.Parameters.AddWithValue("Name", txtname.Text);
            cmd2.Parameters.AddWithValue("Riel", txtriel.Text);
            cmd2.Parameters.AddWithValue("Dollar", txtdollar.Text);
            cmd2.Parameters.AddWithValue("Address", txtaddress.Text);
            cmd2.Parameters.AddWithValue("Other", txtother.Text);
            conn.Open() ;
            cmd2.ExecuteNonQuery();
            conn.Close() ;
            bind_data();
            btnnew_Click(sender, e);
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtname.Text = "";
            txtriel.Text = "";
            txtdollar.Text = "";
            txtaddress.Text = "";
            txtother.Text = "";
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            index = e.RowIndex;
            DataGridViewRow selectedrow = dataGridView1.Rows[index];
            txtid.Text= selectedrow.Cells[0].Value.ToString();
            txtname.Text = selectedrow.Cells[1].Value.ToString();
            txtriel.Text = selectedrow.Cells[2].Value.ToString();
            txtdollar.Text = selectedrow.Cells[3].Value.ToString();
            txtaddress.Text = selectedrow.Cells[4].Value.ToString();
            txtother.Text = selectedrow.Cells[5].Value.ToString();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd3 = new SqlCommand("UPDATE Weddingnote SET Name = @Name, Riel = @Riel, Dollar = @Dollar, Address = @Address, Other = @Other WHERE ID = @id", conn);
            cmd3.Parameters.AddWithValue("@ID", txtid.Text);
            cmd3.Parameters.AddWithValue("@Name", txtname.Text);
            cmd3.Parameters.AddWithValue("@Riel", txtriel.Text);
            cmd3.Parameters.AddWithValue("@Dollar", txtdollar.Text);
            cmd3.Parameters.AddWithValue("@Address", txtaddress.Text);
            cmd3.Parameters.AddWithValue("@Other", txtother.Text);

            conn.Open();
            cmd3.ExecuteNonQuery();
            conn.Close();

            bind_data();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd4 = new SqlCommand("Delete from Weddingnote where ID=@ID", conn);
            cmd4.Parameters.AddWithValue("ID", txtid.Text);
            conn.Open();
            cmd4.ExecuteNonQuery();
            conn.Close();
            bind_data();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

           // conn.Open(); // Open the connection
            SqlCommand cmd = new SqlCommand("select ID,Name,Riel,Dollar,Address,Other from Weddingnote where Name like Name+'%'", conn);
            cmd.Parameters.AddWithValue("Name", txtsearch.Text);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Khmer os siemreap", 10, FontStyle.Bold);
        }
        private Rectangle GetClientArea()
        {
            return new Rectangle
            {
                X = ClientRectangle.X,
                Y = ClientRectangle.Y,
                Width = ClientRectangle.Width - 1,
                Height = ClientRectangle.Height - 1
            };
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap imagebmp = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(imagebmp, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            e.Graphics.DrawImage(imagebmp, 120, 20);
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = printDocument1;
            dlg.PrintPreviewControl.Zoom = 1;
            dlg.ShowDialog();

        }
    }
}
