List<Student> students = new List<Student>();

using (StreamReader studentsReader = new StreamReader("./students.txt")) {
    while (!studentsReader.EndOfStream) {
        string line = studentsReader.ReadLine();
        string[] studentsData = line.Split(';', StringSplitOptions.RemoveEmptyEntries);

        if (studentsData.Length == 5) {
            students.Add(new Student(studentsData[0], int.Parse(studentsData[1]), 
                [uint.Parse(studentsData[2]), uint.Parse(studentsData[3]), uint.Parse(studentsData[4])]));
        } else {
            Console.WriteLine("Неверно заданы данные студента {0}", line);
        }
    }
}

students.Sort();

using (StreamWriter writer = new StreamWriter("./studentsList.txt")) {
    foreach (Student student in students) {
        if (student.PassedExams()) {
            writer.WriteLine(student.ToString());
        }
    }
}

struct Student : IComparable<Student>{
    public string FIO;
    public int group;
    public uint[] marks;

    public Student (string FIO, int group, uint[] marks) {
        this.FIO = FIO;
        this.group = group;
        this.marks = marks;
    }

    override public string ToString() {
        return $"{FIO}\t{group}\t{string.Join(':', marks)}";
    }

    public bool PassedExams() {        
        foreach(uint mark in marks) {
            if (mark <= 2) 
                return false;
        }

        return true;
    }

    public int CompareTo(Student other)
    {
        return group.CompareTo(other.group);
    }
}