using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace test_DataBase
{
    public partial class LogIn : Form
    {
        private readonly DataBase dataBase = new DataBase();

        public LogIn()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Form1_Load вызывается при загрузке формы "Form1"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = '•';
            pictureBoxUnshow.Visible = false;
            textBoxLogin.MaxLength = 50;
            textBoxPassword.MaxLength = 50;
        }

        /// <summary>
        /// ButtonEnter_Click вызывается при нажатии на кнопку "Войти"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonEnter_Click(object sender, EventArgs e)
        {
            var loginUser = textBoxLogin.Text;
            var passwordUser = textBoxPassword.Text;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();
            string querystring = $"select UserID, UserLogin, UserPassword from Registration where UserLogin = '{loginUser}' and UserPassword = '{passwordUser}'";
            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.GetConnection());
            sqlDataAdapter.SelectCommand = sqlCommand;
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 form1 = new Form1();
                this.Hide();
                form1.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Такого аккаунта не существует!", "Аккаунта не существует!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// ButtonClear_Click вызывается при нажатии на кнопку очистки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            textBoxLogin.Text = "";
            textBoxPassword.Text = "";
        }

        /// <summary>
        /// PictureBoxUnshow_Click вызывается при нажатии на кнопку скрыть пароль
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxUnshow_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = true;
            pictureBoxShow.Visible = true;
            pictureBoxUnshow.Visible = false;
        }

        /// <summary>
        /// PictureBoxShow_Click вызывается при нажатии на кнопку показать пароль
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBoxShow_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = false;
            pictureBoxShow.Visible = false;
            pictureBoxUnshow.Visible = true;
        }

        /// <summary>
        /// LabelAuth_Click вызывается при нажатии на текст "Ещё нет аккаунта?"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelAuth_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp formLogin = new SignUp();
            formLogin.ShowDialog();
        }
    }
}