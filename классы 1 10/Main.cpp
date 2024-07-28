#include <iostream>
#include <string>

using namespace std;

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
	static int findDuration(DateTime d1, DateTime d2) //In minutes
	{
		int ret = (d2.day - d1.day) * 1440 + abs(d2.hour - d1.hour) * 60 + abs(d2.minute - d1.minute);
		if (d1.month != d2.month) {
			int a = getMonthDays(d1) - d1.day;
			ret = (d2.day + a) * 1440 + abs(d2.hour - d1.hour) * 60 + abs(d2.minute - d1.minute);
		}

		return ret;
	}

	string toString() {
		return to_string(day) + "." + to_string(month) + "." + to_string(year) + '\t' + to_string(hour) + ':' + to_string(minute);
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
		cout << "Ticket from " + from + " to " + to + ". Departure date: " + departure.toString() +
			". Arrival date: " + arrival.toString() + ". Ticket cost: " + to_string(cost) + '\n';
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


	Ticket()
	{
		count++;
		arrival = DateTime(2, 1, 1900, 12, 0);
		departure = DateTime(1, 1, 1900, 12, 0);
		cost = 10;
		from = "Saratov";
		to = "Moscow";
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

int Ticket::count;

int main() {
	Ticket* t1,* t2,* t3;

	t1 = new Ticket(DateTime(3, 1, 2023, 15, 10), DateTime(30, 12, 2022, 14, 0), 100, string("Voronezh"), string("Saratov"));
	t2 = new Ticket(DateTime(3, 1, 1900, 13, 10), DateTime(2, 1, 1900, 14, 0), 100, string("Voronezh"), string("Saratov"));
	t3 = new Ticket(DateTime(11, 12, 2023, 20, 15), DateTime(10, 12, 2023, 12, 40), 500, "Saratov", "Sochi");

	t1->print();
	t2->print();
	t3->print();

	cout << "t1 > t2? " << (t1 > t2) << '\n';
	cout << "t2 < t3? " << (t2 < t3) << '\n';
	cout << "t1 == t3? " << (t1 == t3) << '\n';

	t1->setArrival(DateTime(10, 1, 1900, 15, 20));
	t1->print();
	cout << t1->getCost() << '\n';
	cout << Ticket::getCount() << '\n';

	return 0;
}