using System;
using System.Collections.Generic;
using System.Text;

namespace BucketOOP.Classes
{
    public class OilDrum : Container
    {
        private readonly int defaultCapacity = 159;
        public OilDrum()
        {
            Capacity = defaultCapacity;
        }
        public OilDrum(int content)
        {
            Capacity = defaultCapacity;
            Fill(content);
        }
    }
}
