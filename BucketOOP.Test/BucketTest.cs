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
        //Temp
        public static IEnumerable<object[]> BucketFilling
        {
            get
            {
                return new List<object[]>
                {
                    new object[]{1, 1},
                    new object[]{0, 0},
                    new object[]{12, 12},
                    new object[]{14, 12},
                };
            }
        }

        [DataTestMethod]
        [DynamicData(nameof(BucketFilling), DynamicDataSourceType.Property)]
        [TestMethod]
        public void DefaultFill(int addedAmount, int expectedContent)
        {
            //Arrange in TestInitialize

            //Act
            bucket.Fill(addedAmount);

            //Assert
            Assert.AreEqual(expectedContent, bucket.Content);
        }
    }
}
