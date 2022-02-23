using System.Data;
using System.Data.SQLite;
using Applied_WebApp.SQLite;

namespace Applied_WebApp.SQLite
{
    public class CreateTables
    {
        private string[] MyTables;
        private DataTable MyDataTable;
        private SQLiteConnection MyConnection = CreateDatabase.MyConnection;

        public CreateTables()
        {
            MyTables =  { "Users", "Logs"};

        }

        public DataTable GetDataTable(string _TableName)
        {
            string _CommandText = "Select * From " + _TableName ;
            SQLiteCommand cmd = new SQLiteCommand("", MyConnection);


        }





    }
}
