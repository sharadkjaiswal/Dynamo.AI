using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.DesignScript.Runtime;
using MathNet.Numerics.Data.Text;
using MathNet.Numerics.LinearAlgebra;
using NumMatrix = MathNet.Numerics.LinearAlgebra.Matrix<double>;

namespace Dynamo.AI.Data
{
    /// <summary>
    /// Defines Matrix class
    /// </summary>
    public class Matrix
    {
        private NumMatrix storage;

        internal Matrix(NumMatrix storage)
        {
            this.storage = storage;
        }

        internal NumMatrix Storage { get { return storage; } }

        #region Operations
        /// <summary>
        /// Returns the size of the matrix as rows and columns
        /// </summary>
        /// <returns></returns>
        [MultiReturn("rows", "columns")]
        public Dictionary<string, int> Size()
        {
            return new Dictionary<string, int>() { { "rows", this.RowCount }, { "columns", ColumnCount } };
        }

        /// <summary>
        /// Gets the number of columns.
        /// </summary>
        public int ColumnCount { get { return storage.ColumnCount; } }

        /// <summary>
        /// Gets the number of rows.
        /// </summary>
        public int RowCount { get { return storage.RowCount; } }
        
        /// <summary>
        /// Returns a list of columns
        /// </summary>
        public IEnumerable<Vector> EnumerateColumns()
        {
            return storage.EnumerateColumns().Select(v => new Vector(v));
        }

        /// <summary>
        /// Returns a list of rows
        /// </summary>
        public IEnumerable<Vector> EnumerateRows()
        {
            return storage.EnumerateRows().Select(v => new Vector(v));
        }

        /// <summary>
        /// Computes the absolute value of a matrix pointwise
        /// </summary>
        public Matrix Abs()
        {
            return new Matrix(NumMatrix.Abs(this.storage));
        }

        /// <summary>
        /// Computes the acos of a matrix pointwise
        /// </summary>
        public Matrix Acos()
        {
            return new Matrix(NumMatrix.Acos(storage));
        }

        /// <summary>
        /// Computes the asin of a matrix pointwise
        /// </summary>
        public Matrix Asin()
        {
            return new Matrix(NumMatrix.Asin(storage));
        }

        /// <summary>
        /// Computes the atan of a matrix pointwise
        /// </summary>
        public Matrix Atan()
        {
            return new Matrix(NumMatrix.Atan(storage));
        }

        /// <summary>
        /// Computes the ceiling of a matrix pointwise
        /// </summary>
        public Matrix Ceiling()
        {
            return new Matrix(NumMatrix.Ceiling(storage));
        }

        /// <summary>
        /// Computes the cos of a matrix pointwise
        /// </summary>
        public Matrix Cos()
        {
            return new Matrix(NumMatrix.Cos(storage));
        }

        /// <summary>
        /// Computes the cosh of a matrix pointwise
        /// </summary>
        public Matrix Cosh()
        {
            return new Matrix(NumMatrix.Cosh(storage));
        }

        /// <summary>
        /// Computes the exponential of a matrix pointwise
        /// </summary>
        public Matrix Exp()
        {
            return new Matrix(NumMatrix.Exp(storage));
        }

        /// <summary>
        /// Computes the floor of a matrix pointwise
        /// </summary>
        public Matrix Floor()
        {
            return new Matrix(NumMatrix.Floor(storage));
        }

        /// <summary>
        /// Computes the log of a matrix pointwise
        /// </summary>
        public Matrix Log()
        {
            return new Matrix(NumMatrix.Log(storage));
        }

        /// <summary>
        /// Computes the log10 of a matrix pointwise
        /// </summary>
        public Matrix Log10()
        {
            return new Matrix(NumMatrix.Log10(storage));
        }

        /// <summary>
        /// Performs elementwise/pointwise division of dividend with divisor matrices
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public static Matrix DotDivide(Matrix dividend, Matrix divisor)
        {
            return new Matrix(NumMatrix.op_DotDivide(dividend.storage, divisor.storage));
        }

        /// <summary>
        /// Elementwise/pointwise raise the given matrix to a given exponent.
        /// </summary>
        /// <param name="matrix">The input matrix</param>
        /// <param name="exponent">The power exponent</param>
        /// <returns>New matrix</returns>
        public static Matrix DotHat(Matrix matrix, double exponent)
        {
            return new Matrix(NumMatrix.op_DotHat(matrix.storage, exponent));
        }

        /// <summary>
        /// Elementwise/pointwise raise the given matrix to a given exponent.
        /// </summary>
        /// <param name="matrix">The input matrix</param>
        /// <param name="exponent">The power exponent matrix</param>
        /// <returns>New matrix</returns>
        public static Matrix DotHat(Matrix matrix, Matrix exponent)
        {
            return new Matrix(NumMatrix.op_DotHat(matrix.storage, exponent.storage));
        }

        /// <summary>
        /// Elementwise/pointwise multiplication of the two given matrix.
        /// </summary>
        /// <param name="x">First matrix</param>
        /// <param name="y">Second matrix</param>
        /// <returns>The product matrix</returns>
        public static Matrix DotMultiply(Matrix x, Matrix y)
        {
            return new Matrix(NumMatrix.op_DotMultiply(x.storage, y.storage));
        }

        /// <summary>
        /// Pointwise remainder (% operator), where the result has the sign of 
        /// the dividend, of the dividend matrix by divisor matrix.
        /// </summary>
        /// <param name="dividend">The numerator matrix to use</param>
        /// <param name="divisor">The denominator matrix to use</param>
        /// <returns>Remainder matrix</returns>
        public static Matrix DotRemainder(Matrix dividend, Matrix divisor)
        {
            return new Matrix(NumMatrix.op_DotPercent(dividend.storage, divisor.storage));
        }

        /// <summary>
        /// Computes the rounded value of a matrix pointwise
        /// </summary>
        public Matrix Round()
        {
            return new Matrix(NumMatrix.Round(storage));
        }

        /// <summary>
        /// Computes the sin of a matrix pointwise
        /// </summary>
        public Matrix Sin()
        {
            return new Matrix(NumMatrix.Sin(storage));
        }

        /// <summary>
        /// Computes the sinh of a matrix pointwise
        /// </summary>
        public Matrix Sinh()
        {
            return new Matrix(NumMatrix.Sinh(storage));
        }

        /// <summary>
        /// Computes the sqrt of a matrix pointwise
        /// </summary>
        public Matrix Sqrt()
        {
            return new Matrix(NumMatrix.Sqrt(storage));
        }

        /// <summary>
        /// Computes the tan of a matrix pointwise
        /// </summary>
        public Matrix Tan()
        {
            return new Matrix(NumMatrix.Tan(storage));
        }

        /// <summary>
        /// Computes the tanh of a matrix pointwise
        /// </summary>
        public Matrix Tanh()
        {
            return new Matrix(NumMatrix.Tanh(storage));
        }

        /// <summary>
        /// Adds another matrix to this matrix.
        /// </summary>
        /// <param name="other">The matrix to add to this matrix.</param>
        /// <returns>The result of the addition.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// If the two matrices don't have the same dimensions.</exception>
        public Matrix Add(Matrix other)
        {
            return new Matrix(storage.Add(other.storage));
        }

        /// <summary>
        /// Adds a scalar value to each element of the matrix.
        /// </summary>
        /// <param name="value">The scalar value to add.</param>
        /// <returns>The result of the addition.</returns>
        public Matrix Add(double value)
        {
            return new Matrix(storage.Add(value));
        }
        
        /// <summary>
        /// Concatenates this matrix with the given matrix.
        /// </summary>
        /// <param name="right">The matrix to concatenate.</param>
        /// <returns>The combined matrix.</returns>
        public Matrix Append(Matrix right)
        {
            return new Matrix(storage.Append(right.storage));
        }
        
        /// <summary>
        /// Computes the determinant of this matrix.
        /// </summary>
        /// <returns>The determinant of this matrix.</returns>
        public double Determinant()
        {
            return storage.Determinant();
        }
        
        /// <summary>
        /// Returns the elements of the diagonal in a Vector.
        /// </summary>
        /// <returns>The elements of the diagonal.</returns>
        /// <remarks>For non-square matrices, the method returns Min(Rows, Columns)
        /// elements where i == j (i is the row index, and j is the column index).</remarks>
        public Vector Diagonal()
        {
            return new Vector(storage.Diagonal());
        }
        
        /// <summary>
        /// Divides each element of this matrix with a scalar.
        /// </summary>
        /// <param name="value">The scalar value to divide with.</param>
        /// <returns>The result of the division.</returns>
        public Matrix Divide(double value)
        {
            return new Matrix(storage.Divide(value));
        }
        
        /// <summary>
        /// Divides a scalar by each element of the matrix.
        /// </summary>
        /// <param name="value">The scalar to divide.</param>
        /// <returns>The result of the division.</returns>
        public Matrix DivideByThis(double value)
        {
            return new Matrix(storage.DivideByThis(value));
        }

        /// <summary>
        /// Multiplies this matrix with another matrix and returns the result.
        /// </summary>
        /// <param name="other">The matrix to multiply with.</param>
        /// <returns>The result of the multiplication.</returns>
        /// <exception cref="T:System.ArgumentException">If this.Columns != other.Rows.</exception>
        public Matrix Multiply(Matrix other)
        {
            return new Matrix(storage.Multiply(other.storage));
        }

        /// <summary>
        /// Multiplies this matrix by a vector and returns the result.
        /// </summary>
        /// <param name="rightSide">The vector to multiply with.</param>
        /// <returns>The result of the multiplication.</returns>
        /// <exception cref="T:System.ArgumentException">If this.ColumnCount != rightSide.Count.</exception>
        public Vector Multiply(Vector rightSide)
        {
            return new Vector(storage.Multiply(rightSide.Storage));
        }
        
        /// <summary>
        /// Multiplies each element of this matrix with a scalar.
        /// </summary>
        /// <param name="value">The scalar to multiply with.</param>
        /// <returns>The result of the multiplication.</returns>
        public Matrix Multiply(double value)
        {
            return new Matrix(storage.Multiply(value));
        }
        /// <summary>
        /// Returns this matrix as array of row arrays. The returned arrays will be independent
        /// from this matrix. A new memory block will be allocated for the arrays.</summary>
        public double[][] ToArray()
        {
            return storage.ToRowArrays();
        }

        /// <summary>
        /// Saves this Matrix to a given CSV file.
        /// </summary>
        /// <param name="filePath">The CSV file path</param>
        /// <returns></returns>
        public Matrix ToCSVFile(string filePath)
        {
            DelimitedWriter.Write<double>(filePath, storage, ",");
            return this;
        }
        
        /// <summary>
        /// Retrieves the requested element without range checking.
        /// </summary>
        /// <param name="row">The row index of the element.</param>
        /// <param name="column">The column index of the element.</param>
        /// <returns>The requested element.</returns>
        public double ElementAt(int row, int column)
        {
            return storage.At(row, column);
        }
        
        /// <summary>
        /// Copies a column into a new Vector>.
        /// </summary>
        /// <param name="index">The column to copy.</param>
        /// <returns>A Vector containing the copied elements.</returns>
        public Vector Column(int index)
        {
            return new Vector(storage.Column(index));
        }
        
        /// <summary>
        /// Copies a row into a new Vector>.
        /// </summary>
        /// <param name="index">The row to copy.</param>
        /// <returns>A Vector containing the copied elements.</returns>
        public Vector Row(int index)
        {
            return new Vector(storage.Row(index));
        }
        
        /// <summary>
        /// Returns the transpose of this matrix.
        /// </summary>
        /// <returns>The transpose of this matrix.</returns>
        public Matrix Transpose()
        {
            return new Matrix(storage.Transpose());
        }
        
        /// <summary>
        /// Computes the inverse of this matrix.
        /// </summary>
        /// <returns>The inverse of this matrix.</returns>
        public Matrix Inverse()
        {
            return new Matrix(storage.Inverse());
        }

        /// <summary>
        /// Computes the Moore-Penrose Pseudo-Inverse of this matrix.
        /// </summary>
        public Matrix PseudoInverse()
        {
            return new Matrix(storage.PseudoInverse());
        }

        /// <summary>
        /// Subtracts a scalar value from each element of the matrix.
        /// </summary>
        /// <param name="value">The scalar value to subtract.</param>
        /// <returns>A new matrix containing the subtraction of this matrix and the scalar.</returns>
        public Matrix Subtract(double value)
        {
            return new Matrix(storage.Subtract(value));
        }
        
        /// <summary>
        /// Subtracts another matrix from this matrix.
        /// </summary>
        /// <param name="other">The matrix to subtract.</param>
        /// <returns>The result of the subtraction.</returns>
        public Matrix Subtract(Matrix other)
        {
            return new Matrix(storage.Subtract(other.storage));
        }

        /// <summary>
        /// Solves a system of linear equations, Ax = y, with A QR factorized.
        /// </summary>
        /// <param name="y">The right hand side vector</param>
        /// <returns>The left hand side vector x</returns>
        public Vector SolveLinearEquation(Vector y)
        {
            return new Vector(storage.Solve(y.Storage));
        }

        /// <summary>
        /// Creates a matrix that contains the values from the requested sub-matrix.
        /// </summary>
        /// <param name="rowIndex">The row to start copying from.</param>
        /// <param name="rowCount">The number of rows to copy. Must be positive.</param>
        /// <param name="columnIndex">The column to start copying from.</param>
        /// <param name="columnCount">The number of columns to copy. Must be positive.</param>
        /// <returns>The requested sub-matrix.</returns>
        public Matrix SubMatrix(int rowIndex, int rowCount, int columnIndex, int columnCount)
        {
            return new Matrix(storage.SubMatrix(rowIndex, rowCount, columnIndex, columnCount));
        }

        /// <summary>
        ///     Shuffles the matrix by randomizing the order of its rows.
        /// </summary>
        /// <returns name="matrix">Randomized Matrix by rows.</returns>
        /// <search>random,randomize,shuffle,jitter,randomness</search>
        public Matrix ShuffleRows()
        {
            var rng = new Random();
            var rows = storage.EnumerateRows().OrderBy(_ => rng.Next());
            return new Matrix(CreateMatrix.DenseOfRowVectors(rows));
        }

        /// <summary>
        /// Determines whether the specified System.Object is equal to this instance.
        /// </summary>
        /// <param name="obj">The System.Object to compare with this instance.</param>
        /// <returns>true if the specified System.Object is equal to this instance; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            var m = obj as Matrix;
            return m != null ? storage.Equals(m.storage) : false;
        }
        
        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(Matrix other)
        {
            return storage.Equals(other.storage);
        }

        /// <summary>
        /// Gets the string representation.
        /// </summary>
        public override string ToString()
        {
            return string.Format("Matrix[{0}x{1}]", RowCount, ColumnCount);
        }

        /// <summary>
        /// Returns hash code
        /// </summary>
        public override int GetHashCode()
        {
            return storage.GetHashCode();
        }
        #endregion

        #region constructors
        /// <summary>
        /// Create a new matrix with the given number of rows and columns. All cells
        /// of the matrix will be initialized to zero. Zero-length matrices are not 
        /// supported.
        /// </summary>
        public static Matrix Zeros(int rows, int columns)
        {
            return new Matrix(CreateMatrix.Dense<double>(rows, columns));
        }

        /// <summary>
        /// Create a new matrix with the given number of rows and columns. All cells
        /// of the matrix will be initialized to one. Zero-length matrices are not 
        /// supported. 
        /// </summary>
        public static Matrix Ones(int rows, int columns)
        {
            return new Matrix(CreateMatrix.Dense<double>(rows, columns, 1));
        }

        /// <summary>
        /// Create a new matrix with the given number of rows and columns. All cells
        /// of the matrix will be initialized to the given value. Zero-length matrices 
        /// are not supported.
        /// </summary>
        /// <param name="rows">Number of rows</param>
        /// <param name="columns">Number of columns</param>
        /// <param name="value">The initial value for each cells.</param>
        /// <returns>A matrix initialized with given value</returns>
        public static Matrix ByValue(int rows, int columns, double value)
        {
            return new Matrix(CreateMatrix.Dense<double>(rows, columns, value));
        }

        /// <summary>
        /// Create a new dense matrix with the given number of rows and columns directly
        /// binding to a raw array. The array is assumed to be in column-major order (column
        /// by column) and is used directly without copying. Very efficient, but changes
        /// to the array and the matrix will affect each other.
        /// </summary>
        public static Matrix Reshape(int rows, int columns, double[] values)
        {
            return new Matrix(CreateMatrix.Dense(rows, columns, values));
        }

        /// <summary>
        /// Create a new diagonal identity matrix with a one-diagonal.
        /// </summary>
        public static Matrix Identity(int order)
        {
            return new Matrix(CreateMatrix.DiagonalIdentity<double>(order));
        }

        /// <summary>
        /// Create a new dense matrix with values sampled from the standard distribution
        /// with a system random source.
        /// </summary>
        public static Matrix Random(int rows, int columns)
        {
            return new Matrix(CreateMatrix.Random<double>(rows, columns));
        }

        /// <summary>
        /// Create a new dense matrix with values sampled from the standard distribution
        /// with a system random source.
        /// </summary>
        public static Matrix Random(int rows, int columns, int seed)
        {
            return new Matrix(CreateMatrix.Random<double>(rows, columns, seed));
        }

        /// <summary>
        /// Create a new dense matrix with the diagonal as a copy of the given vector. This
        /// new matrix will be independent from the vector. A new memory block will be allocated
        /// for storing the matrix.
        /// </summary>
        public static Matrix ByDiagonalVector(Vector diagonal)
        {
            return new Matrix(CreateMatrix.DenseOfDiagonalVector(diagonal.Storage));
        }

        /// <summary>
        /// Create a new square diagonal matrix directly binding to a raw array. The array
        /// is assumed to represent the diagonal values and is used directly without copying.
        /// Very efficient, but changes to the array and the matrix will affect each other.
        /// </summary>
        public static Matrix ByDiagonalVector(double[] diagonal)
        {
            return new Matrix(CreateMatrix.Diagonal(diagonal));
        }

        /// <summary>
        /// Create a new dense matrix as a copy of the given enumerable of columns.
        ///     Each list in the master enumerable specifies a column. This new matrix
        ///     will be independent from the enumerables. A new memory block will be allocated
        ///     for storing the matrix.
        /// </summary>
        public static Matrix ByColumns(IEnumerable<double[]> columns)
        {
            return new Matrix(CreateMatrix.DenseOfColumnArrays(columns));
        }

        /// <summary>
        /// Create a new dense matrix as a copy of the given column vectors. This new matrix
        ///     will be independent from the vectors. A new memory block will be allocated for
        ///     storing the matrix.
        /// </summary>
        public static Matrix ByColumns(IEnumerable<Vector> columns)
        {
            return new Matrix(CreateMatrix.DenseOfColumnVectors(columns.Select(c => c.Storage)));
        }

        /// <summary>
        /// Create a new dense matrix of T as a copy of the given row arrays. This new matrix
        ///     will be independent from the arrays. A new memory block will be allocated for
        ///     storing the matrix.
        /// </summary>
        public static Matrix ByRows(IEnumerable<double[]> rows)
        {
            return new Matrix(CreateMatrix.DenseOfRowArrays(rows));
        }

        /// <summary>
        /// Create a new dense matrix as a copy of the given row vectors. This new matrix
        /// will be independent from the vectors. A new memory block will be allocated for
        /// storing the matrix.</summary>
        public static Matrix ByRows(IEnumerable<Vector> rows)
        {
            return new Matrix(CreateMatrix.DenseOfRowVectors(rows.Select(r => r.Storage)));
        }

        /// <summary>
        /// Reads a CSV file and creates a matrix
        /// </summary>
        /// <param name="filePath">The SCV file path</param>
        /// <returns>Matrix</returns>
        public static Matrix ReadFromCSV(string filePath)
        {
            var m = DelimitedReader.Read<double>(filePath, false, ",");
            return new Matrix(m);
        }
        #endregion
    }
}
