﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Events.Queries.GetEventList
{
    public class GetEventListQuery : IRequest<EventListVm>
    {
    }
}
