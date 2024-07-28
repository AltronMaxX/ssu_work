#include <iostream>
#include <cmath>

using namespace std;

double f(double x1, double y1, double x2, double y2) {
	return sqrt(pow(x1 - x2, 2) + pow(y1 - y2, 2));
}

bool t(double a, double b, double c) {
	return a + b > c && b + c > a && a + c > b;
}

int main() {
	setlocale(LC_ALL, "Russian");

	double x1, y1, x2, y2, x3, y3, x4, y4;

	cout << "Введите координаты 1 точки" << endl;
	cin >> x1 >> y1;

	cout << "Введите координаты 2 точки" << endl;
	cin >> x2 >> y2;

	cout << "Введите координаты 3 точки" << endl;
	cin >> x3 >> y3;

	cout << "Введите координаты 4 точки" << endl;
	cin >> x4 >> y4;

	int count = 0;

	double a, b, c, d, e, g;

	a = f(x1, y1, x2, y2);
	b = f(x1, y1, x3, y3);
	c = f(x1, y1, x4, y4);
	d = f(x2, y2, x3, y3);
	e = f(x2, y2, x4, y4);
	g = f(x3, y3, x4, y4);

	if (t(a, d, b)) {
		count++;
	}
	if (t(b, g, c)) {
		count++;
	}
	if (t(c, e, a)) {
		count++;
	}
	if (t(d, g, e)) {
		count++;
	}

	cout << "Количество треугольников: " << count;

	return count;
}