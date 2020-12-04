using BucketOOP.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace BucketOOP.Classes
{
    public abstract class Container
    {

        #region properties;
        public int Capacity { get; protected set; }
        public int Content { get; set; }       
        #endregion

        #region contructors
        public Container() { }

        public Container(int capacity)
        {
            Capacity = capacity;
        }

        public Container(int capacity, int content)
        {
            Capacity = capacity;
            Content = content;
        }
        #endregion
        /*TODO IMplement
        Code check fullness before fill.
         if (Content + amount > Capacity)
            {
                ContainerAmountEventArgs args = new ContainerAmountEventArgs();
                args.Amount = Capacity - Content;
                OnNearCapacityAmount(args);
            }
         */

        #region methods
        public void Fill(int amount)
        {
            int PriorContent = Content;
            Content += amount;

            if (PriorContent < Capacity && Content == Capacity)
                OnCapacityReached(EventArgs.Empty);
            else if (Content > Capacity)
            {
                CapacityDeviationEventArgs args = new CapacityDeviationEventArgs();
                args.Amount = Content - Capacity;
                OnOverCapacityAmount(args);

                //Set Content to Capacity, as all excess would be "spiled".
                Content = Capacity;
            }
        }
        public void Empty()
        {
            Content = 0;
        }
        public void Empty(int amount)
        {
            if (Content - amount < 0)
                Empty();
            else
                Content -= amount;
        }
        #endregion

        #region events
        private event EventHandler CapacityReached;
        protected virtual void OnCapacityReached(EventArgs e)
        {
            EventHandler handler = CapacityReached;
            handler?.Invoke(this, e);
        }
        /// <summary>
        /// Will return how much till the capacity of container is reached.
        /// </summary>
        private event EventHandler<CapacityDeviationEventArgs> NearCapacityAmount;
        protected virtual void OnNearCapacityAmount(CapacityDeviationEventArgs e)
        {
            EventHandler<CapacityDeviationEventArgs> handler = NearCapacityAmount;
            handler?.Invoke(this, e);
        }
        /// <summary>
        /// Will return how much over capacity the container was filled.
        /// </summary>
        private event EventHandler<CapacityDeviationEventArgs> OverCapacityAmount;
        protected virtual void OnOverCapacityAmount(CapacityDeviationEventArgs e)
        {
            EventHandler<CapacityDeviationEventArgs> handler = OverCapacityAmount;
            handler?.Invoke(this, e);
        }
        #endregion
    }
}
