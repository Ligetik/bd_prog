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

namespace bd
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            string loginUser = loginTextBox.Text;
            string passUser = passTextBox.Text;

            DB db = new DB();

            string query = "SELECT * FROM users WHERE login = '" + loginUser.Trim() + "' AND pass = '" + passUser.Trim() + "'";

            SqlDataAdapter adapter = new SqlDataAdapter(query, db.GetSqlConnection());
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            if (dataTable.Rows.Count == 1)
            {
                MainForm mainForm = new MainForm();
                this.Hide();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин и пароль");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
           
        }

        private void loginTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                passTextBox.Focus();
            }
        }

        private void passTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                signInButton.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangePassForm changePassForm = new ChangePassForm();
            this.Hide();
            changePassForm.Show();;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
