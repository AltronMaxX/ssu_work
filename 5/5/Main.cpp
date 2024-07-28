#include <iostream>

using namespace std;

int main() {

	double x, y;

	cin >> x >> y;

	if (x >= 1 && (y >= 2 && y <= 4)) {
		cout << "Yes";
	}
	else {
		cout << "No";
	}

	return 0;
}