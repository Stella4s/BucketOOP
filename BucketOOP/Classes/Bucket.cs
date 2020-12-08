using BucketOOP.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace BucketOOP.Classes
{
    public class Bucket : Container
    {
        public const int MinCapacity = 10;
        private bool IsNearCapacityRaised;

        #region constructors
        /// <summary>
        /// Standard constructor sets capacity at 12;
        /// </summary>
        public Bucket(): this(12, 0){}

        public Bucket(int capacity) : this(capacity, 0){}

        /// <summary>
        /// Does not allow capacity to be set below MinCapacity.
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="content"></param>
        public Bucket(int capacity, int content)
        {
            if (capacity < MinCapacity)
                capacity = MinCapacity;
            Capacity = capacity;

            //Instead of Content(Fill), check if content isn't over capacity. Then set it.
            //Might change back later.
            if (content > Capacity)
                content = Capacity;
            Content = content;
        }
        #endregion

        /// <summary>
        /// Fills bucket with content of other specified bucket. Empties other bucket.
        /// </summary>
        /// <param name="supplyBucket"></param>
        public void Fill(Bucket supplyBucket)
        {
            Fill(supplyBucket.Content);
            //Only empty the other bucket if NearCapacity was not raised.
            if (!IsNearCapacityRaised) { 
                if (!IsNearCapacityRaised)
                    supplyBucket.Empty();
                IsNearCapacityRaised = false;
            }
        }
        /// <summary>
        /// Fills current bucket with part of the content of other specified bucket.
        /// </summary>
        /// <param name="supplyBucket"></param>
        /// <param name="amount">The amount to exchange.</param>
        public void Fill(Bucket supplyBucket, int amount)
        {
            //Check if the amount being added isn't more than is in the supplyBucket. 
            //If so the amount exchanged is the entire content of supplyBucket.
            if (amount > supplyBucket.Content)
                amount = supplyBucket.Content;
            Fill(amount);
            //Only empty the other bucket, if NearCapacity was not raised.
            if (!IsNearCapacityRaised)
                supplyBucket.Empty(amount);
            IsNearCapacityRaised = false;
        }

        protected override void OnNearCapacity(CapacityDeviationEventArgs e)
        {
            //Bucket specific code.
            IsNearCapacityRaised = true;
            //Raise baseclass event.
            base.OnNearCapacity(e);
        }
    }
}
