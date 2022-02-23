namespace Applied_WebApp.Data
{
    public class MyOptionRecord
    {
        public MyOptionRecord()
        {
            Name = "";
            FName = "";
            DOB = new DateTime(1950, 1, 1);
            Address = "";
            Phone = "";
        }

        public string Name { get; set; }
        public string FName { get; set; }  
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
