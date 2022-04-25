
# Ping Payments C# SDK

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

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

#### 1.a Create a client
```c#
var apiUrl = Configuration["PingPayments:ApiUrl"];
var tenantId = Configuration["PingPayments:TenantId"];
var httpClient = new HttpClient().ConfigurePingPaymentsClient(apiUrl, tenantId);
var api = new PingPaymentsApiClient(httpClient);
```

#### 1.b Dependency injection
```c#
services.AddHttpClient<IPingPaymentsApiClient, PingPaymentsApiClient>(client =>
{
    var apiUrl = Configuration["PingPayments:ApiUrl"];
    var tenantId = Configuration["PingPayments:TenantId"];
    client.ConfigurePingPaymentsClient(apiUrl, tenantId);
});
```

#### 2. Create a merchant 
```c#
var merchant = new CreateMerchantRequest {
    Name = "test merchant AB",
    Organization = new Organization {
        Country = "SE",
        SeOrganizationNumber = "123456-7890"
    }
};
Guid merchantId = await api.Merchants.V1.Create(merchant);
```

#### 3. Create a order to collect payments in
```c#
Guid orderId = await api.PaymentOrder.V1.Create();
```

#### 4. Create a new swish payment for the order through the API
```c#
var orderItems = new OrderItem
(
    10.ToMinorCurrencyUnit(), 
    "A test article", 
    SwedishVat.Vat25, 
    merchantId
).InList();
var request = CreatePayment.Swish.Ecommerce
(
    orderItems,
    "07012345678",
    "Thanks for your Swish Payment!",
    new Uri("https://my-callback.my-api.com")
);
var response = await api.Payments.V1.Initiate(orderId, request);
```

#### 5.a Pattern match on response (if you like it functionally!)
```c#
await response.MatchAsync
(
    OnSuccess: async (SwishECommerceResponse ipr) => await ShowDialog("Open Swish on your device..."),
    OnFailure: async (ErrorResponseBody error) => await ShowError(error)
);
```

#### 5.b Use the ResponseBody help class and classical if-blocks
```c#
if(response.IsSuccessful)
{
    await ShowDialog("Open Swish on your device...");
} 
else
{
    await ShowError(response.Body.ErrorResponseBody);
}
```


## Tests

Download the repository and update TestSetup.json with your TenantId and additional testdata.


## SDK Reference

[//]: #  "Link anchor definitions"

[Payments API]: doc/payments_api.md

[Merchant]: doc/api_resources/payments_api/merchant.md

[Payment Orders]: doc/api_resources/payments_api/payment_order.md

[Payment]: doc/api_resources/payments_api/payment.md
