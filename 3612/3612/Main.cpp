#include <iostream>
#include <iomanip>
#include <cmath>

using namespace std;

double f(double x)
{
	if (x < 0) {
		return 0;
	}
	else if (x == 1) {
		return 1;
	}
	else {
		return pow(x, 2) + 1;
	}
}

int main() {
	setlocale(LC_ALL, "Russian");

	double a, b, h;
	
	cout << "������� ��������� �������� x" << endl;
	cin >> a;

	cout << "������� �������� �������� x" << endl;
	cin >> b;	

	cout << "������� ��� �����" << endl;
	cin >> h;

	if (a > b) {
		cout << "������� ������� ��������!";
		return 0;
	}

	cout << "X" << '\t' << "Y" << fixed << setprecision(3);

	for (double i = a; i <= b; i += h) {
		cout << '\n' << i << '\t' << f(i);
	}

	return 0;
}