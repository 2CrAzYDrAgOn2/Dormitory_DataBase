using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace test_DataBase
{
    public partial class SignUp : Form
    {
        private readonly DataBase dataBase = new DataBase();

        public SignUp()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// SignUp_Load вызывается при загрузке формы "SignUp"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignUp_Load(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = '•';
            pictureBoxUnshow.Visible = false;
            textBoxLogin.MaxLength = 50;
            textBoxPassword.MaxLength = 50;
        }

        /// <summary>
        /// ButtonCreate_Click вызывается при нажатии на кнопку "Войти"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            var login = textBoxLogin.Text;
            var password = textBoxPassword.Text;
            string querystring = $"Insert into Registration(UserLogin, UserPassword) values('{login}', '{password}')";
            SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.GetConnection());
            dataBase.OpenConnection();
            if (sqlCommand.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт успешно создан!", "Успех!");
                LogIn formLogin = new LogIn();
                this.Hide();
                formLogin.ShowDialog();
            }
            else
            {
                MessageBox.Show("Аккаунт не создан!");
            }
            dataBase.CloseConnection();
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

        //private Boolean checkUser()
        //{
        //    var loginUser = textBoxLogin.Text;
        //    var passwordUser = textBoxPassword.Text;
        //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
        //    DataTable dataTable = new DataTable();
        //    string querystring = $"select Номер_Пользователя, Логин_Пользователя, Пароль_Пользвателя from Регистрация where Логин_Пользователя = '{loginUser}' and Пароль_Пользователя = '{passwordUser}'";
        //    SqlCommand sqlCommand = new SqlCommand(querystring, dataBase.GetConnection());
        //    sqlDataAdapter.SelectCommand = sqlCommand;
        //    sqlDataAdapter.Fill(dataTable);
        //    if (dataTable.Rows.Count > 0)
        //    {
        //        MessageBox.Show("Пользователь уже существует!");
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}