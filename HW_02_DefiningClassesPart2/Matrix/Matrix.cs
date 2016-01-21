namespace ClassMatrix
{
    using System;
    using System.Text;
    class Matrix<T>  where T : struct, IComparable<T>
    {
        private T[,] matrix;
        private int rows;
        private int cols;
        
        public Matrix(int rows, int cols)
        {
            this.matrix = new T[rows, cols];
            this.Rows = rows;
            this.Cols = cols;
        }

        //public Matrix(T[,] matrix)
        //{
        //    this.matrix = matrix;
        //    this.Rows = matrix.GetLength(0);
        //    this.Cols = matrix.GetLength(1);
        //}


        public int Rows 
        {
            get { return this.rows; }
            set 
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("Matrix rows cannot be less than zero!");
                }
                this.rows = value;
            }
        }

        public int Cols 
        {
            get { return this.cols; }
            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("Matrix cols cannot be less than zero!");
                }
                this.cols = value;
            }
        }

        public T this[int row, int col]
        {
            get 
            {
                if (row >= this.Rows || row < 0 ||
                    col >= this.Cols || col < 0)
                {
                    throw new IndexOutOfRangeException(string.Format("Invalis indexes for (row, col) : ({0}, {1})", row, col));
                }

                return this.matrix[row, col];

            }
            set
            {
                if (row >= this.Rows || row < 0 ||
                    col >= this.Cols || col < 0)
                {
                    throw new IndexOutOfRangeException(string.Format("Invalis indexes for (row, col) : ({0}, {1})", row, col));
                }
                this.matrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)
        {
            if ((a.Rows != b.Rows) || (a.Cols != b.Cols))
            {
                throw new ArgumentException("Addition cannot be applied on matrices with different sizes!");
            }

            Matrix<T> resultMatrix = new Matrix<T>(a.Rows, a.Cols);

            for (int row = 0; row < resultMatrix.Rows; row++)
            {
                for (int col = 0; col < resultMatrix.Cols; col++)
                {
                    resultMatrix[row, col] = (dynamic)a[row, col] + b[row, col];
                }
            }
            return resultMatrix;
        }

        public static Matrix<T> operator -(Matrix<T> a, Matrix<T> b)
        {
            if ((a.Rows != b.Rows) || (a.Cols != b.Cols))
            {
                throw new ArgumentException("Substraction cannot be applied on matrices with different sizes!");
            }

            Matrix<T> resultMatrix = new Matrix<T>(a.Rows, a.Cols);

            for (int row = 0; row < resultMatrix.Rows; row++)
            {
                for (int col = 0; col < resultMatrix.Cols; col++)
                {
                    resultMatrix[row, col] = (dynamic)a[row, col] - b[row, col];
                }
            }

            return resultMatrix;
        }

        public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
        {
            if (a.Cols != b.Rows)
            {
                throw new ArgumentException("Multiplication cannot be applied!");
            }

            Matrix<T> resultMatrix = new Matrix<T>(a.rows, b.Cols);

            for (int row = 0; row < resultMatrix.Rows; row++)
            {
                for (int col = 0; col < resultMatrix.Cols; col++)
                {
                    T tempEntry = default(T);
                    for (int index = 0; index < a.Cols; index++)
                    {
                        tempEntry += (dynamic)a[row, index] * b[index, col];
                    }
                    resultMatrix[row, col] = (dynamic)tempEntry;
                }
            }
            return resultMatrix;
        }        

        public static bool operator true(Matrix<T> matrix)
        {
            return !ContainsZeroElements(matrix);
        }

        public static bool operator false(Matrix<T> matrix)
        {
            return ContainsZeroElements(matrix);
        }

        private static bool ContainsZeroElements(Matrix<T> matrix)
        {
            bool isZero = false;
            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    if (matrix[row, col] == (dynamic)0)
                    {
                        isZero = true;
                    }                  
                }
            }            
            return isZero;
        }

        public override string ToString()
        {
            StringBuilder printedString = new StringBuilder();
            printedString.Append(string.Format("Matrix {0}x{1}: \n", this.Rows, this.Cols));
            for (int row = 0; row < this.Rows; row++)
            {
                printedString.Append("[");
                for (int col = 0; col < this.Cols; col++)
                {
                    printedString.Append(string.Format("{0}, ", this[row, col]));
                }
                printedString.Remove(printedString.Length - 2, 2);
                printedString.Append("]\n");
            }
            printedString.Remove(printedString.Length - 1, 1);
            return printedString.ToString();
        }
    }
}
