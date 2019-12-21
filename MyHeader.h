#pragma once
#include <ctime>
#include <string>
#include <utility>
#include <cstdlib>
#include <iostream>
#include <chrono>

#define myExport __declspec(dllexport)

/*extern "C" myExport void initMatrix(int size);

extern "C" myExport void fillClass(double* arr, int size, int i);

extern "C" myExport void solveMatrixCpp(double* rightVal, int rValSize);*/

extern "C" myExport long mainCpp(double* matrix, int size, double* rVal, int rValSize);

extern "C" myExport double doubleRand(double min, double max);

extern "C" myExport void helloWorld();

class myExport Matrix
{
	double** matrix;
	int size;

public:
	void print();
	std::pair <double*, int> solve(double rightVal[], int amount);
	int getSize();
	double** getMatrix();
	Matrix(double v11, double v12, double v13, double v21, double v22, double v23, double v31, double v32, double v33);
	Matrix(double** _matrix, int size);
	Matrix(int n);
	~Matrix();
};