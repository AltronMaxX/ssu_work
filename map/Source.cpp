#include <map>
#include <fstream>
#include <string>

using namespace std;

bool isNumber(string s) {
	for (char c : s) {
		if (isdigit(c))
			return true;
	}
	return false;
}

int main() {
	ifstream in("in.txt");
	ofstream out("out.txt");

	map<string, string> words;

	int i = 0;

	while (in.peek() != EOF) {
		string s;
		in >> s;
		if (isNumber(s)) {
			i++;
			continue;
		}
		else {
			if (words.count(s) > 0) {
				string a;
				if (words[s].find(' ') != string::npos) 
					a = words[s].substr(0, words[s].find(' '));
				else
					a = words[s];
				words[s] = a + ' ' + to_string(i);
			}
			else {
				words[s] = to_string(i);
			}
		}
		i++;
	}

	for (const auto& word : words) {
		out << word.first << ": " << word.second << '\n';
	}

	return 0;
}