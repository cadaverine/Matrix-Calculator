using System.Data;

namespace MatrixCalculator
{
    /// <summary>
    /// Представляет класс методов расширения для объектов класса <see cref="Matrix"/>
    /// </summary>
    public static class MatrixExtension
    {
        #region ToDataTable
        /// <summary>
        /// Создает и возвращает объект <see cref="DataTable"/> на основе содержимого объекта <see cref="Matrix"/>
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(this Matrix matrix)
        {
            DataTable table = new DataTable();

            for (int i = 0; i < matrix.RowsNum; i++)
                table.Rows.Add();
            for (int i = 0; i < matrix.ColumnsNum; i++)
                table.Columns.Add();

            for (int i = 0; i < matrix.RowsNum; i++)
                for (int j = 0; j < matrix.ColumnsNum; j++)
                    table.Rows[i][j] = matrix[i, j];

            return table;
        }
        #endregion
    }
}
