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
        /// CreateColumns вызывается при создании колонок
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
        /// CreateColumns вызывается при очистке полей
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
        /// ReadSingleRow вызывается при чтении строк
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="iDataRecord"></param>
        private void ReadSingleRow(DataGridView dataGridView, IDataRecord iDataRecord)
        {
            try
            {
                switch (dataGridView.Name)
                {
                    case "dataGridViewDormitories":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), RowState.Modified);
                        break;

                    case "dataGridViewFaculties":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), RowState.Modified);
                        break;

                    case "dataGridViewGroups":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), RowState.Modified);
                        break;

                    case "dataGridViewHousingOrders":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.GetInt32(2), iDataRecord.GetInt32(3), RowState.Modified);
                        break;

                    case "dataGridViewHousingPayments":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetDateTime(1), iDataRecord.GetInt32(2), iDataRecord.GetInt32(3), RowState.Modified);
                        break;

                    case "dataGridViewRoomAssignment":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetInt32(1), iDataRecord.GetInt32(2), RowState.Modified);
                        break;

                    case "dataGridViewRooms":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.GetInt32(2), iDataRecord.GetInt32(3), iDataRecord.GetInt32(4), iDataRecord.GetString(5), iDataRecord.GetInt32(6), RowState.Modified);
                        break;

                    case "dataGridViewStudents":
                        dataGridView.Rows.Add(iDataRecord.GetInt32(0), iDataRecord.GetString(1), iDataRecord.GetInt32(2), iDataRecord.GetInt32(3), iDataRecord.GetString(4), RowState.Modified);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// RefreshDataGrid вызывается при обновлении dataGridView
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
                    ReadSingleRow(dataGridView, sqlDataReader);
                }
                sqlDataReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Form1_Load вызывается при загрузке формы "Form1"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// DataGridView_CellClick вызывается при нажатии на ячейку в DataGridView
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="selectedRow"></param>
        private void DataGridView_CellClick(DataGridView dataGridView, int selectedRow)
        {
            try
            {
                DataGridViewRow dataGridViewRow = dataGridView.Rows[selectedRow];
                switch (dataGridView.Name)
                {
                    case "dataGridViewDormitories":
                        textBoxDormitoryID.Text = dataGridViewRow.Cells[0].Value.ToString();
                        textBoxDormitoryName.Text = dataGridViewRow.Cells[1].Value.ToString();
                        break;

                    case "dataGridViewFaculties":
                        textBoxFacultyID.Text = dataGridViewRow.Cells[0].Value.ToString();
                        textBoxFacultyName.Text = dataGridViewRow.Cells[1].Value.ToString();
                        break;

                    case "dataGridViewGroups":
                        textBoxGroupID.Text = dataGridViewRow.Cells[0].Value.ToString();
                        textBoxGroupName.Text = dataGridViewRow.Cells[1].Value.ToString();
                        break;

                    case "dataGridViewHousingOrders":
                        textBoxOrderID.Text = dataGridViewRow.Cells[0].Value.ToString();
                        textBoxOrderNumber.Text = dataGridViewRow.Cells[1].Value.ToString();
                        textBoxFacultyIDHousingOrders.Text = dataGridViewRow.Cells[2].Value.ToString();
                        textBoxStudentIDHousingOrders.Text = dataGridViewRow.Cells[3].Value.ToString();
                        break;

                    case "dataGridViewHousingPayments":
                        textBoxPaymentID.Text = dataGridViewRow.Cells[0].Value.ToString();
                        textBoxPaymentDate.Text = dataGridViewRow.Cells[1].Value.ToString();
                        textBoxPaidAmount.Text = dataGridViewRow.Cells[2].Value.ToString();
                        textBoxStudentIDHousingPayments.Text = dataGridViewRow.Cells[3].Value.ToString();
                        break;

                    case "dataGridViewRoomAssignment":
                        textBoxRoomAssignmentID.Text = dataGridViewRow.Cells[0].Value.ToString();
                        textBoxStudentIDRoomAssignment.Text = dataGridViewRow.Cells[1].Value.ToString();
                        textBoxRoomIDRoomAssignment.Text = dataGridViewRow.Cells[2].Value.ToString();
                        break;

                    case "dataGridViewRooms":
                        textBoxRoomID.Text = dataGridViewRow.Cells[0].Value.ToString();
                        textBoxRoomNumber.Text = dataGridViewRow.Cells[1].Value.ToString();
                        textBoxCapacity.Text = dataGridViewRow.Cells[2].Value.ToString();
                        textBoxNumberOfCabinets.Text = dataGridViewRow.Cells[3].Value.ToString();
                        textBoxNumberOfChairs.Text = dataGridViewRow.Cells[4].Value.ToString();
                        textBoxAdditionalInfo.Text = dataGridViewRow.Cells[5].Value.ToString();
                        textBoxDormitoryIDRooms.Text = dataGridViewRow.Cells[6].Value.ToString();
                        break;

                    case "dataGridViewStudents":
                        textBoxStudentID.Text = dataGridViewRow.Cells[0].Value.ToString();
                        textBoxFullName.Text = dataGridViewRow.Cells[1].Value.ToString();
                        textBoxGroupIDStudents.Text = dataGridViewRow.Cells[2].Value.ToString();
                        textBoxFacultyIDStudents.Text = dataGridViewRow.Cells[3].Value.ToString();
                        textBoxPassportNumber.Text = dataGridViewRow.Cells[4].Value.ToString();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Search вызывается при поиске данных в DataGridView
        /// </summary>
        /// <param name="dataGridView"></param>
        private void Search(DataGridView dataGridView)
        {
            try
            {
                dataGridView.Rows.Clear();
                switch (dataGridView.Name)
                {
                    case "dataGridViewDormitories":
                        string searchStringDormitories = $"select * from Dormitories where concat (DormitoryID, DormitoryName) like '%" + textBoxSearchDormitories.Text + "%'";
                        SqlCommand sqlCommandDormitories = new SqlCommand(searchStringDormitories, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader sqlDataReaderDormitories = sqlCommandDormitories.ExecuteReader();
                        while (sqlDataReaderDormitories.Read())
                        {
                            ReadSingleRow(dataGridView, sqlDataReaderDormitories);
                        }
                        sqlDataReaderDormitories.Close();
                        break;

                    case "dataGridViewFaculties":
                        string searchStringFaculties = $"select * from Faculties where concat (FacultyID, FacultyName) like '%" + textBoxSearchFaculties.Text + "%'";
                        SqlCommand sqlCommandFaculties = new SqlCommand(searchStringFaculties, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader sqlDataReaderFaculties = sqlCommandFaculties.ExecuteReader();
                        while (sqlDataReaderFaculties.Read())
                        {
                            ReadSingleRow(dataGridView, sqlDataReaderFaculties);
                        }
                        sqlDataReaderFaculties.Close();
                        break;

                    case "dataGridViewGroups":
                        string searchStringGroups = $"select * from Groups where concat (GroupID, GroupName) like '%" + textBoxSearchGroups.Text + "%'";
                        SqlCommand sqlCommandGroups = new SqlCommand(searchStringGroups, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader sqlDataReaderGroups = sqlCommandGroups.ExecuteReader();
                        while (sqlDataReaderGroups.Read())
                        {
                            ReadSingleRow(dataGridView, sqlDataReaderGroups);
                        }
                        sqlDataReaderGroups.Close();
                        break;

                    case "dataGridViewHousingOrders":
                        string searchStringHousingOrders = $"select * from HousingOrders where concat (OrderID, OrderNumber, FacultyID, StudentID) like '%" + textBoxSearchHousingOrders.Text + "%'";
                        SqlCommand sqlCommandHousingOrders = new SqlCommand(searchStringHousingOrders, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader sqlDataReaderHousingOrders = sqlCommandHousingOrders.ExecuteReader();
                        while (sqlDataReaderHousingOrders.Read())
                        {
                            ReadSingleRow(dataGridView, sqlDataReaderHousingOrders);
                        }
                        sqlDataReaderHousingOrders.Close();
                        break;

                    case "dataGridViewHousingPayments":
                        string searchStringHousingPayments = $"select * from HousingPayments where concat (PaymentID, PaymentDate, PaidAmount, StudentID) like '%" + textBoxSearchHousingPayments.Text + "%'";
                        SqlCommand sqlCommandHousingPayments = new SqlCommand(searchStringHousingPayments, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader sqlDataReaderHousingPayments = sqlCommandHousingPayments.ExecuteReader();
                        while (sqlDataReaderHousingPayments.Read())
                        {
                            ReadSingleRow(dataGridView, sqlDataReaderHousingPayments);
                        }
                        sqlDataReaderHousingPayments.Close();
                        break;

                    case "dataGridViewRoomAssignment":
                        string searchStringRoomAssignment = $"select * from RoomAssignment where concat (RoomAssignmentID, StudentID, RoomID) like '%" + textBoxSearchRoomAssignment.Text + "%'";
                        SqlCommand sqlCommandRoomAssignment = new SqlCommand(searchStringRoomAssignment, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader sqlDataReaderRoomAssignment = sqlCommandRoomAssignment.ExecuteReader();
                        while (sqlDataReaderRoomAssignment.Read())
                        {
                            ReadSingleRow(dataGridView, sqlDataReaderRoomAssignment);
                        }
                        sqlDataReaderRoomAssignment.Close();
                        break;

                    case "dataGridViewRooms":
                        string searchStringRooms = $"select * from Rooms where concat (RoomID, RoomNumber, Capacity, NumberOfCabinets, NumberOfChairs, AdditionalInfo, DormitoryID) like '%" + textBoxSearchRooms.Text + "%'";
                        SqlCommand sqlCommandRooms = new SqlCommand(searchStringRooms, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader sqlDataReaderRooms = sqlCommandRooms.ExecuteReader();
                        while (sqlDataReaderRooms.Read())
                        {
                            ReadSingleRow(dataGridView, sqlDataReaderRooms);
                        }
                        sqlDataReaderRooms.Close();
                        break;

                    case "dataGridViewStudents":
                        string searchStringStudents = $"select * from Students where concat (StudentID, FullName, GroupID, FacultyID, PassportNumber) like '%" + textBoxSearchStudents.Text + "%'";
                        SqlCommand sqlCommandStudents = new SqlCommand(searchStringStudents, dataBase.GetConnection());
                        dataBase.OpenConnection();
                        SqlDataReader sqlDataReaderStudents = sqlCommandStudents.ExecuteReader();
                        while (sqlDataReaderStudents.Read())
                        {
                            ReadSingleRow(dataGridView, sqlDataReaderStudents);
                        }
                        sqlDataReaderStudents.Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// DeleteRow вызывается при удалении строки
        /// </summary>
        /// <param name="dataGridView"></param>
        private void DeleteRow(DataGridView dataGridView)
        {
            try
            {
                int index = dataGridView.CurrentCell.RowIndex;
                dataGridView.Rows[index].Visible = false;
                switch (dataGridView.Name)
                {
                    case "dataGridViewDormitories":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[2].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[2].Value = RowState.Deleted;
                        break;

                    case "dataGridViewFaculties":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[2].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[2].Value = RowState.Deleted;
                        break;

                    case "dataGridViewGroups":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[2].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[2].Value = RowState.Deleted;
                        break;

                    case "dataGridViewHousingOrders":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[4].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[4].Value = RowState.Deleted;
                        break;

                    case "dataGridViewHousingPayments":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[4].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[4].Value = RowState.Deleted;
                        break;

                    case "dataGridViewRoomAssignment":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[3].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[3].Value = RowState.Deleted;
                        break;

                    case "dataGridViewRooms":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[7].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[7].Value = RowState.Deleted;
                        break;

                    case "dataGridViewStudents":
                        if (dataGridView.Rows[index].Cells[0].Value.ToString() == string.Empty)
                        {
                            dataGridView.Rows[index].Cells[5].Value = RowState.Deleted;
                            return;
                        }
                        dataGridView.Rows[index].Cells[5].Value = RowState.Deleted;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// UpdateBase вызывается при обновлении базы данных
        /// </summary>
        /// <param name="dataGridView"></param>
        private void UpdateBase(DataGridView dataGridView)
        {
            try
            {
                dataBase.OpenConnection();
                for (int index = 0; index < dataGridView.Rows.Count; index++)
                {
                    switch (dataGridView.Name)
                    {
                        case "dataGridViewDormitories":
                            var rowStateDormitories = (RowState)dataGridView.Rows[index].Cells[2].Value;
                            if (rowStateDormitories == RowState.Existed)
                            {
                                continue;
                            }
                            if (rowStateDormitories == RowState.Deleted)
                            {
                                var dormitoryID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"delete from Dormitories where DormitoryID = {dormitoryID}";
                                var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rowStateDormitories == RowState.Modified)
                            {
                                var dormitoryID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var dormitoryName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var changeQuery = $"update Dormitories set DormitoryName = '{dormitoryName}' where DormitoryID = '{dormitoryID}'";
                                var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            break;

                        case "dataGridViewFaculties":
                            var rowStateFaculties = (RowState)dataGridView.Rows[index].Cells[2].Value;
                            if (rowStateFaculties == RowState.Existed)
                            {
                                continue;
                            }
                            if (rowStateFaculties == RowState.Deleted)
                            {
                                var facultyID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"delete from Faculties where FacultyID = {facultyID}";
                                var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rowStateFaculties == RowState.Modified)
                            {
                                var facultyID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var facultyName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var changeQuery = $"update Faculties set FacultyName = '{facultyName}' where FacultyID = '{facultyID}'";
                                var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            break;

                        case "dataGridViewGroups":
                            var rowStateGroups = (RowState)dataGridView.Rows[index].Cells[2].Value;
                            if (rowStateGroups == RowState.Existed)
                            {
                                continue;
                            }
                            if (rowStateGroups == RowState.Deleted)
                            {
                                var groupID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"delete from Groups where GroupID = {groupID}";
                                var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rowStateGroups == RowState.Modified)
                            {
                                var groupID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var GroupName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var changeQuery = $"update Groups set GroupName = '{GroupName}' where GroupID = '{groupID}'";
                                var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            break;

                        case "dataGridViewHousingOrders":
                            var rowStateHousingOrders = (RowState)dataGridView.Rows[index].Cells[4].Value;
                            if (rowStateHousingOrders == RowState.Existed)
                            {
                                continue;
                            }
                            if (rowStateHousingOrders == RowState.Deleted)
                            {
                                var orderID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"delete from HousingOrders where OrderID = {orderID}";
                                var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rowStateHousingOrders == RowState.Modified)
                            {
                                var orderID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var orderNumber = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var facultyID = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var studentID = dataGridView.Rows[index].Cells[3].Value.ToString();
                                var changeQuery = $"update HousingOrders set OrderNumber = '{orderNumber}', FacultyID = '{facultyID}', StudentID = '{studentID}' where OrderID = '{orderID}'";
                                var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            break;

                        case "dataGridViewHousingPayments":
                            var rowStateHousingPayments = (RowState)dataGridView.Rows[index].Cells[4].Value;
                            if (rowStateHousingPayments == RowState.Existed)
                            {
                                continue;
                            }
                            if (rowStateHousingPayments == RowState.Deleted)
                            {
                                var paymentID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"delete from HousingPayments where PaymentID = {paymentID}";
                                var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rowStateHousingPayments == RowState.Modified)
                            {
                                var paymentID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var paymentDate = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var paidAmount = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var studentID = dataGridView.Rows[index].Cells[3].Value.ToString();
                                var changeQuery = $"update HousingPayments set PaymentDate = '{paymentDate}', PaidAmount = '{paidAmount}', StudentID = '{studentID}' where PaymentID = '{paymentID}'";
                                var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            break;

                        case "dataGridViewRoomAssignment":
                            var rowStateRoomAssignment = (RowState)dataGridView.Rows[index].Cells[3].Value;
                            if (rowStateRoomAssignment == RowState.Existed)
                            {
                                continue;
                            }
                            if (rowStateRoomAssignment == RowState.Deleted)
                            {
                                var roomAssignmentID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"delete from RoomAssignment where RoomAssignmentID = {roomAssignmentID}";
                                var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rowStateRoomAssignment == RowState.Modified)
                            {
                                var roomAssignmentID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var studentID = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var roomID = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var changeQuery = $"update RoomAssignment set StudentID = '{studentID}', RoomID = '{roomID}' where RoomAssignmentID = '{roomAssignmentID}'";
                                var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            break;

                        case "dataGridViewRooms":
                            var rowStateRooms = (RowState)dataGridView.Rows[index].Cells[7].Value;
                            if (rowStateRooms == RowState.Existed)
                            {
                                continue;
                            }
                            if (rowStateRooms == RowState.Deleted)
                            {
                                var roomID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"delete from Rooms where RoomID = {roomID}";
                                var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rowStateRooms == RowState.Modified)
                            {
                                var roomID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var roomNumber = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var capacity = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var numberOfCabinets = dataGridView.Rows[index].Cells[3].Value.ToString();
                                var numberOfChairs = dataGridView.Rows[index].Cells[4].Value.ToString();
                                var additionalInfo = dataGridView.Rows[index].Cells[5].Value.ToString();
                                var dormitoryID = dataGridView.Rows[index].Cells[6].Value.ToString();
                                var changeQuery = $"update Rooms set RoomNumber = '{roomNumber}', Capacity = '{capacity}', NumberOfCabinets = '{numberOfCabinets}', NumberOfChairs = '{numberOfChairs}', AdditionalInfo = '{additionalInfo}', DormitoryID = '{dormitoryID}' where RoomID = '{roomID}'";
                                var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            break;

                        case "dataGridViewStudents":
                            var rowStateStudents = (RowState)dataGridView.Rows[index].Cells[5].Value;
                            if (rowStateStudents == RowState.Existed)
                            {
                                continue;
                            }
                            if (rowStateStudents == RowState.Deleted)
                            {
                                var studentID = Convert.ToInt32(dataGridView.Rows[index].Cells[0].Value);
                                var deleteQuery = $"delete from Students where StudentID = {studentID}";
                                var sqlCommand = new SqlCommand(deleteQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            if (rowStateStudents == RowState.Modified)
                            {
                                var studentID = dataGridView.Rows[index].Cells[0].Value.ToString();
                                var fullName = dataGridView.Rows[index].Cells[1].Value.ToString();
                                var groupID = dataGridView.Rows[index].Cells[2].Value.ToString();
                                var facultyID = dataGridView.Rows[index].Cells[3].Value.ToString();
                                var passportNumber = dataGridView.Rows[index].Cells[4].Value.ToString();
                                var changeQuery = $"update Students set FullName = '{fullName}', GroupID = '{groupID}', FacultyID = '{facultyID}', PassportNumber = '{passportNumber}' where StudentID = '{studentID}'";
                                var sqlCommand = new SqlCommand(changeQuery, dataBase.GetConnection());
                                sqlCommand.ExecuteNonQuery();
                            }
                            break;
                    }
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

        /// <summary>
        /// Change вызывается при изменении данных в базе данных
        /// </summary>
        /// <param name="dataGridView"></param>
        private void Change(DataGridView dataGridView)
        {
            try
            {
                var selectedRowIndex = dataGridView.CurrentCell.RowIndex;
                switch (dataGridView.Name)
                {
                    case "dataGridViewDormitories":
                        var dormitoryID = textBoxDormitoryID.Text;
                        var dormitoryName = textBoxDormitoryName.Text;
                        dataGridView.Rows[selectedRowIndex].SetValues(dormitoryID, dormitoryName);
                        dataGridView.Rows[selectedRowIndex].Cells[2].Value = RowState.Modified;
                        break;

                    case "dataGridViewFaculties":
                        var facultyID = textBoxFacultyID.Text;
                        var facultyName = textBoxFacultyName.Text;
                        dataGridView.Rows[selectedRowIndex].SetValues(facultyID, facultyName);
                        dataGridView.Rows[selectedRowIndex].Cells[2].Value = RowState.Modified;
                        break;

                    case "dataGridViewGroups":
                        var groupID = textBoxGroupID.Text;
                        var groupName = textBoxGroupName.Text;
                        dataGridView.Rows[selectedRowIndex].SetValues(groupID, groupName);
                        dataGridView.Rows[selectedRowIndex].Cells[2].Value = RowState.Modified;
                        break;

                    case "dataGridViewHousingOrders":
                        var orderID = textBoxOrderID.Text;
                        var orderNumber = textBoxOrderNumber.Text;
                        var facultyIDHousingOrders = textBoxFacultyIDHousingOrders.Text;
                        var studentIDHousingOrders = textBoxStudentIDHousingOrders.Text;
                        dataGridView.Rows[selectedRowIndex].SetValues(orderID, orderNumber, facultyIDHousingOrders, studentIDHousingOrders);
                        dataGridView.Rows[selectedRowIndex].Cells[4].Value = RowState.Modified;
                        break;

                    case "dataGridViewHousingPayments":
                        var paymentID = textBoxPaymentID.Text;
                        var paymentDate = textBoxPaymentDate.Text;
                        var paidAmount = textBoxPaidAmount.Text;
                        var studentIDHousingPayments = textBoxStudentIDHousingPayments.Text;
                        dataGridView.Rows[selectedRowIndex].SetValues(paymentID, paymentDate, paidAmount, studentIDHousingPayments);
                        dataGridView.Rows[selectedRowIndex].Cells[4].Value = RowState.Modified;
                        break;

                    case "dataGridViewRoomAssignment":
                        var roomAssignmentID = textBoxRoomAssignmentID.Text;
                        var studentIDRoomAssignment = textBoxStudentIDRoomAssignment.Text;
                        var roomIDRoomAssignment = textBoxRoomIDRoomAssignment.Text;
                        dataGridView.Rows[selectedRowIndex].SetValues(roomAssignmentID, studentIDRoomAssignment, roomIDRoomAssignment);
                        dataGridView.Rows[selectedRowIndex].Cells[3].Value = RowState.Modified;
                        break;

                    case "dataGridViewRooms":
                        var roomID = textBoxRoomID.Text;
                        var roomNumber = textBoxRoomNumber.Text;
                        var capacity = textBoxCapacity.Text;
                        var numberOfCabinets = textBoxNumberOfCabinets.Text;
                        var numberOfChairs = textBoxNumberOfChairs.Text;
                        var additionalInfo = textBoxAdditionalInfo.Text;
                        var dormitoryIDRooms = textBoxDormitoryIDRooms.Text;
                        dataGridView.Rows[selectedRowIndex].SetValues(roomID, roomNumber, capacity, numberOfCabinets, numberOfChairs, additionalInfo, dormitoryIDRooms);
                        dataGridView.Rows[selectedRowIndex].Cells[7].Value = RowState.Modified;
                        break;

                    case "dataGridViewStudents":
                        var studentID = textBoxStudentID.Text;
                        var fullName = textBoxFullName.Text;
                        var groupIDStudents = textBoxGroupIDStudents.Text;
                        var facultyIDStudents = textBoxFacultyIDStudents.Text;
                        var passportNumber = textBoxPassportNumber.Text;
                        dataGridView.Rows[selectedRowIndex].SetValues(studentID, fullName, groupIDStudents, facultyIDStudents, passportNumber);
                        dataGridView.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
                        break;
                }
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
                    DataGridView_CellClick(dataGridViewDormitories, selectedRow);
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
                    DataGridView_CellClick(dataGridViewFaculties, selectedRow);
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
                    DataGridView_CellClick(dataGridViewGroups, selectedRow);
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
                    DataGridView_CellClick(dataGridViewHousingOrders, selectedRow);
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
                    DataGridView_CellClick(dataGridViewHousingPayments, selectedRow);
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
                    DataGridView_CellClick(dataGridViewRoomAssignment, selectedRow);
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
                    DataGridView_CellClick(dataGridViewRooms, selectedRow);
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
                    DataGridView_CellClick(dataGridViewStudents, selectedRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonRefresh_Click вызывается при нажатии на кнопку обновления
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
        /// TextBoxSearchDormitories_TextChanged вызывается при изменении текста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxSearchDormitories_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Search(dataGridViewDormitories);
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
                Search(dataGridViewFaculties);
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
                Search(dataGridViewGroups);
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
                Search(dataGridViewHousingOrders);
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
                Search(dataGridViewHousingPayments);
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
                Search(dataGridViewRoomAssignment);
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
                Search(dataGridViewRooms);
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
                Search(dataGridViewStudents);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteDormitories_Click вызывается при нажатии на кнопку "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteDormitories_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewDormitories);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteFaculties_Click вызывается при нажатии на кнопку "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteFaculties_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewFaculties);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteGroups_Click вызывается при нажатии на кнопку "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteGroups_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewGroups);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteHousingOrders_Click вызывается при нажатии на кнопку "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteHousingOrders_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewHousingOrders);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteHousingPayments_Click вызывается при нажатии на кнопку "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteHousingPayments_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewHousingPayments);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteRoomAssignment_Click вызывается при нажатии на кнопку "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteRoomAssignment_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewRoomAssignment);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteRooms_Click вызывается при нажатии на кнопку "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteRooms_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewRooms);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonDeleteStudents_Click вызывается при нажатии на кнопку "Удалить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteStudents_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRow(dataGridViewStudents);
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveDormitories_Click вызывается при нажатии на кнопку "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveDormitories_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBase(dataGridViewDormitories);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveFaculties_Click вызывается при нажатии на кнопку "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveFaculties_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBase(dataGridViewFaculties);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveGroups_Click вызывается при нажатии на кнопку "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveGroups_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBase(dataGridViewGroups);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveHousingOrders_Click вызывается при нажатии на кнопку "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveHousingOrders_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBase(dataGridViewHousingOrders);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveHousingPayments_Click вызывается при нажатии на кнопку "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveHousingPayments_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBase(dataGridViewHousingPayments);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveRoomAssignment_Click вызывается при нажатии на кнопку "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveRoomAssignment_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBase(dataGridViewRoomAssignment);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveRooms_Click вызывается при нажатии на кнопку "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveRooms_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBase(dataGridViewRooms);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ButtonSaveStudents_Click вызывается при нажатии на кнопку "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveStudents_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateBase(dataGridViewStudents);
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
                Change(dataGridViewDormitories);
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
                Change(dataGridViewFaculties);
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
                Change(dataGridViewGroups);
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
                Change(dataGridViewHousingOrders);
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
                Change(dataGridViewHousingPayments);
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
                Change(dataGridViewRoomAssignment);
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
                Change(dataGridViewRooms);
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
                Change(dataGridViewStudents);
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