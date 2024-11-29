Student[] students = [new Student("Ivanov Ivan Ivanovich", 221, [3, 5, 4]), new Student("Petrov Petr Petrovich", 251, [4, 3, 2]), 
    new Student("Ivanov Andrew Ivanovich", 221, [4, 5, 5]), new Student("Petrov Maxim Maximovich", 251, [4, 5, 3])];

Array.Sort(students);

StreamWriter writer = new StreamWriter("./studentsList.txt");

foreach (Student student in students) {
    if (student.PassedExams()) {
        writer.WriteLine(student.ToString());
    }
}

writer.Flush();

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
        if (group == other.group) return 0;
        if (group < other.group) return -1;
        return 1;
    }
}