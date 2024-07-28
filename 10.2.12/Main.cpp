#include <fstream>
#include <string>
#include <iostream>

using namespace std;

ifstream in("input.txt");

struct product {
	string type, sort;
	double cost; 
	int count;
	void readProduct();
};

void product::readProduct() {
	in >> type >> sort >> cost >> count;
}

int main() {
	int x;

	cin >> x;
	
	ofstream out("out.txt");

	while (in.peek() != EOF) {
		product a;
		a.readProduct();
		a.cost += a.cost * (x / 100.0);

		out << a.type << ' ' << a.sort << ' ' << a.cost << ' ' << a.count << '\n';
	}

	in.close();
	out.close();

	return 0;
}