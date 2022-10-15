# FastDo.VivaWallet.Net

According to : [https://developer.vivawallet.com/apis-for-payments/payment-api/](https://developer.vivawallet.com/apis-for-payments/payment-api/)


## Requirements

 - .NET 6.0

## NuGet

This library is avalaible from NuGet Package Manager 

```
PM> Install-Package FastDo.VivaWallet.Net
```

## Dependencies

- Restsharp

## Usage 

### Using DI (1. method)

Register service in `Program.cs`:
```cs
builder.Services.AddVivaWalletService(config);
```

Add configurations in `appsettings.json`. Example for demo api:
```json
"VivaWalletServiceSettings": {
    "AccountsBaseUrl": "https://demo-accounts.vivapayments.com",
    "ApiBaseUrl": "https://demo-api.vivapayments.com",
    "ClientId": "your client id",
    "ClientSecret": "your client secret"
    }
```

### Using DI (2. method)

It is possible to pass settings directly without using `appsettings.json`. Register service in `Program.cs`:
```cs
var settings = new VivaWalletServiceSettings()
        {
            AccountsBaseUrl = "https://demo-accounts.vivapayments.com",
            ApiBaseUrl = "https://demo-api.vivapayments.com",
            ClientId = "k6qtgjg32x4advs1e15834ysnek5z2589w4xi9qg3sse3.apps.vivapayments.com",
            ClientSecret = "CQtOvA8BficCU0t80buW5178D6610Q",
        };

builder.Services.AddVivaWalletService(settings);
```

**Using DI will register interface IVivaWalletService which will be used.**

### Creating instance of VivaWalletService

You can also create instace manualy:
```cs
var settings = new VivaWalletServiceSettings()
        {
            AccountsBaseUrl = "https://demo-accounts.vivapayments.com",
            ApiBaseUrl = "https://demo-api.vivapayments.com",
            ClientId = "k6qtgjg32x4advs1e15834ysnek5z2589w4xi9qg3sse3.apps.vivapayments.com",
            ClientSecret = "CQtOvA8BficCU0t80buW5178D6610Q",
        };

var vivaWalletService = new VivaWalletService(settings);
```

## Methods

### GetAccessTokenAsync

Will get access_token.

```cs
var result = await _vivaWalletService.GetAccessTokenAsync();
```

### CreatePaymentOrderAsync

Will get access_token.

```cs
// You must obtain access_token first.
await _vivaWalletService.GetAccessTokenAsync();

// For example, if you want to create a payment for €230.587, you need to pass the value 23058
var request = new CreatePaymentOrderRequest()
{
    Amount = 23058,
};

var result = await _vivaWalletService.CreatePaymentOrderAsync(request);
```




## Contributing

Contributions from others would be very much appreciated! Send pull request/ issue. Thanks!

## License

Copyright (c) 2022 Petr Jílek. MIT Licensed, see LICENSE for details.
