#include <iostream>
#include <cmath>

using namespace std;

double rast(double x, double y)
{
	return sqrt(pow(x, 2) + pow(y, 2));
}

int main() {
	setlocale(LC_ALL, "Russian");

	double x, y;

	cout << "������� ���������� �����" << endl;

	cin >> x >> y;

	double point = rast(x, y);

	if (point < 15 || point > 25)
	{
		cout << "��";
	}
	else if (point > 15 && point < 25) {
		cout << "���";
	}
	else {
		cout << "�� �������";
	}

	return 0;
}
