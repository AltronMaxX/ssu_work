#include <fstream>
#include <iostream>

using namespace std;

int main() {
    setlocale(LC_ALL, "Russian");

    ofstream out("binary.dat", ios::binary);

    int n;
    cout << "¬водим n:";
    cin >> n;
    for (int i = 0; i <= n; i++) {
        out.write((char*)&i, sizeof(int));
    }

    out.close();

    ifstream in("binary.dat", ios::binary);
    int i = 0;
    while (in.read((char*)&i, sizeof(int))) {
        cout << i << '\n';
        in.seekg(sizeof(int), ios::cur);
    }

    return 0;
}
