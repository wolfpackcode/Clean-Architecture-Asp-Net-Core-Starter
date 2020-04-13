using Clean_Architecture_Asp_Net_Core_Starter.Application.Common.Interfaces;
using System;

namespace Clean_Architecture_Asp_Net_Core_Starter.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
