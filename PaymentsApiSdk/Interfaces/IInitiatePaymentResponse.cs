using PaymentsApiSDK.Models;
using System;

namespace PaymentsApiSDK.Interfaces
{
    public interface IInitiatePaymentResponse
    {
        InitiateBillmatePaymentResponse billmate { get; set; }
        Guid id { get; set; }
        InitiateSwishPaymentResponse swish { get; set; }
        InitiateVerifonePaymentResponse verifone { get; set; }
    }
}