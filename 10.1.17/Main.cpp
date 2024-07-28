#include <fstream>
#include <iostream>
#include <string>
#include <cmath>

using namespace std;

ifstream in("input.txt");

struct point {
	double x, y, z;
	void create();
	void show();
};

void point::show(){
	cout << x << ' ' << y << ' ' << z << endl;
}

void point::create() {
	in >> x;
	in >> y;
	in >> z;
}

double sideLength(point p1, point p2) {
	return sqrt(pow(p2.x - p1.x, 2) + pow(p2.y - p1.y, 2) + pow(p2.z - p1.z, 2));
}

double perimeter(double s1, double s2, double s3) {
	return s1 + s2 + s3;
}

bool isExists(double p, double s1, double s2, double s3) {
	return sqrt(p * (p - s1) * (p - s2) * (p - s3)) != 0;
}


int main() {
	int i = 0;
	point a[20];
	
	while (!in.eof()) {
		point t;
		t.create();
		a[i] = t;
		i++;
	}

	in.close();

	point maxPointA, maxPointB, maxPointC;
	double maxP = 0;

	for (int j = 0; j <= i; j++) {
		point p1 = a[j];
		for (int k = 0; k <= i; k++) {
			if (k == j) continue;
			point p2 = a[k];
			for (int f = 0; f <= i; f++) {
				if (f == k || f == j) continue;
				point p3 = a[f];
				double s1 = sideLength(p1, p2), s2 = sideLength(p2, p3), s3 = sideLength(p3, p1);
				double p = perimeter(s1, s2, s3);
				if (isExists(p/2, s1,s2,s3)) {
					if (p > maxP) {
						maxP = p;
						maxPointA = p1;
						maxPointB = p2;
						maxPointC = p3;
					}
				}
				else
					continue;
			}
		}
	}

	cout << maxP << '\n';

	maxPointA.show();
	maxPointB.show();
	maxPointC.show();

	return 0;
}