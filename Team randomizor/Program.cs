using Team_randomizor;
using System.IO;

List<Student> allStudents = new List<Student>();
List<List<Student>> Teams = new List<List<Student>>();

Console.WriteLine("Enter .csv file location: ");
string excelFileLoc = Console.ReadLine();
string outputFileLoc = excelFileLoc.Substring(0, excelFileLoc.Length - 4);
outputFileLoc += "_teams.csv";

// Read data
try
{
    using StreamReader sr = new StreamReader(excelFileLoc);
    while (!sr.EndOfStream)
    {
        string line = sr.ReadLine();
        char delimiter = ',';
        string[] student = line.Split(delimiter);

        Student st = new Student(student);
        allStudents.Add(st);
    }
    sr.Close();
}
catch (Exception err)
{
    Console.WriteLine("An error occured while reading the file provided" + err);
}


// Generate teams
TeamGenerator TG = new TeamGenerator(allStudents);
double numOfTeams = Math.Ceiling(allStudents.Count() / 5.0);

for (int i = 0; i < numOfTeams; i++)
{
    Teams.Add(TG.basic_generate());
}

// Write data
try
{
    using StreamWriter sw = new StreamWriter(outputFileLoc);
    sw.WriteLine("Team number, Names");
    int i = 0;
    foreach (var team in Teams)
    {
        sw.Write(i + 1);
        sw.Write(",");
        foreach (var std in team)
        {
            sw.Write(std.ValName + ",");
        }
        i++;
        sw.Write("\n");
    }
    sw.Close();
    Console.WriteLine("Done :)");
}
catch (Exception err)
{
    Console.WriteLine("An error occured when writing file to " + outputFileLoc + "err: " + err);
}
