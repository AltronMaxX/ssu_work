#include <fstream>
#include <iostream>
#include <string>

using namespace std;

int main() {
	ifstream in("Input.txt");
	ofstream out("Out.txt");
	int len;

	cin >> len;

	while (!in.eof()) {
		string s;
		getline(in, s);

		if (len > s.length())
			out << s << '\n';
	}
	
	return 0;
}