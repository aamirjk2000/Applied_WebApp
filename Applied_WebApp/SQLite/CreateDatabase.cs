using System.Data.SQLite;

namespace Applied_WebApp.SQLite
{

    public class CreateDatabase
    {
        public static SQLiteConnection MyConnection { get => AppliedConnection(DB_File()); }
        public bool DBFile_Exist = false;
        public string MyMessage = "No Message";

        public CreateDatabase()
        {
            if(File.Exists(DB_File())) { DBFile_Exist=true; }
        }

        public static string DB_File()
        {
            return ".\\Data\\AppliedDB.sqlite3";
        }
        public bool CreateAppliedDB()
        {
            string _DB_File = DB_File();

            if (!File.Exists(_DB_File))
            {
                SQLiteConnection.CreateFile(_DB_File);
                return true;
            }
            else
            {
                return false;
            }
        }


        public static SQLiteConnection AppliedConnection(string _DB_File)
        {
            if(File.Exists(DB_File()))
            {
                SQLiteConnection _Connection = new("Data Source =" + _DB_File);
                _Connection.Open();
                return _Connection;
            }
            return new SQLiteConnection();
        }
    }
}
