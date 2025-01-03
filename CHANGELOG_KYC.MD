# Change Log

## 5.1.0 (2024-01-03)
Updated Create Agreement request body:
- Added an EventCallbackUrl that continuously sends agreement updates

## 5.0.0 (2024-04-12)

Updated `SignMethodEnum` when creating an Oneflow Agreement to:
-   swedish_bankid,
-   standard_esign,
-   sms,
-   norwegian_bankid,
-   danish_mitid,
-   finnish_bankid

## 4.4.0 (2024-01-16)

Removed unused Session-functionality that has been moved to `PingPayments.Payments`

## 4.3.0 (2023-09-26)

Added new fuctionality when creating a oneflow agreements:

-   Added `ProviderStateCallbackUrl` which is the Url where callbacks regarding the provider status are sent to.

## 4.2.0 (2023-08-29)

Added new fuctionality regarding oneflow agreements:

-   Added `CreateAccessLink` which is used to create an access link for a specific participant in an agreement.

Bug fix:

-   Identity is no longer required for a subparty that is not a person, when creating an agrement.

## 4.1.0 (2023-08-11)

Added new fuctionality regarding oneflow agreements:

-   Added `Create` agreement
-   Added `Get` agreement
-   Added `ListTemplates`
-   Added `Publish` agreement
-   Added `Update` agreement

## 4.0.1 (2023-03-30)

-   Removed an unwanted filed from the KycBody

## 4.0.0 (2023-03-30)

-   Added functionality to add a list of bank accounts.
-   Removed constructors from bank account due to improvements in the api.

## 3.0.0 (2023-03-15)

-   Improved DX(Developer Experience) for the merchant verification request by adding some constructors which makes it easier to see what is required due to some required fields, having default values.

## 2.1.0 (2023-01-17)

-   We have introduced the addition of `Plusgiro` and `Bankgiro` options to the `BankAccount`. Please note that this change will only affect Swedish accounts."

## 2.0.0 (2022-12-15)

-   The tenant id is now passed in the `ConfigurePingPaymentsClient()` function when initiating a HTTP client.
-   As a result, the tenant id has been removed from the `GetKycRequest`, `AisMerchantRequest`, `KycVerificationRequest`, and `InitiateSessionRequest` objects.
-   The `Styles` object has been changed to `Style` (the "s" has been removed).
-   `Merchant.V1.AIS()` now has two sucessfull responses; `OK` and `Created`.

## 1.0.0 (2022-11-10)

-Added Account Information Service for Merchants
-Updated BankAccount object with more paramters which now includes:
-Bic
-Iban
-Bban
-Clearing

## 0.1.1-alpha (2022-10-11)

Fixed typo on SuccessfulResponseBody, added a missing "s".

## 0.1.0-alpha (2022-09-30)

First working implementation of the KYC API in C# SDK.
