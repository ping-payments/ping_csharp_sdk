# Change Log

## 2.2.0 (2023-05-23)
- Metadata can now be put on an Item when creating a payment link.

## 2.1.0 (2023-05-22)
- List of tags can now be put on an item when creating a payment link to route funds

## 2.0.1 (2023-03-30)
- Changed how responses parse 

## 2.0.0 (2022-12-15)
- Changed name of `UrlResponse` to `GetInvoiceResponse` which contains `Url`, `ReferenceType` and `Reference` fileds. 
- The parameter `dueDate` in `CreatePaymentLinkRequest` is no longer requierd. 

## 1.0.0 (2022-11-09)
Added response parameters when using get() and list() payment links:
- Status (status of a payment)
- SmsStatus (status of the sms delivery)

## 0.2.3-alpha (2022-10-11) 
Fixed typo on SuccessfulResponseBody, added a missing "s".

## 0.2.2-alpha (2022-08-23)
- New project reference pointing to the nuget package "PingPayments.Common". Where all shared code between packages resides. 

## 0.2.1-alpha (2022-07-29)
- Minor Buggfixes regarding namespace changes. 

## 0.2.0-alpha (2022-07.28)

Updated structural design with some major code cleanup.
-	Namespace changes. View https://docs.pingpayments.com/docs/payment-links-api for updated documentation.


## 0.1.0-alpha (2022-07-18)

First working implementation of the Ping PaymentLinksApi C# SDK
