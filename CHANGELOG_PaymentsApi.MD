# Change Log

## 4.0.0 (2025-08-12)
- List is now split into ListData and ListPage.
	ListData loops all available pages and return the complete dataset, while ListPage return one page at the time. The user can then choose which option is the most optimal for each situation.

## 3.20.1 (2024-04-11)
- Fixed a bug with the filtering for `ListBankTransfers`

## 3.20.0 (2024-04-10)
- Added BankId funcrtionality to Fortus Invoice
	- `CreatePayment.Fortus.Invoice` now contains a BankId object.
	- `FortusProviderMethodParameters` now contains a BankId object.
	- Added a response object containing BankId information.

## 3.19.0 (2024-03-28)
- Added Endpoints regarding DepositBankAccounts
	- `List`, gets all deposit bank accounts connected to that tenant.
	- `ListBankTransfers`, gets all bank transfers for a specified deposit bank account.
	- `ConnectBankTransfer` Connects a precific bank transfer to a `PingDepositPayment`.

## 3.18.0 (2024-03-26)
- Added refund endpoint to refund payments
	- Refund endpont requires a `PaymentOrderId`, `PaymentId` and a `RefundRequest`.

## 3.17.0 (2024-03-15)
- When initiating a payments, you can now set the receiver of funds to a liquidity account instead of a merchant:
	- Added field `LiquidityAccountId` to `OrderItem`, used when initiating a payment.

## 3.16.0 (2024-02-27)
- When initiating a payments, you can now set the receiver of funds to a liquidity account instead of a merchant:
	- Added field `LiquidityAccountId` to `OrderItem`, used when initiating a payment.

## 3.15.0 (2024-02-20)
- You can now create a merchant with a danish organization number:
	- `DkOrganizationNumber` compined with `Country = "DK"` in the `CreateMerchantRequest`

## 3.14.0 (2024-01-24)
- Added new field in `Payer` when initiating a payment
	- `SourceOfFunds` added to `Payer` and is a list of `SourceOfFundsEnum`.

## 3.13.0 (2024-01-23)
- Added a new field when creating an Invoice with Fortus
	- `OrderNumber` added to `FortusProviderMethodParameters` and as a parameter in `CreatePayment.Fortus.Invoice`.

## 3.12.0 (2024-01-16)
- Added two new endpoints regarding an Account Verification Session:
	- `Create` which creates an Account Verification Session using `CreateSessionRequest`
	- `Get` which fetches an Account Verification Session using an Id

## 3.11.2 (2024-01-10)
- Fixed another but less frequent parsing bug when using the `Get` payment endpoint.

## 3.11.1 (2024-01-09)
- Fixed a parsing bug when using the `Get` payment endpoint

## 3.11.0 (2023-12-11)
- Added `Payer` object to `InitiatePaymentRequest` that should be popuated with available information regarding the payer.

## 3.10.0 (2023-12-07)
- Added `BankAccount` in `PingDepositResponse`
- Marked `CreditAccount` in `PingDepositResponse` as `OBSOLETE`

## 3.9.2 (2023-11-21)
- Corrected parameter name when fetching a liquidity account.

## 3.9.1 (2023-11-17)
- Added missing parameters required for initiating a payment with a liquidity account:
	- `PingCreditProviderMethodParameters` contains the request parameters and can be used through `CreatePayment.PingCredit`.

## 3.9.0 (2023-11-14)
- Added new functionality regarding liquidity accounts:
	- `Get` Fetches a specific liquidity account using it's `Guid`
	- `Create` Creates a liquidity account using `CreateLiquidityAccountRequest`
- Added some helpfull records:
	- `AccountHolder`
	- `BankAccount`
	- `DepositInformation`
	- `LegalEntityIdentity`
- Added some helpfull Enums:
	- `LegalEntityCountryEnum`
	- `LegalEntityTypeEnum`

## 3.8.3 (2023-11-07)
- Small fix regarding fortus payents:
	- `Fortus` is now actually listed as a payment provider in `ProviderEnum`

## 3.8.2 (2023-10-09)
- Small fix regarding fortus payents:
	- `AdditionalInformation` is now a parameter in `Invoice`

## 3.8.1 (2023-09-28)
- Added new parameters when creating a fortus invoice: 
	- `Email`, email of payer.
	- `ArticleNumber`, article number of an invoice item.
	- `AdditionalInformation` a list of string with additional information regarding the invoice.

## 3.8.0 (2023-09-05)
- Added Fortus as a new payment provider for invoice payments.

## 3.7.0 (2023-05-31)
- Added support for new cashier parameters when initiating card payments.

## 3.6.0 (2023-04-12)
- Added tags to order items that can be set when initiating a payment.

## 3.5.0 (2023-04-06)
- Added CSS padding option to container for cashier parameter when initiating card payments.

## 3.4.0 (2023-04-04)
- Added chashier parameter when initiating card payments.

## 3.3.0 (2023-03-22)
- Added refund information when using the get payment endpoint.

## 3.2.0 (2023-03-07)
- Added amount to the get disbursement response.

## 3.1.0 (2023-03-03)
- Added request token swish m-commerce response. 

## 3.0.0 (2023-03-02)
- Corrected the namespace of Bankgirot request body and is now same as the rest: `PingPayments.PaymentsApi.Payments.V1.Initiate.Request`. 

## 2.0.0 (2023-02-29)
- Changed name on parameter `reuseReference` to `reference` and removed `DesiredDateOfPayment` on `PingDeposit` . 

## 1.9.2 (2023-02-21)
- Added bban and bic to DepositAccount.  

## 1.9.1 (2023-02-20)
- Fixed a bug where the desired deposit payment date formated incorrectly.

## 1.9.0 (2023-02-09)
- Status history of a payment now contains an id for status changes.

## 1.8.0 (2022-12-17)
- The `person` object has been extended with a field named `Country`. 

## 1.7.0 (2022-12-02)
- Verifone payments is no longer supported. 


## 1.6.2 (2022-12-01)
- Added missing AutogiroResponseBody to InitiatePaymentResponse. 

## 1.6.1 (2022-11-30)
- Added AutogiroResponseBody. 
- If no response body is found for the chosen payment provider `null` will be returned instead of throwing `new NotImplementedException()`.

## 1.6.0 (2022-11-29)
- When initiating a payment, you can now add metadata to order items with the optional parameter `metadata`. 

This metadata is available in the response body via `Payments.V1.Get()`, `Disbursement.V1.Get()` and 
`PaymentOrder.V1.Allocations()`. 

## 1.5.0 (2022-10-29)
- The new Payment status `FUNDED` added to PaymentStatusEnum.
- Added a new optional parameter `CompleteWhenFunded` of type `bool` to PingDepositParameters. If this parameter is set to `false`, the payment status will not change to `COMPLETED` when the payment funds matches the total amount, the payment status will instead remain at status `FUNDED`. **The deafult value of this parameter is set to `true`**.
- The required `orderItems` parameter used in the call to `Reconcile()` is now changed to an optional parameter. When you reconcile a payment with status `FUNDED`, it is possible to omit the `orderItems` parameter.


## 1.4.0 (2022-10-28)
- Added support for reusable reference types regarding completed deposit payments

## 1.3.0 (2022-10-26)
- Added reconcile functionality to payments. It is now possible to "correct" underfunded or overfunded payments with the reconcile endpoint.
- Added helper method for bankgirot autogiro payments.

## 1.2.0 (2022-10-19)
- Currencies EUR, DKK in GBP is now available for Ping Deposit payments.
- UNDERFUNDED and OVERFUNDED added to Payment status enum.
- Added funds property to status_history items.
- deposit_account field added to PingDepositResponse. 
- desired_date_of_payment field added to PingDepositParameters
- New paramaters added for CreatePayment.PingDeposit.Ocr() and CreatePayment.PingDeposit.Kid(). Parameters that have been added for these methods are: currency and DesiredDateOfPayment (optional). 

## 1.1.1 (2022-10-12)
- The parameter "statusCallbackUrl" of InitiatePaymentRequest is now nullable. 
- When creating a Depost payment using the helper method CreatePayment, you no longer need to specify the ReferenceType as a parameter in the method call.

## 1.1.0 (2022-10-11)
- The Payment Order enpoint now have a Allocations method where you can get all Allocations for a Payment Order. 
- Fixed typo on SuccessfulResponseBody, added a missing "s".

## 1.0.0 (2022-09-30)
- New endpoints added:
  - Disbursments 
  - Tenants 
  - Payouts
  - Poke 
  - Signing keys 

- PingEnvironments has changed to support multiple APIs. In the previos versions you accessed the Payments API environments with the following notation: PingEnvironments.SandboxUri and PingEnvironments.ProductionUri. This is changed to the following: PingEnvironments.PaymentsApi.SandboxUri and PingEnvironments.PaymentsApi.ProductionUri.

- PaymentOrder now contains a currency field with the type CurrencyEnum. 
- PaymentResponseBody now contains a StatusHistory field that contains a list of status history of a payment.
- ErrorMessage now contains a additional_information field.
- MerchantStatus enum moved to PingPayments.Common. The new namespace for MerchantStatus is PingPayments.Shared.Enums. 

## 0.8.0-alpha (2022-08-26)
- BAASE was added as a payment method. 

## 0.7.0-alpha (2022-08-23)
- New project reference pointing to the nuget package "PingPayments.Common" where all shared code between packages resides.

## 0.6.1-alpha (2022-07-29)
- Moved LangVersionCsharp9Fix file to each project.

## 0.6.0-alpha (2022-07-29)
- Change namespaces and usings to map to the new shared project. 

## 0.5.1-alpha (2022-07-18)
- The SDK has been expanded into two different packages. From PingPayments to PingPayments.PaymentsApi and PingPayments.PaymentLinksApi.
- The user can now choose to use to work with the package that is suitable for them. 

## 0.4.1-alpha (2022-06-02)
- Moving environments to own class.
- Fixing swish phonenumber bug.
- use netstandard2.0.

## 0.4.0-alpha (2022-05-31)
- Adding x-api-secret.
- Renaming. From "Endpoint" to "Operation" and "Endpoints" to "Resource".

## 0.3.3-alpha (2022-05-18)
- Added locale for Payment Iq Parameter.

## 0.3.2-alpha (2022-05-18)
- Adding support for "/" and non "/" client urls.
- Can pass currency when creating order. 
- Fix for default border for swish qr code.

## 0.3.1-alpha (2022-04-25)
- Added missing interface.

## 0.3.0-alpha (2022-04-25)
- Better dependency injection using typed http client.

## 0.2.4-alpha (2022-04-22)
- Changing from cancel_url to error_url for PaymentIqParameters.

## 0.2.3-alpha (2022-04-20)
-  Better names for helpers.
-  Wrapped response body for response and added interfaces.

## 0.2.2-alpha (2022-04-14)
-  Support for swish ecommerce/mcommerce.
-  Ping deposit implemented.
-  Better convention for helpers. 

## 0.2.1-alpha (2022-04-01)
- Adding pattern matching and making currency changeable for Payment Iq helper.

## 0.2.0-alpha (2022-03-30)
- Better DX experience.
- Payment Iq implemented.
- Added "V1" namespace for versioning.

## 0.1.0-alpha (2022-03-23)

First working implementation of the Ping PaymentsApi C# SDK.
