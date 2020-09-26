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

namespace fase2
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Andres Lopez\source\repos\ProyectoFase2\fase2\prueba.mdf;Integrated Security = True");
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [Table] (numCuenta, nombre, edad) values ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            displayData();
            displayData2();
            MessageBox.Show("Datos insertados exitosamente");

        }
        public void displayData2()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select" +
                "[Current LSN]," +
                "[Transaction ID]," +
                "[Operation]," +
                "[Transaction Name]," +
                "[CONTEXT]," +
                "[AllocUnitName]," +
                "[Page ID]," +
                "[Slot ID]," +
                "[Begin Time]," +
                "[End Time]," +
                "[Number of Locks]," +
                "[Lock Information]" +
                "from sys.fn_dblog(NULL, NULL)" +
                "where Operation IN" +
                "('LOP_INSERT_ROWS','LOP_MODIFY_ROW'," +
                "'LOP_DELETE_ROWS','LOP_BEGIN_XACT','LOP_COMMIT_XACT')";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dta);
            dataGridView2.DataSource = dta;
            con.Close();
        }
        public void displayData()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [Table]";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dta);
            dataGridView1.DataSource = dta;
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            displayData();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from [Table] where numCuenta = '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            displayData();
            displayData2();
            MessageBox.Show("Datos eliminados exitosamente");

        }

        private void button3_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update [Table] set Nombre = '" + textBox2.Text + "' where Nombre = '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            displayData();
            displayData2();
            MessageBox.Show("Datos actualizada exitosamente");

        }

        private void button4_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [Table] where Nombre = '" + textBox4.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable da = new DataTable();
            SqlDataAdapter dada = new SqlDataAdapter(cmd);
            dada.Fill(da);
            dataGridView1.DataSource = da;
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
