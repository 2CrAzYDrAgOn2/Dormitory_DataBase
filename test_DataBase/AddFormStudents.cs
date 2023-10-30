using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace test_DataBase
{
    public partial class AddFormStudents : Form
    {
        private readonly DataBase dataBase = new DataBase();

        public AddFormStudents()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// ButtonSave_Click вызывается при нажатии на кнопку "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                dataBase.OpenConnection();
                var fullName = textBoxFullName.Text;
                var passportNumber = textBoxPassportNumber.Text;
                if (int.TryParse(textBoxGroupID.Text, out int groupID) && int.TryParse(textBoxFacultyID.Text, out int facultyID))
                {
                    var addQuery = $"insert into Students (FullName, GroupID, FacultyID, PassportNumber) values ('{fullName}', '{groupID}', '{facultyID}', '{passportNumber}')";
                    var sqlCommand = new SqlCommand(addQuery, dataBase.GetConnection());
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Цена должна иметь числовой формат!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dataBase.CloseConnection();
            }
        }
    }
}