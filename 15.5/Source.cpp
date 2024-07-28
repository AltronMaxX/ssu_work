#include <iostream>
#include <vector>
#include <string>

using namespace std;

class Persona {
protected:
	string birthDate, family;
public:
	virtual void printInfo() {
		cout << family << ' ' << birthDate << '\n';
	}

	string getBirthDate() { return birthDate; }
	void setBirthDate(string val) {birthDate = val;}

	string getFamily() { return family; }
	void setFamily(string val) { family = val; }

	int getAge(string curDate) {
		struct Date {
			int day, month, year;
			Date(string date) {
				day = stoi(date.substr(0, 2));
				month = stoi(date.substr(3, 2));
				year = stoi(date.substr(6, 4));
			}
		};
		Date bDate = Date(birthDate), cDate = Date(curDate);
		int ret = cDate.year - bDate.year;
		if (bDate.day > cDate.day && bDate.month > cDate.month)
			ret--;

		return ret;
	}
};

class Enrollee: public Persona {
private:
	string faculty;
public:
	Enrollee() {};
	Enrollee(string family, string date, string faculty) {
		this->family = family;
		this->birthDate = date;
		this->faculty = faculty;
	};

	string getFaculty() { return faculty; }
	void setFaculty(string val) { faculty = val; }

	void printInfo() {
		cout << family << ' ' << birthDate << ' ' << faculty << '\n';
	}
};

class Student: public Persona {
private:
	string faculty;
	int course;
public:
	Student() {};
	Student(string family, string date, string faculty, int course) {
		this->family = family;
		this->birthDate = date;
		this->faculty = faculty;
		this->course = course;
	};

	string getFaculty() { return faculty; }
	void setFaculty(string val) { faculty = val; }

	int getCourse() { return course; }
	void setCourse(int val) { course = val; }

	void printInfo() {
		cout << family << ' ' << birthDate << ' ' << faculty << ' ' << course << '\n';
	}
};

class Teacher: public Persona {
private:
	string faculty, job;
	int experience;
public:
	Teacher() {};
	Teacher(string family, string date, string faculty, string job, int experience) {
		this->family = family;
		this->birthDate = date;
		this->faculty = faculty;
		this->job = job;
		this->experience = experience;
	};

	string getFaculty() { return faculty; }
	void setFaculty(string val) { faculty = val; }

	string getJob() { return job; }
	void setJob(string val) { job = val; }

	int getExperience() { return experience; }
	void setExperience(int val) { experience = val; }

	void printInfo() {
		cout << family << ' ' << birthDate << ' ' << faculty << ' ' << job << ' ' << experience << '\n';
	}
};

int main() {
	int from, to;
	string curDate;

	vector<Persona*> people = {
		new Teacher("Petrova", "05.10.1990", "CSIT", "Programming", 5),
		new Enrollee("Pupkin", "01.10.2004", "CSIT"),
		new Student("Memes", "06.03.2002", "MEHMAT", 3),
		new Student("Ivanov", "10.10.2003", "MEHMAT", 2)
	};

	for (Persona* person : people){
		person->printInfo();
	}

	cin >> curDate >> from >> to;

	cout << "Finding people with this age" << '\n';
	for (Persona* person : people) {
		if (person->getAge(curDate) > from && person->getAge(curDate) < to)
			person->printInfo();
	}

	return 0;
}