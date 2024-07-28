#include <iostream>

using namespace std;

int** multiple(int** A, int** B, int n) {
	int** res = new int* [n];
	for (int i = 0; i < n; i++)
		res[i] = new int[n];

	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			res[i][j] = 0;
		}
	}

	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			for (int k = 0; k < n; k++) {
				res[i][j] += A[i][k] * B[k][j];
			}
		}
	}

	return res;
}


int main() {
	int m, n;
	cin >> n;

	int** a = new int* [n];
	for (int i = 0; i < n; i++)
		a[i] = new int[n];

	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			cin >> a[i][j];
		}
	}

	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			cout << a[i][j] << '\t';
		}
		cout << '\n';
	}

	cin >> m;

	int** b = new int* [n];
	for (int i = 0; i < n; i++)
		b[i] = new int[n];

	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			b[i][j] = a[i][j];
		}
	}

	while (m > 1) {
		b = multiple(a, b, n);
		m--;
	}

	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			cout << b[i][j] << '\t';
		}
		cout << '\n';
	}
}