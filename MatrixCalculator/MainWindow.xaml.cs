using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace MatrixCalculator
{
    /// <summary>
    /// Главное окно приложения.
    /// </summary>
    public partial class MainWindow
    {
        #region Fields
        Matrix _matrixA;
        Matrix _matrixB;
        Matrix _matrixC;
        Matrix _buffer;

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
            _matrixA = null;
            _matrixB = null;
            _matrixC = null;
            _buffer = null;
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
        private void CreateAndSetMatrix(ref Matrix matrix, DataGrid dataGrid, TextBox textBoxRowsNum, TextBox textBoxColumnsNum)
        {
            try
            {
                int rowsNum    = Int32.Parse(textBoxRowsNum.Text);
                int columnsNum = Int32.Parse(textBoxColumnsNum.Text);
                matrix = new Matrix(rowsNum, columnsNum);
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
                _matrixA = GetMatrixFromDataGrid(DataGridMatrixA);
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
                _matrixB = GetMatrixFromDataGrid(DataGridMatrixB);
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
                        _matrixC = _matrixA + _matrixB;
                        break;
                    case Operations.Subtraction:
                        _matrixC = _matrixA - _matrixB;
                        break;
                    case Operations.Multiplication:
                        _matrixC = _matrixA * _matrixB;
                        break;
                }
                DataGridMatrixC.DataContext = _matrixC.ToDataTable().DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
        #endregion

        #region ButtonOkMatrixA_Click
        /// <summary>
        /// Создает объект класса <see cref="Matrix"/> и устанавливает его в <see cref="DataGrid"/>
        /// при нажатии кнопки <see cref="ButtonOkMatrixA"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOkMatrixA_Click(object sender, RoutedEventArgs e)
        {
            CreateAndSetMatrix(ref _matrixA, DataGridMatrixA, TextBoxRowsNumMatrixA, TextBoxColumnsNumMatrixA);
        }
        #endregion

        #region ButtonOkMatrixB_Click
        /// <summary>
        /// Создает объект класса <see cref="Matrix"/> и устанавливает его в <see cref="DataGrid"/>
        /// при нажатии кнопки <see cref="ButtonOkMatrixB"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOkMatrixB_Click(object sender, RoutedEventArgs e)
        {
            CreateAndSetMatrix(ref _matrixB, DataGridMatrixB, TextBoxRowsNumMatrixB, TextBoxColumnsNumMatrixB);
        }
        #endregion

        #region ButtonCalculateMatrices_Click
        /// <summary>
        /// Производит одну из выбранных операций над матрицами A и B и помещает результат в <see cref="DataGrid"/> результирующей матрицы С
        /// при нажатии кнопки <see cref="ButtonCalculateMatrices"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCalculateMatrices_Click(object sender, RoutedEventArgs e)
        {
            if((bool)RadioButtonAddition.IsChecked)
            {
                CalculateMatricesAndSetResult(Operations.Addition);
            }
            else if ((bool)RadioButtonSubtraction.IsChecked)
            {
                CalculateMatricesAndSetResult(Operations.Subtraction);
            }
            else if ((bool)RadioButtonMultiplication.IsChecked)
            {
                CalculateMatricesAndSetResult(Operations.Multiplication);
            }
        }
        #endregion

        #region ButtonTransposeMatrixA_Click
        /// <summary>
        /// Производит транспонирование матрицы А при нажатии на кнопку <see cref="ButtonTransposeMatrixA"/> 
        /// и помещает результат в <see cref="DataGrid"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTransposeMatrixA_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _matrixA = GetMatrixFromDataGrid(DataGridMatrixA);

                _matrixA = _matrixA.Transpose();

                DataGridMatrixA.DataContext = _matrixA.ToDataTable().DefaultView;

                TextBoxRowsNumMatrixA.Text = _matrixA.RowsNum.ToString();
                TextBoxColumnsNumMatrixA.Text = _matrixA.ColumnsNum.ToString();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Матрица не была создана.", "Ошибка");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " матрицы А.", "Ошибка");
            }
        }
        #endregion

        #region ButtonTransposeMatrixB_Click
        /// <summary>
        /// Производит транспонирование матрицы B при нажатии на кнопку <see cref="ButtonTransposeMatrixB"/> 
        /// и помещает результат в <see cref="DataGrid"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTransposeMatrixB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _matrixB = GetMatrixFromDataGrid(DataGridMatrixB);

                _matrixB = _matrixB.Transpose();

                DataGridMatrixB.DataContext = _matrixB.ToDataTable().DefaultView;

                TextBoxRowsNumMatrixB.Text = _matrixB.RowsNum.ToString();
                TextBoxColumnsNumMatrixB.Text = _matrixB.ColumnsNum.ToString();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Матрица не была создана.", "Ошибка");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " матрицы B.", "Ошибка");
            }
        }
        #endregion

        #region ButtonTransposeMatrixC_Click
        /// <summary>
        /// Производит транспонирование матрицы B при нажатии на кнопку <see cref="ButtonTransposeMatrixC"/> 
        /// и помещает результат в <see cref="DataGrid"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTransposeMatrixC_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _matrixC = GetMatrixFromDataGrid(DataGridMatrixC);

                _matrixC = _matrixC.Transpose();

                DataGridMatrixC.DataContext = _matrixC.ToDataTable().DefaultView;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Матрица не была создана.", "Ошибка");
            }
        }
        #endregion

        #region ButtonCopyMatrixA_Click
        /// <summary>
        /// Производит копирование в буфер содержимого <see cref="DataGrid"/> матрицы А
        /// при нажатии кнопки <see cref="ButtonCopyMatrixA"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCopyMatrixA_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _buffer = GetMatrixFromDataGrid(DataGridMatrixA);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Матрица не была создана.", "Ошибка");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " матрицы А.", "Ошибка");
            }
        }
        #endregion

        #region ButtonPasteMatrixA_Click
        /// <summary>
        /// Производит копирование содержимого буфера в <see cref="DataGrid"/> матрицы А
        /// при нажатии кнопки <see cref="ButtonPasteMatrixA"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPasteMatrixA_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGridMatrixA.DataContext = _buffer.ToDataTable().DefaultView;

                TextBoxRowsNumMatrixA.Text = _buffer.RowsNum.ToString();
                TextBoxColumnsNumMatrixA.Text = _buffer.ColumnsNum.ToString();
            }
            catch
            {
                MessageBox.Show("Буфер пуст.", "Ошибка");
            }
        }
        #endregion

        #region ButtonCopyMatrixB_Click
        /// <summary>
        /// Производит копирование в буфер содержимого <see cref="DataGrid"/> матрицы B
        /// при нажатии кнопки <see cref="ButtonCopyMatrixB"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCopyMatrixB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _buffer = GetMatrixFromDataGrid(DataGridMatrixB);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Матрица не была создана.", "Ошибка");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " матрицы B.", "Ошибка");
            }
        }
        #endregion

        #region ButtonPasteMatrixB_Click
        /// <summary>
        /// Производит копирование содержимого буфера в <see cref="DataGrid"/> матрицы B
        /// при нажатии кнопки <see cref="ButtonPasteMatrixB"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPasteMatrixB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGridMatrixB.DataContext = _buffer.ToDataTable().DefaultView;

                TextBoxRowsNumMatrixB.Text = _buffer.RowsNum.ToString();
                TextBoxColumnsNumMatrixB.Text = _buffer.ColumnsNum.ToString();
            }
            catch
            {
                MessageBox.Show("Буфер пуст.", "Ошибка");
            }
        }
        #endregion

        #region ButtonCopyMatrixC_Click
        /// <summary>
        /// Производит копирование в буфер содержимого <see cref="DataGrid"/> матрицы C
        /// при нажатии кнопки <see cref="ButtonCopyMatrixC"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCopyMatrixC_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _buffer = GetMatrixFromDataGrid(DataGridMatrixC);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Матрица не была создана.", "Ошибка");
            }
        }
        #endregion

        #region ButtonPasteMatrixC_Click
        /// <summary>
        /// Производит копирование содержимого буфера в <see cref="DataGrid"/> матрицы C
        /// при нажатии кнопки <see cref="ButtonPasteMatrixC"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPasteMatrixC_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGridMatrixC.DataContext = _buffer.ToDataTable().DefaultView;
            }
            catch
            {
                MessageBox.Show("Буфер пуст.", "Ошибка");
            }
        }
        #endregion
    }
}
