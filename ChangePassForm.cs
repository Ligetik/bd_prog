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
    public partial class ChangePassForm : Form
    {
        public ChangePassForm()
        {
            InitializeComponent();

            //userNameTextBox.Text = "Введите имя";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void userNameTextBox_Enter(object sender, EventArgs e)
        {
            //if (userNameTextBox.Text == "Введите имя")
            //{
            //    userNameTextBox.Text = "";
            //}
            
        }

        private void RegForm_Load(object sender, EventArgs e)
        {

        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            DB dB = new DB();

            string newPassUser = newPassTextBox.Text;
            string confirmPassUser = confirmPassTextBox.Text;
            string loginUser = loginTextBox.Text;
            string passUser = passTextBox.Text;


            string connectionString = @"Data Source=DESKTOP-7VG9T54;Initial Catalog=sql;Integrated Security=True";

            ////string sqlExpression = "UPDATE users SET pass = '" + confirmPassUser.Trim() + "'WHERE pass = '" + passUser.Trim() + "'";

            //string sqlExpression = "UPDATE users SET pass = '" + confirmPassUser.Trim() + "'WHERE login = '" + loginUser.Trim() + "'";

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    SqlCommand command = new SqlCommand(sqlExpression, connection);
            //    int number = command.ExecuteNonQuery();
            //    Console.WriteLine("Обновлено объектов: {0}", number);
            //}

            try
            {
                if (newPassUser == confirmPassUser)
                {
                    string sqlExpression = "UPDATE users SET pass = '" + confirmPassUser.Trim() + "'WHERE login = '" + loginUser.Trim() 
                        + "' AND pass = '" + passUser.Trim() + "'";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(sqlExpression, connection);

                        int number = command.ExecuteNonQuery();

                        if (number > 0)
                        {
                            MessageBox.Show("Ваш пароль обновлён");
                        }

                        else
                        {
                            MessageBox.Show("Ваш пароль не обновлён, попробуйте ещё раз");
                        }                            
                    }
                }
                else
                {
                MessageBox.Show("Ваш пароль не обновлён, попробуйте ещё раз");
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }



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
                newPassTextBox.Focus();
            }
        }

        private void newPassTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                confirmPassTextBox.Focus();
            }
        }

        private void confirmPassTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                changePassButton.Focus();
            }
        }

        private void loginTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void confirmPassTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.Show();
            
        }

        private void ChangePassForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void changePassButton_Click(object sender, EventArgs e)
        {

        }
    }
}
