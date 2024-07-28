#include <iostream>

using namespace std;

int main() {
	setlocale(LC_ALL, "Russian");

	int n, v;

	int first = -1;

	cout << "¬ведите n ";
	cin >> n;

	int * a = new int[n+1];

	for (int i = 0; i < n; i++) {
		cout << "¬ведите элемент " << i << ": ";
		cin >> a[i];
		if (first == -1 && a[i] < 0) {
			first = i;
		}
	}

	cout << "¬ведите элемент, который нужно вставить: ";
	cin >> v;

	int j = n;

	while (j > first) {
		a[j] = a[j - 1];
		j--;
	}
	a[first] = v;

	for (int i = 0; i <= n; i++) {
		cout << '[' << i << "]: " << a[i] << '\n';
	}

	return 0;
}