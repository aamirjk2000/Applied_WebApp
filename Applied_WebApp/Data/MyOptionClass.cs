namespace Applied_WebApp.Data
{
    public class MyOptionClass
    {
        public static MyOptionRecord GetMyRecord()
        {
            MyOptionRecord MyRecord = new();
            MyRecord.Name = "Muhammad Aamir Jahangir";
            MyRecord.FName = "Muhammad Jahangir Khan";
            MyRecord.DOB = new DateTime(1968, 4, 1);
            MyRecord.Address = "Flat # 105, 106, Ellahabad Terrace, Block 14, FB Area, Karachi.";
            MyRecord.Phone = "+92 (336) 24 54 230";
            return MyRecord;
        }
    }
}
