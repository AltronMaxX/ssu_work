#include <iostream>
#include <string>

using namespace std;

int main() {
	setlocale(LC_ALL, "Russian");
	string s;

	cout << "¬ведите строку: ";
	getline(cin, s);

	bool flag = false;

	for (int i = 0; i < s.length() - 1; i++) {
		if (s[i] == s[i + 1]) {
			flag = true;
			break;
		}
	}

	cout << flag << '\n';

	return 0;
}