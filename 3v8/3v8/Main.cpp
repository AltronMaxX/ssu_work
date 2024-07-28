#include <iostream>
#include <cmath>
#include <iomanip>

using namespace std;

double f(double x) {
	return (3*x + 4) / sqrt(pow(x, 2) + 2 * x + 1);
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

	cout << "X" << '\t' << "Y";

	for (double i = a; i <= b; i += h) {
		if (i == -1) {
			cout << '\n' << i <<'\t' << "�� ����������";
		}
		else {
			cout << '\n' << i << '\t' << fixed << setprecision(3) << f(i);
		}
	}

	return 0;
}