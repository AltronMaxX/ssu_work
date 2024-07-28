#include <iostream>
#include <string>

using namespace std;

int summ(string s) {
	int ret = 0;

	int i = 0;

	while (i < s.length())
	{
		if (isdigit(s[i])) {
			string chisl = "";
			chisl += s[i];
			int j = i + 1;
			while (isdigit(s[j])) {
				chisl += s[j];
				j++;
			}
			i = j;
			if (stoi(chisl) % 2 != 0) {
				ret += stoi(chisl);
			}
		}
		else {
			i++;
		}
	}

	return ret;
}

int main() {
	setlocale(0, "Russian");

	string s;

	cout << "Введите текст" << '\n';
	getline(cin, s); // This is the 1 state in this test. I like 51 apples. We love to ride banana. Everything is 14. We love 10.

	cout << "Сумма нечёт. цифр: " << summ(s);//52

	return 0; 
}