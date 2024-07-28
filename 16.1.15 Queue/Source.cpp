#include <fstream>

using namespace std;

template <class T> class Queue {
private:
	struct Element {
		T inf;
		Element* next;
		Element(T x) : inf(x), next(0) {}
	};
	Element* head, * tail;

public:
	Queue() : head(0), tail(0) {}

	bool isEmpty() {
		return head == 0;
	}

	void put(T item) {
		Element* t = tail;
		tail = new Element(item);

		if (isEmpty())
			head = tail;
		else
			t->next = tail;
	}

	T pop() {
		if (isEmpty())
			throw "Queue is empty";

		Element* t = head;
		T i = t->inf;
		head = t->next;

		delete t;
		return i;
	}
};

int main() {
	ifstream in("input.txt");
	Queue<int> q;
	while (in.peek() != EOF) {
		int a;
		in >> a;
		q.put(a);
	}

	Queue<int> pos, neg;
	while (!q.isEmpty()) {
		int a = q.pop();
		if (a < 0)
			neg.put(a);
		else
			pos.put(a);
	}

	while (!pos.isEmpty()) {
		q.put(pos.pop());
	}

	while (!neg.isEmpty()) {
		q.put(neg.pop());
	}

	ofstream out("output.txt");
	while (!q.isEmpty()) {
		out << q.pop() << '\t';
	}

	return 0;
}