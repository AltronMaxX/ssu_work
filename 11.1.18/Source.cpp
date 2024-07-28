#include <fstream>
#include <string>
#include <vector>

using namespace std;

ifstream in("input.txt");
ofstream out("output.txt");

struct student {
	string name, surname, patronymic;
	int year;
	double marks[5];
	void readStudent();
	void print();
};

void student::print() {
	out << surname << ' ' << name << ' ' << patronymic << ' ' << year;
	for (int i = 0; i < 5; i++) {
		out << ' ' << marks[i];
	}
}

void student::readStudent() {
	in >> surname >> name >> patronymic >> year;

	for (int i = 0; i < 5; i++) {
		in >> marks[i];
	}
}

student topStudent(student s1, student s2) {
	student ret;
	if (s1.surname[0] < s2.surname[0]) {
		return s1;
	}
	else if (s1.surname[0] == s2.surname[0]) {
		if (s1.name[0] < s2.name[0])
			return s1;
		else if (s1.name[0] == s2.name[0]) {
			if (s1.patronymic[0] < s2.patronymic[0])
				return s1;
			if (s1.patronymic[0] == s2.patronymic[0])
				return NULL;
			else
				return s2;
		}
		else
			return s2;
	}
	else 
		return s2;
}

void sortStudents(student* mas, int n) {
	for (int i = 0; i < n - 1; i++) {
		student s1 = mas[i];
		for (int j = i + 1; j < n; j++) {
			student s2 = mas[j];
			student top = topStudent(t, s2);
			if (top != NULL) {
				student temp = top == s1 ? s1 : s2;
				a[i] = top;
				a[j] = temp;
			}
		}
	}
}

int main() {

	int groupId;

	in >> groupId;

	int i = 0;

	while (!in.eof()) {
		string s;
		getline(in, s);
		i++;
	}

	in.close();

	in.open("input.txt");
	in >> groupId;

	student* students = new student[i];

	int j = 0;

	while (in.peek() != EOF) {
		student s;
		s.readStudent();
		students[j] = s;
	}

	out << groupId << '\n';

	sortStudents(students, i);

	for (int f = 0; f < i; f++) {
		students[f].print();
	}

	in.close();
	out.close();

	return 0;
}