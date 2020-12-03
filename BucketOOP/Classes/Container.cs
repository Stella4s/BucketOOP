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

        #region methods
        public void Fill(int amount)
        {
            if (Content + amount > Capacity)
            {
                OnNearCapacity(EventArgs.Empty);

                ContainerAmountEventArgs args = new ContainerAmountEventArgs();
                args.Amount = Capacity - Content;
                OnNearCapacityAmount(args);
            }

            Content += amount;

            if (Content == Capacity)
                OnCapacityReached(EventArgs.Empty);
            else if (Content > Capacity)
            {
                OnOverCapacity(EventArgs.Empty);

                ContainerAmountEventArgs args = new ContainerAmountEventArgs();
                args.Amount = Content - Capacity;
                OnOverCapacityAmount(args);
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
        private event EventHandler NearCapacity;
        protected virtual void OnNearCapacity(EventArgs e)
        {
            EventHandler handler = NearCapacity;
            handler?.Invoke(this, e);
        }
        /// <summary>
        /// Will return how much till the capacity of container is reached.
        /// </summary>
        private event EventHandler<ContainerAmountEventArgs> NearCapacityAmount;
        protected virtual void OnNearCapacityAmount(ContainerAmountEventArgs e)
        {
            EventHandler<ContainerAmountEventArgs> handler = NearCapacityAmount;
            handler?.Invoke(this, e);
        }
        private event EventHandler OverCapacity;
        protected virtual void OnOverCapacity(EventArgs e)
        {
            EventHandler handler = OverCapacity;
            handler?.Invoke(this, e);
        }
        /// <summary>
        /// Will return how much over capacity the container was filled.
        /// </summary>
        private event EventHandler<ContainerAmountEventArgs> OverCapacityAmount;
        protected virtual void OnOverCapacityAmount(ContainerAmountEventArgs e)
        {
            EventHandler<ContainerAmountEventArgs> handler = OverCapacityAmount;
            handler?.Invoke(this, e);
        }
        #endregion
    }
}
