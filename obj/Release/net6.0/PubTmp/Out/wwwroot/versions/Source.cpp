#include <iostream>
#include "Header.h"
using namespace std;


bool IssEmpty(const queue& Q)
{
	return Q.head == Q.tail;
}
bool IssFull(const queue& Q)
{
	return Q.tail == dimmax - 1;
}

void InitQ(queue& Q)
{
	Q.tail = 0;
	Q.head = 0;
}

void Put(queue& Q, atom a)
{
	Q.vect[Q.tail] = a;
	Q.tail=NextPos(Q.tail);
	if (IssFull(Q))
		InitQ(Q);
}

atom Get(queue& Q)
{
	atom a = Q.vect[Q.head];
	Q.head = NextPos(Q.head);
	if (IssEmpty(Q)==true)
		InitQ(Q);
	return a;
}

atom Front(const queue& Q)
{
	return Q.vect[Q.head];
}

int NextPos(int index)
{
	if (index < dimmax - 1)//altă soluție??
		return index + 1;
	else return 0;
}