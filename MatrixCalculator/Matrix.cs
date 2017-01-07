using System;

namespace MatrixCalculator
{
    /// <summary>
    /// Представляет класс объектов математических матриц.
    /// </summary>
    public class Matrix
    {
        #region Fields
        private readonly double[,] _array2D;
        #endregion

        #region Properties
        /// <summary>
        /// Возвращает количество строк матрицы
        /// </summary>
        public int RowsNum => _array2D.GetLength(0);

        /// <summary>
        /// Возвращает количество столбцов матрицы
        /// </summary>
        public int ColumnsNum => _array2D.GetLength(1);

        #endregion

        #region Indexer
        /// <summary>
        /// Определение двумерного индексатора для объектов класса <see cref="Matrix"/>
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public double this[int i, int j]
        {
            get { return _array2D[i, j]; }
            set { _array2D[i, j] = value; }
        }
        #endregion

        #region Constructor
        public Matrix(int n, int m)
        {
            _array2D = new double[n, m];

            for (int i = 0; i < 0; i++)
                for (int j = 0; j < 0; j++)
                    _array2D[i, j] = 0;
        }
        #endregion

        #region operator+
        /// <summary>
        /// Перегрузка оператора "+" для реализации сложения объектов класса <see cref="Matrix"/>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
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
        #endregion

        #region operator-
        /// <summary>
        /// Перегрузка оператора "-" для реализации вычитания объектов класса <see cref="Matrix"/>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
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
        #endregion

        #region operator*
        /// <summary>
        /// Перегрузка оператора "+" для реализации умножения объектов класса <see cref="Matrix"/>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
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
        #endregion

        #region Transpose
        /// <summary>
        /// Метод, создающий и возвращающий объект класса <see cref="Matrix"/>, содержащий результат транспонирования исходной матрицы
        /// </summary>
        /// <returns></returns>
        public Matrix Transpose()
        {
            Matrix result = new Matrix(ColumnsNum, RowsNum);

            for (int i = 0; i < result.RowsNum; i++)
                for (int j = 0; j < result.ColumnsNum; j++)
                    result[i, j] = this[j, i];

            return result;
        }
        #endregion
    }
}
