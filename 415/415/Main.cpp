#include <iostream>
#include <cmath>

using namespace std;

int main() {
	setlocale(LC_ALL, "Russian");

	int n;

	cout << "¬ведите n" << endl;
	cin >> n;

	double b1 = 1, b2 = 2, bn;

	for (int i = 3; i <= n; i++) {
		bn = b1 / 4 + 5 / pow(b2, 2);
		b1 = b2;
		b2 = bn;
		cout << i << ": " << bn << endl;
	}

	return 0;
}