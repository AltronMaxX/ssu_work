#include <iostream>

using namespace std;

int main() {
	setlocale(LC_ALL, "Russian");

	int a, b;
	
	cout << "������� ����� �� �������� ������ ������" << endl;
	cin >> a;

	cout << "������� ����� �� ������� ��������� ������" << endl;
	cin >> b;

	if (a > b) {
		cout << "������� ������� �����!";
		return 0;
	}

	cout << "������ 1" << endl;

	for (int i = a; i <= b; i++) {
		if (i < 1)
			continue;

		cout << i << endl;
	}

	cout << "������ 2" << endl;

	int j = a;

	while (j <= b) {
		if (j >= 1) {
			cout << j << endl;
		}
		j++;
	}

	cout << "������ 3" << endl;

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