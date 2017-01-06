using System;

namespace MatrixCalculator
{
    public class Matrix
    {
        private double[,] array2D;

        public Matrix(int n, int m)
        {
            try
            {
                array2D = new double[n, m];
            }
            catch
            {
                throw;
            }

            for (int i = 0; i < 0; i++)
                for (int j = 0; j < 0; j++)
                    array2D[i, j] = 0;
        }

        public double this[int i, int j]
        {
            get { return array2D[i, j]; }
            set { array2D[i, j] = value; }
        }

        public int RowsNum
        {
            get { return array2D.GetLength(0); }
        }

        public int ColumnsNum
        {
            get { return array2D.GetLength(1); }
        }

        public static Matrix operator+(Matrix a, Matrix b)
        {
            try
            {
                if (a.RowsNum == b.RowsNum && a.ColumnsNum == b.ColumnsNum)
                {
                    Matrix result = new Matrix(a.RowsNum, a.ColumnsNum);

                    for (int i = 0; i < a.RowsNum; i++)
                        for (int j = 0; j < a.ColumnsNum; j++)
                            result[i, j] = a[i, j] + b[i, j];

                    return result;
                }
                else
                {
                    throw new Exception("Размеры матриц не совпадают.");
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Matrix operator-(Matrix a, Matrix b)
        {
            try
            {
                if (a.RowsNum == b.RowsNum && a.ColumnsNum == b.ColumnsNum)
                {
                    Matrix result = new Matrix(a.RowsNum, a.ColumnsNum);

                    for (int i = 0; i < a.RowsNum; i++)
                        for (int j = 0; j < a.ColumnsNum; j++)
                            result[i, j] = a[i, j] - b[i, j];

                    return result;
                }
                else
                {
                    throw new Exception("Размеры матриц не совпадают.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static Matrix operator*(Matrix a, Matrix b)
        {
            try
            {
                if(a.ColumnsNum == b.RowsNum)
                {
                    Matrix result = new Matrix(a.RowsNum, b.ColumnsNum);

                    for (int i = 0; i < a.RowsNum; i++)
                        for (int j = 0; j < b.ColumnsNum; j++)
                            for (int k = 0; k < a.ColumnsNum; k++)
                                result[i, j] += a[i, k] * b[k, j];

                    return result;
                }
                else
                {
                    throw new Exception("Количество столбцов первой матрицы не равно количеству строк второй.");
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Matrix Transpose()
        {
            Matrix result = new Matrix(this.ColumnsNum, this.RowsNum);

            for (int i = 0; i < result.RowsNum; i++)
                for (int j = 0; j < result.ColumnsNum; j++)
                    result[i, j] = this[j, i];

            return result;
        }
    }
}
