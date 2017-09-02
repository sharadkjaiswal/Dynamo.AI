using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.DesignScript.Runtime;
using MathNet.Numerics.LinearAlgebra;
using Stats = MathNet.Numerics.Statistics.Statistics;

namespace Dynamo.AI.Data
{
    /// <summary>
    /// Statistics algorithms
    /// </summary>
    public static class Statistics
    {
        /// <summary>
        /// Evaluates the sample mean, an estimate of the population mean. Returns NaN if
        ///     data is empty or if any entry is NaN.
        /// </summary>
        /// <param name="data">The data to calculate the mean of.</param>
        /// <returns>The mean of the sample.</returns>
        public static double Mean(IEnumerable<double> data)
        {
            return Stats.Mean(data);
        }

        /// <summary>
        /// Evaluates the sample mean, an estimate of the population mean. Returns NaN if
        /// data is empty or if any entry is NaN.
        /// </summary>
        /// <param name="data">The data to calculate the mean of.</param>
        /// <returns>The mean of the sample.</returns>
        public static double Mean(Vector data)
        {
            return Stats.Mean(data.Storage.Enumerate());
        }

        /// <summary>
        /// Evaluates the sample mean of each column as a vector of means, an estimate of 
        /// the population mean. Returns NaN if data is empty or if any entry is NaN.
        /// </summary>
        /// <param name="data">The matrix data to calculate the mean of.</param>
        /// <returns>The mean cector of the matrix data.</returns>
        public static Vector Mean(Matrix data)
        {
            var vec = data.Storage.EnumerateColumns().Select(v => Mean(v));
            return new Vector(CreateVector.DenseOfEnumerable(vec));
        }

        /// <summary>
        /// Estimates the unbiased population standard deviation from the provided samples.
        /// On a dataset of size N will use an N-1 normalizer (Bessel's correction). Returns
        /// NaN if data has less than two entries or if any entry is NaN.
        /// </summary>
        /// <param name="samples">A subset of samples, sampled from the full population.</param>
        /// <returns>Standard deviation and mean of the samples</returns>
        [MultiReturn("sd", "mean")]
        public static Dictionary<string, double> StandardDeviation(IEnumerable<double> samples)
        {
            var result = Stats.MeanStandardDeviation(samples);
            return new Dictionary<string, double>() { { "mean", result.Item1 }, { "sd", result.Item2 } };
        }

        /// <summary>
        /// Estimates the unbiased population standard deviation from the provided samples.
        /// On a dataset of size N will use an N-1 normalizer (Bessel's correction). Returns
        /// NaN if data has less than two entries or if any entry is NaN.
        /// </summary>
        /// <param name="data">A vector representing subset of samples, sampled 
        /// from the full population.</param>
        /// <returns>Standard deviation and mean of the samples</returns>
        [MultiReturn("sd", "mean")]
        public static Dictionary<string, double> StandardDeviation(Vector data)
        {
            return StandardDeviation(data.Enumerate());
        }

        /// <summary>
        /// Estimates the unbiased population standard deviation from the provided samples.
        /// On a dataset of size N will use an N-1 normalizer (Bessel's correction). Returns
        /// NaN if data has less than two entries or if any entry is NaN.
        /// </summary>
        /// <param name="data">A matrix representing subset of samples, sampled 
        /// from the full population.</param>
        /// <returns>Standard deviation and mean of the samples</returns>
        [MultiReturn("sd", "mean")]
        public static Dictionary<string, Vector> StandardDeviation(Matrix data)
        {
            var result = data.Storage.EnumerateColumns().Select(v => Stats.MeanStandardDeviation(v.Enumerate())).ToArray();
            return new Dictionary<string, Vector>() { { "mean", Vector.ByValues(result.Select(t => t.Item1).ToArray()) },
                                                      { "sd", Vector.ByValues(result.Select(t => t.Item2).ToArray()) } };
        }

        /// <summary>
        /// Normalizes the given matrix using mean and standard deviation vector
        /// </summary>
        /// <param name="data">The input matrix for normalization</param>
        /// <param name="mean">The mean vector</param>
        /// <param name="sd">The standard deviation vector</param>
        /// <returns>Normalized matrix</returns>
        public static Matrix Normalize(Matrix data, Vector mean, Vector sd)
        {
            var rows = data.Storage.EnumerateRows().Select(r => r.Subtract(mean.Storage).PointwiseDivide(sd.Storage));
            return Matrix.ByRows(rows.Select(v => new Vector(v)));
        }

        /// <summary>
        /// Normalizes the given vector using mean and standard deviation vector.
        /// All vectors should be of the same size.
        /// </summary>
        /// <param name="data">The input vector for normalization</param>
        /// <param name="mean"></param>
        /// <param name="sd"></param>
        /// <returns></returns>
        public static Vector Normalize(Vector data, Vector mean, Vector sd)
        {
            var vec = data.Storage.Subtract(mean.Storage).PointwiseDivide(sd.Storage);
            return new Vector(vec);
        }
    }
}
