using System;
using System.Collections.Generic;
using System.Text;

namespace BucketOOP.Classes
{
    public class Regenton : Container
    {
        public Regenton(RegentonSizes size)
        {
            Capacity = ConvertSizeToInt(size);
        }
        public Regenton(RegentonSizes size, int content)
        {
            Capacity = ConvertSizeToInt(size);
            Fill(content);
        }

        private static int ConvertSizeToInt(RegentonSizes size)
        {
            return size switch
            {
                RegentonSizes.Small => 80,
                RegentonSizes.Medium => 120,
                RegentonSizes.Large => 160,
                _ => 80,
            };
        }
    }

    public enum RegentonSizes
    {
        Small,
        Medium,
        Large
    }
}
