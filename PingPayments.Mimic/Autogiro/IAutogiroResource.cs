using System;
using System.Collections.Generic;
using System.Text;

namespace PingPayments.Mimic.Autogiro
{
    public interface IAutogiroResource
    {
        IAutogiroV1 V1 { get; }
    }
}
