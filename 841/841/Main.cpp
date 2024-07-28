#include <iostream>
#include <string>

using namespace std;

unsigned func(unsigned n){
	unsigned ret = 0;
	
	unsigned temp = n;

	while (temp != 0) {
		ret += temp % 10;
		temp /= 10;
	}

	return ret;
}

int main() {
	setlocale(LC_ALL, "Russian");

	unsigned a, b;

	cout << "Введите a и b (> 0)" << '\n';
	cin >> a >> b;

	if (a > b) {
		cout << "Неверно введены числа!";
		return -1;
	}

	for (unsigned i = a; i <= b; i++) {
		cout << i << '\t' << func(i) << '\n';
	}

	return 0;
}