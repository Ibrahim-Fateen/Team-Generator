namespace Team_randomizor
{
    public class Student
    {
        private string name;
        private int id;
        private int[] preference; // ids of students to include in the team
        private int[] unwanted; // ids of all students to not include in the team

        public Student() { }

        public Student(string[] line)
        {
            // use data from excel to generate an instance of student
            // condition array is to be populated with all id's of students this pupil can't work with
        }
        
        
        public string valName
        {
            get { return name; }
        }

        public int valId
        {
            get { return id; }
        }

        public int[] valPreference
        {
            get { return preference; }
        }

        public int[] valUnwanted
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
                        if (availableStudents[random] == 0) available = false;
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