using System;
using System.Collections.Generic;
using System.Text;

namespace BucketOOP.Utility
{
    public class ContainerAmountEventArgs : EventArgs
    {
        /// <summary>
        /// Over or under capacity.
        /// </summary>
        public int Amount { get; set; }
    }
}
