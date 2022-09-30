using PingPayments.Shared;
using System;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.Poke
{
    public interface IPokeV1
    {
        Task<EmptyResponse> Request(Uri callbackUrl);
    }
}