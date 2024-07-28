#include <iostream>
#include <cfloat>

using namespace std;

int main() {
	setlocale(LC_ALL, "Russian");

	int n;
	cout << "������� ���������� ��������� ������� ";
	cin >> n;

	double * a = new double[n];

	for (int i = 0; i < n; i++) {
		cout << "������� ������� ������� �� ������� " << i << " ";
		cin >> a[i];
	}

	int nmax = 0;
	int nmin = 0;

	double max = -FLT_MAX, min = FLT_MAX;

	for (int i = 0; i < n; i++) {
		if (a[i] > max) {
			max = a[i];
			nmax = i;
		}
		if (a[i] <= min) {
			min = a[i];
			nmin = i;
		}
	}

	if (nmax > nmin) {
		cout << "������������ ����� ������� ��� ����� ������������!!!";
		return 0;
	}

	double s = 0;

	for (int i = nmax + 1; i < nmin; i++) {
		s += a[i];
	}

	cout << s;

	return 1;
}