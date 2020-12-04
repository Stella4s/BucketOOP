using BucketOOP.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BucketOOP.Test
{
    [TestClass]
    public class BucketTest
    {
        #region test initalize and cleanup
        private Bucket bucket;

        [TestInitialize]
        public void TestInitialize()
        {
            bucket = new Bucket();
        }
        [TestCleanup]
        public void TestCleanup()
        {
        }
        #endregion

        [DataTestMethod]
        [DynamicData(nameof(TestData.BucketFillData), typeof(TestData), DynamicDataSourceType.Property)]
        [TestMethod]
        public void DefaultFill_ReturnsCorrectContent(int addedAmount, int expectedContent)
        {
            //Arrange in TestInitialize

            //Act
            bucket.Fill(addedAmount);

            //Assert
            Assert.AreEqual(expectedContent, bucket.Content);
        }
        [DataTestMethod]
        [DynamicData(nameof(TestData.BucketEmptyData), typeof(TestData), DynamicDataSourceType.Property)]
        [TestMethod]
        public void Empty_ReturnsCorrectContent(int removedAmount, int expectedContent)
        {
            //Arrange
            int maxCap = bucket.Capacity;
            bucket.Fill(maxCap);

            //Act
            bucket.Empty(removedAmount);

            //Assert
            Assert.AreEqual(expectedContent, bucket.Content);
        }
    }
}
