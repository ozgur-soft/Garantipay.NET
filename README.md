[![license](https://img.shields.io/:license-mit-blue.svg)](https://github.com/ozgur-soft/Garantipay.NET/blob/main/LICENSE.md)

# Garantipay.NET
Garanti Bankası Virtual POS API with .NET

# Installation
```bash
dotnet add package Garantipay --version 1.0.2
```

# Usage
```c#
using Garantipay;

var garantipay = new Garantipay();
garantipay.SetClientId("API clientid");
garantipay.SetUsername("API username");
garantipay.SetPassword("API password");
garantipay.SetIPv4("Customer IPv4 address");
garantipay.Pay(
    "Credit card number (Eg: 4321432143214321)",
    "Card month (Eg: 02)",
    "Card year (Eg: 22)",
    "Card security code: (Eg: 123)",
    "Customer firstname",
    "Customer lastname",
    "Customer phone number",
    "Amount (Eg: 1.00)",
    "Currency code ( $: 840 || €: 978 || ₺: 949 )"
);
```
