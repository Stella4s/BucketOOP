using System;
using System.Collections.Generic;
using System.Text;

namespace BucketOOP.Utility
{
    public class CapacityDeviationEventArgs : EventArgs
    {
        /// <summary>
        /// How much the content is over or under capacity.
        /// </summary>
        public int Amount { get; set; }
    }
}
