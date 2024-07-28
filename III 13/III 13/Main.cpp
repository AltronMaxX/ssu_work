#include <iostream>

using namespace std;

int main() {
	setlocale(LC_ALL, "Russian");

	int a, b;
	
	cout << "Введите число от которого начать отсчёт" << endl;
	cin >> a;

	cout << "Введите число на котором закончить отсчёт" << endl;
	cin >> b;

	if (a > b) {
		cout << "Неверно введены числа!";
		return 0;
	}

	cout << "Способ 1" << endl;

	for (int i = a; i <= b; i++) {
		if (i < 1)
			continue;

		cout << i << endl;
	}

	cout << "Способ 2" << endl;

	int j = a;

	while (j <= b) {
		if (j >= 1) {
			cout << j << endl;
		}
		j++;
	}

	cout << "Способ 3" << endl;

	j = a;

	do {
		if (j < 1) {
			j++;
			continue;
		}
		cout << j << endl;
		j++;
	} while (j <= b);

	return 1;
}