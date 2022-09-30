namespace PingPayments.PaymentsApi.Poke
{
    public class PokeResource : IPokeResource
    {
        public PokeResource(IPokeV1 v1) => V1 = v1;

        public IPokeV1 V1 { get; }
    }
}
