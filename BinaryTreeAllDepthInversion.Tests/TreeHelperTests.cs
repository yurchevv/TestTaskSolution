using AutoFixture;

namespace BinaryTreeAllDepthInversion.Tests
{
    [TestClass]
    public sealed class TreeHelperTests
    {
        [TestMethod]
        public void AssertThat_DoubleSwapResult_LeadsToInitial()
        {
            // Arrange
            var fixture = new Fixture();
            var randomSeed = new Random();
            var treeLength = randomSeed.Next(10, 1000); // Нет уверенности, что Fixture.Create<int>() создаст необходимый Length
            var treeContents = fixture.CreateMany<int>(treeLength).ToArray();

            var tree = TreeHelper.CreateBinaryTreeFromArray(treeContents);

            var expectedTree = TreeHelper.CreateBinaryTreeFromArray(treeContents);
            var tracedExpectedTreeList = new List<int>();
            TreeHelper.TraceTree(expectedTree, tracedExpectedTreeList);

            // Act
            var swappedTree = TreeHelper.Swap(tree);
            var doubleSwappedTree = TreeHelper.Swap(swappedTree);

            var tracedDoubleSwappedTreeList = new List<int>();
            TreeHelper.TraceTree(doubleSwappedTree, tracedDoubleSwappedTreeList);

            // Assert
            CollectionAssert.AreEqual(tracedExpectedTreeList, tracedDoubleSwappedTreeList);
        }
    }
}
