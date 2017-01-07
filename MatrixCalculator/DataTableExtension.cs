using System;
using System.Data;

namespace MatrixCalculator
{
    /// <summary>
    /// Представляет класс методов расширения для объектов класса <see cref="DataTable"/>
    /// </summary>
    public static class DataTableExtension
    {
        #region ToMatrix
        /// <summary>
        /// Создает и возвращает объект <see cref="Matrix"/> на основе содержимого объекта <see cref="DataTable"/>
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static Matrix ToMatrix(this DataTable table)
        {

            Matrix result = new Matrix(table.Rows.Count, table.Columns.Count);

            for (int i = 0; i < table.Rows.Count; i++)
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    try
                    {
                        result[i, j] = Convert.ToDouble(table.Rows[i][j]);
                    }
                    catch
                    {
                        throw new Exception("Некорректное значение: строка № " + (i + 1) + ", столбец № " + (j + 1));
                    } 
                }
            return result;
        }
        #endregion
    }
}
