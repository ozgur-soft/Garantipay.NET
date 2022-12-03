using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Garantipay {
    public interface IGarantipay {
        void SetMode(string mode);
        void SetClientID(string clientid);
        void SetUsername(string username);
        void SetPassword(string password);
        void SetIPv4(string ipv4);
        void SetOrderID(string orderid);
        void SetAmount(string amount, string currency);
        void SetInstallment(string installment);
        void SetCardHolder(string firstname, string lastname);
        void SetPhoneNumber(string phonenumber);
        void SetCardNumber(string cardnumber);
        void SetCardExpiry(string cardmonth, string cardyear);
        void SetCardCode(string cardcode);
        Garantipay.GVPSResponse Pay();
        Garantipay.GVPSResponse Cancel();
        Garantipay.GVPSResponse Refund();
    }
    public class Garantipay : IGarantipay {
        private string Endpoint { get; set; }
        private string Mode { get; set; }
        private string ClientID { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private string IPv4 { get; set; }
        private string OrderID { get; set; }
        private string Amount { get; set; }
        private string Currency { get; set; }
        private string Installment { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string PhoneNumber { get; set; }
        private string CardNumber { get; set; }
        private string CardMonth { get; set; }
        private string CardYear { get; set; }
        private string CardCode { get; set; }
        public Garantipay() {
            Endpoint = "https://sanalposprov.garanti.com.tr/VPServlet";
        }
        [Serializable, XmlRoot("GVPSRequest")]
        public class GVPSRequest {
            [XmlElement("Mode", IsNullable = false)]
            public string Mode { init; get; }
            [XmlElement("Version", IsNullable = false)]
            public string Version { init; get; }
            [XmlElement("ChannelCode", IsNullable = false)]
            public string ChannelCode { init; get; }
            [XmlElement("Terminal", IsNullable = false)]
            public Terminal Terminal { init; get; }
            [XmlElement("Customer", IsNullable = false)]
            public Customer Customer { init; get; }
            [XmlElement("Card", IsNullable = false)]
            public Card Card { init; get; }
            [XmlElement("Order", IsNullable = false)]
            public Order Order { init; get; }
            [XmlElement("Transaction", IsNullable = false)]
            public Transaction Transaction { init; get; }
        }

        public class Terminal {
            [XmlElement("MerchantID", IsNullable = false)]
            public string MerchantID { init; get; }
            [XmlElement("ProvUserID", IsNullable = false)]
            public string ProvUserID { init; get; }
            [XmlElement("UserID", IsNullable = false)]
            public string UserID { init; get; }
            [XmlElement("ID", IsNullable = false)]
            public string ID { init; get; }
            [XmlElement("HashData", IsNullable = false)]
            public string HashData { init; get; }
        }

        public class Card {
            [XmlElement("Number", IsNullable = false)]
            public string Number { init; get; }
            [XmlElement("ExpireDate", IsNullable = false)]
            public string Expiry { init; get; }
            [XmlElement("CVV2", IsNullable = false)]
            public string Code { init; get; }
        }

        public class Customer {
            [XmlElement("IPAddress", IsNullable = false)]
            public string IPAddress { init; get; }
            [XmlElement("EmailAddress", IsNullable = false)]
            public string EmailAddress { init; get; }
        }

        public class Transaction {
            [XmlElement("Type", IsNullable = false)]
            public string Type { init; get; }
            [XmlElement("SubType", IsNullable = false)]
            public string SubType { init; get; }
            [XmlElement("FirmCardNo", IsNullable = false)]
            public string FirmCardNo { init; get; }
            [XmlElement("InstallmentCnt", IsNullable = false)]
            public string InstallmentCnt { init; get; }
            [XmlElement("Amount", IsNullable = false)]
            public string Amount { init; get; }
            [XmlElement("CurrencyCode", IsNullable = false)]
            public string CurrencyCode { init; get; }
            [XmlElement("CardholderPresentCode", IsNullable = false)]
            public string CardholderPresentCode { init; get; }
            [XmlElement("MotoInd", IsNullable = false)]
            public string MotoInd { init; get; }
            [XmlElement("AuthCode", IsNullable = false)]
            public string AuthCode { init; get; }
            [XmlElement("RetrefNum", IsNullable = false)]
            public string RetrefNum { init; get; }
            [XmlElement("BatchNum", IsNullable = false)]
            public string BatchNum { init; get; }
            [XmlElement("SequenceNum", IsNullable = false)]
            public string SequenceNum { init; get; }
            [XmlElement("ProvDate", IsNullable = false)]
            public string ProvDate { init; get; }
            [XmlElement("CardNumberMasked", IsNullable = false)]
            public string CardNumberMasked { init; get; }
            [XmlElement("CardHolderName", IsNullable = false)]
            public string CardHolderName { init; get; }
            [XmlElement("CardType", IsNullable = false)]
            public string CardType { init; get; }
            [XmlElement("HashData", IsNullable = false)]
            public string HashData { init; get; }
            [XmlElement("Description", IsNullable = false)]
            public string Description { init; get; }
            [XmlElement("Secure3D", IsNullable = false)]
            public Secure3D Secure3D { init; get; }
            [XmlElement("Response", IsNullable = false)]
            public Response Response { init; get; }
        }

        public class Secure3D {
            [XmlElement("AuthenticationCode", IsNullable = false)]
            public string AuthenticationCode { init; get; }
            [XmlElement("SecurityLevel", IsNullable = false)]
            public string SecurityLevel { init; get; }
            [XmlElement("TxnID", IsNullable = false)]
            public string TxnID { init; get; }
            [XmlElement("Md", IsNullable = false)]
            public string Md { init; get; }
        }

        public class Order {
            [XmlElement("OrderID", IsNullable = false)]
            public string OrderID { init; get; }
            [XmlElement("GroupID", IsNullable = false)]
            public string GroupID { init; get; }
            [XmlElement("AddressList", IsNullable = false)]
            public AddressList AddressList { init; get; }
        }

        public class AddressList {
            [XmlElement("Address", IsNullable = false)]
            public Address Address { init; get; }
        }

        public class Address {
            [XmlElement("Type", IsNullable = false)]
            public string Type { init; get; }
            [XmlElement("Name", IsNullable = false)]
            public string Name { init; get; }
            [XmlElement("LastName", IsNullable = false)]
            public string LastName { init; get; }
            [XmlElement("Company", IsNullable = false)]
            public string Company { init; get; }
            [XmlElement("Text", IsNullable = false)]
            public string Text { init; get; }
            [XmlElement("Country", IsNullable = false)]
            public string Country { init; get; }
            [XmlElement("City", IsNullable = false)]
            public string City { init; get; }
            [XmlElement("District", IsNullable = false)]
            public string District { init; get; }
            [XmlElement("PostalCode", IsNullable = false)]
            public string PostalCode { init; get; }
            [XmlElement("PhoneNumber", IsNullable = false)]
            public string PhoneNumber { init; get; }
            [XmlElement("GsmNumber", IsNullable = false)]
            public string GsmNumber { init; get; }
            [XmlElement("FaxNumber", IsNullable = false)]
            public string FaxNumber { init; get; }
        }

        public class Response {
            [XmlElement("Source", IsNullable = false)]
            public string Source { init; get; }
            [XmlElement("Code", IsNullable = false)]
            public string Code { init; get; }
            [XmlElement("ReasonCode", IsNullable = false)]
            public string ReasonCode { init; get; }
            [XmlElement("Message", IsNullable = false)]
            public string Message { init; get; }
            [XmlElement("ErrorMsg", IsNullable = false)]
            public string ErrorMsg { init; get; }
            [XmlElement("SysErrMsg", IsNullable = false)]
            public string SysErrMsg { init; get; }
        }

        [Serializable, XmlRoot("GVPSResponse")]
        public class GVPSResponse {
            [XmlElement("Mode", IsNullable = false)]
            public string Mode { init; get; }
            [XmlElement("Terminal", IsNullable = false)]
            public Terminal Terminal { init; get; }
            [XmlElement("Customer", IsNullable = false)]
            public Customer Customer { init; get; }
            [XmlElement("Card", IsNullable = false)]
            public Card Card { init; get; }
            [XmlElement("Order", IsNullable = false)]
            public Order Order { init; get; }
            [XmlElement("Transaction", IsNullable = false)]
            public Transaction Transaction { init; get; }
        }
        public class Writer : StringWriter {
            public override Encoding Encoding => Encoding.UTF8;
        }
        public static string SHA1Encrypt(string data) {
            var sha1 = BitConverter.ToString(SHA1.Create().ComputeHash(Encoding.ASCII.GetBytes(data))).Replace("-", "").ToLowerInvariant();
            return sha1;
        }
        public void SetMode(string mode) {
            Mode = mode;
        }
        public void SetClientID(string clientid) {
            ClientID = clientid;
        }
        public void SetUsername(string username) {
            Username = username;
        }
        public void SetPassword(string password) {
            Password = password;
        }
        public void SetIPv4(string ipv4) {
            IPv4 = ipv4;
        }
        public void SetOrderID(string orderid) {
            OrderID = orderid;
        }
        public void SetAmount(string amount, string currency) {
            Amount = amount;
            Currency = currency switch {
                "TRY" => "949",
                "YTL" => "949",
                "TRL" => "949",
                "TL" => "949",
                "USD" => "840",
                "EUR" => "978",
                "GBP" => "826",
                "JPY" => "392",
                _ => currency
            };
        }
        public void SetInstallment(string installment) {
            Installment = installment;
        }
        public void SetCardHolder(string firstname, string lastname) {
            FirstName = firstname;
            LastName = lastname;
        }
        public void SetPhoneNumber(string phonenumber) {
            PhoneNumber = phonenumber;
        }
        public void SetCardNumber(string cardnumber) {
            CardNumber = cardnumber;
        }
        public void SetCardExpiry(string cardmonth, string cardyear) {
            CardMonth = cardmonth;
            CardYear = cardyear;
        }
        public void SetCardCode(string cardcode) {
            CardCode = cardcode;
        }
        public GVPSResponse Pay() {
            var data = new GVPSRequest {
                Mode = Mode ?? "PROD",
                Version = "v1.0",
                Terminal = new Terminal {
                    ID = ClientID,
                    MerchantID = Username,
                    UserID = "PROVAUT",
                    ProvUserID = "PROVAUT",
                    HashData = SHA1Encrypt(OrderID + ClientID + CardNumber + Amount.Replace(".", string.Empty) + SHA1Encrypt(Password + ClientID.PadLeft(9, '0')).ToUpperInvariant()).ToUpperInvariant()
                },
                Customer = new Customer {
                    IPAddress = IPv4
                },
                Card = new Card {
                    Number = CardNumber,
                    Expiry = CardMonth + CardYear,
                    Code = CardCode
                },
                Transaction = new Transaction {
                    Type = "sales",
                    Amount = Amount.Replace(".", string.Empty),
                    CurrencyCode = Currency,
                    InstallmentCnt = Installment,
                    MotoInd = "H"
                },
                Order = new Order {
                    AddressList = new AddressList {
                        Address = new Address {
                            Type = "B",
                            Name = FirstName,
                            LastName = LastName,
                            PhoneNumber = PhoneNumber ?? ""
                        }
                    }
                }
            };
            var gvpsrequest = new XmlSerializer(typeof(GVPSRequest));
            var gvpsresponse = new XmlSerializer(typeof(GVPSResponse));
            using var writer = new Writer();
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            gvpsrequest.Serialize(writer, data, ns);
            try {
                using var http = new HttpClient();
                using var request = new HttpRequestMessage(HttpMethod.Post, Endpoint) {
                    Content = new StringContent(writer.ToString(), Encoding.UTF8, "text/xml")
                };
                using var response = http.Send(request);
                var result = (GVPSResponse)gvpsresponse.Deserialize(response.Content.ReadAsStream());
                return result;
            } catch (Exception err) {
                if (err.InnerException != null) {
                    Console.WriteLine(err.InnerException.Message);
                } else {
                    Console.WriteLine(err.Message);
                }
            }
            return null;
        }
        public GVPSResponse Cancel() {
            var data = new GVPSRequest {
                Mode = Mode ?? "PROD",
                Version = "v1.0",
                Terminal = new Terminal {
                    ID = ClientID,
                    MerchantID = Username,
                    UserID = "PROVRFN",
                    ProvUserID = "PROVRFN",
                    HashData = SHA1Encrypt(OrderID + ClientID + Amount.Replace(".", string.Empty) + SHA1Encrypt(Password + ClientID.PadLeft(9, '0')).ToUpperInvariant()).ToUpperInvariant()
                },
                Customer = new Customer {
                    IPAddress = IPv4
                },
                Transaction = new Transaction {
                    Type = "void",
                    Amount = Amount.Replace(".", string.Empty),
                    CurrencyCode = Currency
                },
                Order = new Order {
                    OrderID = OrderID
                }
            };
            var gvpsrequest = new XmlSerializer(typeof(GVPSRequest));
            var gvpsresponse = new XmlSerializer(typeof(GVPSResponse));
            using var writer = new Writer();
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            gvpsrequest.Serialize(writer, data, ns);
            try {
                using var http = new HttpClient();
                using var request = new HttpRequestMessage(HttpMethod.Post, Endpoint) {
                    Content = new StringContent(writer.ToString(), Encoding.UTF8, "text/xml")
                };
                using var response = http.Send(request);
                var result = (GVPSResponse)gvpsresponse.Deserialize(response.Content.ReadAsStream());
                return result;
            } catch (Exception err) {
                if (err.InnerException != null) {
                    Console.WriteLine(err.InnerException.Message);
                } else {
                    Console.WriteLine(err.Message);
                }
            }
            return null;
        }
        public GVPSResponse Refund() {
            var data = new GVPSRequest {
                Mode = Mode ?? "PROD",
                Version = "v1.0",
                Terminal = new Terminal {
                    ID = ClientID,
                    MerchantID = Username,
                    UserID = "PROVRFN",
                    ProvUserID = "PROVRFN",
                    HashData = SHA1Encrypt(OrderID + ClientID + Amount.Replace(".", string.Empty) + SHA1Encrypt(Password + ClientID.PadLeft(9, '0')).ToUpperInvariant()).ToUpperInvariant()
                },
                Customer = new Customer {
                    IPAddress = IPv4
                },
                Transaction = new Transaction {
                    Type = "refund",
                    Amount = Amount.Replace(".", string.Empty),
                    CurrencyCode = Currency
                },
                Order = new Order {
                    OrderID = OrderID
                }
            };
            var gvpsrequest = new XmlSerializer(typeof(GVPSRequest));
            var gvpsresponse = new XmlSerializer(typeof(GVPSResponse));
            using var writer = new Writer();
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            gvpsrequest.Serialize(writer, data, ns);
            try {
                using var http = new HttpClient();
                using var request = new HttpRequestMessage(HttpMethod.Post, Endpoint) {
                    Content = new StringContent(writer.ToString(), Encoding.UTF8, "text/xml")
                };
                using var response = http.Send(request);
                var result = (GVPSResponse)gvpsresponse.Deserialize(response.Content.ReadAsStream());
                return result;
            } catch (Exception err) {
                if (err.InnerException != null) {
                    Console.WriteLine(err.InnerException.Message);
                } else {
                    Console.WriteLine(err.Message);
                }
            }
            return null;
        }
        public static string JsonString<T>(T data) where T : class {
            return JsonSerializer.Serialize(data, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });
        }
    }
}