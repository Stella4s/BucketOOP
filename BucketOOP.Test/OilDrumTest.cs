using System;
using System.Collections.Generic;
using System.Text;
using BucketOOP.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BucketOOP.Test
{
    [TestClass]
    public class OilDrumTest
    {
        #region Properties and Helper Methods
        #endregion

        #region TestMethods
        [OilDrumTest]
        [TestMethod]
        public void DefaultConstructor_SetsCorrectCapacity()
        {
            //Arrange
            OilDrum testOilDrum = new OilDrum();
            //Act?
            //Assert
            Assert.AreEqual(159, testOilDrum.Capacity);
        }
        [OilDrumTest]
        [DataTestMethod]
        [DynamicData(nameof(TestData.OilDrumConstructContentData), typeof(TestData), DynamicDataSourceType.Property)]
        [TestMethod]
        public void OverloadConstructor_SetsCorrectContent(int setContent, int expectedContent)
        {
            //Arrange
            OilDrum testOilDrum;

            //Act
            testOilDrum = new OilDrum(setContent);

            //Assert
            Assert.AreEqual(expectedContent, testOilDrum.Content);
        }
        #endregion
    }
}
