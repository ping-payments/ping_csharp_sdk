using System;

namespace PingPayments.PaymentsApi.Payments.Shared.V1
{
    public static class MethodEnumHelpers
    {
        public static string Stringify(this MethodEnum methodEnum) =>
            methodEnum switch
            {
                MethodEnum.e_commerce =>  "e-commerce",
                MethodEnum.m_commerce =>  "m-commerce",
                _ => methodEnum.ToString()
            };

        public static MethodEnum ToMethodEnum(this string methodEnumValue) =>
            methodEnumValue switch
            {
                "e-commerce" => MethodEnum.e_commerce,
                "m-commerce" => MethodEnum.m_commerce,
                _ => Enum.Parse<MethodEnum>(methodEnumValue)
            };
    }
}
