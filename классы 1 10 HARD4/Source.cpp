#include <string>
#include <fstream>
#include <vector>
#include <algorithm>
#include <iomanip>

using namespace std;

ifstream in("in.txt");
ofstream out("out.txt");

class DateTime
{
private:
	static bool isVis(DateTime d) {
		return d.year % 4 == 0 && d.year % 100 != 0 && d.year % 400 == 0;
	}

	static int getMonthDays(DateTime d) {
		switch (d.month) {
		case 2:
			if (isVis(d))
				return 29;
			else
				return 28;
			break;
		case 1: case 3: case 5: case 7: case 8: case 10: case 12:
			return 31;
			break;
		case 4: case 6: case 9: case 11:
			return 30;
			break;
		}
	}

	int day, month, year, hour, minute;
public:
	static DateTime fromString(string date, string time) {
		DateTime ret;

		ret.day = stoi(date.substr(0, date.find_first_of('.')));
		ret.month = stoi(date.substr(date.find_first_of('.') + 1, date.find_last_of('.')));
		ret.year = stoi(date.substr(date.find_last_of('.') + 1, date.length()));

		ret.hour = stoi(time.substr(0, time.find_first_of(':')));
		ret.minute = stoi(time.substr(time.find_first_of(':') + 1, 2));

		return ret;
	}

	static int findDuration(DateTime d1, DateTime d2) //In minutes
	{
		int ret = (d2.day - d1.day) * 1440 + abs(d2.hour - d1.hour) * 60 + abs(d2.minute - d1.minute);
		if (d1.month != d2.month) {
			int a = getMonthDays(d1) - d1.day;
			ret = (d2.day + a) * 1440 + abs(d2.hour - d1.hour) * 60 + abs(d2.minute - d1.minute);
		}

		return ret;
	}

	void print() {
		out << setw(2) << setfill('0') << day << '.' << setw(2) << setfill('0') << month << '.' << setw(4) << setfill('0') << year
			<< '\t' << setw(2) << setfill('0') << hour << ':' << setw(2) << setfill('0') << minute;
	}

	DateTime() {
		day = 1;
		hour = 12;
		year = 1900;
		month = 1;
		minute = 0;
	}

	DateTime(int day, int month, int year, int hour, int minute)
	{
		this->day = day;
		this->hour = hour;
		this->year = year;
		this->month = month;
		this->minute = minute;
	}
	void operator = (DateTime d2) {
		day = d2.day;
		month = d2.month;
		year = d2.year;
		minute = d2.minute;
		hour = d2.hour;
	}
};

class Ticket
{
private:
	static int count;
	int cost;
	string from, to;
	DateTime arrival, departure;

public:
	void print() {
		out << getFrom() << ' ' << getTo() << ' ' << getCost() << ' ';
		getDeparture().print();
		out << ' ';
		getArrival().print();
		out << '\n';
	}

	static Ticket * input() {
		string from, to, depart, arriv, time_dep, time_arriv;
		int cost;

		in >> from >> to >> cost >> depart >> time_dep >> arriv >> time_arriv;
		Ticket* t = new Ticket(DateTime::fromString(arriv, time_arriv), DateTime::fromString(depart, time_dep), cost, from, to);
		return t;
	}

	void setFrom(string val) {
		from = val;
	}

	void setTo(string val) {
		to = val;
	}

	void setArrival(DateTime val) {
		arrival = val;
	}

	void setDeparture(DateTime val) {
		departure = val;
	}

	void setCost(unsigned int val) {
		cost = val;
	}

	static int getCount()
	{
		return count;
	}

	string getFrom()
	{
		return from;
	}

	string getTo()
	{
		return to;
	}

	DateTime getArrival() {
		return arrival;
	}

	DateTime getDeparture() {
		return departure;
	}

	int getCost() {
		return cost;
	}

	int getDuration() {
		return DateTime::findDuration(arrival, departure);
	}

	Ticket(DateTime arrival, DateTime departure, int cost, std::string from, std::string to) {
		count++;
		this->arrival = arrival;
		this->departure = departure;
		this->cost = cost;
		this->from = from;
		this->to = to;
	}

	~Ticket()
	{
		count--;
	}

	bool operator > (Ticket t2) {
		return getDuration() > t2.getDuration();
	}

	bool operator < (Ticket t2) {
		return getDuration() < t2.getDuration();
	}

	bool operator == (Ticket t2) {
		return getDuration() == t2.getDuration();
	}
};

vector<Ticket*> tickets;

int Ticket::count;

bool Pred(Ticket* t1, Ticket* t2) {
	return t1 < t2;
}

int main() {
	while (in.peek() != EOF) {
		tickets.push_back(Ticket::input());
	}

	sort(tickets.begin(), tickets.end(), Pred);

	for (Ticket* t : tickets) {
		t->print();
	}

	return 0;
}