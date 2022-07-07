# Ping Payments C# SDK

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
![Nuget](https://img.shields.io/nuget/v/PingPayments)

Use this C# nuget library to manage Ping Payments resources regarding payments and payment links.

## Table of contents

* [Requirements](#requirements)

* [Installation](#installation)

* [Documentation](#documentation) 

*  [Payments API](#payment-api)

*  [Payments Links API](#payment-links-api)

* [Tests](#tests)

* [SDK Reference](#sdk-reference)


## Requirements

Use of the Ping Payments .NET SDK requires:
NET Standard 2.1 or higher. 

## Installation

Install the latest SDK using dotnet CLI:

```sh
dotnet add package PingPayments
```

Install the latest SDK using NuGet.exe

```sh
nuget install PingPayments
```

## Documentation
For a more comprehensive documentation check out the [API documentation](https://docs.pingpayments.com/docs/the-ping-payments-c-sdk). 


## Payment API 

### Usage 


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

## Payment Links API 
### Usage 

#### Create a payment link example

##### 1.a Create a client
```c#
var apiUrl = Configuration["PingPayments:ApiUrl"];
var tenantId = Configuration["PingPayments:TenantId"];
var httpClient = new HttpClient().ConfigurePingPaymentsClient(apiUrl, tenantId);
var api = new PingPaymentLinksApiClient(httpClient);
```

##### 1.b Dependency injection
```c#
services.AddHttpClient<IPingPaymentLinksApiClient, PingPaymentLinksApiClient>(client =>
{
    var apiUrl = Configuration["PingPayments:ApiUrl"];
    var tenantId = Configuration["PingPayments:TenantId"];
    client.ConfigurePingPaymentsClient(apiUrl, tenantId);
});
```

##### 2. Create a new payment link through the API  
```c#
var customer = new Customer("FirstName", "LastName");
var dueDate = "2023-01-01";
var suppler = new Supplier("Supllier name");
var swishMcommmerce = CreatePaymentProviderMethod.Swish.Mcommerce("A swish message");
var verifone = CreatePaymentProviderMethod.Verifone.Card();

var paymentLinkRequest = new CreatePaymentLinkRequest
(
    OrderId,
    CurrencyEnum.SEK,
    customer,
    dueDate,
    Locale.Swedish,
    new Item[]
    {
        new Item("Hawaii Pizza", MerchantId, 7000, 2, SwedishVat.Vat12)
    },
    suppler,
    new PaymentProviderMethod[]
    {
        swishMcommmerce,
        Verifone
    }
);

var response = await api.PaymentLinks.V1.Create(paymentLinkRequest);
```
##### 3.a Pattern match on response (if you like it functionally)
```c#
await response.MatchAsync
(
    OnSuccess: async (CreatePaymentLinkResponse cplr) => await ShowDialog("A new payment link has been created..."),
    OnFailure: async (ErrorResponseBody error) => await ShowError(error) 
);
```

##### 3.b Use the ResponseBody help class and classical if-blocks
```c#
if(response.IsSuccessful)
{
    ShowDialog("A new payment link has been created...");
} 
else
{
    await ShowError(response.Body.ErrorResponseBody);
}
```

## Tests

Download the repository and update TestSetup.json with your TenantId and additional testdata.


## SDK Reference
