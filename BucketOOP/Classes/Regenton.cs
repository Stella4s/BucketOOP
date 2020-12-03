using System;
using System.Collections.Generic;
using System.Text;

namespace BucketOOP.Classes
{
    public class Regenton : Container
    {
        public Regenton(RegentonSizes size)
        {
            switch (size)
            {
                case RegentonSizes.Small:
                    Capacity = 80;
                    break;
                case RegentonSizes.Medium:
                    Capacity = 120;
                    break;
                case RegentonSizes.Large:
                    Capacity = 160;
                    break;
            }
        }
    }

    public enum RegentonSizes
    {
        Small,
        Medium,
        Large
    }
}
