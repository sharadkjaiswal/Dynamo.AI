using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.DesignScript.Runtime;
using MathNet.Numerics.LinearAlgebra;
using NumVector = MathNet.Numerics.LinearAlgebra.Vector<double>;

namespace Dynamo.AI.Data
{
    /// <summary>
    /// Represents a vector
    /// </summary>
    public class Vector
    {
        private NumVector storage;

        internal Vector(NumVector s)
        {
            storage = s;
        }

        internal NumVector Storage { get { return storage; } }

        #region Operations
        /// <summary>
        /// Gets the length or number of dimensions of this vector.
        /// </summary>
        public int Size { get { return storage.Count; } }

        /// <summary>
        /// Computes the absolute value of a vector pointwise
        /// </summary>
        public Vector Abs()
        {
            return new Vector(NumVector.Abs(storage));
        }

        /// <summary>
        /// Computes the acos of a vector pointwise
        /// </summary>
        public Vector Acos()
        {
            return new Vector(NumVector.Acos(storage));
        }

        /// <summary>
        /// Computes the asin of a vector pointwise
        /// </summary>
        public Vector Asin()
        {
            return new Vector(NumVector.Asin(storage));
        }

        /// <summary>
        /// Computes the atan of a vector pointwise
        /// </summary>
        public Vector Atan()
        {
            return new Vector(NumVector.Atan(storage));
        }

        /// <summary>
        /// Computes the ceiling of a vector pointwise
        /// </summary>
        public Vector Ceiling()
        {
            return new Vector(NumVector.Ceiling(storage));
        }

        /// <summary>
        /// Computes the cos of a vector pointwise
        /// </summary>
        public Vector Cos()
        {
            return new Vector(NumVector.Cos(storage));
        }

        /// <summary>
        /// Computes the cosh of a vector pointwise
        /// </summary>
        public Vector Cosh()
        {
            return new Vector(NumVector.Cosh(storage));
        }

        /// <summary>
        /// Computes the exponential of a vector pointwise
        /// </summary>
        public Vector Exp()
        {
            return new Vector(NumVector.Exp(storage));
        }

        /// <summary>
        /// Computes the floor of a vector pointwise
        /// </summary>
        public Vector Floor()
        {
            return new Vector(NumVector.Floor(storage));
        }

        /// <summary>
        /// Computes the log of a vector pointwise
        /// </summary>
        public Vector Log()
        {
            return new Vector(NumVector.Log(storage));
        }

        /// <summary>
        /// Computes the log10 of a vector pointwise
        /// </summary>
        public Vector Log10()
        {
            return new Vector(NumVector.Log10(storage));
        }

        /// <summary>
        /// Computes elementwise/pointwise division of two vectors of same size
        /// </summary>
        /// <param name="dividend">The numerator</param>
        /// <param name="divisor">The denominator</param>
        /// <returns>Result vector</returns>
        public static Vector DotDivide(Vector dividend, Vector divisor)
        {
            return new Vector(NumVector.op_DotDivide(dividend.storage, divisor.storage));
        }

        /// <summary>
        /// Computes elementwise/pointwise raise the given vector to a given exponent.
        /// </summary>
        /// <param name="vector">The input vector</param>
        /// <param name="exponent">The power exponent</param>
        /// <returns>Result vector</returns>
        public static Vector DotHat(Vector vector, double exponent)
        {
            return new Vector(NumVector.op_DotHat(vector.storage, exponent));
        }

        /// <summary>
        /// Computes elementwise/pointwise raise the given vector to a given exponent.
        /// </summary>
        /// <param name="vector">The input vector</param>
        /// <param name="exponent">The power exponent</param>
        /// <returns>Result vector</returns>
        public static Vector DotHat(Vector vector, Vector exponent)
        {
            return new Vector(NumVector.op_DotHat(vector.storage, exponent.storage));
        }

        /// <summary>
        /// Computes elementwise/pointwise multiplication of two given vectors of
        /// same size.
        /// </summary>
        /// <param name="x">First vector</param>
        /// <param name="y">Second vector</param>
        /// <returns>Result vector</returns>
        public static Vector DotMultiply(Vector x, Vector y)
        {
            return new Vector(NumVector.op_DotMultiply(x.storage, y.storage));
        }

        /// <summary>
        /// Pointwise remainder (% operator), where the result has the sign of 
        /// the dividend, of the dividend vector by divisor vector.
        /// </summary>
        /// <param name="dividend">The numerator</param>
        /// <param name="divisor">The denominator</param>
        /// <returns>Result vector</returns>
        public static Vector DotPercent(Vector dividend, Vector divisor)
        {
            return new Vector(NumVector.op_DotPercent(dividend.storage, divisor.storage));
        }
        
        /// <summary>
        /// Computes the rounded value of a vector pointwise
        /// </summary>
        public Vector Round()
        {
            return new Vector(NumVector.Round(storage));
        }

        /// <summary>
        /// Computes the sin of a vector pointwise
        /// </summary>
        public Vector Sin()
        {
            return new Vector(NumVector.Sin(storage));
        }

        /// <summary>
        /// Computes the sinh of a vector pointwise
        /// </summary>
        public Vector Sinh()
        {
            return new Vector(NumVector.Sinh(storage));
        }

        /// <summary>
        /// Computes the sqrt of a vector pointwise
        /// </summary>
        public Vector Sqrt()
        {
            return new Vector(NumVector.Sqrt(storage));
        }

        /// <summary>
        /// Computes the tan of a vector pointwise
        /// </summary>
        public Vector Tan()
        {
            return new Vector(NumVector.Tan(storage));
        }

        /// <summary>
        /// Computes the tanh of a vector pointwise
        /// </summary>
        public Vector Tanh()
        {
            return new Vector(NumVector.Tanh(storage));
        }

        /// <summary>
        /// Adds a scalar to each element of the vector.
        /// </summary>
        /// <param name="value">The scalar to add.</param>
        /// <returns>A new vector with the scalar added.</returns>
        public Vector Add(double value)
        {
            return new Vector(storage.Add(value));
        }
        
        /// <summary>
        /// Adds another vector to this vector.
        /// </summary>
        /// <param name="other">The vector to add to this one.</param>
        /// <returns>A new vector containing the sum of both vectors.</returns>
        public Vector Add(Vector other)
        {
            return new Vector(storage.Add(other.storage));
        }
        
        /// <summary>
        /// Gets the value at the given index without range checking
        /// </summary>
        /// <param name="index">The index of the value to get or set.</param>
        /// <returns>The value of the vector at the given index.</returns>
        public double ElementAt(int index)
        {
            return storage.At(index);
        }
        
        /// <summary>
        /// Divides each element of the vector by a scalar.
        /// </summary>
        /// <param name="value">The scalar to divide with.</param>
        /// <returns>A new vector that is the division of the vector and the scalar.</returns>
        public Vector Divide(double value)
        {
            return new Vector(storage.Divide(value));
        }
        
        /// <summary>
        /// Divides a scalar by each element of the vector.
        /// </summary>
        /// <param name="value">The scalar to divide.</param>
        /// <returns>A new vector that is the division of the vector and the scalar.</returns>
        public Vector DivideByThis(double value)
        {
            return new Vector(storage.DivideByThis(value));
        }
        
        /// <summary>
        /// Computes the dot product between this vector and another vector.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>The sum of a[i]*b[i] for all i.</returns>
        public double DotProduct(Vector other)
        {
            return storage.DotProduct(other.storage);
        }
        
        /// <summary>
        /// Returns an IEnumerable that can be used to iterate through all values of the
        /// vector.
        /// </summary>
        /// <returns>The enumerator will include all values, even if they are zero.</returns>
        public IEnumerable<double> Enumerate()
        {
            return storage.Enumerate();
        }
        
        /// <summary>
        /// Determines whether the specified System.Object is equal to this instance.
        /// </summary>
        public sealed override bool Equals(object obj)
        {
            var v = obj as Vector;
            return v != null ? storage.Equals(v.storage) : false;
        }
        
        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(Vector other)
        {
            return storage.Equals(other.storage);
        }
        
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public sealed override int GetHashCode()
        {
            return storage.GetHashCode();
        }

        /// <summary>
        /// Returns the value of maximum element.
        /// </summary>
        [MultiReturn("max", "index")]
        public Dictionary<string, double> Maximum()
        {
            return new Dictionary<string, double>() { { "max", storage.Maximum() }, { "index", storage.MaximumIndex() } };
        }

        /// <summary>
        /// Returns the value of the minimum element.
        /// </summary>
        [MultiReturn("min", "index")]
        public Dictionary<string, double> Minimum()
        {
            return new Dictionary<string, double>() { { "min", storage.Minimum() }, { "index", storage.MinimumIndex() } };
        }

        /// <summary>
        /// Multiplies a scalar to each element of the vector.
        /// </summary>
        /// <param name="value">The scalar to multiply.</param>
        /// <returns>A new vector that is the multiplication of the vector and the scalar.</returns>
        public Vector Multiply(double value)
        {
            return new Vector(storage.Multiply(value));
        }

        /// <summary>
        /// Returns a negated vector.
        /// </summary>
        public Vector Negate()
        {
            return new Vector(storage.Negate());
        }
        
        /// <summary>
        /// Computes the outer product M[i,j] = u[i]*v[j] of this and another vector.
        /// </summary>
        /// <param name="other">The other vector</param>
        /// <returns>Result matrix</returns>
        public Matrix OuterProduct(Vector other)
        {
            return new Matrix(storage.OuterProduct(other.storage));
        }
        
        /// <summary>
        /// Computes the remainder (vector % divisor), where the result has the sign of the
        /// dividend, for each element of the vector for the given divisor.
        /// </summary>
        /// <param name="divisor">The scalar denominator to use.</param>
        /// <returns>A vector containing the result.</returns>
        public Vector Remainder(double divisor)
        {
            return new Vector(storage.Remainder(divisor));
        }
        
        /// <summary>
        /// Subtracts a scalar from each element of the vector.
        /// </summary>
        /// <param name="value">The scalar to subtract.</param>
        /// <returns>A new vector containing the subtraction of this vector and the scalar.</returns>
        public Vector Subtract(double value)
        {
            return new Vector(storage.Subtract(value));
        }
        
        /// <summary>
        /// Subtracts another vector from this vector.
        /// </summary>
        /// <param name="other">The vector to subtract from this one.</param>
        /// <returns>A new vector containing the subtraction of the the two vectors.</returns>
        public Vector Subtract(Vector other)
        {
            return new Vector(storage.Subtract(other.storage));
        }
        
        /// <summary>
        /// Subtracts each element of the vector from a scalar.
        /// </summary>
        /// <param name="value">The scalar to subtract from.</param>
        /// <returns>A new vector containing the subtraction of the scalar and this vector.</returns>
        public Vector SubtractFrom(double value)
        {
            return new Vector(storage.SubtractFrom(value));
        }
        
        /// <summary>
        /// Creates a vector containing specified elements.
        /// </summary>
        /// <param name="index">The first element to begin copying from.</param>
        /// <param name="count">The number of elements to copy.</param>
        /// <returns>A vector containing a copy of the specified elements.</returns>
        public Vector SubVector(int index, int count)
        {
            return new Vector(storage.SubVector(index, count));
        }

        /// <summary>
        ///     Shuffles the vector, randomizing the order of its items.
        /// </summary>
        /// <returns name="vector">Randomized vector.</returns>
        /// <search>random,randomize,shuffle,jitter,randomness</search>
        public Vector Shuffle()
        {
            var rng = new Random();
            var s = storage.Enumerate().OrderBy(_ => rng.Next());
            return new Vector(CreateVector.DenseOfEnumerable(s));
        }

        /// <summary>
        /// Computes the sum of the vector's elements.
        /// </summary>
        public double Sum()
        {
            return storage.Sum();
        }

        /// <summary>
        /// Computes the sum of the absolute value of the vector's elements.
        /// </summary>
        public double SumMagnitudes()
        {
            return storage.SumMagnitudes();
        }

        /// <summary>
        /// Returns the data contained in the vector as an array. The returned array will
        /// be independent from this vector. A new memory block will be allocated for the
        /// array.
        /// </summary>
        public double[] ToArray()
        {
            return storage.ToArray();
        }

        /// <summary>
        /// Create a matrix based on this vector in column form (one single column).
        /// </summary>
        public Matrix ToColumnMatrix()
        {
            return new Matrix(storage.ToColumnMatrix());
        }

        /// <summary>
        /// Create a matrix based on this vector in row form (one single row).
        /// </summary>
        public Matrix ToRowMatrix()
        {
            return new Matrix(storage.ToRowMatrix());
        }

        /// <summary>
        /// Gets string representation.
        /// </summary>
        public override string ToString()
        {
            return string.Format("Vector[{0}x1]", Size);
        }
        
        #endregion

        #region Constructors
        /// <summary>
        /// Create a new vector and initialize each value using the provided value.
        /// </summary>
        /// <param name="size">Size of the vector</param>
        /// <returns>New Vector</returns>
        public static Vector Ones(int size)
        {
            return new Vector(CreateVector.Dense(size, 1.0));
        }

        /// <summary>
        /// Create a new vector and initialize each value as zero.
        /// </summary>
        /// <param name="size">Size of the vector</param>
        /// <returns>New Vector</returns>
        public static Vector Zeros(int size)
        {
            return new Vector(CreateVector.Dense<double>(size));
        }

        /// <summary>
        /// Create a new vector as a copy of the given list of values.
        /// </summary>
        /// <param name="values">List of values</param>
        /// <returns>New Vector</returns>
        public static Vector ByValues(double[] values)
        {
            return new Vector(CreateVector.DenseOfArray(values));
        }

        /// <summary>
        /// Create a new vector with values sampled from the standard distribution
        /// with a system random source.</summary>
        /// <param name="size">Size of the vector</param>
        /// <param name="seed">Seed parameter</param>
        /// <returns>New Vector</returns>
        public static Vector Random(int size, int seed)
        {
            return new Vector(CreateVector.Random<double>(size, seed));
        }
        #endregion
    }
}
