#include <iostream>

using namespace std;

int main() {
	setlocale(LC_ALL, "Russian");

	unsigned k;
	double x,p = 1;

	cout << "¬ведите k: ";
	cin >> k;

	cout << "¬ведите x: ";
	cin >> x;

	short a = 1;
	double xs = x;

	for (int n = 1; n <= k; n++) {
		a *= -1;
		xs *= x * x;
		p *= 1 + a * xs / (pow(n,3) + pow(n,2));
	}
	cout << "P: " << p;

	return 0;
}
