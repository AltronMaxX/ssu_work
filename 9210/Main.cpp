#include <fstream>
#include <iostream>
#include <string>
	
using namespace std;

int main() {
	ifstream in("f.txt");
	ofstream g("g.txt");
	ofstream h("h.txt");

	while (!in.eof()) {
		string s;
		getline(in, s);

		for (int i = 0; i < s.length(); i++) {
			if (ispunct(s[i]))
				g << s[i];
			else
				h << s[i];
		}
	}

	return 0;
}