# Garantipay.NET
Garanti Bankası POS API with .NET

# Installation
```bash
dotnet add package Garantipay --version 1.3.0
```

# Sanalpos satış işlemi
```c#
namespace Garantipay {
    internal class Program {
        static void Main(string[] args) {
            var garantipay = new Garantipay(MODE.Test); // Çalışma ortamı
            garantipay.SetClientID(""); // Terminal no
            garantipay.SetUsername(""); // Üye işyeri no
            garantipay.SetPassword(""); // PROVAUT kullanıcı şifresi
            var request = new Garantipay.GVPSRequest();
            request.SetCardNumber("4242424242424242"); // Kart numarası
            request.SetCardExpiry("02", "20"); // Son kullanma tarihi (Ay ve Yılın son 2 hanesi)
            request.SetCardCode("123"); // Cvv2 Kodu (kartın arka yüzündeki 3 haneli numara)
            request.SetAmount("1.00", "TRY"); // Satış tutarı ve para birimi
            request.SetInstallment(""); // Taksit sayısı (varsa)
            request.SetCardHolder("Ad", "Soyad"); // Kart sahibi
            request.SetPhoneNumber(""); // Müşteri telefon numarası
            request.SetIPv4("1.2.3.4"); // Müşteri IP adresi (zorunlu)
            var response = garantipay.Auth(request);
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
            var garantipay = new Garantipay(MODE.Test); // Çalışma ortamı
            garantipay.SetClientID(""); // Terminal no
            garantipay.SetUsername(""); // Üye işyeri no
            garantipay.SetPassword(""); // PROVRFN kullanıcı şifresi
            var request = new Garantipay.GVPSRequest();
            request.SetAmount("1.00", "TRY"); // İade tutarı ve para birimi
            request.SetIPv4("1.2.3.4"); // IP adresi (zorunlu)
            request.SetOrderID("SISTxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"); // Sipariş numarası
            var response = garantipay.Refund(request);
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
            var garantipay = new Garantipay(MODE.Test); // Çalışma ortamı
            garantipay.SetClientID(""); // Terminal no
            garantipay.SetUsername(""); // Üye işyeri no
            garantipay.SetPassword(""); // PROVRFN kullanıcı şifresi
            var request = new Garantipay.GVPSRequest();
            request.SetAmount("1.00", "TRY"); // İptal tutarı ve para birimi
            request.SetIPv4("1.2.3.4"); // IP adresi (zorunlu)
            request.SetOrderID("SISTxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"); // Sipariş numarası
            var response = garantipay.Cancel(request);
            if (response != null) {
                Console.WriteLine(Garantipay.JsonString<Garantipay.GVPSResponse>(response));
            }
        }
    }
}
```