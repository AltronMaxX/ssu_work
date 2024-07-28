#include <fstream>

using namespace std;

template <class T> class Stack {
private:
	struct Element {
		T inf;
		Element* next;
		Element(T inf, Element* next) : inf(inf), next(next) {}
	};
	Element* head;
public: 
	Stack() : head(0) {}
	bool isEmpty(){ return head == 0; }
	T pop() {
		if (isEmpty())
			throw "Stack is empty!";
		Element* r = head;
		T i = r->inf;
		head = r->next;
		delete r;
		return i;
	}
	void push(T a) {
		head = new Element(a, head);
	}	
	T top() {
		if (isEmpty())
			throw "Stack is empty!";
		return head->inf;
	}
};

Stack<int> revertStack(Stack<int> stack) {
	Stack<int> temp;
	while (!stack.isEmpty()) {
		temp.push(stack.pop());
	}
	return temp;
}

int main() {
	ifstream in("input.txt");
	Stack<int> s;
	while (in.peek() != EOF) {
		int a;
		in >> a;
		s.push(a);
	}

	Stack<int> pos, neg;
	while (!s.isEmpty()) {
		int a = s.pop();
		if (a < 0)
			neg.push(a);
		else
			pos.push(a);
	}

	neg = revertStack(neg);
	pos = revertStack(pos);

	while (!neg.isEmpty()) {
		s.push(neg.pop());
	}

	while (!pos.isEmpty()) {
		s.push(pos.pop());
	}

	ofstream out("output.txt");
	while (!s.isEmpty()) {
		out << s.pop() << '\t';
	}

	return 0;
}