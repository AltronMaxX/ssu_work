#include <fstream>
#include <iostream>
#include <string>

using namespace std;

int main() {
	ofstream out("binary.dat", ios::binary);
	
	for (int i = 0; i <= 10; i++) {
		double a = pow(3, i);
		out.write((char *)&a, sizeof(double));
	}
	out.close();

	ifstream in("binary.dat", ios::binary);

	int i = 0;
	double d;
	while (in.read((char*)&d, sizeof(double))) {
		cout << d << '\n';

		in.seekg(sizeof(double), ios::cur);
	}

	return 0;
}