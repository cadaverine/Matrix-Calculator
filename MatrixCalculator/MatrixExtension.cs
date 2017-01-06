using System.Data;

namespace MatrixCalculator
{
    public static class MatrixExtension
    {
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
    }
}
