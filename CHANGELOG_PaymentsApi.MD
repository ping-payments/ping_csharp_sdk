# Change Log

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