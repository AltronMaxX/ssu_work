#include <iostream>

using namespace std;

int main() {
    setlocale(0, "Russian");
	int n, m;
    cout << "Введите n и m" << '\n';
	cin >> n >> m;

	int** a = new int* [n];

	for (int i = 0; i < n; i++) {
		a[i] = new int[m];
	}

    cout << "Введите массив" << '\n';
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < m; j++) {
            cout << "Введите элемент [" << i << ',' << j << "]: ";
			cin >> a[i][j];
		}
	}

    int i, j;
    for (i = 0; i < n; ++i) { //Строки
        j = 0;
        while ((j < m) && (a[i][j] == 0))
        {
            ++j;
        }   
        if (j == m) {
            --n;
            for (int k = i; k < n; ++k) {
                for (j = 0; j < m; ++j)
                    a[k][j] = a[k + 1][j];
            }
            --i;
        }
    }

    for (j = 0; j < m; ++j) { //Столбцы
        i = 0;
        while ((i < n) && (a[i][j] == 0))
        {
            ++i;
        }     
        if (i == n) {
            --m;
            for (int k = j; k < m; ++k) {
                for (i = 0; i < n; ++i)
                    a[i][k] = a[i][k + 1];
            }
            --j;
        }
    }

	for (i = 0; i < n; i++) {
		for (j = 0; j < m; j++) {
			cout << a[i][j] << '\t';
		}
		cout << '\n';
	}

	return 0;
}