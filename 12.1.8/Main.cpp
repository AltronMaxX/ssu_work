#include <fstream>
#include <vector>
#include <algorithm>

using namespace std;

bool Pred(int x) {
	return x % 9 == 0;
}

int main() {
	vector<int> a;

	ifstream in("input.txt");
	ofstream out("output.txt");

	while (in.peek() != EOF) {
		int f;
		in >> f;
		a.push_back(f);
	}

	long long i = count_if(a.begin(), a.end(), Pred);

	out << i;

	in.close();
	out.close();

	return 0;
}