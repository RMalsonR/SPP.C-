using System;
using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solver.Test
{
    [TestClass]
    public class Test
    {
        public void TestQuadraticEquationsSolver( double a, double b, double c, params double[] expectedResults) 
        {
            var result = Library.Solver.QuadraticEquationsSolver(a, b, c);
            Assert.AreEqual(expectedResults.Length, result.Length);

            for (int i = 0; i < result.Length; i++)
                Assert.AreEqual(expectedResults[i], result[i]);
        }

        [TestMethod]
        public void TestMethod1()
        {
            TestQuadraticEquationsSolver(1, -3, 2, 2, 1);
        }

        [TestMethod]
        public void TestNegativeDiscriminant()
        {
            TestQuadraticEquationsSolver(1, 1, 1);
        }
        
        [TestMethod]
        public void NullDescriminant()
        {
            TestQuadraticEquationsSolver(1, -2, 1, 1);
        }
    }
}
