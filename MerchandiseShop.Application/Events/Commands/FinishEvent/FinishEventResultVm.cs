﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseShop.Application.Events.Commands.FinishEvent
{
    public class FinishEventResultVm
    {
        public bool IsFinished { get; set; }
        public string ErrorMessage { get; set; }
    }
}
