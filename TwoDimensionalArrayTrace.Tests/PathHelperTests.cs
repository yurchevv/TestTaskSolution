using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TwoDimensionalArrayTrace.Tests
{
    [TestClass]
    public sealed class PathHelperTests
    {
        [TestMethod]
        [DataRow(1, 1000, 1, false)]
        [DataRow(1000, 1, 1, false)]
        [DataRow(2, 2, 2, false)]
        [DataRow(3, 3, 6, false)]
        [DataRow(3, 4, 10, false)]
        [DataRow(4, 5, 35, false)]
        [DataRow(5, 5, 70, false)]
        [DataRow(5, 6, null, true)]
        [DataRow(5, 7, null, true)]
        [DataRow(5, 8, null, true)]
        [DataRow(6, 6, null, true)]
        [DataRow(6, 7, null, true)]
        [DataRow(7, 7, null, true)]
        [DataRow(8, 8, null, true)]
        public void AssertThat_GetPathCount_ReturnsExpectedResult(int n, int m, int? expected, bool useOnlyTwoResultsToAssert)
        {
            // Act
            var result = PathHelper.GetPathCount(n, m);
            var recursiveResult = PathHelper.GetPathCountRecursively(0, 0, n, m);

            // Assert
            if (useOnlyTwoResultsToAssert)
            {
                Assert.AreEqual(result, recursiveResult);
            }
            else
            {
                Assert.AreEqual(expected, result);
                Assert.AreEqual(expected, recursiveResult);
                Assert.AreEqual(result, recursiveResult);
            }
        }

        [TestMethod]
        [DataRow(-1, 0)]
        [DataRow(10, 11)]
        public void AssertThat_GetPathCount_ThrowsArgumentOutOfRangeException(int n, int m)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => PathHelper.GetPathCount(n, m));
        }

        [TestMethod]
        [DataRow(-1, 0, 1, 2)]
        public void AssertThat_GetPathCountRecursively_ThrowsArgumentOutOfRangeException(int firstIndexStartingPosition, int secondIndexStartingPosition, int n, int m)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => PathHelper.GetPathCountRecursively(firstIndexStartingPosition, secondIndexStartingPosition, n, m));
        }
    }
}
