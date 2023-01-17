
# Change Log

## 2.1.0 (2023-01-17)
- We have introduced the addition of `Plusgiro` and `Bankgiro` options to the `BankAccount`. Please note that this change will only affect Swedish accounts."

## 2.0.0 (2022-12-15)
- The tenant id is now passed in the `ConfigurePingPaymentsClient()` function when initiating a HTTP client.
- As a result, the tenant id has been removed from the `GetKycRequest`, `AisMerchantRequest`, `KycVerificationRequest`, and `InitiateSessionRequest` objects.
- The `Styles` object has been changed to `Style` (the "s" has been removed).
- `Merchant.V1.AIS()` now has two sucessfull responses; `OK` and `Created`. 


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
