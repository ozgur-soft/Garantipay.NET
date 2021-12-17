using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Garantipay {
    public interface IGarantipay {
        void SetClientId(string clientid);
        void SetUsername(string username);
        void SetPassword(string password);
        void SetMode(string mode);
        void SetIPv4(string ipv4);
        Garantipay.GVPSResponse Pay(string cardnumber, string cardmonth, string cardyear, string cardcode, string firstname, string lastname, string phone, string price, string currency);
    }
    public class Garantipay : IGarantipay {
        private const string Endpoint = "https://sanalposprov.garanti.com.tr/VPServlet";
        private string ClientId { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private string Mode { get; set; }
        private string IPv4 { get; set; }
        public Garantipay() { }
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
            public string ExpireDate { init; get; }
            [XmlElement("CVV2", IsNullable = false)]
            public string CVV2 { init; get; }
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
        public void SetClientId(string clientid) {
            ClientId = clientid;
        }
        public void SetUsername(string username) {
            Username = username;
        }
        public void SetPassword(string password) {
            Password = password;
        }
        public void SetMode(string mode) {
            Mode = mode;
        }
        public void SetIPv4(string ipv4) {
            IPv4 = ipv4;
        }
        public GVPSResponse Pay(string cardnumber, string cardmonth, string cardyear, string cardcode, string firstname, string lastname, string phone, string price, string currency) {
            var data = new GVPSRequest {
                Mode = Mode ?? "PROD",
                Version = "v1.0",
                Terminal = new Terminal {
                    ID = ClientId,
                    MerchantID = Username,
                    UserID = "PROVAUT",
                    ProvUserID = "PROVAUT",
                    HashData = SHA1Encrypt(ClientId + cardnumber + price.Replace(".", string.Empty) + SHA1Encrypt(Password + ClientId.PadLeft(9, '0')).ToUpperInvariant()).ToUpperInvariant()
                },
                Customer = new Customer {
                    IPAddress = IPv4,
                },
                Card = new Card {
                    Number = cardnumber,
                    ExpireDate = cardmonth + cardyear,
                    CVV2 = cardcode,
                },
                Transaction = new Transaction {
                    Type = "sales",
                    Amount = price.Replace(".", string.Empty),
                    CurrencyCode = currency,
                    InstallmentCnt = "",
                    MotoInd = "H",
                },
                Order = new Order {
                    AddressList = new AddressList {
                        Address = new Address {
                            Type = "B",
                            Name = firstname,
                            LastName = lastname,
                            PhoneNumber = phone ?? "",
                        }
                    }
                }
            };
            var gvpsrequest = new XmlSerializer(typeof(GVPSRequest));
            var gvpsresponse = new XmlSerializer(typeof(GVPSResponse));
            var writer = new Writer();
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            gvpsrequest.Serialize(writer, data, ns);
            try {
                var http = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, Endpoint) {
                    Content = new StringContent(writer.ToString(), Encoding.UTF8, "text/xml")
                };
                var response = http.Send(request);
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
    }
}