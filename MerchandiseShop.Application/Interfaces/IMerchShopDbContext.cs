﻿using MerchandiseShop.Domain.CurrencyTransactions;
using MerchandiseShop.Domain.Event;
using MerchandiseShop.Domain.Holiday;
using MerchandiseShop.Domain.Notifications;
using MerchandiseShop.Domain.Order;
using MerchandiseShop.Domain.Products;
using MerchandiseShop.Domain.UserRefreshTokens;
using MerchandiseShop.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Interfaces
{
    public interface IMerchShopDbContext
    {
        DbSet<CurrencyTransaction> CurrencyTransactions { get; set; }
        DbSet<Event> Events { get; set; }
        DbSet<EventParticipant> EventParticipants { get; set; }
        DbSet<EventResponsible> EventResponsibles { get; set; }
        DbSet<EventRole> EventRoles { get; set; }
        DbSet<Holiday> Holidays { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductColor> ProductColors { get; set; }
        DbSet<ProductSize> ProductSizes { get; set; }
        DbSet<ProductType> ProductTypes { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
