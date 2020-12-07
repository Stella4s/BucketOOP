using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using BucketOOP.Classes;

namespace BucketOOP.Test
{
    [TestClass]
    public class RegentonTest
    {
        #region TestMethods
        [RegentonTest]
        [DataTestMethod]
        [DynamicData(nameof(TestData.RegentonConstructCapacitytData), typeof(TestData), DynamicDataSourceType.Property)]
        [TestMethod]
        public void Constructor_SizeSetCorrectCapacity(RegentonSizes size, int expectedCapacity)
        {
            //Arrange
            Regenton testRegenTon;
            //Act
            testRegenTon = new Regenton(size);

            //Assert
            Assert.AreEqual(expectedCapacity, testRegenTon.Capacity);
        }
        #endregion
    }
}
