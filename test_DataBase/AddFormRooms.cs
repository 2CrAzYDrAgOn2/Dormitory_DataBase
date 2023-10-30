using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace test_DataBase
{
    public partial class AddFormRooms : Form
    {
        private readonly DataBase dataBase = new DataBase();

        public AddFormRooms()
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
                var roomNumber = textBoxRoomNumber.Text;
                var additionalInfo = textBoxAdditionalInfo.Text;
                if (int.TryParse(textBoxCapacity.Text, out int capacity) && int.TryParse(textBoxNumberOfCabinets.Text, out int numberOfCabinets) && int.TryParse(textBoxNumberOfChairs.Text, out int numberOfChairs) && int.TryParse(textBoxDormitoryID.Text, out int dormitoryID))
                {
                    var addQuery = $"insert into Rooms (RoomNumber, Capacity, NumberOfCabinets, NumberOfChairs, AdditionalInfo, DormitoryID) values ('{roomNumber}', '{capacity}', '{numberOfCabinets}', '{numberOfChairs}', '{additionalInfo}', '{dormitoryID}')";
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