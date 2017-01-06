using System;
using System.Data;

namespace MatrixCalculator
{
    public static class DataTableExtension
    {
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
    }
}
