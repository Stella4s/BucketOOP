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
        [TestMethod]
        public void OilDrumDefaultConstructor_SetsCorrectCapacity()
        {
            //Arrange
            OilDrum testOilDrum = new OilDrum();
            //Act?
            //Assert
            Assert.AreEqual(159, testOilDrum.Capacity);
        }
        [DataTestMethod]
        [DynamicData(nameof(TestData.OilDrumConstructContentData), typeof(TestData), DynamicDataSourceType.Property)]
        [TestMethod]
        public void OilDrumContentConstructor_SetsCorrectContent(int setContent, int expectedContent)
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
