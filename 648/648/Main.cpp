#include <iostream>

using namespace std;

int main() {
	setlocale(LC_ALL, "Russian");

	int n;

	cout << "Введите n: ";
	cin >> n;

	int ** a = new int * [n];
	for (int i = 0; i < n; i++) {
		a[i] = new int[n];
	}

	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			cout << "Введите элемент массива в " << i << ' ' << j << ' ';
			cin >> a[i][j];
		}
	}

	int* b = new int[n];
	for (int j = 0; j < n; j++) {
		int summ = 0;
		for (int i = 0; i < n; i++) {
			int c = a[i][j];
			if (c > 0 && c % 2 == 0) {
				summ += c;
			}
		}
		b[j] = summ;
	}

	for (int i = 0; i < n; i++) {
		cout << "Сумма столбца " << i << ' ' << b[i] << '\n';
	}

	return 0;
}