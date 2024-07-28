#include <iostream>

using namespace std;

template <typename B> B** massIn(int n, int m) {
	B** retMas = new B * [n];
	for (int i = 0; i < n; i++) {
		retMas[i] = new B[m];
	}

	for (int i = 0; i < n; i++) {
		for (int j = 0; j < m; j++) {
			cout << "������� ������� ������� [" << i << ',' << j << "]: ";
			cin >> retMas[i][j];
		}
	}

	return retMas;
}

template <typename B> void massOut(B** mas, int n, int m) {
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < m; j++) {
			cout << mas[i][j] << '\t';
		}

		cout << '\n';
	}
}

template <typename B> double srOtr(B** a, int n, int m) {
	double summ = 0.0;
	int count = 0;

	for (int j = 0; j < m; j++) {
		for (int i = 0; i < n; i++) {
			if (a[i][j] < 0)
			{
				summ += a[i][j];
				count += 1;
			}
		}
	}

	return summ / count;
}

int main() {
	setlocale(0, "Russian");

	int n, m;

	cout << "������� n � m" << '\n';
	cin >> n >> m;

	int** m1 = massIn<int>(n, m);
	cout << "������ ������" << '\n';
	massOut<int>(m1, n, m);

	double** m2 = massIn<double>(n, m);
	cout << "������ ������" << '\n';
	massOut<double>(m2, n, m);

	cout << "��������� ��� ������� �������: " << srOtr<int>(m1, n, m) << '\n';
	cout << "��������� ��� ������� �������: " << srOtr<double>(m2, n, m) << '\n';

	return 0;
}