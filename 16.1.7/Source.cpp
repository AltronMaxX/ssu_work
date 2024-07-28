#include <fstream>
#include <list>

using namespace std;

int main() {

	ifstream in("input.txt");
	ofstream out("out.txt");

	list<int> l;

	while (in.peek() != EOF) {
		int i;
		in >> i;
		l.push_back(i);
	}

	l.unique();

	out << "List: ";
	while (!l.empty()) {
		out << l.front() << ' ';
		l.pop_front();
	}

	return 0;
}