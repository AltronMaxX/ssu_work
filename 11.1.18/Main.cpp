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
	out << '\n';
}

void student::readStudent() {
	in >> surname >> name >> patronymic >> year;

	for (int i = 0; i < 5; i++) {
		in >> marks[i];
	}
}

void sortStudents(student* mas, int n) {
	for (int i = 0; i < n-1; i++) {
		int minIndex = i;
		for (int j = i+1; j < n; j++) {
			student s1 = mas[minIndex];
			student s2 = mas[j];
			if (s2.surname[0] < s1.surname[0])
				minIndex = j;
			else if (s2.surname[0] == s1.surname[0]) {
				if (s2.name[0] < s1.name[0])
					minIndex = j;
				else if (s2.name[0] == s1.name[0]) {
					if (s2.patronymic[0] < s1.patronymic[0])
						minIndex = j;
				}
			}
		}
		swap(mas[i], mas[minIndex]);
	}
}

int main() {
	int groupId;

	in >> groupId;

	student students[50];

	int i = 0;

	while (in.peek() != EOF) {
		students[i].readStudent();
		i++;
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