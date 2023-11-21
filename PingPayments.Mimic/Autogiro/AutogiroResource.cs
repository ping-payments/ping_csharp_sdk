namespace PingPayments.Mimic.Autogiro
{
    public class AutogiroResource : IAutogiroResource
    {
        public AutogiroResource(AutogiroV1 v1) => V1 = v1;
        public IAutogiroV1 V1 { get; }
    }
}
