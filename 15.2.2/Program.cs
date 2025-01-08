List<Student> students = new List<Student>();

using (StreamReader reader = new StreamReader("./students.txt")) {
    while (!reader.EndOfStream) {
        string line = reader.ReadLine();
        string[] studentData = line.Split(';', StringSplitOptions.RemoveEmptyEntries);
        if (studentData.Length == 4) {
            students.Add(new Student(studentData[0], uint.Parse(studentData[1]), studentData[2], uint.Parse(studentData[3])));
        } else {
            Console.WriteLine("Неверно заданы данные студента {0}", line);
        }
    }
}

var sortedStudents = from student in students group student by student.GetSchoolNumber();

using (StreamWriter writer = new StreamWriter("./SortedStudents.txt")) {
    foreach(var studentGroup in sortedStudents) {
        writer.WriteLine(studentGroup.First().GetSchoolNumber());
        foreach (var student in studentGroup) {
            writer.WriteLine($"{student}");
        }
    }
}

struct Student
{
    string FIO;
    uint BirthYear;
    string HomeAddress;
    uint SchoolNumber;

    public Student(string FIO, uint BirthYear, string HomeAddress, uint SchoolNumber) {
        this.FIO = FIO;
        this.BirthYear = BirthYear;
        this.HomeAddress = HomeAddress;
        this.SchoolNumber = SchoolNumber;
    }

    public uint GetSchoolNumber() {
        return SchoolNumber;
    }

    public override string ToString() {
        return $"{FIO};{BirthYear};{HomeAddress};{SchoolNumber}";
    }
}