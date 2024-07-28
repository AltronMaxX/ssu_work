#include <iostream>
#include <vector>
#include <string>
#include <cmath>

using namespace std;

float f(float x) {
	if (x < pow(0.5, 0.2))
		throw "Не определена";

	return log(abs(3*x)*sqrt(2*pow(x, 5)-1));
}

int main() {
	float a, b, h;
	setlocale(0, "Russian");

	cout << "Введите границы x: ";
	cin >> a >> b;

	cout << "Введите шаг h: ";
	cin >> h;

	for (float i = a; i <= b; i += h) {
		cout << i << '\t';
		try {
			cout << f(i);
		}
		catch (const char* s) {
			cout << s;
		}
		cout << '\n';
	}

	return 0;
}