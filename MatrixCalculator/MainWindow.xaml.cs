using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace MatrixCalculator
{
    /// <summary>
    /// Главное окно приложения.
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields
        Matrix matrixA;
        Matrix matrixB;
        Matrix matrixC;
        Matrix buffer;

        enum Operations
        {
            Addition,
            Subtraction,
            Multiplication
        }
        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
            matrixA = null;
            matrixB = null;
            matrixC = null;
            buffer = null;
        }
        #endregion

        #region CreateAndSetMatrix
        /// <summary>
        /// Метод для создания объекта класса <see cref="Matrix"/> и установки его в <see cref="DataGrid"/>
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="dataGrid"></param>
        /// <param name="textBoxRowsNum"></param>
        /// <param name="textBoxColumnsNum"></param>
        private void CreateAndSetMatrix(Matrix matrix, DataGrid dataGrid, TextBox textBoxRowsNum, TextBox textBoxColumnsNum)
        {
            int RowsNum = 0;
            int ColumnsNum = 0;

            try
            {
                RowsNum    = Int32.Parse(textBoxRowsNum.Text);
                ColumnsNum = Int32.Parse(textBoxColumnsNum.Text);
                matrix = new Matrix(RowsNum, ColumnsNum);
                DataTable dataTable = matrix.ToDataTable();
                dataGrid.DataContext = dataTable.DefaultView;
            }
            catch
            {
                MessageBox.Show("Некорректно введена размерность матрицы!", "Ошибка");
            }
        }
        #endregion

        #region GetMatrixFromDataGrid
        /// <summary>
        /// Метод создает и возвращает объект класса  <see cref="Matrix"/> из содержимого <see cref="DataGrid"/>
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        private Matrix GetMatrixFromDataGrid(DataGrid dataGrid)
        {
            return ((DataView)dataGrid.ItemsSource).ToTable().ToMatrix();
        }
        #endregion

        #region CalculateMatricesAndSetResult
        /// <summary>
        /// Метод производит операцию над объектами класса <see cref="Matrix"/> и помещает результат в <see cref="DataGrid"/> результирующей матрицы
        /// </summary>
        /// <param name="operation"></param>
        private void CalculateMatricesAndSetResult(Operations operation)
        {
            try
            {
                matrixA = GetMatrixFromDataGrid(dataGrid_MatrixA);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Матрица не была создана.", "Ошибка");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " матрицы А.", "Ошибка");
                return;
            }
            try
            {
                matrixB = GetMatrixFromDataGrid(dataGrid_MatrixB);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Матрица не была создана.", "Ошибка");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " матрицы B.", "Ошибка");
                return;
            }
            try
            {
                switch (operation)
                {
                    case Operations.Addition:
                        matrixC = matrixA + matrixB;
                        break;
                    case Operations.Subtraction:
                        matrixC = matrixA - matrixB;
                        break;
                    case Operations.Multiplication:
                        matrixC = matrixA * matrixB;
                        break;
                }
                dataGrid_MatrixC.DataContext = matrixC.ToDataTable().DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                return;
            }
        }
        #endregion

        #region button_Ok_MatrixA_Click
        /// <summary>
        /// Создает объект класса <see cref="Matrix"/> и устанавливает его в <see cref="DataGrid"/>
        /// при нажатии кнопки <see cref="button_Ok_MatrixA"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Ok_MatrixA_Click(object sender, RoutedEventArgs e)
        {
            CreateAndSetMatrix(this.matrixA, this.dataGrid_MatrixA, textBox_RowsNum_MatrixA, textBox_ColumnsNum_MatrixA);
        }
        #endregion

        #region button_Ok_MatrixB_Click
        /// <summary>
        /// Создает объект класса <see cref="Matrix"/> и устанавливает его в <see cref="DataGrid"/>
        /// при нажатии кнопки <see cref="button_Ok_MatrixB"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Ok_MatrixB_Click(object sender, RoutedEventArgs e)
        {
            CreateAndSetMatrix(this.matrixB, this.dataGrid_MatrixB, textBox_RowsNum_MatrixB, textBox_ColumnsNum_MatrixB);
        }
        #endregion

        #region button_CalculateMatrices_Click
        /// <summary>
        /// Производит одну из выбранных операций над матрицами A и B и помещает результат в <see cref="DataGrid"/> результирующей матрицы С
        /// при нажатии кнопки <see cref="button_CalculateMatrices"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_CalculateMatrices_Click(object sender, RoutedEventArgs e)
        {
            if((bool)radioButton_Addition.IsChecked)
            {
                CalculateMatricesAndSetResult(Operations.Addition);
            }
            else if ((bool)radioButton_Subtraction.IsChecked)
            {
                CalculateMatricesAndSetResult(Operations.Subtraction);
            }
            else if ((bool)radioButton_Multiplication.IsChecked)
            {
                CalculateMatricesAndSetResult(Operations.Multiplication);
            }
        }
        #endregion

        #region button_Transpose_MatrixA_Click
        /// <summary>
        /// Производит транспонирование матрицы А при нажатии на кнопку <see cref="button_Transpose_MatrixA"/> 
        /// и помещает результат в <see cref="DataGrid"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Transpose_MatrixA_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                matrixA = GetMatrixFromDataGrid(dataGrid_MatrixA);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Матрица не была создана.", "Ошибка");
                return;
            }
            matrixA = matrixA.Transpose();

            dataGrid_MatrixA.DataContext = matrixA.ToDataTable().DefaultView;

            textBox_RowsNum_MatrixA.Text = matrixA.RowsNum.ToString();
            textBox_ColumnsNum_MatrixA.Text = matrixA.ColumnsNum.ToString();
        }
        #endregion

        #region button_Transpose_MatrixB_Click
        /// <summary>
        /// Производит транспонирование матрицы B при нажатии на кнопку <see cref="button_Transpose_MatrixB"/> 
        /// и помещает результат в <see cref="DataGrid"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Transpose_MatrixB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                matrixB = GetMatrixFromDataGrid(dataGrid_MatrixB);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Матрица не была создана.", "Ошибка");
                return;
            }
            matrixB = matrixB.Transpose();

            dataGrid_MatrixB.DataContext = matrixB.ToDataTable().DefaultView;

            textBox_RowsNum_MatrixB.Text = matrixB.RowsNum.ToString();
            textBox_ColumnsNum_MatrixB.Text = matrixB.ColumnsNum.ToString();
        }
        #endregion

        #region button_Transpose_MatrixB_Click
        /// <summary>
        /// Производит транспонирование матрицы B при нажатии на кнопку <see cref="button_Transpose_MatrixB"/> 
        /// и помещает результат в <see cref="DataGrid"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Transpose_MatrixC_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                matrixC = GetMatrixFromDataGrid(dataGrid_MatrixC);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Матрица не была создана.", "Ошибка");
                return;
            }
            matrixC = matrixC.Transpose();

            dataGrid_MatrixC.DataContext = matrixC.ToDataTable().DefaultView;
        }
        #endregion

        #region button_Copy_MatrixA_Click
        /// <summary>
        /// Производит копирование в буфер содержимого <see cref="DataGrid"/> матрицы А
        /// при нажатии кнопки <see cref="button_Copy_MatrixA"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Copy_MatrixA_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buffer = GetMatrixFromDataGrid(dataGrid_MatrixA);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Матрица не была создана.", "Ошибка");
                return;
            }
        }
        #endregion

        #region button_Paste_MatrixA_Click
        /// <summary>
        /// Производит копирование содержимого буфера в <see cref="DataGrid"/> матрицы А
        /// при нажатии кнопки <see cref="button_Paste_MatrixA"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Paste_MatrixA_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dataGrid_MatrixA.DataContext = buffer.ToDataTable().DefaultView;

                textBox_RowsNum_MatrixA.Text = buffer.RowsNum.ToString();
                textBox_ColumnsNum_MatrixA.Text = buffer.ColumnsNum.ToString();
            }
            catch
            {
                MessageBox.Show("Буфер пуст.", "Ошибка");
                return;
            }
        }
        #endregion

        #region button_Copy_MatrixB_Click
        /// <summary>
        /// Производит копирование в буфер содержимого <see cref="DataGrid"/> матрицы B
        /// при нажатии кнопки <see cref="button_Copy_MatrixB"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Copy_MatrixB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buffer = GetMatrixFromDataGrid(dataGrid_MatrixB);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Матрица не была создана.", "Ошибка");
                return;
            }
        }
        #endregion

        #region button_Paste_MatrixB_Click
        /// <summary>
        /// Производит копирование содержимого буфера в <see cref="DataGrid"/> матрицы B
        /// при нажатии кнопки <see cref="button_Paste_MatrixB"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Paste_MatrixB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dataGrid_MatrixB.DataContext = buffer.ToDataTable().DefaultView;

                textBox_RowsNum_MatrixB.Text = buffer.RowsNum.ToString();
                textBox_ColumnsNum_MatrixB.Text = buffer.ColumnsNum.ToString();
            }
            catch
            {
                MessageBox.Show("Буфер пуст.", "Ошибка");
                return;
            }
        }
        #endregion

        #region button_Copy_MatrixC_Click
        /// <summary>
        /// Производит копирование в буфер содержимого <see cref="DataGrid"/> матрицы C
        /// при нажатии кнопки <see cref="button_Copy_MatrixC"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Copy_MatrixC_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                buffer = GetMatrixFromDataGrid(dataGrid_MatrixC);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Матрица не была создана.", "Ошибка");
                return;
            }
        }
        #endregion

        #region button_Paste_MatrixC_Click
        /// <summary>
        /// Производит копирование содержимого буфера в <see cref="DataGrid"/> матрицы C
        /// при нажатии кнопки <see cref="button_Paste_MatrixC"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Paste_MatrixC_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dataGrid_MatrixC.DataContext = buffer.ToDataTable().DefaultView;
            }
            catch
            {
                MessageBox.Show("Буфер пуст.", "Ошибка");
                return;
            }
        }
        #endregion
    }
}
