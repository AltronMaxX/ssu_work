#include <iostream>
#include <cmath>
#include <iomanip>

using namespace std;

int main() {
	setlocale(LC_ALL, "Russian");
	double x1, y1, x2, y2, x3, y3;

	cout << "¬ведите координаты 1 точки" << endl;
	cin >> x1 >> y1;

	cout << "¬ведите координаты 2 точки" << endl;
	cin >> x2 >> y2;

	cout << "¬ведите координаты 3 точки" << endl;
	cin >> x3 >> y3;

	double a, b, c;
	a = sqrt(pow(x1 - x2, 2) + pow(y1 - y2, 2));
	b = sqrt(pow(x2 - x3, 2) + pow(y2 - y3, 2));
	c = sqrt(pow(x3 - x1, 2) + pow(y3 - y1, 2));

	double p;
	p = (a + b + c) / 2;

	double s = sqrt(p * (p - a) * (p - b) * (p - c));

	cout << "ѕлощадь треугольника равна " << fixed << setprecision(3) << s;
}