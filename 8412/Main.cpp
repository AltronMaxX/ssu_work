#include <iostream>

using namespace std;

float F(float x) {
	if (x < 0) {
		return 0;
	}
	else if (x >= 0 && x != 1) {
		return x * x + 1;
	}
	else {
		return 1;
	}
}

void F(float x, float& y) {
	if (x < 0) {
		y = 0;
	}
	else if (x >= 0 && x != 1) {
		y = x * x + 1;
	}
	else {
		y = 1;
	}
}

int main() {
	setlocale(LC_ALL, "Russian");

	float x;
	cout << "������� x: ";
	cin >> x;

	cout << "�������� 1 �������: " << F(x) << '\n';

	float y = 0;
	F(x, y);
	cout << "�������� 2 �������: " << y << '\n';

	return 0;
}