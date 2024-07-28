#include <iostream>
#include <iomanip>

using namespace std;

int main() {
	setlocale(LC_ALL, "Russian");

	unsigned n;
	cout << "¬ведите n" << endl;
	cin >> n;

	int nf = 1;
	double s = 1;

	for (int i = 2; i <= n; i++) {
		nf *= i;
		s += 1.0 / nf;
	}

	cout << s;
	return s;
}