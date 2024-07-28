#include <iostream>
#include <cmath>

using namespace std;

int main() {

	double x, y;

	cin >> x >> y;

	if ((x >= 1 && x <= 4) &&
		(y >= 1 && y <= 5) &&
		(( -(4.0 / 3.0) * x + 19.0 / 3.0) >= y)) {
		cout << "Yes";
	}
	else {
		cout << "No";
	}
	return 0;
}