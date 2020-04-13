using System;

namespace Clean_Architecture_Asp_Net_Core_Starter.Application.Common.Interfaces
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }
}
