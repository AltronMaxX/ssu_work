#include <set>
#include <fstream>
#include <vector>
#include <string>

using namespace std;

int main() {
	ifstream in("in.txt");
	ofstream out("out.txt");

	vector<int> numbers;

	while (in.peek() != EOF) {
		int a;
		in >> a;
		numbers.push_back(a);
	}

	set<int> first_num;
	set<int> second_num;
	for (int i = 0; i < numbers.size() - 1; i++) {
		set<int> printed;
		out << numbers[i] << " : " << numbers[i + 1] << ": ";
		for (char c : to_string(numbers[i])) {
			first_num.insert((int)c - 48);
		}
		for (char c : to_string(numbers[i + 1])) {
			int a = (int)c - 48;
			second_num.insert(a);
			if (first_num.count(a) > 0 && printed.count(a) == 0) {
				printed.insert(a);
				out << a << ' ';
			}
		}
		for (int i = 0; i < 10; i++) {
			if (first_num.count(i) == 0 && second_num.count(i) == 0 && printed.count(i) == 0) {
				printed.insert(i);
				out << i << ' ';
			}
		}
		first_num.clear();
		second_num.clear();
		printed.clear();
		out << '\n';
	}

	return 0;
}