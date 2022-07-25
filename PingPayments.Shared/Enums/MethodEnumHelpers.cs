using System;

namespace PingPayments.Shared.Enums
{
    public static class MethodEnumHelpers
    {
        public static string Stringify(this MethodEnum methodEnum) =>
            methodEnum switch
            {
                MethodEnum.e_commerce =>  "e_commerce",
                MethodEnum.m_commerce =>  "m_commerce",
                _ => methodEnum.ToString()
            };

        public static MethodEnum ToMethodEnum(this string methodEnumValue) =>
            methodEnumValue switch
            {
                "e_commerce" => MethodEnum.e_commerce,
                "m_commerce" => MethodEnum.m_commerce,
                _ => (MethodEnum)Enum.Parse(typeof(MethodEnum), methodEnumValue)
            };
    }
}
