using Team_randomizor;
using System.IO;

List<Student> allStudents = new List<Student>();
List<List<Student>> Teams = new List<List<Student>>();

Console.WriteLine("Enter .csv file location: ");
String excelFileLoc = Console.ReadLine();
try
{
    using (StreamReader sr = new StreamReader(excelFileLoc))
    {
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            char delimiter = ',';
            string[] student = line.Split(delimiter);

            Student st = new Student(student);
            allStudents.Add(st);
        }
    }
}
catch (Exception)
{
    Console.WriteLine("An error occured while reading the file provided");
}

TeamGenerator TG = new TeamGenerator(allStudents);
double numOfTeams = Math.Ceiling(allStudents.Count() / 5.0);

for (int i = 0; i < numOfTeams; i++)
{
    Teams.Add(TG.basic_generate());
}
