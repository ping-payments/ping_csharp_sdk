using PingPayments.PaymentsApi.SigningKeys.Generate.V1;
using PingPayments.PaymentsApi.SigningKeys.Get.V1;
using System.Threading.Tasks;

namespace PingPayments.PaymentsApi.SigningKeys
{
    public interface ISigningKeyV1
    {
        Task<GenerateResponse> Generate();
        Task<GetKeyRespons> Get();
    }
}