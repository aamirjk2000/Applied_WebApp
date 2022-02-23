using System.Data.SQLite;

namespace Applied_WebApp.SQLite
{
    interface ICreateDatabase
    {
        public SQLiteConnection DefaultConnection();

    }

    public class CreateDatabase : ICreateDatabase
    {
        public static SQLiteConnection MyConnection { get => AppliedConnection(DB_File()); }
        //private string DB_File = "";
        public string MyMessage = "No Message";

        public CreateDatabase()
        {
            CreateAppliedDB();
        }

        public static string DB_File()
        {
            return ".\\Data\\AppliedDB.sqlite3";
        }
        private void CreateAppliedDB()
        {
            MyMessage = "Connection has been established";
            if (!File.Exists(DB_File())) { SQLiteConnection.CreateFile(DB_File()); MyMessage = "Database created."; }
        }

        public SQLiteConnection DefaultConnection()
        {
            if (MyConnection.State != System.Data.ConnectionState.Open)
            {
                MyConnection.Open();
            }
            return MyConnection;
        }

        public static SQLiteConnection AppliedConnection(string _DB_File)
        {
            return new SQLiteConnection("Data Source =" + _DB_File);
        }
    }
}
