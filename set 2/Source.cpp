#include <set>
#include <fstream>
#include <string>

using namespace std;

int main() {
	ifstream in("input.txt");
	ofstream out("out.txt");

	set<int> numbers;

	string s;
	while (in.peek() != EOF) {
		getline(in, s);
		set<int> printed;
		for (char c : s) {
			if (isdigit(c)) {
				int a = (int)c - 48;
				if (numbers.count(a) == 1 && printed.count(a) == 0) {
					out << a << ' ';
					printed.insert(a);
				}
				else {
					numbers.insert(a);
				}
			}
		}
		out << '\n';
		numbers.clear();
	}

	return 0;
}