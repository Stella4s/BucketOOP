using BucketOOP.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BucketOOP.Test
{
    [TestClass]
    public class BucketTest
    {
        #region helper methods and properties.
        //Switched to helper methods instead of Initialize and Teardown due to bloat.
        private Bucket CreateDefaultBucket()
        {
            return new Bucket();
        }

        #endregion

        #region Constructor Tests
        [BucketTest]
        [DataTestMethod]
        [DynamicData(nameof(TestData.BucketConstructCapacityData), typeof(TestData), DynamicDataSourceType.Property)]
        [TestMethod]
        public void Constructor_SetsCorrectCapacity(int setCapacity, int expectedCapacity, bool checkDefaultCtor)
        {
            //Arrange
            Bucket testBucket;

            //Act
            if (checkDefaultCtor)
                testBucket = new Bucket();
            else
                testBucket = new Bucket(setCapacity);
            
            //Assert
            Assert.AreEqual(expectedCapacity, testBucket.Capacity);
        }
        [BucketTest]
        [DataTestMethod]
        [DynamicData(nameof(TestData.BucketConstructContentData), typeof(TestData), DynamicDataSourceType.Property)]
        [TestMethod]
        public void Constructor_SetsCorrectContentForCapacity(int setCapacity, int setContent, int expectedContent)
        {
            //Arrange
            Bucket testBucket;

            //Act
            testBucket = new Bucket(setCapacity, setContent);

            //Assert
            Assert.AreEqual(expectedContent, testBucket.Content);
        }
        #endregion

        #region Fill Tests
        [BucketTest]
        [DataTestMethod]
        [DynamicData(nameof(TestData.BucketFillData), typeof(TestData), DynamicDataSourceType.Property)]
        [TestMethod]
        public void DefaultFill_ReturnsCorrectContent(int addedAmount, int expectedContent)
        {
            //Arrange
            Bucket bucket = CreateDefaultBucket();

            //Act
            bucket.Fill(addedAmount);

            //Assert
            Assert.AreEqual(expectedContent, bucket.Content);
        }
        [BucketTest]
        [TestMethod]
        public void UseNearCapacity_Fill_ReturnsCorrectContent()
        {
            //Arrange
            Bucket bucket = CreateDefaultBucket();
            bucket.UseNearCapacity = true;

            //Act
            bucket.Fill(13);

            //Assert
            Assert.AreEqual(0, bucket.Content);
        }
        [BucketTest]
        [DataTestMethod]
        [DynamicData(nameof(TestData.BucketFillFromBucketData), typeof(TestData), DynamicDataSourceType.Property)]
        [TestMethod]
        public void FillFromBucket_ReturnsCorrectContent(int exchangedAmount, int setContentSupplier, int expectedContentReceiver, int expectedContentSupplier)
        {
            //Arrange
            Bucket bucket = CreateDefaultBucket();
            Bucket bucketSupplier = new Bucket();
            bucketSupplier.Fill(setContentSupplier);

            //Act
            bucket.Fill(bucketSupplier, exchangedAmount);

            //Assert
            Assert.AreEqual(expectedContentReceiver, bucket.Content);
            Assert.AreEqual(expectedContentSupplier, bucketSupplier.Content);
        }
        [BucketTest]
        [TestMethod]
        public void UseNearCapacity_StopFill_FillFromBucket_DoesNotEmptySupplier()
        {
            //Arrange
            Bucket bucketReceiver = CreateDefaultBucket();
            bucketReceiver.UseNearCapacity = true;
            Bucket bucketSupplier = new Bucket(13, 13);

            //Act
            bucketReceiver.Fill(bucketSupplier);

            //Assert
            Assert.AreEqual(0, bucketReceiver.Content);
            Assert.AreEqual(13, bucketSupplier.Content);
        }
        #endregion

        [BucketTest]
        [DataTestMethod]
        [DynamicData(nameof(TestData.BucketEmptyData), typeof(TestData), DynamicDataSourceType.Property)]
        [TestMethod]
        public void Empty_ReturnsCorrectContent(int removedAmount, int expectedContent)
        {
            //Arrange
            Bucket bucket = CreateDefaultBucket();
            int maxCap = bucket.Capacity;
            bucket.Fill(maxCap);

            //Act
            bucket.Empty(removedAmount);

            //Assert
            Assert.AreEqual(expectedContent, bucket.Content);
        }


    }
}
