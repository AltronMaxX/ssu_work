#include <fstream>
#include <string>

using namespace std;

int main() {
	ifstream input("input.txt");
	ofstream output("output.txt");

	while (input.peek() != EOF) {
		string s, result;
		getline(input, s);

		for (int i = 0; i < s.length(); i++) {
			if ((i - 1) % 2 != 0) {
				result += s[i];
			}
		}
		output << result << endl;
	}

	input.close();
	output.close();

	return 0;
}