#include <iostream>

using namespace std;

int main() {
	setlocale(LC_ALL, "Russian");

	int n;

	int a[20];
	int b[20][20];

	double sr = 0;

	bool c = false;
	cout << "������������ ��������� ������? (1 - ��, 0 - ���)" << endl;
	cin >> c;

	double sum = 0.0;

	if (c) {
		cout << "������� n" << endl;
		cin >> n;

		int l;
		cout << "������� l" << endl;
		cin >> l;

		for (int i = 0; i < n; i++) {
			for (int j = 0; j < l; j++) {
				cout << "������� ����� � ������� " << i << ':' << j << ": ";
				cin >> b[i][j];
				sum += b[i][j];
			}
		}
		sr = sum / (n * l);
	}
	else {
		cout << "������� ���������� ����� ��� ������� (<20)" << endl;
		cin >> n;

		for (int i = 0; i < n; i++) {
			cout << "������� ����� � ������� " << i << ": ";
			cin >> a[i];
			sum += a[i];
		}
		sr = sum / n;
	}

	cout << "������� ��������������: " << sr;

	return 0;
}