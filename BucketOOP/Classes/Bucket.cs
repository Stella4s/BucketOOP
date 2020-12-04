using System;
using System.Collections.Generic;
using System.Text;

namespace BucketOOP.Classes
{
    public class Bucket : Container
    {
        public const int MinCapacity = 10;

        #region constructors
        /// <summary>
        /// Standard constructor sets capacity at 12;
        /// </summary>
        public Bucket()
        {
            Capacity = 12;
        }
        /// <summary>
        /// Constructor sets customized bucket capacity.
        /// But no lower than MinCapacity.
        /// </summary>
        /// <param name="capacity"></param>
        public Bucket(int capacity)
        {
            if (capacity < MinCapacity)
                capacity = MinCapacity;
            Capacity = capacity;
        }
        public Bucket(int capacity, int content)
        {
            if (capacity < MinCapacity)
                capacity = MinCapacity;
            Capacity = capacity;
            Fill(content);
        }
        #endregion

        /// <summary>
        /// Fills bucket with content of other specified bucket. Empties other bucket.
        /// </summary>
        /// <param name="supplyBucket"></param>
        public void Fill(Bucket supplyBucket)
        {
            Fill(supplyBucket.Content);
            supplyBucket.Empty();
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
            supplyBucket.Empty(amount);
        }
    }
}
