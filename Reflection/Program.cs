using System.Reflection;

namespace Reflection
{
    public class Program
    {
        public static void Main()
        {
            DisplayPublicProperties(new Student("Amanda", "Let's Code", 25));
            Console.WriteLine();
            CreateInstance("Amanda", "Let's Code", 25);
        }

        public static void DisplayPublicProperties(Object obj)
        {
            foreach (var property in typeof(Student).GetProperties())
            {
                var pName = property.Name;
                var pValue = property.GetValue(obj);
                Console.WriteLine($"{pName}: {pValue}");
            }
        }

        public static void CreateInstance(string pName, string pUniversity, int pRollNumber)
        {
            var assembly = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var property in assembly)
            {
                if (property.Name == "Student")
                {
                    var obj = (Student)Activator.CreateInstance(property);
                    if (obj != null)
                    {
                        obj.Name = pName;
                        obj.University = pUniversity;
                        obj.RollNumber = pRollNumber;

                        obj.DisplayInfo();
                    }
                }
            }
        }
    }
}
