#pragma once
#include "pch.h"
#include "MyHeader.h"

// dllmain.cpp : Определяет точку входа для приложения DLL.p;,
BOOL APIENTRY DllMain(HMODULE hModule,
	DWORD  ul_reason_for_call,
	LPVOID lpReserved
)
{
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
	case DLL_THREAD_ATTACH:
		std::cout << "Started c++ part!\n";
	case DLL_THREAD_DETACH:
	case DLL_PROCESS_DETACH:
		break;
	}
	return TRUE;
}

long mainCpp(double* matrix, int size, double* rVal, int rValSize)
{
	Matrix* matrixCpp = new Matrix(size);
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			matrixCpp->getMatrix()[i][j] = matrix[i * size + j];
		}
	}
	//matrixCpp->print();
	std::pair <double*, int> slnPair;
	std::chrono::time_point<std::chrono::system_clock> start, end;
	start = std::chrono::system_clock::now();
	try
	{
		slnPair = matrixCpp->solve(rVal, rValSize);
	}
	catch (std::string str)
	{
		std::cout << str;
		end = std::chrono::system_clock::now();
		long elapsed_milliseconds = std::chrono::duration_cast<std::chrono::milliseconds>	(end - start).count();
		return elapsed_milliseconds;
	}
	end = std::chrono::system_clock::now();
	std::cout << "Solution:\t";
	for (int i = 0; i < slnPair.second; i++)
	{
		std::cout << slnPair.first[i] << '\t';
	}
	std::cout << '\n';
	long elapsed_milliseconds = std::chrono::duration_cast<std::chrono::milliseconds>	(end - start).count();
	std::cout << "Calculation took " << elapsed_milliseconds << " milliseconds\n";
	delete[] slnPair.first;
	matrixCpp->~Matrix();
	return elapsed_milliseconds;
}

void helloWorld()
{
	std::cout << "Hello, World!\n";
}

int Matrix::getSize()
{
	return size;
}

double** Matrix::getMatrix()
{
	return matrix;
}

void Matrix::print()
{
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			std::cout << std::to_string(matrix[i][j]) << '\t';
		}
		std::cout << '\n';
	}
}

std::pair <double*, int> Matrix::solve(double rightVal[], int amount)
{
	if (amount < size)
	{
		throw std::length_error("Right value must have an equal or more size than matrix");
	}

	double* solvArr = new double[size];

	for (int i = 0; i < size; i++)
	{
		solvArr[i] = rightVal[i];
	}

	double** matrixCpy = new double* [size];
	for (int i = 0; i < size; i++)
	{
		matrixCpy[i] = new double[size];
		for (int j = 0; j < size; j++)
		{
			matrixCpy[i][j] = matrix[i][j];
		}
	}

	for (int i = 0; i < size; i++)
	{
		for (int j = i + 1; j < size; j++)
		{
			double mult = matrixCpy[j][i] / matrixCpy[i][i];
			for (int k = 0; k < size; k++)
			{
				matrixCpy[j][k] = matrixCpy[j][k] - matrixCpy[i][k] * mult;
			}
			solvArr[j] = solvArr[j] - solvArr[i] * mult;
		}
	}

	for (int i = size - 1; i >= 0; i--)
	{
		for (int j = i - 1; j >= 0; j--)
		{
			double mult = matrixCpy[j][i] / matrixCpy[i][i];
			for (int k = 0; k < size; k++)
			{
				matrixCpy[j][k] = matrixCpy[j][k] - matrixCpy[i][k] * mult;
			}
			solvArr[j] = solvArr[j] - solvArr[i] * mult;
		}
	}

	for (int i = 0; i < size; i++)
	{
		if (matrixCpy[i][i] == 0)
		{
		std::string str = "Couldn't solve a system. It has 0 or infinite amount of solutions";
			throw (str);
		}
		solvArr[i] = solvArr[i] / matrixCpy[i][i];
	}

	for (int i = 0; i < size; i++)
	{
		delete[] matrixCpy[i];
	}
	delete[] matrixCpy;

	return std::pair <double*, int>(solvArr, size);
}

Matrix::Matrix(double v11, double v12, double v13, double v21, double v22, double v23, double v31, double v32, double v33)
{
	size = 3;
	matrix = new double* [size];
	double* t_row1 = new double[size];
	double* t_row2 = new double[size];
	double* t_row3 = new double[size];
	t_row1[0] = v11;
	t_row1[1] = v12;
	t_row1[2] = v13;
	t_row2[0] = v21;
	t_row2[1] = v22;
	t_row2[2] = v23;
	t_row3[0] = v31;
	t_row3[1] = v32;
	t_row3[2] = v33;
	matrix[0] = t_row1;
	matrix[1] = t_row2;
	matrix[2] = t_row3;
}

Matrix::~Matrix()
{
	for (int i = 0; i < size; i++)
	{
		delete[] matrix[i];
		matrix[i] = NULL;
	}
	delete matrix;
	matrix = NULL;
}

double doubleRand(double min, double max)
{
	return (double)(rand()) / RAND_MAX * (max - min) + min;
}

Matrix::Matrix(int n)
{
	size = n;
	matrix = new double* [size];
	for (int i = 0; i < size; i++)
	{
		matrix[i] = new double[size];
		for (int j = 0; j < size; j++)
		{
			matrix[i][j] = doubleRand(0, 100);
		}
	}
}

Matrix::Matrix(double** _matrix, int n)
{
	matrix = _matrix;
	size = n;
}