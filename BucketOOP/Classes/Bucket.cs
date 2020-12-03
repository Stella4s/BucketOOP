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
        #endregion

        /// <summary>
        /// Fills bucket with content of other specified bucket.
        /// </summary>
        /// <param name="bucket"></param>
        public void Fill(Bucket bucket)
        {
            Fill(bucket.Content);
        }
    }
}
