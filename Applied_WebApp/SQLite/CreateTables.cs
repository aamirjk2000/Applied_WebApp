using System.Data;
using System.Data.SQLite;
using Applied_WebApp.SQLite;

namespace Applied_WebApp.SQLite
{
    public class CreateTables
    {
        internal string[] MyTables;
        private SQLiteConnection MyConnection = CreateDatabase.MyConnection;
        string MyMessage = "";

        string SQL_Users = "CREATE TABLE [Users](" +
                                          "[ID] INTEGER PRIMARY KEY NOT NULL UNIQUE," +
                                          "[UserID] NVARCHAR(100) NOT NULL UNIQUE," +
                                          "[UserEmail] NVARCHAR NOT NULL UNIQUE," +
                                          "[LastLogin] DATETEXT," +
                                          "[Session] NVARCHAR)";

        string AddUser = "INSERT INTO [Users] ([ID], [UserID], [UserEmail]) VALUES (1,'Admin','Admin@jahangir.com')";

        public CreateTables()
        {
            MyTables = new string[] { "Users", "logs" };
        }

        public DataTable GetDataTable(string _TableName)
        {
            DataTable _DataTable = new();
            string _CommandText = "Select * From " + _TableName;
            SQLiteCommand _Command = new(_CommandText, MyConnection);
            SQLiteDataAdapter _Adapter = new(_Command);
            DataSet _DataSet = new();
            _Adapter.Fill(_DataSet, _TableName);
            _DataTable = _DataSet.Tables[0];
            return _DataTable;
        }

        public bool ExistTable(string _TableName)
        {
            MyConnection = CreateDatabase.MyConnection;
            string _CommandText = "select * from sqlite_master where type = 'table' and name = '" + _TableName + "'";
            SQLiteCommand _Command = new(_CommandText, MyConnection);
            if(MyConnection.State != ConnectionState.Open) { MyConnection.Open(); }
            int _Result = _Command.ExecuteNonQuery();
            if (_Result == 1) 
            { 
                return true; 
            } 
            else { 
                return false; 
            }
        }

        public bool CreateTable(string _TableName)
        {
            if(!ExistTable(_TableName))
            {
                string _CommandText = GetCommandText(_TableName);
                ExecuteCommand(_CommandText);

                // Add a Admin user record if table name is Users
                if(_TableName == "Users") { ExecuteCommand(AddUser); }
            }

            return true;
        }

        private string GetCommandText(string _TableName)
        {
            switch (_TableName)
            {
                case "Users":
                    return SQL_Users;

                default:
                    return "";
            }
        }

        public bool ExecuteCommand(string _CommandText)
        {
            bool _Result = false;
            SQLiteCommand _Command = new(_CommandText, MyConnection);
            try
            {
                _Command.ExecuteNonQuery();
                MyMessage = "Table created.";
                _Result = true;
            }
            catch (Exception)
            {
                MyMessage = "Table not created.";
                throw;
            }
            return _Result;
        }

        //-------------------------------------------------eof
    }
}
