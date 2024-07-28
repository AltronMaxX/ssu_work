#include <fstream>
#include <iostream>

using namespace std;

ifstream in("input.txt");
ofstream out("output.txt");

int** readMatrix(int n) {
	int** ret = new int * [n];

	for (int i = 0; i < n; i++) {
		ret[i] = new int[n];
		for (int j = 0; j < n; j++) {
			in >> ret[i][j];
		}
	}

	return ret;
}

void sortDiagonal(int* d, int n, bool asc) {
	if (asc) {
		for (int i = 1; i < n; i++) {
			int j = i;
			while (j > 0 && d[j - 1] < d[j]) {
				swap(d[j], d[j - 1]);
				j--;
			}	
		}
	}
	else {
		for (int i = 1; i < n; i++) {
			int j = i;
			while (j > 0 && d[j - 1] > d[j])
			{
				swap(d[j], d[j - 1]);
				j--;
			}
		}
	}
}

void sortMatrix(int ** a, int n) {
	int i = 0, j = 1, len_d = 0, temp_i = i, temp_j = j;
	while (j < n - 1) {
		temp_i = i, temp_j = j;

		len_d = 0;
		int* d = new int[j + 1];
		while (j >= 0) {
			d[len_d] = a[i][j];
			len_d++;
			i++;
			j--;
		}

		sortDiagonal(d, len_d, false);

		i = temp_i;
		j = temp_j;
		for (int l = 0; l < len_d; l++) {
			a[i][j] = d[l];
			i++;
			j--;
		}

		i = temp_i;
		j = temp_j + 1;
	}

	i = 1, j = n - 1, len_d = 0;
	while (i < n - 1) {
		temp_i = i, temp_j = j;

		len_d= 0;
		int* d = new int[i + 1];
		while (i < n) {
			d[len_d] = a[i][j];
			len_d++;
			j--;
			i++;
		}

		sortDiagonal(d, len_d, true);

		i = temp_i;
		j = temp_j;
		for (int l = 0; l < len_d; l++) {
			a[i][j] = d[l];
			i++;
			j--;
		}

		i = temp_i + 1;
		j = temp_j;
	}
}

int main() {
	int n;
	in >> n;

	int** mat = readMatrix(n);

	sortMatrix(mat, n);

	for (int i = 0; i < n; i++) {
		for (int j = 0; j < n; j++) {
			out << mat[i][j] << '\t';
		}
		out << '\n';
	}

	in.close();
	out.close();

	return 0;
}