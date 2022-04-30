[![license](https://img.shields.io/:license-mit-blue.svg)](https://github.com/ozgur-soft/Garantipay.NET/blob/main/LICENSE.md)

# Garantipay.NET
Garanti Bankası Virtual POS API with .NET

# Installation
```bash
dotnet add package Garantipay --version 1.1.1
```

# Sanalpos satış işlemi
```c#
namespace Garantipay {
    internal class Program {
        static void Main(string[] args) {
            var garantipay = new Garantipay();
            garantipay.SetClientID(""); // Terminal no
            garantipay.SetUsername(""); // Üye işyeri no
            garantipay.SetPassword(""); // PROVAUT kullanıcı şifresi
            garantipay.SetCardNumber("4242424242424242"); // Kart numarası
            garantipay.SetCardExpiry("02", "20"); // Son kullanma tarihi (Ay ve Yılın son 2 hanesi)
            garantipay.SetCardCode("123"); // Cvv2 Kodu (kartın arka yüzündeki 3 haneli numara)
            garantipay.SetAmount("1.00", "TRY"); // Satış tutarı ve para birimi
            garantipay.SetInstallment(""); // Taksit sayısı (varsa)
            garantipay.SetCardHolder("Ad", "Soyad"); // Kart sahibi
            garantipay.SetPhoneNumber(""); // Müşteri telefon numarası
            garantipay.SetIPv4("1.2.3.4"); // Müşteri IP adresi (zorunlu)
            var response = garantipay.Pay();
            if (response != null) {
                Console.WriteLine(Garantipay.JsonString<Garantipay.GVPSResponse>(response));
            }
        }
    }
}
```

# Sanalpos iade işlemi
```c#
namespace Garantipay {
    internal class Program {
        static void Main(string[] args) {
            var garantipay = new Garantipay();
            garantipay.SetClientID(""); // Terminal no
            garantipay.SetUsername(""); // Üye işyeri no
            garantipay.SetPassword(""); // PROVRFN kullanıcı şifresi
            garantipay.SetAmount("1.00", "TRY"); // İade tutarı ve para birimi
            garantipay.SetIPv4("1.2.3.4"); // IP adresi (zorunlu)
            garantipay.SetOrderID("SISTxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"); // Sipariş numarası
            var response = garantipay.Refund();
            if (response != null) {
                Console.WriteLine(Garantipay.JsonString<Garantipay.GVPSResponse>(response));
            }
        }
    }
}
```

# Sanalpos iptal işlemi
```c#
namespace Garantipay {
    internal class Program {
        static void Main(string[] args) {
            var garantipay = new Garantipay();
            garantipay.SetClientID(""); // Terminal no
            garantipay.SetUsername(""); // Üye işyeri no
            garantipay.SetPassword(""); // PROVRFN kullanıcı şifresi
            garantipay.SetAmount("1.00", "TRY"); // İptal tutarı ve para birimi
            garantipay.SetIPv4("1.2.3.4"); // IP adresi (zorunlu)
            garantipay.SetOrderID("SISTxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"); // Sipariş numarası
            var response = garantipay.Cancel();
            if (response != null) {
                Console.WriteLine(Garantipay.JsonString<Garantipay.GVPSResponse>(response));
            }
        }
    }
}
```