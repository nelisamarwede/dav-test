using EasyTraders.Domain.Entities;
using EasyTraders.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyTraders.Domain
{
    public static class DomainContextRepoExtensions
    {
        public static IRepository<Product> ProductsRepository(this DomainContext context) => context.Repository<Product>();
        public static IRepository<Supplier> SuppliersRepository(this DomainContext context) => context.Repository<Supplier>();
        public static IRepository<Order> OrdersRepository(this DomainContext context) => context.Repository<Order>();
        public static IRepository<ProductLine> ProductLinesRepository(this DomainContext context) => context.Repository<ProductLine>();
    }
}
