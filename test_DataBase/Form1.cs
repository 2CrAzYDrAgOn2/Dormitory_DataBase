using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace test_DataBase
{
    internal enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class Form1 : Form
    {
        private readonly DataBase dataBase = new DataBase();
        private int selectedRow;

        public Form1()
        {
            try
            {
                InitializeComponent();
                StartPosition = FormStartPosition.CenterScreen;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// CreateColumns вызывается при создании колонок в dataGridView
        /// </summary>
        private void CreateColumns()
        {
            try
            {
                dataGridViewDormitories.Columns.Add("DorimitoryID", "Номер");
                dataGridViewDormitories.Columns.Add("DormitoryName", "Название общежития");
                dataGridViewDormitories.Columns.Add("IsNew", String.Empty);
                dataGridViewFaculties.Columns.Add("FacultyID", "Номер");
                dataGridViewFaculties.Columns.Add("FacultyName", "Название факультета");
                dataGridViewFaculties.Columns.Add("IsNew", String.Empty);
                dataGridViewGroups.Columns.Add("GroupID", "Номер");
                dataGridViewGroups.Columns.Add("GroupName", "Название группы");
                dataGridViewGroups.Columns.Add("IsNew", String.Empty);
                dataGridViewHousingOrders.Columns.Add("OrderID", "Номер");
                dataGridViewHousingOrders.Columns.Add("OrderNumber", "Номер приказа");
                dataGridViewHousingOrders.Columns.Add("FacultyID", "Номер факультета");
                dataGridViewHousingOrders.Columns.Add("StudentID", "Номер студента");
                dataGridViewHousingOrders.Columns.Add("IsNew", String.Empty);
                dataGridViewHousingPayments.Columns.Add("PaymentID", "Номер");
                dataGridViewHousingPayments.Columns.Add("PaymentDate", "Дата оплаты");
                dataGridViewHousingPayments.Columns.Add("PaidAmount", "Сумма к оплате");
                dataGridViewHousingPayments.Columns.Add("StudentID", "Номер студента");
                dataGridViewHousingPayments.Columns.Add("IsNew", String.Empty);
                dataGridViewRoomAssignment.Columns.Add("RoomAssignment", "Номер");
                dataGridViewRoomAssignment.Columns.Add("StudentID", "Номер студента");
                dataGridViewRoomAssignment.Columns.Add("RoomID", "Номер комнаты");
                dataGridViewRoomAssignment.Columns.Add("IsNew", String.Empty);
                dataGridViewRooms.Columns.Add("RoomID", "Номер");
                dataGridViewRooms.Columns.Add("RoomNumber", "Номер комнаты");
                dataGridViewRooms.Columns.Add("Capacity", "Вместимость");
                dataGridViewRooms.Columns.Add("NumberOfCabinets", "Количество шкафов");
                dataGridViewRooms.Columns.Add("NumberOfChairs", "Количество стульев");
                dataGridViewRooms.Columns.Add("AdditionalInfo", "Доп. информация");
                dataGridViewRooms.Columns.Add("DormitoryID", "Номер общежития");
                dataGridViewRooms.Columns.Add("IsNew", String.Empty);
                dataGridViewStudents.Columns.Add("StudentID", "Номер");
                dataGridViewStudents.Columns.Add("FullName", "Полное имя");
                dataGridViewStudents.Columns.Add("GroupID", "Номер группы");
                dataGridViewStudents.Columns.Add("FacultyID", "Номер факультета");
                dataGridViewStudents.Columns.Add("PassportNumber", "Номер пасспорта");
                dataGridViewStudents.Columns.Add("IsNew", String.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ClearFields вызывается при очистке всех полей
        /// </summary>
        private void ClearFields()
        {
            try
            {
                textBoxDormitoryID.Text = "";
                textBoxDormitoryName.Text = "";
                textBoxFacultyID.Text = "";
                textBoxFacultyName.Text = "";
                textBoxGroupID.Text = "";
                textBoxGroupName.Text = "";
                textBoxOrderID.Text = "";
                textBoxOrderNumber.Text = "";
                textBoxFacultyIDHousingOrders.Text = "";
                textBoxStudentIDHousingOrders.Text = "";
                textBoxPaymentID.Text = "";
                textBoxPaymentDate.Text = "";
                textBoxPaidAmount.Text = "";
                textBoxStudentIDHousingPayments.Text = "";
                textBoxRoomAssignmentID.Text = "";
                textBoxStudentIDRoomAssignment.Text = "";
                textBoxRoomIDRoomAssignment.Text = "";
                textBoxRoomID.Text = "";
                textBoxRoomNumber.Text = "";
                textBoxCapacity.Text = "";
                textBoxNumberOfCabinets.Text = "";
                textBoxNumberOfChairs.Text = "";
                textBoxAdditionalInfo.Text = "";
                textBoxDormitoryIDRooms.Text = "";
                textBoxStudentID.Text = "";
                textBoxFullName.Text = "";
                textBoxGroupIDStudents.Text = "";
                textBoxFacultyIDStudents.Text = "";
                textBoxPassportNumber.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ReadSingleRow вызывается при чтении всех строк
        /// </summary>
        /// <param name="name"></param>
        /// <param name="iDataRecord"></param>
        private void ReadSingleRow(string name, IDataRecord iDataRecord)
        {
            try
            {
                switch (name)
                {
                    case "Dormitories":
                        dataGridViewDormitories.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), RowState.Modified);
                        break;

                    case "Faculties":
                        dataGridViewFaculties.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), RowState.Modified);
                        break;

                    case "Groups":
                        dataGridViewGroups.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), RowState.Modified);
                        break;

                    case "HousingOrders":
                        dataGridViewHousingOrders.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.GetInt32(2), iDataRecord.GetInt32(3), RowState.Modified);
                        break;

                    case "HousingPayments":
                        dataGridViewHousingPayments.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetDateTime(1), iDataRecord.GetInt32(2), iDataRecord.GetInt32(3), RowState.Modified);
                        break;

                    case "RoomAssignment":
                        dataGridViewRoomAssignment.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetInt32(1), iDataRecord.GetInt32(2), RowState.Modified);
                        break;

                    case "Rooms":
                        dataGridViewRooms.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.GetInt32(2), iDataRecord.GetInt32(3), iDataRecord.GetInt32(4), iDataRecord.GetString(5), iDataRecord.GetInt32(6), RowState.Modified);
                        break;

                    case "Students":
                        dataGridViewStudents.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.GetInt32(2), iDataRecord.GetInt32(3), iDataRecord.GetString(4), RowState.Modified);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// RefreshDataGrid вызывается при обновлении dataGrid
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="tableName"></param>
        private void RefreshDataGrid(DataGridView dataGridView, string tableName)
        {
            try
            {
                dataGridView.Rows.Clear();
                string queryString = $"select * from {tableName}";
                SqlCommand sqlCommand = new SqlCommand(queryString, dataBase.GetConnection());
                dataBase.OpenConnection();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    ReadSingleRow(tableName, sqlDataReader);
                }
                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Form1_Load вызывается при открытии формы "Form1"
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                CreateColumns();
                RefreshDataGrid(dataGridViewDormitories, "Dormitories");
                RefreshDataGrid(dataGridViewFaculties, "Faculties");
                RefreshDataGrid(dataGridViewGroups, "Groups");
                RefreshDataGrid(dataGridViewHousingOrders, "HousingOrders");
                RefreshDataGrid(dataGridViewHousingPayments, "HousingPayments");
                RefreshDataGrid(dataGridViewRoomAssignment, "RoomAssignment");
                RefreshDataGrid(dataGridViewRooms, "Rooms");
                RefreshDataGrid(dataGridViewStudents, "Students");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewDormitories_CellClick вызывается при нажатии на ячейку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewDormitories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow dataGridViewRow = dataGridViewDormitories.Rows[selectedRow];
                    textBoxDormitoryID.Text = dataGridViewRow.Cells[0].Value.ToString();
                    textBoxDormitoryName.Text = dataGridViewRow.Cells[1].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewFaculties_CellClick вызывается при нажатии на ячейку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewFaculties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow dataGridViewRow = dataGridViewFaculties.Rows[selectedRow];
                    textBoxFacultyID.Text = dataGridViewRow.Cells[0].Value.ToString();
                    textBoxFacultyName.Text = dataGridViewRow.Cells[1].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewGroups_CellClick вызывается при нажатии на ячейку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewGroups_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow dataGridViewRow = dataGridViewGroups.Rows[selectedRow];
                    textBoxGroupID.Text = dataGridViewRow.Cells[0].Value.ToString();
                    textBoxGroupName.Text = dataGridViewRow.Cells[1].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewHousingOrders_CellClick вызывается при нажатии на ячейку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewHousingOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow dataGridViewRow = dataGridViewHousingOrders.Rows[selectedRow];
                    textBoxOrderID.Text = dataGridViewRow.Cells[0].Value.ToString();
                    textBoxOrderNumber.Text = dataGridViewRow.Cells[1].Value.ToString();
                    textBoxFacultyIDHousingOrders.Text = dataGridViewRow.Cells[2].Value.ToString();
                    textBoxStudentIDHousingOrders.Text = dataGridViewRow.Cells[3].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewHousingPayments_CellClick вызывается при нажатии на ячейку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewHousingPayments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow dataGridViewRow = dataGridViewHousingPayments.Rows[selectedRow];
                    textBoxPaymentID.Text = dataGridViewRow.Cells[0].Value.ToString();
                    textBoxPaymentDate.Text = dataGridViewRow.Cells[1].Value.ToString();
                    textBoxPaidAmount.Text = dataGridViewRow.Cells[2].Value.ToString();
                    textBoxStudentIDHousingPayments.Text = dataGridViewRow.Cells[3].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewRoomAssignment_CellClick вызывается при нажатии на ячейку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewRoomAssignment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow dataGridViewRow = dataGridViewRoomAssignment.Rows[selectedRow];
                    textBoxRoomAssignmentID.Text = dataGridViewRow.Cells[0].Value.ToString();
                    textBoxStudentIDRoomAssignment.Text = dataGridViewRow.Cells[1].Value.ToString();
                    textBoxRoomIDRoomAssignment.Text = dataGridViewRow.Cells[2].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewRooms_CellClick вызывается при нажатии на ячейку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewRooms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow dataGridViewRow = dataGridViewRooms.Rows[selectedRow];
                    textBoxRoomID.Text = dataGridViewRow.Cells[0].Value.ToString();
                    textBoxRoomNumber.Text = dataGridViewRow.Cells[1].Value.ToString();
                    textBoxCapacity.Text = dataGridViewRow.Cells[2].Value.ToString();
                    textBoxNumberOfCabinets.Text = dataGridViewRow.Cells[3].Value.ToString();
                    textBoxNumberOfChairs.Text = dataGridViewRow.Cells[4].Value.ToString();
                    textBoxAdditionalInfo.Text = dataGridViewRow.Cells[5].Value.ToString();
                    textBoxDormitoryIDRooms.Text = dataGridViewRow.Cells[6].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DataGridViewStudents_CellClick вызывается при нажатии на ячейку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                selectedRow = e.RowIndex;
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow dataGridViewRow = dataGridViewStudents.Rows[selectedRow];
                    textBoxStudentID.Text = dataGridViewRow.Cells[0].Value.ToString();
                    textBoxFullName.Text = dataGridViewRow.Cells[1].Value.ToString();
                    textBoxGroupIDStudents.Text = dataGridViewRow.Cells[2].Value.ToString();
                    textBoxFacultyIDStudents.Text = dataGridViewRow.Cells[3].Value.ToString();
                    textBoxPassportNumber.Text = dataGridViewRow.Cells[4].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonRefresh_Click вызывается при нажатии на кнопку обновить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshDataGrid(dataGridViewDormitories, "Dormitories");
                RefreshDataGrid(dataGridViewFaculties, "Faculties");
                RefreshDataGrid(dataGridViewGroups, "Groups");
                RefreshDataGrid(dataGridViewHousingOrders, "HousingOrders");
                RefreshDataGrid(dataGridViewHousingPayments, "HousingPayments");
                RefreshDataGrid(dataGridViewRoomAssignment, "RoomAssignment");
                RefreshDataGrid(dataGridViewRooms, "Rooms");
                RefreshDataGrid(dataGridViewStudents, "Students");
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewDormitories_Click вызывается при нажатии на кнопку "Новая запись"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewDormitories_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormDormitories addForm = new AddFormDormitories();
                addForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewFaculties_Click вызывается при нажатии на кнопку "Новая запись"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewFaculties_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormFaculties addForm = new AddFormFaculties();
                addForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewGroups_Click вызывается при нажатии на кнопку "Новая запись"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewGroups_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormGroups addForm = new AddFormGroups();
                addForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewHousingOrders_Click вызывается при нажатии на кнопку "Новая запись"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewHousingOrders_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormHousingOrders addForm = new AddFormHousingOrders();
                addForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewHousingPayments_Click вызывается при нажатии на кнопку "Новая запись"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewHousingPayments_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormHousingPayments addForm = new AddFormHousingPayments();
                addForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewRoomAssignment_Click вызывается при нажатии на кнопку "Новая запись"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewRoomAssignment_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormRoomAssignment addForm = new AddFormRoomAssignment();
                addForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewRooms_Click вызывается при нажатии на кнопку "Новая запись"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewRooms_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormRooms addForm = new AddFormRooms();
                addForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonNewStudents_Click вызывается при нажатии на кнопку "Новая запись"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewStudents_Click(object sender, EventArgs e)
        {
            try
            {
                AddFormStudents addForm = new AddFormStudents();
                addForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// SearchDormitories вызывается при поиске
        /// </summary>
        private void SearchDormitories()
        {
            try
            {
                dataGridViewDormitories.Rows.Clear();
                string searchString = $"select * from Dormitories where concat (DormitoryID, DormitoryName) like '%" + textBoxSearchDormitories.Text + "%'";
                SqlCommand sqlCommand = new SqlCommand(searchString, dataBase.GetConnection());
                dataBase.OpenConnection();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    ReadSingleRow("Dormitories", sqlDataReader);
                }
                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// SearchFaculties вызывается при поиске
        /// </summary>
        private void SearchFaculties()
        {
            try
            {
                dataGridViewFaculties.Rows.Clear();
                string searchString = $"select * from Faculties where concat (FacultyID, FacultyName) like '%" + textBoxSearchFaculties.Text + "%'";
                SqlCommand sqlCommand = new SqlCommand(searchString, dataBase.GetConnection());
                dataBase.OpenConnection();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    ReadSingleRow("Faculties", sqlDataReader);
                }
                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// SearchGroups вызывается при поиске
        /// </summary>
        private void SearchGroups()
        {
            try
            {
                dataGridViewGroups.Rows.Clear();
                string searchString = $"select * from Groups where concat (GroupID, GroupName) like '%" + textBoxSearchGroups.Text + "%'";
                SqlCommand sqlCommand = new SqlCommand(searchString, dataBase.GetConnection());
                dataBase.OpenConnection();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    ReadSingleRow("Groups", sqlDataReader);
                }
                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// SearchHousingOrders вызывается при поиске
        /// </summary>
        private void SearchHousingOrders()
        {
            try
            {
                dataGridViewHousingOrders.Rows.Clear();
                string searchString = $"select * from HousingOrders where concat (OrderID, OrderNumber, FacultyID, StudentID) like '%" + textBoxSearchHousingOrders.Text + "%'";
                SqlCommand sqlCommand = new SqlCommand(searchString, dataBase.GetConnection());
                dataBase.OpenConnection();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    ReadSingleRow("HousingOrders", sqlDataReader);
                }
                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// SearchHousingPayments вызывается при поиске
        /// </summary>
        private void SearchHousingPayments()
        {
            try
            {
                dataGridViewHousingPayments.Rows.Clear();
                string searchString = $"select * from HousingPayments where concat (PaymentID, PaymentDate, PaidAmount, StudentID) like '%" + textBoxSearchHousingPayments.Text + "%'";
                SqlCommand sqlCommand = new SqlCommand(searchString, dataBase.GetConnection());
                dataBase.OpenConnection();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    ReadSingleRow("HousingPayments", sqlDataReader);
                }
                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// SearchRoomAssignment вызывается при поиске
        /// </summary>
        private void SearchRoomAssignment()
        {
            try
            {
                dataGridViewRoomAssignment.Rows.Clear();
                string searchString = $"select * from RoomAssignment where concat (RoomAssignmentID, StudentID, RoomID) like '%" + textBoxSearchRoomAssignment.Text + "%'";
                SqlCommand sqlCommand = new SqlCommand(searchString, dataBase.GetConnection());
                dataBase.OpenConnection();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    ReadSingleRow("RoomAssignment", sqlDataReader);
                }
                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// SearchRooms вызывается при поиске
        /// </summary>
        private void SearchRooms()
        {
            try
            {
                dataGridViewRooms.Rows.Clear();
                string searchString = $"select * from Rooms where concat (RoomID, RoomNumber, Capacity, NumberOfCabinets, NumberOfChairs, AdditionalInfo, DormitoryID) like '%" + textBoxSearchRooms.Text + "%'";
                SqlCommand sqlCommand = new SqlCommand(searchString, dataBase.GetConnection());
                dataBase.OpenConnection();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    ReadSingleRow("Rooms", sqlDataReader);
                }
                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// SearchStudents вызывается при поиске
        /// </summary>
        private void SearchStudents()
        {
            try
            {
                dataGridViewStudents.Rows.Clear();
                string searchString = $"select * from Students where concat (StudentID, FullName, GroupID, FacultyID, PassportNumber) like '%" + textBoxSearchStudents.Text + "%'";
                SqlCommand sqlCommand = new SqlCommand(searchString, dataBase.GetConnection());
                dataBase.OpenConnection();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    ReadSingleRow("Students", sqlDataReader);
                }
                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DeleteRowDormitories вызывается при удалении строки
        /// </summary>
        private void DeleteRowDormitories()
        {
            try
            {
                int index = dataGridViewDormitories.CurrentCell.RowIndex;
                dataGridViewDormitories.Rows[index].Visible = false;
                if (dataGridViewDormitories.Rows[index].Cells[0].Value.ToString() == string.Empty)
                {
                    dataGridViewDormitories.Rows[index].Cells[2].Value = RowState.Deleted;
                    return;
                }
                dataGridViewDormitories.Rows[index].Cells[2].Value = RowState.Deleted;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DeleteRowFaculties вызывается при удалении строки
        /// </summary>
        private void DeleteRowFaculties()
        {
            try
            {
                int index = dataGridViewFaculties.CurrentCell.RowIndex;
                dataGridViewFaculties.Rows[index].Visible = false;
                if (dataGridViewFaculties.Rows[index].Cells[0].Value.ToString() == string.Empty)
                {
                    dataGridViewFaculties.Rows[index].Cells[2].Value = RowState.Deleted;
                    return;
                }
                dataGridViewFaculties.Rows[index].Cells[2].Value = RowState.Deleted;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DeleteRowGroups вызывается при удалении строки
        /// </summary>
        private void DeleteRowGroups()
        {
            try
            {
                int index = dataGridViewGroups.CurrentCell.RowIndex;
                dataGridViewGroups.Rows[index].Visible = false;
                if (dataGridViewGroups.Rows[index].Cells[0].Value.ToString() == string.Empty)
                {
                    dataGridViewGroups.Rows[index].Cells[2].Value = RowState.Deleted;
                    return;
                }
                dataGridViewGroups.Rows[index].Cells[2].Value = RowState.Deleted;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DeleteRowHousingOrders вызывается при удалении строки
        /// </summary>
        private void DeleteRowHousingOrders()
        {
            try
            {
                int index = dataGridViewHousingOrders.CurrentCell.RowIndex;
                dataGridViewHousingOrders.Rows[index].Visible = false;
                if (dataGridViewHousingOrders.Rows[index].Cells[0].Value.ToString() == string.Empty)
                {
                    dataGridViewHousingOrders.Rows[index].Cells[4].Value = RowState.Deleted;
                    return;
                }
                dataGridViewHousingOrders.Rows[index].Cells[4].Value = RowState.Deleted;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DeleteRowHousingPayments вызывается при удалении строки
        /// </summary>
        private void DeleteRowHousingPayments()
        {
            try
            {
                int index = dataGridViewHousingPayments.CurrentCell.RowIndex;
                dataGridViewHousingPayments.Rows[index].Visible = false;
                if (dataGridViewHousingPayments.Rows[index].Cells[0].Value.ToString() == string.Empty)
                {
                    dataGridViewHousingPayments.Rows[index].Cells[4].Value = RowState.Deleted;
                    return;
                }
                dataGridViewHousingPayments.Rows[index].Cells[4].Value = RowState.Deleted;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DeleteRowRoomAssignment вызывается при удалении строки
        /// </summary>
        private void DeleteRowRoomAssignment()
        {
            try
            {
                int index = dataGridViewRoomAssignment.CurrentCell.RowIndex;
                dataGridViewRoomAssignment.Rows[index].Visible = false;
                if (dataGridViewRoomAssignment.Rows[index].Cells[0].Value.ToString() == string.Empty)
                {
                    dataGridViewRoomAssignment.Rows[index].Cells[3].Value = RowState.Deleted;
                    return;
                }
                dataGridViewRoomAssignment.Rows[index].Cells[3].Value = RowState.Deleted;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DeleteRowRooms вызывается при удалении строки
        /// </summary>
        private void DeleteRowRooms()
        {
            try
            {
                int index = dataGridViewRooms.CurrentCell.RowIndex;
                dataGridViewRooms.Rows[index].Visible = false;
                if (dataGridViewRooms.Rows[index].Cells[0].Value.ToString() == string.Empty)
                {
                    dataGridViewRooms.Rows[index].Cells[7].Value = RowState.Deleted;
                    return;
                }
                dataGridViewRooms.Rows[index].Cells[7].Value = RowState.Deleted;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DeleteRowStudents вызывается при удалении строки
        /// </summary>
        private void DeleteRowStudents()
        {
            try
            {
                int index = dataGridViewStudents.CurrentCell.RowIndex;
                dataGridViewStudents.Rows[index].Visible = false;
                if (dataGridViewStudents.Rows[index].Cells[0].Value.ToString() == string.Empty)
                {
                    dataGridViewStudents.Rows[index].Cells[5].Value = RowState.Deleted;
                    return;
                }
                dataGridViewStudents.Rows[index].Cells[5].Value = RowState.Deleted;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// UpdateBaseDormitories вызывается при обновлении
        /// </summary>
        private void UpdateBaseDormitories()
        {
            try
            {
                dataBase.OpenConnection();
                for (int index = 0; index < dataGridViewDormitories.Rows.Count; index++)
                {
                    var rowState = (RowState)dataGridViewDormitories.Rows[index].Cells[2].Value;
                    if (rowState == RowState.Existed)
                    {
                        continue;
                    }
                    if (rowState == RowState.Deleted)
                    {
                        var dormitoryID = Convert.ToInt32(dataGridViewDormitories.Rows[index].Cells[0].Value);
                        var deleteQuery = $"delete from Dormitories where DormitoryID = {dormitoryID}";
                        var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                        sqlCommand.ExecuteNonQuery();
                    }
                    if (rowState == RowState.Modified)
                    {
                        var dormitoryID = dataGridViewDormitories.Rows[index].Cells[0].Value.ToString();
                        var dormitoryName = dataGridViewDormitories.Rows[index].Cells[1].Value.ToString();
                        var changeQuery = $"update Dormitories set DormitoryName = '{dormitoryName}' where DormitoryID = '{dormitoryID}'";
                        var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                dataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// UpdateBaseFaculties вызывается при обновлении
        /// </summary>
        private void UpdateBaseFaculties()
        {
            try
            {
                dataBase.OpenConnection();
                for (int index = 0; index < dataGridViewFaculties.Rows.Count; index++)
                {
                    var rowState = (RowState)dataGridViewFaculties.Rows[index].Cells[2].Value;
                    if (rowState == RowState.Existed)
                    {
                        continue;
                    }
                    if (rowState == RowState.Deleted)
                    {
                        var facultyID = Convert.ToInt32(dataGridViewFaculties.Rows[index].Cells[0].Value);
                        var deleteQuery = $"delete from Faculties where FacultyID = {facultyID}";
                        var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                        sqlCommand.ExecuteNonQuery();
                    }
                    if (rowState == RowState.Modified)
                    {
                        var facultyID = dataGridViewFaculties.Rows[index].Cells[0].Value.ToString();
                        var facultyName = dataGridViewFaculties.Rows[index].Cells[1].Value.ToString();
                        var changeQuery = $"update Faculties set FacultyName = '{facultyName}' where FacultyID = '{facultyID}'";
                        var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                dataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// UpdateBaseGroups вызывается при обновлении
        /// </summary>
        private void UpdateBaseGroups()
        {
            try
            {
                dataBase.OpenConnection();
                for (int index = 0; index < dataGridViewGroups.Rows.Count; index++)
                {
                    var rowState = (RowState)dataGridViewGroups.Rows[index].Cells[2].Value;
                    if (rowState == RowState.Existed)
                    {
                        continue;
                    }
                    if (rowState == RowState.Deleted)
                    {
                        var groupID = Convert.ToInt32(dataGridViewGroups.Rows[index].Cells[0].Value);
                        var deleteQuery = $"delete from Groups where GroupID = {groupID}";
                        var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                        sqlCommand.ExecuteNonQuery();
                    }
                    if (rowState == RowState.Modified)
                    {
                        var groupID = dataGridViewGroups.Rows[index].Cells[0].Value.ToString();
                        var GroupName = dataGridViewGroups.Rows[index].Cells[1].Value.ToString();
                        var changeQuery = $"update Groups set GroupName = '{GroupName}' where GroupID = '{groupID}'";
                        var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                dataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// UpdateBaseHousingOrders вызывается при обновлении
        /// </summary>
        private void UpdateBaseHousingOrders()
        {
            try
            {
                dataBase.OpenConnection();
                for (int index = 0; index < dataGridViewHousingOrders.Rows.Count; index++)
                {
                    var rowState = (RowState)dataGridViewHousingOrders.Rows[index].Cells[4].Value;
                    if (rowState == RowState.Existed)
                    {
                        continue;
                    }
                    if (rowState == RowState.Deleted)
                    {
                        var orderID = Convert.ToInt32(dataGridViewHousingOrders.Rows[index].Cells[0].Value);
                        var deleteQuery = $"delete from HousingOrders where OrderID = {orderID}";
                        var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                        sqlCommand.ExecuteNonQuery();
                    }
                    if (rowState == RowState.Modified)
                    {
                        var orderID = dataGridViewHousingOrders.Rows[index].Cells[0].Value.ToString();
                        var orderNumber = dataGridViewHousingOrders.Rows[index].Cells[1].Value.ToString();
                        var facultyID = dataGridViewHousingOrders.Rows[index].Cells[2].Value.ToString();
                        var studentID = dataGridViewHousingOrders.Rows[index].Cells[3].Value.ToString();
                        var changeQuery = $"update HousingOrders set OrderNumber = '{orderNumber}', FacultyID = '{facultyID}', StudentID = '{studentID}' where OrderID = '{orderID}'";
                        var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                dataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// UpdateBaseHousingPayments вызывается при обновлении
        /// </summary>
        private void UpdateBaseHousingPayments()
        {
            try
            {
                dataBase.OpenConnection();
                for (int index = 0; index < dataGridViewHousingPayments.Rows.Count; index++)
                {
                    var rowState = (RowState)dataGridViewHousingPayments.Rows[index].Cells[4].Value;
                    if (rowState == RowState.Existed)
                    {
                        continue;
                    }
                    if (rowState == RowState.Deleted)
                    {
                        var paymentID = Convert.ToInt32(dataGridViewHousingPayments.Rows[index].Cells[0].Value);
                        var deleteQuery = $"delete from HousingPayments where PaymentID = {paymentID}";
                        var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                        sqlCommand.ExecuteNonQuery();
                    }
                    if (rowState == RowState.Modified)
                    {
                        var paymentID = dataGridViewHousingPayments.Rows[index].Cells[0].Value.ToString();
                        var paymentDate = dataGridViewHousingPayments.Rows[index].Cells[1].Value.ToString();
                        var paidAmount = dataGridViewHousingPayments.Rows[index].Cells[2].Value.ToString();
                        var studentID = dataGridViewHousingPayments.Rows[index].Cells[3].Value.ToString();
                        var changeQuery = $"update HousingPayments set PaymentDate = '{paymentDate}', PaidAmount = '{paidAmount}', StudentID = '{studentID}' where PaymentID = '{paymentID}'";
                        var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                dataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// UpdateBaseRoomAssignment вызывается при обновлении
        /// </summary>
        private void UpdateBaseRoomAssignment()
        {
            try
            {
                dataBase.OpenConnection();
                for (int index = 0; index < dataGridViewRoomAssignment.Rows.Count; index++)
                {
                    var rowState = (RowState)dataGridViewRoomAssignment.Rows[index].Cells[3].Value;
                    if (rowState == RowState.Existed)
                    {
                        continue;
                    }
                    if (rowState == RowState.Deleted)
                    {
                        var roomAssignmentID = Convert.ToInt32(dataGridViewRoomAssignment.Rows[index].Cells[0].Value);
                        var deleteQuery = $"delete from RoomAssignment where RoomAssignmentID = {roomAssignmentID}";
                        var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                        sqlCommand.ExecuteNonQuery();
                    }
                    if (rowState == RowState.Modified)
                    {
                        var roomAssignmentID = dataGridViewRoomAssignment.Rows[index].Cells[0].Value.ToString();
                        var studentID = dataGridViewRoomAssignment.Rows[index].Cells[1].Value.ToString();
                        var roomID = dataGridViewRoomAssignment.Rows[index].Cells[2].Value.ToString();
                        var changeQuery = $"update RoomAssignment set StudentID = '{studentID}', RoomID = '{roomID}' where RoomAssignmentID = '{roomAssignmentID}'";
                        var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                dataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// UpdateBaseRooms вызывается при обновлении
        /// </summary>
        private void UpdateBaseRooms()
        {
            try
            {
                dataBase.OpenConnection();
                for (int index = 0; index < dataGridViewRooms.Rows.Count; index++)
                {
                    var rowState = (RowState)dataGridViewRooms.Rows[index].Cells[7].Value;
                    if (rowState == RowState.Existed)
                    {
                        continue;
                    }
                    if (rowState == RowState.Deleted)
                    {
                        var roomID = Convert.ToInt32(dataGridViewRooms.Rows[index].Cells[0].Value);
                        var deleteQuery = $"delete from Rooms where RoomID = {roomID}";
                        var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                        sqlCommand.ExecuteNonQuery();
                    }
                    if (rowState == RowState.Modified)
                    {
                        var roomID = dataGridViewRooms.Rows[index].Cells[0].Value.ToString();
                        var roomNumber = dataGridViewRooms.Rows[index].Cells[1].Value.ToString();
                        var capacity = dataGridViewRooms.Rows[index].Cells[2].Value.ToString();
                        var numberOfCabinets = dataGridViewRooms.Rows[index].Cells[3].Value.ToString();
                        var numberOfChairs = dataGridViewRooms.Rows[index].Cells[4].Value.ToString();
                        var additionalInfo = dataGridViewRooms.Rows[index].Cells[5].Value.ToString();
                        var dormitoryID = dataGridViewRooms.Rows[index].Cells[6].Value.ToString();
                        var changeQuery = $"update Rooms set RoomNumber = '{roomNumber}', Capacity = '{capacity}', NumberOfCabinets = '{numberOfCabinets}', NumberOfChairs = '{numberOfChairs}', AdditionalInfo = '{additionalInfo}', DormitoryID = '{dormitoryID}' where RoomID = '{roomID}'";
                        var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                dataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// UpdateBaseStudents вызывается при обновлении
        /// </summary>
        private void UpdateBaseStudents()
        {
            try
            {
                dataBase.OpenConnection();
                for (int index = 0; index < dataGridViewStudents.Rows.Count; index++)
                {
                    var rowState = (RowState)dataGridViewStudents.Rows[index].Cells[5].Value;
                    if (rowState == RowState.Existed)
                    {
                        continue;
                    }
                    if (rowState == RowState.Deleted)
                    {
                        var studentID = Convert.ToInt32(dataGridViewStudents.Rows[index].Cells[0].Value);
                        var deleteQuery = $"delete from Students where StudentID = {studentID}";
                        var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                        sqlCommand.ExecuteNonQuery();
                    }
                    if (rowState == RowState.Modified)
                    {
                        var studentID = dataGridViewStudents.Rows[index].Cells[0].Value.ToString();
                        var fullName = dataGridViewStudents.Rows[index].Cells[1].Value.ToString();
                        var groupID = dataGridViewStudents.Rows[index].Cells[2].Value.ToString();
                        var facultyID = dataGridViewStudents.Rows[index].Cells[3].Value.ToString();
                        var passportNumber = dataGridViewStudents.Rows[index].Cells[4].Value.ToString();
                        var changeQuery = $"update Students set FullName = '{fullName}', GroupID = '{groupID}', FacultyID = '{facultyID}', PassportNumber = '{passportNumber}' where StudentID = '{studentID}'";
                        var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                dataBase.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchDormitories_TextChanged вызывается при изменении текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchDormitories_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SearchDormitories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchFaculties_TextChanged вызывается при изменении текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchFaculties_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SearchFaculties();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchGroups_TextChanged вызывается при изменении текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchGroups_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SearchGroups();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchHousingOrders_TextChanged вызывается при изменении текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchHousingOrders_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SearchHousingOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchHousingPayments_TextChanged вызывается при изменении текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchHousingPayments_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SearchHousingPayments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchRoomAssignment_TextChanged вызывается при изменении текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchRoomAssignment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SearchRoomAssignment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchRooms_TextChanged вызывается при изменении текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchRooms_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SearchRooms();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// TextBoxSearchStudents_TextChanged вызывается при изменении текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchStudents_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SearchStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteDormitories_Click вызывается при нажатии кнопки "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteDormitories_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRowDormitories();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteFaculties_Click вызывается при нажатии кнопки "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteFaculties_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRowFaculties();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteGroups_Click вызывается при нажатии кнопки "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteGroups_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRowGroups();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteHousingOrders_Click вызывается при нажатии кнопки "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteHousingOrders_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRowHousingOrders();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteHousingPayments_Click вызывается при нажатии кнопки "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteHousingPayments_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRowHousingPayments();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteRoomAssignment_Click вызывается при нажатии кнопки "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteRoomAssignment_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRowRoomAssignment();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteRooms_Click вызывается при нажатии кнопки "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteRooms_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRowRooms();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteStudents_Click вызывается при нажатии кнопки "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteStudents_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRowStudents();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveDormitories_Click вызывается при нажатии кнопки "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveDormitories_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBaseDormitories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveFaculties_Click вызывается при нажатии кнопки "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveFaculties_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBaseFaculties();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveGroups_Click вызывается при нажатии кнопки "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveGroups_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBaseGroups();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveHousingOrders_Click вызывается при нажатии кнопки "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveHousingOrders_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBaseHousingOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveHousingPayments_Click вызывается при нажатии кнопки "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveHousingPayments_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBaseHousingPayments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveRoomAssignment_Click вызывается при нажатии кнопки "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveRoomAssignment_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBaseRoomAssignment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveRooms_Click вызывается при нажатии кнопки "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveRooms_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBaseRooms();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveStudents_Click вызывается при нажатии кнопки "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveStudents_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBaseStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ChangeDormitories вызывается при изменении данных
        /// </summary>
        private void ChangeDormitories()
        {
            try
            {
                var selectedRowIndex = dataGridViewDormitories.CurrentCell.RowIndex;
                var dormitoryID = textBoxDormitoryID.Text;
                var dormitoryName = textBoxDormitoryName.Text;
                dataGridViewDormitories.Rows[selectedRowIndex].SetValues(dormitoryID, dormitoryName);
                dataGridViewDormitories.Rows[selectedRowIndex].Cells[2].Value = RowState.Modified;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //if (dataGridViewDormitories.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            //{
            //    if (int.TryParse(textBoxPrice.Text, out int price))
            //    {
            //        dataGridViewDormitories.Rows[selectedRowIndex].SetValues(id, naz, quantinity, postavshik, price);
            //        dataGridViewDormitories.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Цена должна иметь числовой формат!");w
            //    }
            //}
        }

        /// <summary>
        /// ChangeFaculties вызывается при изменении данных
        /// </summary>
        private void ChangeFaculties()
        {
            try
            {
                var selectedRowIndex = dataGridViewFaculties.CurrentCell.RowIndex;
                var facultyID = textBoxFacultyID.Text;
                var facultyName = textBoxFacultyName.Text;
                dataGridViewFaculties.Rows[selectedRowIndex].SetValues(facultyID, facultyName);
                dataGridViewFaculties.Rows[selectedRowIndex].Cells[2].Value = RowState.Modified;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ChangeGroups вызывается при изменении данных
        /// </summary>
        private void ChangeGroups()
        {
            try
            {
                var selectedRowIndex = dataGridViewGroups.CurrentCell.RowIndex;
                var groupID = textBoxGroupID.Text;
                var groupName = textBoxGroupName.Text;
                dataGridViewGroups.Rows[selectedRowIndex].SetValues(groupID, groupName);
                dataGridViewGroups.Rows[selectedRowIndex].Cells[2].Value = RowState.Modified;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ChangeHousingOrders вызывается при изменении данных
        /// </summary>
        private void ChangeHousingOrders()
        {
            try
            {
                var selectedRowIndex = dataGridViewHousingOrders.CurrentCell.RowIndex;
                var orderID = textBoxOrderID.Text;
                var orderNumber = textBoxOrderNumber.Text;
                var facultyID = textBoxFacultyIDHousingOrders.Text;
                var studentID = textBoxStudentIDHousingOrders.Text;
                dataGridViewHousingOrders.Rows[selectedRowIndex].SetValues(orderID, orderNumber, facultyID, studentID);
                dataGridViewHousingOrders.Rows[selectedRowIndex].Cells[4].Value = RowState.Modified;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ChangeHousingPayments вызывается при изменении данных
        /// </summary>
        private void ChangeHousingPayments()
        {
            try
            {
                var selectedRowIndex = dataGridViewHousingPayments.CurrentCell.RowIndex;
                var paymentID = textBoxPaymentID.Text;
                var paymentDate = textBoxPaymentDate.Text;
                var paidAmount = textBoxPaidAmount.Text;
                var studentID = textBoxStudentIDHousingPayments.Text;
                dataGridViewHousingPayments.Rows[selectedRowIndex].SetValues(paymentID, paymentDate, paidAmount, studentID);
                dataGridViewHousingPayments.Rows[selectedRowIndex].Cells[4].Value = RowState.Modified;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ChangeRoomAssignment вызывается при изменении данных
        /// </summary>
        private void ChangeRoomAssignment()
        {
            try
            {
                var selectedRowIndex = dataGridViewRoomAssignment.CurrentCell.RowIndex;
                var roomAssignmentID = textBoxRoomAssignmentID.Text;
                var studentID = textBoxStudentIDRoomAssignment.Text;
                var roomID = textBoxRoomIDRoomAssignment.Text;
                dataGridViewRoomAssignment.Rows[selectedRowIndex].SetValues(roomAssignmentID, studentID, roomID);
                dataGridViewRoomAssignment.Rows[selectedRowIndex].Cells[3].Value = RowState.Modified;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ChangeRooms вызывается при изменении данных
        /// </summary>
        private void ChangeRooms()
        {
            try
            {
                var selectedRowIndex = dataGridViewRooms.CurrentCell.RowIndex;
                var roomID = textBoxRoomID.Text;
                var roomNumber = textBoxRoomNumber.Text;
                var capacity = textBoxCapacity.Text;
                var numberOfCabinets = textBoxNumberOfCabinets.Text;
                var numberOfChairs = textBoxNumberOfChairs.Text;
                var additionalInfo = textBoxAdditionalInfo.Text;
                var dormitoryID = textBoxDormitoryIDRooms.Text;
                dataGridViewRooms.Rows[selectedRowIndex].SetValues(roomID, roomNumber, capacity, numberOfCabinets, numberOfChairs, additionalInfo, dormitoryID);
                dataGridViewRooms.Rows[selectedRowIndex].Cells[7].Value = RowState.Modified;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ChangeStudents вызывается при изменении данных
        /// </summary>
        private void ChangeStudents()
        {
            try
            {
                var selectedRowIndex = dataGridViewStudents.CurrentCell.RowIndex;
                var studentID = textBoxStudentID.Text;
                var fullName = textBoxFullName.Text;
                var groupID = textBoxGroupIDStudents.Text;
                var facultyID = textBoxFacultyIDStudents.Text;
                var passportNumber = textBoxPassportNumber.Text;
                dataGridViewStudents.Rows[selectedRowIndex].SetValues(studentID, fullName, groupID, facultyID, passportNumber);
                dataGridViewStudents.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeDormitories_Click вызывается при нажатии на кнопку "Изменить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeDormitories_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeDormitories();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeFaculties_Click вызывается при нажатии на кнопку "Изменить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeFaculties_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeFaculties();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeGroups_Click вызывается при нажатии на кнопку "Изменить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeGroups_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeGroups();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeHousingOrders_Click вызывается при нажатии на кнопку "Изменить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeHousingOrders_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeHousingOrders();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeHousingPayments_Click вызывается при нажатии на кнопку "Изменить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeHousingPayments_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeHousingPayments();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeRoomAssignment_Click вызывается при нажатии на кнопку "Изменить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeRoomAssignment_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeRoomAssignment();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeRooms_Click вызывается при нажатии на кнопку "Изменить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeRooms_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeRooms();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonChangeStudents_Click вызывается при нажатии на кнопку "Изменить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonChangeStudents_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeStudents();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonClear_Click вызывается при нажатии на кнопку "Изменить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}