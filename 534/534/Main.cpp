#include <iostream>
#include <iomanip>

using namespace std;

int main() {
	setlocale(LC_ALL, "Russian");
	double e, s = 0, a = 1.0 / 2.0;

	cout << "¬ведите e" << '\n';
	cin >> e;

	int i = 2;

	while (a >= e) {
		s += a;
		a = 1.0 / (i * (i + 1));
		i++;
	}

	cout << "S: " << s;

	return 0;
}