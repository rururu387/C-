using System;
using System.Collections.Generic;
using System.Text;

namespace Goose3.NET
{
    public class MatrixC_
    {
        public double[][] matrix;
        /*public double[][] getMatrix()
        {
            return matrix;
        }*/
        public int size
        {
            get;
        }
        public MatrixC_(int  n)
        {
            size = n;
            matrix = new double[size][];
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                double []t_arr;
                t_arr = new double[size];
                for (int j = 0; j < size; j++)
                    t_arr[j] = rnd.Next(0, 10000);
                matrix[i] = t_arr;
            }
        }
        public MatrixC_(MatrixC_ someMatrix)
        {
            size = someMatrix.size;
            matrix = new double[size][];
            for (int i = 0; i < size; i++)
            {
                matrix[i] = new double[size];
                for (int j = 0; j < size; j++)
                    matrix[i][j] = someMatrix.matrix[i][j];
            }
        }
        public MatrixC_()
        {
            size = 5;
            matrix = new double[size][];
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                double[] t_arr;
                t_arr = new double[size];
                for (int j = 0; j < size; j++)
                    t_arr[j] = rnd.Next(0, 10000);
                matrix[i] = t_arr;
            }
        }
        public MatrixC_(double v11, double v12, double v13, double v21, double v22, double v23, double v31, double v32, double v33)
        {
            size = 3;
            matrix = new double[size][];

            double[] t_arr1 = new double[3], t_arr2 = new double[3], t_arr3 = new double[3];
            t_arr1[0] = v11;
            t_arr1[1] = v12;
            t_arr1[2] = v13;
            t_arr2[0] = v21;
            t_arr2[1] = v22;
            t_arr2[2] = v23;
            t_arr3[0] = v31;
            t_arr3[1] = v32;
            t_arr3[2] = v33;
            matrix[0] = t_arr1;
            matrix[1] = t_arr2;
            matrix[2] = t_arr3;
        }
        public MatrixC_(params double [][]data)
        {
            size = data.Length;
            matrix = new double[size][];
            for (int i = 0; i < size; i++)
            {
                matrix[i] = data[i];
            }
        }
        public double[] solveSystem(double []rightVal)
        {
            double[] solve = new double[size];
            double[] rightValCpy = new double[rightVal.Length];
            if (rightVal.Length < size)
                throw new System.RankException("Right value length is less than matrix dimension");

            double[][] matrixCpy = new double[size][];
            for (int i = 0; i < size; i++)
            {
                double[] t_arr;
                t_arr = new double[size];
                for (int j = 0; j < size; j++)
                    t_arr[j] = 0;
                matrixCpy[i] = t_arr;
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrixCpy[i][j] = matrix[i][j];
                }
            }

            for (int i = 0; i < rightVal.Length; i++)
            {
                rightValCpy[i] = rightVal[i];
            }

            double mult = 0.0;
            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    mult = matrixCpy[j][i] / matrixCpy[i][i];
                    for (int k = 0; k < size; k++)
                    {
                        matrixCpy[j][k] = matrixCpy[j][k] - matrixCpy[i][k] * mult;
                    }
                    rightValCpy[j] = rightValCpy[j] - rightValCpy[i] * mult;
                }
            }

            double mult2 = 0.0;
            for (int i = size - 1; i >= 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    mult2 = matrixCpy[j][i] / matrixCpy[i][i];
                    for (int k = 0; k < size; k++)
                    {
                        matrixCpy[j][k] = matrixCpy[j][k] - matrixCpy[i][k] * mult2;
                    }
                    rightValCpy[j] = rightValCpy[j] - rightValCpy[i] * mult2;
                }
            }

            for (int i = 0; i < size; i++)
            {
                if (matrixCpy[i][i] == 0 || Double.IsNaN(matrixCpy[i][i]))
                    throw new DivideByZeroException("Couldn't solve a system. It has 0 or infinite amount of solutions");
                solve[i] = rightValCpy[i] / matrixCpy[i][i];
            }

            return solve;
        }

        public override string ToString()
        {
            string matrixStr = "";
            for (int i = 0; i < size; i++)
            {
                matrixStr += "1)\t";
                for (int j = 0; j < size; j++)
                {
                    matrixStr += matrix[i][j].ToString() + '\t';
                }
                matrixStr += '\n';
            }
            return matrixStr;
        }
    }
}
