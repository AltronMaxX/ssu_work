#include <iostream>

using namespace std;

int main() {
	setlocale(LC_ALL, "Russian");

	int n;

	int a[20];
	int b[20][20];

	double sr = 0;

	bool c = false;
	cout << "»спользовать двумерный массив? (1 - да, 0 - нет)" << endl;
	cin >> c;

	double sum = 0.0;

	if (c) {
		cout << "¬ведите n" << endl;
		cin >> n;

		int l;
		cout << "¬ведите l" << endl;
		cin >> l;

		for (int i = 0; i < n; i++) {
			for (int j = 0; j < l; j++) {
				cout << "¬ведите число в позиции " << i << ':' << j << ": ";
				cin >> b[i][j];
				sum += b[i][j];
			}
		}
		sr = sum / (n * l);
	}
	else {
		cout << "¬ведите количество чисел дл€ массива (<20)" << endl;
		cin >> n;

		for (int i = 0; i < n; i++) {
			cout << "¬ведите число в позиции " << i << ": ";
			cin >> a[i];
			sum += a[i];
		}
		sr = sum / n;
	}

	cout << "—реднее арифметическое: " << sr;

	return 0;
}