using System;
using System.Collections.Generic;
using System.Text;

namespace BucketOOP.Classes
{
    public class OilDrum : Container
    {
        private readonly int defaultCapacity = 159;
        public OilDrum() : this (0){}

        /// <summary>
        /// Sets default capacity. Does not allow set content to be above default capacity.
        /// </summary>
        /// <param name="content"></param>
        public OilDrum(int content)
        {
            Capacity = defaultCapacity;
            if (content > Capacity)
                content = Capacity;
            Content = content;
        }
    }
}
