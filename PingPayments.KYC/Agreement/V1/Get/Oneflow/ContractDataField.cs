﻿using System.Text;
using System.Text.Json.Serialization;

namespace PingPayments.KYC.Agreement.V1.Get.Oneflow
{
    public class ContractDataField
    {
        /// <summary>
        /// If the data field has been filled out or not
        /// </summary>
        /// <value>If the data field has been filled out or not</value>
        [JsonPropertyName("filled_out")]
        public bool? FilledOut { get; set; }

        /// <summary>
        /// The id of the data field
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of data field
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }


        /// <summary>
        /// value of data field
        /// </summary>
        [JsonPropertyName("value")]
        public string Value { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OneflowContractDataField {\n");
            sb.Append("  FilledOut: ").Append(FilledOut).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
