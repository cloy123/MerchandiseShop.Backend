﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Id).NotEqual(Guid.Empty);
            RuleFor(h => h.ProductTypeId).NotEqual(Guid.Empty);
            RuleFor(h => h.ProductSizeId).NotEqual(Guid.Empty);
            RuleFor(h => h.ProductColorId).NotEqual(Guid.Empty);
            RuleFor(h => h.ShowInCatalog).NotEmpty();
            RuleFor(h => h.Quantity).NotEmpty();
            RuleFor(h => h.MinQuantity).NotEmpty();
            RuleFor(h => h.Price).NotEmpty();
            RuleFor(h => h.Discount).NotEmpty();
            RuleFor(h => h.ImageFileName).NotEmpty();
        }
    }
}
