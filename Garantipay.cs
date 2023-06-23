using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Garantipay {
    public enum MODE {
        Test,
        Prod
    }
    public class Garantipay {
        public string Mode { get; set; }
        public string Endpoint { get; set; }
        private string TerminalId { get; set; }
        private string MerchantId { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private string StoreKey { get; set; }
        public void SetTerminalId(string terminalid) {
            TerminalId = terminalid;
        }
        public void SetMerchantId(string merchantid) {
            MerchantId = merchantid;
        }
        public void SetUsername(string username) {
            Username = username;
        }
        public void SetPassword(string password) {
            Password = password;
        }
        public void SetStoreKey(string storekey) {
            StoreKey = storekey;
        }
        public Garantipay(MODE mode) {
            Mode = mode switch {
                MODE.Test => "TEST",
                MODE.Prod => "PROD",
                _ => null
            };
            Endpoint = mode switch {
                MODE.Test => "https://sanalposprovtest.garanti.com.tr/VPServlet",
                MODE.Prod => "https://sanalposprov.garanti.com.tr/VPServlet",
                _ => null
            };
        }
        [XmlRoot("GVPSRequest")]
        public class GVPSRequest {
            [FormElement("mode")]
            [XmlElement("Mode", IsNullable = false)]
            public string Mode { get; set; }
            [FormElement("apiversion")]
            [XmlElement("Version", IsNullable = false)]
            public string Version { get; set; }
            [XmlElement("ChannelCode", IsNullable = false)]
            public string ChannelCode { get; set; }
            [XmlElement("Terminal", IsNullable = false)]
            public Terminal Terminal { get; set; }
            [XmlElement("Customer", IsNullable = false)]
            public Customer Customer { get; set; }
            [XmlElement("Card", IsNullable = false)]
            public Card Card { get; set; }
            [XmlElement("Order", IsNullable = false)]
            public Order Order { get; set; }
            [XmlElement("Transaction", IsNullable = false)]
            public Transaction Transaction { get; set; }
            [FormElement("companyname")]
            [XmlIgnore]
            public string CompanyName { get; set; }
            [FormElement("refreshtime")]
            [XmlIgnore]
            public string RefreshTime { get; set; }
            [FormElement("lang")]
            [XmlIgnore]
            public string Lang { get; set; }
            public GVPSRequest() {
                Version = "v1.0";
                Terminal = new Terminal();
                Customer = new Customer();
                Card = new Card();
                Order = new Order();
                Transaction = new Transaction();
            }
        }
        public class Terminal {
            [FormElement("terminalmerchantid")]
            [XmlElement("MerchantID", IsNullable = false)]
            public string MerchantId { get; set; }
            [FormElement("terminalprovuserid")]
            [XmlElement("ProvUserID", IsNullable = false)]
            public string ProvUserId { get; set; }
            [FormElement("terminaluserid")]
            [XmlElement("UserID", IsNullable = false)]
            public string UserId { get; set; }
            [FormElement("terminalid")]
            [XmlElement("ID", IsNullable = false)]
            public string Id { get; set; }
            [FormElement("secure3dhash")]
            [XmlElement("HashData", IsNullable = false)]
            public string HashData { get; set; }
            [FormElement("secure3dsecuritylevel")]
            [XmlIgnore]
            public string Level { get; set; }
        }
        public class Card {
            [FormElement("cardnumber")]
            [XmlElement("Number", IsNullable = false)]
            public string Number { get; set; }
            [XmlElement("ExpireDate", IsNullable = false)]
            public string Expiry { get; set; }
            [FormElement("cardexpiredatemonth")]
            [XmlIgnore]
            public string CardMonth { get; set; }
            [FormElement("cardexpiredateyear")]
            [XmlIgnore]
            public string CardYear { get; set; }
            [FormElement("cardcvv2")]
            [XmlElement("CVV2", IsNullable = false)]
            public string Code { get; set; }
            public void SetCardNumber(string cardnumber) {
                Number = cardnumber;
            }
            public void SetCardExpiry(string cardmonth, string cardyear) {
                Expiry = cardmonth + cardyear;
                CardMonth = cardmonth;
                CardYear = cardyear;
            }
            public void SetCardCode(string cardcode) {
                Code = cardcode;
            }
        }
        public class Customer {
            [FormElement("customeripaddress")]
            [XmlElement("IPAddress", IsNullable = false)]
            public string IPv4 { get; set; }
            [FormElement("customeremailaddress")]
            [XmlElement("EmailAddress", IsNullable = false)]
            public string Email { get; set; }
            public void SetIPv4(string ipv4) {
                IPv4 = ipv4;
            }
            public void SetEmail(string email) {
                Email = email;
            }
        }
        public class Transaction {
            [FormElement("txntype")]
            [XmlElement("Type", IsNullable = false)]
            public string Type { get; set; }
            [FormElement("txnsubtype")]
            [XmlElement("SubType", IsNullable = false)]
            public string SubType { get; set; }
            [XmlElement("FirmCardNo", IsNullable = false)]
            public string FirmCardNo { get; set; }
            [FormElement("txninstallmentcount")]
            [XmlElement("InstallmentCnt", IsNullable = false)]
            public string Installment { get; set; }
            [FormElement("txnamount")]
            [XmlElement("Amount", IsNullable = false)]
            public string Amount { get; set; }
            [FormElement("txncurrencycode")]
            [XmlElement("CurrencyCode", IsNullable = false)]
            public string Currency { get; set; }
            [XmlElement("CardholderPresentCode", IsNullable = false)]
            public string CardholderPresentCode { get; set; }
            [FormElement("txnmotoind")]
            [XmlElement("MotoInd", IsNullable = false)]
            public string MotoInd { get; set; }
            [XmlElement("AuthCode", IsNullable = false)]
            public string AuthCode { get; set; }
            [XmlElement("RetrefNum", IsNullable = false)]
            public string RetrefNum { get; set; }
            [XmlElement("BatchNum", IsNullable = false)]
            public string BatchNum { get; set; }
            [XmlElement("SequenceNum", IsNullable = false)]
            public string SequenceNum { get; set; }
            [XmlElement("ProvDate", IsNullable = false)]
            public string ProvDate { get; set; }
            [XmlElement("CardNumberMasked", IsNullable = false)]
            public string CardNumberMasked { get; set; }
            [XmlElement("CardHolderName", IsNullable = false)]
            public string CardHolderName { get; set; }
            [XmlElement("CardType", IsNullable = false)]
            public string CardType { get; set; }
            [XmlElement("HashData", IsNullable = false)]
            public string HashData { get; set; }
            [XmlElement("Description", IsNullable = false)]
            public string Description { get; set; }
            [XmlElement("Secure3D", IsNullable = false)]
            public Secure3D Secure3D { get; set; }
            [XmlElement("Response", IsNullable = false)]
            public Response Response { get; set; }
            [FormElement("txntimestamp")]
            [XmlIgnore]
            public string Timestamp { get; set; }
            [FormElement("successurl")]
            [XmlIgnore]
            public string SuccessUrl { get; set; }
            [FormElement("errorurl")]
            [XmlIgnore]
            public string ErrorUrl { get; set; }
            public void SetAmount(string amount, string currency) {
                Amount = amount.Replace(".", "");
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
        }
        public class Secure3D {
            [XmlElement("AuthenticationCode", IsNullable = false)]
            public string AuthenticationCode { get; set; }
            [XmlElement("SecurityLevel", IsNullable = false)]
            public string SecurityLevel { get; set; }
            [XmlElement("TxnID", IsNullable = false)]
            public string TxnId { get; set; }
            [XmlElement("Md", IsNullable = false)]
            public string Md { get; set; }
        }
        public class Order {
            [FormElement("orderid")]
            [XmlElement("OrderID", IsNullable = false)]
            public string OrderId { get; set; }
            [FormElement("groupid")]
            [XmlElement("GroupID", IsNullable = false)]
            public string GroupId { get; set; }
            [XmlElement("AddressList", IsNullable = false)]
            public AddressList AddressList { get; set; }
            public void SetOrderId(string orderid) {
                OrderId = orderid;
            }
        }
        public class AddressList {
            [XmlElement("Address", IsNullable = false)]
            public Address Address { get; set; }
        }
        public class Address {
            [XmlElement("Type", IsNullable = false)]
            public string Type { get; set; }
            [XmlElement("Name", IsNullable = false)]
            public string Name { get; set; }
            [XmlElement("LastName", IsNullable = false)]
            public string LastName { get; set; }
            [FormElement("cardholder")]
            [XmlElement("Company", IsNullable = false)]
            public string Company { get; set; }
            [XmlElement("Text", IsNullable = false)]
            public string Text { get; set; }
            [XmlElement("Country", IsNullable = false)]
            public string Country { get; set; }
            [XmlElement("City", IsNullable = false)]
            public string City { get; set; }
            [XmlElement("District", IsNullable = false)]
            public string District { get; set; }
            [XmlElement("PostalCode", IsNullable = false)]
            public string PostalCode { get; set; }
            [FormElement("phone")]
            [XmlElement("PhoneNumber", IsNullable = false)]
            public string PhoneNumber { get; set; }
            [XmlElement("GsmNumber", IsNullable = false)]
            public string GsmNumber { get; set; }
            [XmlElement("FaxNumber", IsNullable = false)]
            public string FaxNumber { get; set; }
        }
        public class Response {
            [XmlElement("Source", IsNullable = false)]
            public string Source { get; set; }
            [XmlElement("Code", IsNullable = false)]
            public string Code { get; set; }
            [XmlElement("ReasonCode", IsNullable = false)]
            public string ReasonCode { get; set; }
            [XmlElement("Message", IsNullable = false)]
            public string Message { get; set; }
            [XmlElement("ErrorMsg", IsNullable = false)]
            public string ErrorMsg { get; set; }
            [XmlElement("SysErrMsg", IsNullable = false)]
            public string SysErrMsg { get; set; }
        }
        [XmlRoot("GVPSResponse")]
        public class GVPSResponse {
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
        public class FormElementAttribute : Attribute {
            public string Key { get; }
            public FormElementAttribute(string key) {
                Key = key;
            }
        }
        public class Writer : StringWriter {
            public override Encoding Encoding => Encoding.UTF8;
        }
        public static string Json<T>(T data) where T : class {
            return JsonSerializer.Serialize(data, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });
        }
        public static byte[] Byte(string data) {
            return Encoding.ASCII.GetBytes(data);
        }
        public static string Hex(byte[] data) {
            return BitConverter.ToString(data).Replace("-", "").ToUpperInvariant();
        }
        public static string Hash(string data) {
            return Hex(SHA1.Create().ComputeHash(Byte(data)));
        }
        public GVPSResponse PreAuth(GVPSRequest data) {
            data.Mode = Mode;
            data.Terminal.Id = TerminalId;
            data.Terminal.MerchantId = MerchantId;
            data.Terminal.UserId = Username;
            data.Terminal.ProvUserId = Username;
            data.Transaction.Type = "preauth";
            data.Terminal.HashData = Hash(data.Order.OrderId + data.Terminal.Id + data.Card.Number + data.Transaction.Amount + Hash(Password + data.Terminal.Id.PadLeft(9, '0')));
            return _Transaction(data);
        }
        public GVPSResponse PostAuth(GVPSRequest data) {
            data.Mode = Mode;
            data.Terminal.Id = TerminalId;
            data.Terminal.MerchantId = MerchantId;
            data.Terminal.UserId = Username;
            data.Terminal.ProvUserId = Username;
            data.Transaction.Type = "postauth";
            data.Terminal.HashData = Hash(data.Order.OrderId + data.Terminal.Id + data.Card.Number + data.Transaction.Amount + Hash(Password + data.Terminal.Id.PadLeft(9, '0')));
            return _Transaction(data);
        }
        public GVPSResponse Auth(GVPSRequest data) {
            data.Mode = Mode;
            data.Terminal.Id = TerminalId;
            data.Terminal.MerchantId = MerchantId;
            data.Terminal.UserId = Username;
            data.Terminal.ProvUserId = Username;
            data.Transaction.Type = "sales";
            data.Terminal.HashData = Hash(data.Order.OrderId + data.Terminal.Id + data.Card.Number + data.Transaction.Amount + Hash(Password + data.Terminal.Id.PadLeft(9, '0')));
            return _Transaction(data);
        }
        public GVPSResponse Refund(GVPSRequest data) {
            data.Mode = Mode;
            data.Terminal.Id = TerminalId;
            data.Terminal.MerchantId = MerchantId;
            data.Terminal.UserId = Username;
            data.Terminal.ProvUserId = Username;
            data.Transaction.Type = "refund";
            data.Terminal.HashData = Hash(data.Order.OrderId + data.Terminal.Id + data.Card.Number + data.Transaction.Amount + Hash(Password + data.Terminal.Id.PadLeft(9, '0')));
            data.Card = null;
            return _Transaction(data);
        }
        public GVPSResponse Cancel(GVPSRequest data) {
            data.Mode = Mode;
            data.Terminal.Id = TerminalId;
            data.Terminal.MerchantId = MerchantId;
            data.Terminal.UserId = Username;
            data.Terminal.ProvUserId = Username;
            data.Transaction.Type = "void";
            data.Terminal.HashData = Hash(data.Order.OrderId + data.Terminal.Id + data.Card.Number + data.Transaction.Amount + Hash(Password + data.Terminal.Id.PadLeft(9, '0')));
            data.Card = null;
            return _Transaction(data);
        }
        public GVPSResponse PreAuth3d(GVPSRequest data) {
            data.Mode = Mode;
            data.Terminal.Id = TerminalId;
            data.Terminal.MerchantId = MerchantId;
            data.Terminal.UserId = Username;
            data.Terminal.ProvUserId = Username;
            data.Transaction.Type = "preauth";
            data.Terminal.HashData = Hash(data.Order.OrderId + data.Terminal.Id + data.Card.Number + data.Transaction.Amount + Hash(Password + data.Terminal.Id.PadLeft(9, '0')));
            return _Transaction(data);
        }
        public GVPSResponse Auth3d(GVPSRequest data) {
            data.Mode = Mode;
            data.Terminal.Id = TerminalId;
            data.Terminal.MerchantId = MerchantId;
            data.Terminal.UserId = Username;
            data.Terminal.ProvUserId = Username;
            data.Transaction.Type = "sales";
            data.Terminal.HashData = Hash(data.Order.OrderId + data.Terminal.Id + data.Card.Number + data.Transaction.Amount + Hash(Password + data.Terminal.Id.PadLeft(9, '0')));
            return _Transaction(data);
        }
        public Dictionary<string, string> PreAuth3dForm(GVPSRequest data) {
            data.RefreshTime = "0";
            data.Mode = Mode;
            data.Terminal.Id = TerminalId;
            data.Terminal.MerchantId = MerchantId;
            data.Terminal.UserId = Username;
            data.Terminal.ProvUserId = Username;
            data.Terminal.Level = "3D";
            data.Transaction.Type = "preauth";
            data.Transaction.MotoInd = "N";
            data.Transaction.Timestamp = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            data.Terminal.HashData = Hash(data.Terminal.Id + data.Order.OrderId + data.Transaction.Amount + data.Transaction.SuccessUrl + data.Transaction.ErrorUrl + data.Transaction.Type + data.Transaction.Installment + Hex(Byte(StoreKey)).ToLowerInvariant() + Hash(Password + data.Terminal.Id.PadLeft(9, '0')));
            var form = new Dictionary<string, string>();
            if (data != null) {
                var elements = data.GetType().GetProperties().Where(x => x.GetCustomAttribute<FormElementAttribute>() != null);
                foreach (var element in elements) {
                    var key = element.GetCustomAttribute<FormElementAttribute>().Key;
                    var value = element.GetValue(data)?.ToString();
                    if (!string.IsNullOrEmpty(value)) {
                        form.Add(key, value);
                    }
                }
                if (data.Terminal != null) {
                    var terminal_elements = data.Terminal.GetType().GetProperties().Where(x => x.GetCustomAttribute<FormElementAttribute>() != null);
                    foreach (var element in terminal_elements) {
                        var key = element.GetCustomAttribute<FormElementAttribute>().Key;
                        var value = element.GetValue(data.Terminal)?.ToString();
                        if (!string.IsNullOrEmpty(value)) {
                            form.Add(key, value);
                        }
                    }
                }
                if (data.Order != null) {
                    var order_elements = data.Order.GetType().GetProperties().Where(x => x.GetCustomAttribute<FormElementAttribute>() != null);
                    foreach (var element in order_elements) {
                        var key = element.GetCustomAttribute<FormElementAttribute>().Key;
                        var value = element.GetValue(data.Order)?.ToString();
                        if (!string.IsNullOrEmpty(value)) {
                            form.Add(key, value);
                        }
                    }
                }
                if (data.Transaction != null) {
                    var transaction_elements = data.Transaction.GetType().GetProperties().Where(x => x.GetCustomAttribute<FormElementAttribute>() != null);
                    foreach (var element in transaction_elements) {
                        var key = element.GetCustomAttribute<FormElementAttribute>().Key;
                        var value = element.GetValue(data.Transaction)?.ToString();
                        if (!string.IsNullOrEmpty(value)) {
                            form.Add(key, value);
                        }
                    }
                }
                if (data.Card != null) {
                    var card_elements = data.Card.GetType().GetProperties().Where(x => x.GetCustomAttribute<FormElementAttribute>() != null);
                    foreach (var element in card_elements) {
                        var key = element.GetCustomAttribute<FormElementAttribute>().Key;
                        var value = element.GetValue(data.Card)?.ToString();
                        if (!string.IsNullOrEmpty(value)) {
                            form.Add(key, value);
                        }
                    }
                }
                if (data.Customer != null) {
                    var customer_elements = data.Customer.GetType().GetProperties().Where(x => x.GetCustomAttribute<FormElementAttribute>() != null);
                    foreach (var element in customer_elements) {
                        var key = element.GetCustomAttribute<FormElementAttribute>().Key;
                        var value = element.GetValue(data.Customer)?.ToString();
                        if (!string.IsNullOrEmpty(value)) {
                            form.Add(key, value);
                        }
                    }
                }
            }
            return form;
        }
        public Dictionary<string, string> Auth3dForm(GVPSRequest data) {
            data.RefreshTime = "0";
            data.Mode = Mode;
            data.Terminal.Id = TerminalId;
            data.Terminal.MerchantId = MerchantId;
            data.Terminal.UserId = Username;
            data.Terminal.ProvUserId = Username;
            data.Terminal.Level = "3D";
            data.Transaction.Type = "sales";
            data.Transaction.MotoInd = "N";
            data.Transaction.Timestamp = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            data.Terminal.HashData = Hash(data.Terminal.Id + data.Order.OrderId + data.Transaction.Amount + data.Transaction.SuccessUrl + data.Transaction.ErrorUrl + data.Transaction.Type + data.Transaction.Installment + Hex(Byte(StoreKey)).ToLowerInvariant() + Hash(Password + data.Terminal.Id.PadLeft(9, '0')));
            var form = new Dictionary<string, string>();
            if (data != null) {
                var elements = data.GetType().GetProperties().Where(x => x.GetCustomAttribute<FormElementAttribute>() != null);
                foreach (var element in elements) {
                    var key = element.GetCustomAttribute<FormElementAttribute>().Key;
                    var value = element.GetValue(data)?.ToString();
                    if (!string.IsNullOrEmpty(value)) {
                        form.Add(key, value);
                    }
                }
                if (data.Terminal != null) {
                    var terminal_elements = data.Terminal.GetType().GetProperties().Where(x => x.GetCustomAttribute<FormElementAttribute>() != null);
                    foreach (var element in terminal_elements) {
                        var key = element.GetCustomAttribute<FormElementAttribute>().Key;
                        var value = element.GetValue(data.Terminal)?.ToString();
                        if (!string.IsNullOrEmpty(value)) {
                            form.Add(key, value);
                        }
                    }
                }
                if (data.Order != null) {
                    var order_elements = data.Order.GetType().GetProperties().Where(x => x.GetCustomAttribute<FormElementAttribute>() != null);
                    foreach (var element in order_elements) {
                        var key = element.GetCustomAttribute<FormElementAttribute>().Key;
                        var value = element.GetValue(data.Order)?.ToString();
                        if (!string.IsNullOrEmpty(value)) {
                            form.Add(key, value);
                        }
                    }
                }
                if (data.Transaction != null) {
                    var transaction_elements = data.Transaction.GetType().GetProperties().Where(x => x.GetCustomAttribute<FormElementAttribute>() != null);
                    foreach (var element in transaction_elements) {
                        var key = element.GetCustomAttribute<FormElementAttribute>().Key;
                        var value = element.GetValue(data.Transaction)?.ToString();
                        if (!string.IsNullOrEmpty(value)) {
                            form.Add(key, value);
                        }
                    }
                }
                if (data.Card != null) {
                    var card_elements = data.Card.GetType().GetProperties().Where(x => x.GetCustomAttribute<FormElementAttribute>() != null);
                    foreach (var element in card_elements) {
                        var key = element.GetCustomAttribute<FormElementAttribute>().Key;
                        var value = element.GetValue(data.Card)?.ToString();
                        if (!string.IsNullOrEmpty(value)) {
                            form.Add(key, value);
                        }
                    }
                }
                if (data.Customer != null) {
                    var customer_elements = data.Customer.GetType().GetProperties().Where(x => x.GetCustomAttribute<FormElementAttribute>() != null);
                    foreach (var element in customer_elements) {
                        var key = element.GetCustomAttribute<FormElementAttribute>().Key;
                        var value = element.GetValue(data.Customer)?.ToString();
                        if (!string.IsNullOrEmpty(value)) {
                            form.Add(key, value);
                        }
                    }
                }
            }
            return form;
        }
        private GVPSResponse _Transaction(GVPSRequest data) {
            var gvpsrequest = new XmlSerializer(typeof(GVPSRequest));
            var gvpsresponse = new XmlSerializer(typeof(GVPSResponse));
            using var writer = new Writer();
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            gvpsrequest.Serialize(writer, data, ns);
            try {
                using var http = new HttpClient();
                using var request = new HttpRequestMessage(HttpMethod.Post, Endpoint) { Content = new StringContent(writer.ToString(), Encoding.UTF8, "text/xml") };
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
    }
}