﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BlingRus.Domain
{
    public class ShoppingCart : IHasAggregateCost
    {
        public Guid Id { get; protected set; }

        internal List<ShoppingCartItem> ContentsInternal { get; set; }

        public decimal AggregatedCost => ContentsInternal.Sum(c => c.AggregatedCost);
        public decimal AggregatedShippingCost => ContentsInternal.Sum(c => c.AggregatedShippingCost);

        public ShoppingCart()
        {
            Id = Guid.NewGuid();
            ContentsInternal = new List<ShoppingCartItem>();
        }

        public void Add(int amount, JewelrySize size, IOrderable item)
        {
            Add(new ShoppingCartItem(amount, size, item));
        }

        public void Add(ShoppingCartItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            ContentsInternal.Add(item);
        }

        public void Remove(ShoppingCartItem item)
        {
            ContentsInternal.Remove(item);
        }

        public IEnumerable<ShoppingCartItem> Contents => new List<ShoppingCartItem>(ContentsInternal);
    }
}
