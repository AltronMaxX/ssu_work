#include <fstream>
#include <vector>
#include <algorithm>

using namespace std;

int main() {
	vector<int> a;

	ifstream in("input.txt");
	ofstream out("output.txt");

	while (in.peek() != EOF) {
		int f;
		in >> f;
		a.push_back(f);
	}
		
	int max = *max_element(a.begin(), a.end());
	vector<int>::iterator b = remove(a.begin(), a.end(), max);
	a.erase(b, a.end());

	for (int n : a) {
		out << n << ' ';
	}

	in.close();
	out.close();

	return 0;
}