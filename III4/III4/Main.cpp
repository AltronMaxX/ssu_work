#include <iostream>

using namespace std;

int main() {
	setlocale(LC_ALL, "Russian");

	int a;

	cout << "¬ведите число, до которого идЄт таблица" << endl;
	cin >> a;

	for (int i = 1; i <= a; i++) {
		for (int j = i; j > 0; j--) {
			cout << j << '\t';
		}
		cout << endl;
	}

	return 0;
}