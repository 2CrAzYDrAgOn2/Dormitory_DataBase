using System.Data.SqlClient;

namespace test_DataBase
{
    internal class DataBase
    {
        private readonly SqlConnection sqlConnection = new SqlConnection(@"Data Source=MS-SQL\SQLEXPRESS;Initial Catalog=DormitoryGus;Integrated Security=True");

        /// <summary>
        /// OpenConnection вызывается при открытии соединения с базой данных
        /// </summary>
        public void OpenConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        /// <summary>
        /// CloseConnection вызывается при закрытии соединения с базой данных
        /// </summary>
        public void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        /// <summary>
        /// GetConnection вызывается при получении соединения с базой данных
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
    }
}