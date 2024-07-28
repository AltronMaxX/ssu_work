#include <iostream>

using namespace std;

void func(int n, char c, bool flag) {
	if (!flag) {
		for (int i = 0; i < (80 - n)/ 2; i++) {
			cout << ' ';
		}
		for (int i = 0; i < n; i++) {
			cout << c;
		}
		cout << '\n';
		func(n - 2, c + 1, c + 1 == 'Z' ? true : false);
	}
	else if (flag && c >= 'A') {
		for (int i = 0; i < (80 - n) / 2; i++) {
			cout << ' ';
		}
		for (int i = 0; i < n; i++) {
			cout << c;
		}
		cout << '\n';
		func(n + 2, c - 1, true);
	}	
}

int main() {
	func(80, 'A', false);
	return 0;
}