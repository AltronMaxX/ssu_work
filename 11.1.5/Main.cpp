#include <fstream>
#include <vector>

using namespace std;

ifstream in("input.txt");
ofstream out("output.txt");

void sort(vector<int> &sV, int l, int r) {
	int i = l, j = r;
	int piv = sV[(i + j) / 2];
	while (i <= j) {
		while (sV[i] < piv)
			i++;
		while (sV[j] > piv)
			j--;
		if (i <= j) {
			swap(sV[i], sV[j]);
			i++;
			j--;
		}
	}
	if (l < j)
		sort(sV, l, j);
	if (i < r)
		sort(sV, i, r);
}

int main() {
	int n, m;
	in >> n >> m;

	vector<vector<int>> sV;

	int j = 0;
	vector<int> a;
	while (in.peek() != EOF) {
		int c;
		in >> c;
		a.push_back(c);
		j++;
		if (j == m) {
			j = 0;
			sV.push_back(a);
			a.clear();
		}
	}

	for (int f = 0; f < m; f++) {
		vector<int> b;
		for (int i = 0; i < n; i++) {
			b.push_back(sV[i][f]);
		}
		sort(b, 0, b.size() -1);

		for (int i = 0; i < n; i++) {
			sV[i][f] = b[i];
		}
	}

	out << n << m << '\n';
	for (int i = 0; i < n; i++) {
		for (int j = 0; j < m; j++) {
			out << sV[i][j] << '\t';
		}
		out << '\n';
	}

	return 0;
}