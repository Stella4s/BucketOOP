using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using BucketOOP.Classes;
using BucketOOP.Utility;

namespace BucketOOP.Test
{
    [TestClass]
    public class BucketEventsTest
    {
        #region Class Properties and Helper Methods
        private readonly int OverFillNum = 13;
        private bool _eventIsRaised;
        private object _eventSender;
        private CapacityDeviationEventArgs _eventArgs;

        private Bucket CreateDefaultBucket()
        {
            return new Bucket();
        }

        private void Bucket_CapacityReached(object sender, EventArgs e)
        {
            _eventIsRaised = true;
            _eventSender = sender;
        }
        private void Bucket_OverCapacity(object sender, CapacityDeviationEventArgs e)
        {
            _eventIsRaised = true;
            _eventSender = sender;
            _eventArgs = e;
        }
        private void Bucket_NearCapacity(object sender, CapacityDeviationEventArgs e)
        {
            _eventIsRaised = true;
            _eventSender = sender;
            _eventArgs = e;
        }
        #endregion
        #region TestInitalize and CleanUp Methods
        /// <summary>
        /// Resets all class wide properties at the start of each test.
        /// </summary>
        [TestInitialize]
        public void TestInitalize()
        {
            _eventIsRaised = false;
            _eventSender = null;
            _eventArgs = null;
        }
        #endregion

        #region CapacityReached Tests
        [TestMethod]
        [CapacityReached]
        public void CapacityReachedEvent_IsRaised_ByFill()
        {
            //Arrange
            Bucket bucket = CreateDefaultBucket();
            bucket.CapacityReached += Bucket_CapacityReached;

            //Act
            bucket.Fill(12);

            //Assert
            Assert.IsTrue(_eventIsRaised);
            Assert.AreSame(bucket, _eventSender);
        }
        [TestMethod]
        [CapacityReached]
        public void CapacityReachedEvent_NotRaised_ByOverFill()
        {
            //Arrange
            Bucket bucket = new Bucket(12, 12);
            bucket.CapacityReached += Bucket_CapacityReached;

            //Act
            bucket.Fill(4);

            //Assert
            Assert.IsFalse(_eventIsRaised);
        }
        [TestMethod]
        [CapacityReached]
        public void CapacityReachedEvent_IsRaised_ByEmptyThenFill()
        {
            //Arrange
            Bucket bucket = new Bucket(12, 12);
            bucket.CapacityReached += Bucket_CapacityReached;

            //Act
            bucket.Empty(4);
            bucket.Fill(4);

            //Assert
            Assert.IsTrue(_eventIsRaised);
        }
        #endregion
        #region OverCapacity Tests
        [TestMethod]
        [OverCapacity]
        public void OverCapacityEvent_IsRaised_ByOverFill()
        {
            //Arrange
            Bucket bucket = CreateDefaultBucket();
            bucket.OverCapacity += Bucket_OverCapacity;

            //Act
            bucket.Fill(OverFillNum);

            //Assert
            Assert.IsTrue(_eventIsRaised);
            Assert.AreSame(bucket, _eventSender);
        }
        [TestMethod]
        [OverCapacity]
        public void OverCapacityEvent_ReturnsCorrectExcess()
        {
            //Arrange
            Bucket bucket = CreateDefaultBucket();
            bucket.OverCapacity += Bucket_OverCapacity;

            //Act
            bucket.Fill(OverFillNum);

            //Assert
            Assert.AreEqual(1, _eventArgs.Amount);
        }
        [TestMethod]
        [OverCapacity]
        public void OverCapacityEvent_IsRaisedTwice_ByRepeatOverFill()
        {
            //Arrange
            List<string> receivedEvents = new List<string>();
            Bucket bucket = CreateDefaultBucket();
            bucket.OverCapacity += delegate (object sender, CapacityDeviationEventArgs e)
            {
                receivedEvents.Add(sender.ToString());
            };

            //Act
            bucket.Fill(OverFillNum);
            bucket.Fill(6);

            //Assert
            Assert.AreEqual(2, receivedEvents.Count);
        }
        #endregion

        #region NearCapacityTests
        [TestMethod]
        [NearCapacity]
        public void NearCapacityEvent_IsRaised_ByOverFill()
        {
            //Arrange
            Bucket bucket = CreateDefaultBucket();
            bucket.UseNearCapacity = true;
            bucket.NearCapacity += Bucket_NearCapacity;

            //Act
            bucket.Fill(OverFillNum);

            //Assert
            Assert.IsTrue(_eventIsRaised);
            Assert.AreSame(bucket, _eventSender);
        }
        [TestMethod]
        [NearCapacity]
        public void NearCapacityEvent_ReturnsCorrectDeviation()
        {
            //Arrange
            Bucket bucket = CreateDefaultBucket();
            bucket.UseNearCapacity = true;
            bucket.NearCapacity += Bucket_NearCapacity;

            //Act
            bucket.Fill(OverFillNum);

            //Assert
            Assert.AreEqual(12, _eventArgs.Amount);
        }
        [TestMethod]
        [NearCapacity]
        public void NearCapacityEvent_NotRaised_ByFill()
        {
            //Arrange
            Bucket bucket = CreateDefaultBucket();
            bucket.UseNearCapacity = true;
            bucket.NearCapacity += Bucket_NearCapacity;

            //Act
            bucket.Fill(12);

            //Assert
            Assert.IsFalse(_eventIsRaised);
        }
        #endregion

    }
}
