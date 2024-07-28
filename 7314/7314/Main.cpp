#include <iostream>
#include <string>
#include <Windows.h>

using namespace std;

int main() {
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);

	string s;

	cout << "¬ведите строку: ";
	getline(cin, s);

	string newS;

	newS += toupper(s[0]);

	for (int i = 1; i < s.length() - 1; i++) {
		if (s[i-1] == ' ') {
			newS += toupper(s[i]);
		}
		else
			newS += s[i];
	}

	newS += '.';

	cout << newS;

	return 0;
}