# Change Log

## 1.1.0 (2023-11-23)

-   Added two new endpoints for faking Autogiro calls in Sandbox:
    -   `UpdateMandate`, updates mandate status with `MandateStatusEnum`.
    -   `UpdatePayment`, updates payment status with `PaymentStatusEnum`.

## 1.0.0 (2022-10-19)

-   Currencies EUR, DKK in GBP is now available for Ping Deposit payments.

## 0.2.0-alpha (2022-10-11)

-   The endpoint Disbursement was added. You can now trigger disbursements for Payment Orders.
-   Fixed typo on SuccessfulResponseBody, added a missing "s".

## 0.1.0-alpha (2022-09-30)

First working implementation of the Mimic API in C# SDK.
