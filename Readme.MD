
# Ping Payments C# SDK

[![Publish Payments API SDK Nuget](https://github.com/youcal/ping_csharp_sdk/actions/workflows/publish.yaml/badge.svg)](https://github.com/youcal/ping_csharp_sdk/actions/workflows/publish.yaml) [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Use this C# nuget library to manage Ping Payments resources regarding payments.

## Table of contents

* [Requirements](#requirements)

* [Usage](#usage)

* [Tests](#tests)

* [SDK Reference](#sdk-reference)


## Requirements

Use of the Ping Payments .NET SDK requires:
NET Standard 2.1 or higher

## Installation

Install the latest SDK using dotnet CLI:

```sh
dotnet add package PingPayments
```

Install the latest SDK using NuGet.exe

```sh
nuget install PingPayments
```

## Usage



### Swish e-commerce example

```c#
//Setup api, we recommend dependency injection for this
var tenantId = TestData.TenantId;
var httpClient = new HttpClient{BaseAddress = new Uri(TestData.SandboxUri)};
var api = new PaymentsApiClient(tenantId, httpClient);

//1. Create merchant 
var merchant = new CreateMerchantRequest {
    Name = "test merchant AB",
    Organization = new Organization {
        Country = "SE",
        SeOrganizationNumber = "123456-7890"
    }
};
Guid merchantId = await api.Merchants.V1.Create(merchant);

//2. Create order
Guid orderId = await api.PaymentOrder.V1.Create();

//3. Create payment request object
var orderItems = new OrderItem
(
    10.ToMinorCurrency(), 
    "A test article", 
    SwedishVat.Vat25, 
    merchantId
).ToOrderList();
var request = CreatePayment.Swish.Ecommerce
(
    orderItems.TotalAmountMinorCurrency(), 
    orderItems,
    "07012345678",
    "Thanks for your Swish Payment!",
    new Uri("https://my-callback.my-api.com")
);

//4. Create a new swish payment for the order through the API
var response = await api.Payments.V1.Initiate(orderId, request);

//5. Pattern match on response
await response.MatchAsync
(
    OnSuccess: async (SwishECommerceResponse ipr) => await ShowDialog("Open Swish on your device..."),
    OnFailure: async (ErrorResponseBody error) => await ShowError(error)
);
```



## Tests

Download the repository and update TestSetup.json with your TenantId and additional testdata.



## SDK Reference

[//]: #  "Link anchor definitions"

[Payments API]: doc/payments_api.md

[Merchant]: doc/api_resources/payments_api/merchant.md

[Payment Orders]: doc/api_resources/payments_api/payment_order.md

[Payment]: doc/api_resources/payments_api/payment.md
