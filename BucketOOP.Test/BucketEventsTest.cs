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
        public void Bucket_Fill_Raises_CapacityReachedEvent()
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
        public void Bucket_OverFill_DoesNOTRaise_CapacityReachedEvent()
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
        public void Bucket_EmptyThenFill_Raises_CapacityReachedEvent()
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
        public void Bucket_OverFill_Raises_OverCapacityEvent()
        {
            //Arrange
            Bucket bucket = CreateDefaultBucket();
            bucket.OverCapacity += Bucket_OverCapacity;

            //Act
            bucket.Fill(13);

            //Assert
            Assert.IsTrue(_eventIsRaised);
            Assert.AreSame(bucket, _eventSender);
        }
        [TestMethod]
        public void Bucket_OverCapacityEvent_ReturnsCorrectExcess()
        {
            //Arrange
            Bucket bucket = CreateDefaultBucket();
            bucket.OverCapacity += Bucket_OverCapacity;

            //Act
            bucket.Fill(13);

            //Assert
            Assert.AreEqual(1, _eventArgs.Amount);
        }
        [TestMethod]
        public void Bucket_RepeatFill_RaisesMultiple_OverCapacityEvents()
        {
            //Arrange
            List<string> receivedEvents = new List<string>();
            Bucket bucket = CreateDefaultBucket();
            bucket.OverCapacity += delegate (object sender, CapacityDeviationEventArgs e)
            {
                receivedEvents.Add(sender.ToString());
            };

            //Act
            bucket.Fill(13);
            bucket.Fill(6);

            //Assert
            Assert.AreEqual(2, receivedEvents.Count);
        }
        #endregion

    }
}
