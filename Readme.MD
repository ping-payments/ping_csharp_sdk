# Ping Payments C# SDK

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)\
![Nuget](https://img.shields.io/nuget/v/PingPayments.Payments?label=PingPayments.Payments)\
![Nuget](https://img.shields.io/nuget/v/PingPayments.PaymentLinks?label=PingPayments.PaymentLinks)\
![Nuget](https://img.shields.io/nuget/v/PingPayments.Mimic?label=PingPayments.Mimic)\
![Nuget](https://img.shields.io/nuget/v/PingPayments.KYC?label=PingPayments.KYC)

Use this C# nuget library to manage Ping Payments resources regarding payments and payment links, KYC and to simulate bank operations (Mimic).

## Table of contents

* [Requirements](#requirements)

* [Installation](#installation)

* [Documentation](#documentation) 

* [Exampel Usage](#exampel-usage)


* [Tests](#tests)


## Requirements

Use of the Ping Payments .NET SDK requires:
NET Standard 2.0 or higher. 

## Installation
Select an installation method and a desired package.

Install the latest SDK using dotnet CLI:

```sh
dotnet add package PingPayments.Payments
```
```sh
dotnet add package PingPayments.PaymentLinks
```
```sh
dotnet add package PingPayments.KYC
```
```sh
dotnet add package PingPayments.Mimic
```

Install the latest SDK using NuGet.exe

```sh
nuget install PingPayments.Payments
```
```sh
nuget install PingPayments.PaymentLinks
```
```sh
nuget install PingPayments.KYC
```
```sh
nuget install PingPayments.Mimic
```

From within Visual Studio:

1. Open the Solution Explorer.
2. Right-click on a project within your solution.
3. Click on *Manage NuGet Packages...*
4. Click on the *Browse* tab and search for "PingPayments".
5. Click on a desired package, select the appropriate version in the
   right-tab and click *Install*.


## Documentation
For a more comprehensive documentation check out the [SDK documentation](https://docs.pingpayments.com/docs/the-ping-payments-c-sdk). 


## Exampel Usage 

### Payment API 

#### Swish ecommerce example

##### 1.a Create a client
```c#
var apiUrl = Configuration["PingPayments:ApiUrl"];
var tenantId = Configuration["PingPayments:TenantId"];
var httpClient = new HttpClient().ConfigurePingPaymentsClient(apiUrl, tenantId);
var api = new PingPaymentsApiClient(httpClient);
```

##### 1.b Dependency injection
```c#
services.AddHttpClient<IPingPaymentsApiClient, PingPaymentsApiClient>(client =>
{
    var apiUrl = Configuration["PingPayments:ApiUrl"];
    var tenantId = Configuration["PingPayments:TenantId"];
    client.ConfigurePingPaymentsClient(apiUrl, tenantId);
});
```

##### 2. Create a merchant 
```c#
var merchant = new CreateMerchantRequest {
    Name = "test merchant AB",
    Organization = new Organization {
        Country = "SE",
        SeOrganizationNumber = "1234567890"
    }
};
Guid merchantId = await api.Merchants.V1.Create(merchant);
```

##### 3. Create a order to collect payments in
```c#
Guid orderId = await api.PaymentOrder.V1.Create();
```

##### 4. Create a new swish payment for the order through the API
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

##### 5.a Pattern match on response (if you like it functionally)
```c#
await response.MatchAsync
(
    OnSuccess: async (SwishECommerceResponse ipr) => await ShowDialog("Open Swish on your device..."),
    OnFailure: async (ErrorResponseBody error) => await ShowError(error)
);
```

##### 5.b Use the ResponseBody help class and classical if-blocks
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
