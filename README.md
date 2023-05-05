# Garantipay.NET
Garanti Bankası POS API with .NET

# Installation
```bash
dotnet add package Garantipay --version 1.3.0
```

# Satış
```c#
namespace Garantipay {
    internal class Program {
        static void Main(string[] args) {
            var garantipay = new Garantipay(MODE.Test); // Çalışma ortamı
            garantipay.SetTerminalId(""); // Terminal no
            garantipay.SetMerchantId(""); // Üye işyeri no
            garantipay.SetPassword(""); // PROVAUT kullanıcı şifresi
            var request = new Garantipay.GVPSRequest();
            request.Card.SetCardNumber("4242424242424242"); // Kart numarası
            request.Card.SetCardExpiry("02", "20"); // Son kullanma tarihi (Ay ve Yılın son 2 hanesi)
            request.Card.SetCardCode("123"); // Cvv2 Kodu (kartın arka yüzündeki 3 haneli numara)
            request.Transaction.SetAmount("1.00", "TRY"); // Satış tutarı ve para birimi
            request.Transaction.SetInstallment("0"); // Taksit sayısı
            request.Customer.SetIPv4("1.2.3.4"); // Müşteri IP adresi
            var response = garantipay.Auth(request);
            if (response != null) {
                Console.WriteLine(Garantipay.JsonString<Garantipay.GVPSResponse>(response));
            }
        }
    }
}
```

# İade
```c#
namespace Garantipay {
    internal class Program {
        static void Main(string[] args) {
            var garantipay = new Garantipay(MODE.Test); // Çalışma ortamı
            garantipay.SetTerminalId(""); // Terminal no
            garantipay.SetMerchantId(""); // Üye işyeri no
            garantipay.SetPassword(""); // PROVRFN kullanıcı şifresi
            var request = new Garantipay.GVPSRequest();
            request.Transaction.SetAmount("1.00", "TRY"); // İade tutarı ve para birimi
            request.Customer.SetIPv4("1.2.3.4"); // IP adresi (zorunlu)
            request.Order.SetOrderId("SISTxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"); // Sipariş numarası
            var response = garantipay.Refund(request);
            if (response != null) {
                Console.WriteLine(Garantipay.JsonString<Garantipay.GVPSResponse>(response));
            }
        }
    }
}
```

# İptal
```c#
namespace Garantipay {
    internal class Program {
        static void Main(string[] args) {
            var garantipay = new Garantipay(MODE.Test); // Çalışma ortamı
            garantipay.SetTerminalId(""); // Terminal no
            garantipay.SetMerchantId(""); // Üye işyeri no
            garantipay.SetPassword(""); // PROVRFN kullanıcı şifresi
            var request = new Garantipay.GVPSRequest();
            request.Transaction.SetAmount("1.00", "TRY"); // İptal tutarı ve para birimi
            request.Customer.SetIPv4("1.2.3.4"); // IP adresi (zorunlu)
            request.Order.SetOrderId("SISTxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"); // Sipariş numarası
            var response = garantipay.Cancel(request);
            if (response != null) {
                Console.WriteLine(Garantipay.JsonString<Garantipay.GVPSResponse>(response));
            }
        }
    }
}
```