#include <iostream>
#include <string>

using namespace std;

int summ(string s, int i = 0) {
	int ret = 0;

	if (i < s.length()) {
		if (isdigit(s[i]))
			ret = ret + s[i] - 48 + summ(s, i + 1);
		else
			ret = ret + summ(s, i + 1);
	}

	return ret;
}

int main() {
	setlocale(LC_ALL, "Russian");

	string s1, s2;

	cout << "¬ведите строку 1" << "\n";
	getline(cin, s1);

	cout << "¬ведите строку 2" << "\n";
	getline(cin, s2);

	int sum1 = summ(s1), sum2 = summ(s2);

	if (sum1 > sum2) {
		cout << "—умма цифр в первой строке больше" << '\t' << sum1 << " > " << sum2;
	}
	else if (sum2 > sum1) {
		cout << "—умма цифр во второй строке больше" << '\t' << sum2 << " > " << sum1;
	}
	else {
		cout << "—уммы равны" << '\t' << sum2 << " = " << sum1;
	}

	return 0;
}