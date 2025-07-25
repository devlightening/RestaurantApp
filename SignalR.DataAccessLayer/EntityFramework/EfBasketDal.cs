﻿using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstracts;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfBasketDal : GenericRepository<Basket>, IBasketDal
    {
        public EfBasketDal(SignalRContext context) : base(context)
        {
        }

        public List<Basket> GetBasketsByRestaurantTableNumber(int id)
        {
            using var context = new SignalRContext();

            return context.Baskets
                .Include(b => b.RestaurantTable)
                .Include(b => b.Product)
                .Where(b => b.RestaurantTableId == id)
                .ToList();
        }

        public decimal TBasketCount()
        {
            using var context = new SignalRContext();
            return context.Baskets
                .Where(b => b.Status == true)
                .Sum(b => b.TotalPrice);

        }
    }
    }
