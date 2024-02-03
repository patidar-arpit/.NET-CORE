using System.Text;

namespace FILEHANDLING_EXAMPLES
{
    internal class Program
    {
        static List<Employee> lstEmp = new List<Employee>();
        public static void AddRecs()
        {


            lstEmp.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vishal", Basic = 11000, DeptNo = 10, Gender = "M" });

            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "F" });

            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });

            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
        }

        static void Main(string[] args)
        {
            // AddRecs();

            //  SaveInFileUnformattedData();
            //  ReadFromFileUnformattedData();
            //  SaveInFileFormattedData();
            //  ReadFromFileFormattedData();

            SaveInFileBinaryFormat();
            ReadFromFileBinaryFormat();

        }

        private static void ReadFromFileBinaryFormat()
        {

           

            BinaryReader bw = new BinaryReader(File.Open("D:\\test3.oat", FileMode.Open));

            string s = bw.ReadString();
            int x = bw.ReadInt32();
            bool b = bw.ReadBoolean();

            Console.WriteLine(s);
            Console.WriteLine(x);
            Console.WriteLine(b);

            bw.Close();

        }

        private static void SaveInFileBinaryFormat()
        {
            string s = "Hello";
            int x = 100;
            bool b = false;


            BinaryWriter bw = new BinaryWriter(File.Open("D:\\test3.oat", FileMode.Create));
            bw.Write(s);
            bw.Write(x);
            bw.Write(b);
            
            bw.Close();


        }

        private static void ReadFromFileFormattedData()
        {
            StreamReader reader = File.OpenText("D:\\test2.txt");
            string s;
            while ( (s = reader.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }

            reader.Close();
        }

        private static void SaveInFileFormattedData()
        {
            // in this we do not have to convert into bytes implictly it is done automaticaaly

            StreamWriter writer = File.CreateText("D:\\test2.txt");
            writer.WriteLine("Hello Arpit");
            writer.WriteLine("Good Morning");
            writer.WriteLine("How are you?");
            writer.WriteLine("Done..!");

            writer.Close();

        }

        private static void SaveInFileUnformattedData()
        {

            // using unformatted data
            string s = "Hello World";


            byte[] arr = Encoding.Default.GetBytes(s);

            FileStream stream = File.Open("D:\\test1.txt", FileMode.Create);
            stream.Write(arr, 0, arr.Length);

            stream.Close();

        }

        private static void ReadFromFileUnformattedData()
        {

           
            FileStream stream = File.Open("D:\\test1.txt",FileMode.Open);

            byte[] arr = new byte[stream.Length];
            
            stream.Read(arr, 0, arr.Length );

           
            string res = Encoding.Default.GetString(arr);

            Console.WriteLine(res);


            stream.Close();

        }
    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }
        public override string ToString()
        {
            string s = Name + "," + EmpNo.ToString() + "," + Basic.ToString() + "," + DeptNo.ToString();
            return s;
        }
    }
}