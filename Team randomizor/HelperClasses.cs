namespace Team_randomizor
{
    public class Student
    {
        private string name;
        private int id;
        private List<int> preference = new List<int>(); // ids of students to include in the team
        private List<int> unwanted= new List<int>(); // ids of all students to not include in the team

        public Student() { }

        public Student(string[] line)
        {
            // use data from csv to generate an instance of student
            id = int.Parse(line[3]);
            name = line[1];
        }
        
        
        public string ValName
        {
            get { return name; }
        }

        public int ValId
        {
            get { return id; }
        }

        public List<int> ValPreference
        {
            get { return preference; }
        }

        public List<int> ValUnwanted
        {
            get { return unwanted; }
        }
    }
    
    public class TeamGenerator
    {
        private List<Student> allStudents = new List<Student>();
        private List<Student> availableStudents = new List<Student>();
        private List<List<Student>> Teams = new List<List<Student>>();

        public TeamGenerator(List<Student> students)
        {
            allStudents = students;
            availableStudents = students;
        }

        public List<Student> basic_generate()
        {
            Random rand = new Random();
            List<Student> team = new List<Student>();
            for (int k = 0; k < 5; k++)
            {
                if (!availableStudents.Any()) break;
                while (true)
                {
                    int random = rand.Next(availableStudents.Count());
                    bool available = true;
                    foreach (var std in team)
                    {
                        // ********************************************
                        if (availableStudents[random].ValUnwanted.Contains(std.ValId)) available = false;
                        if (std.ValUnwanted.Contains(availableStudents[random].ValId)) available = false;
                    }

                    if (available)
                    {
                        team.Add(availableStudents[random]);
                        availableStudents.RemoveAt(random);
                        break;
                    }
                }
            }

            return team;
        }
    }
}