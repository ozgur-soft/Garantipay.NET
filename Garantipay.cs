﻿using System.Security.Cryptography;
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
        private string Mode { get; set; }
        private string Endpoint { get; set; }
        private string ClientId { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        internal void SetClientId(string clientid) {
            ClientId = clientid;
        }
        internal void SetUsername(string username) {
            Username = username;
        }
        internal void SetPassword(string password) {
            Password = password;
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
        [Serializable, XmlRoot("GVPSRequest")]
        public class GVPSRequest {
            [XmlElement("Mode", IsNullable = false)]
            public string Mode { set; get; }
            [XmlElement("Version", IsNullable = false)]
            public string Version { set; get; }
            [XmlElement("ChannelCode", IsNullable = false)]
            public string ChannelCode { set; get; }
            [XmlElement("Terminal", IsNullable = false)]
            public Terminal Terminal { set; get; }
            [XmlElement("Customer", IsNullable = false)]
            public Customer Customer { set; get; }
            [XmlElement("Card", IsNullable = false)]
            public Card Card { set; get; }
            [XmlElement("Order", IsNullable = false)]
            public Order Order { set; get; }
            [XmlElement("Transaction", IsNullable = false)]
            public Transaction Transaction { set; get; }
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
            [XmlElement("MerchantID", IsNullable = false)]
            public string MerchantId { set; get; }
            [XmlElement("ProvUserID", IsNullable = false)]
            public string ProvUserId { set; get; }
            [XmlElement("UserID", IsNullable = false)]
            public string UserId { set; get; }
            [XmlElement("ID", IsNullable = false)]
            public string Id { set; get; }
            [XmlElement("HashData", IsNullable = false)]
            public string HashData { set; get; }
        }
        public class Card {
            [XmlElement("Number", IsNullable = false)]
            public string Number { set; get; }
            [XmlElement("ExpireDate", IsNullable = false)]
            public string Expiry { set; get; }
            [XmlElement("CVV2", IsNullable = false)]
            public string Code { set; get; }
            public void SetCardNumber(string cardnumber) {
                Number = cardnumber;
            }
            public void SetCardExpiry(string cardmonth, string cardyear) {
                Expiry = cardmonth + cardyear;
            }
            public void SetCardCode(string cardcode) {
                Code = cardcode;
            }
        }
        public class Customer {
            [XmlElement("IPAddress", IsNullable = false)]
            public string IPv4 { set; get; }
            [XmlElement("EmailAddress", IsNullable = false)]
            public string Email { set; get; }
            public void SetIPv4(string ipv4) {
                IPv4 = ipv4;
            }
            public void SetEmail(string email) {
                Email = email;
            }
        }
        public class Transaction {
            [XmlElement("Type", IsNullable = false)]
            public string Type { set; get; }
            [XmlElement("SubType", IsNullable = false)]
            public string SubType { set; get; }
            [XmlElement("FirmCardNo", IsNullable = false)]
            public string FirmCardNo { set; get; }
            [XmlElement("InstallmentCnt", IsNullable = false)]
            public string InstallmentCnt { set; get; }
            [XmlElement("Amount", IsNullable = false)]
            public string Amount { set; get; }
            [XmlElement("CurrencyCode", IsNullable = false)]
            public string Currency { set; get; }
            [XmlElement("CardholderPresentCode", IsNullable = false)]
            public string CardholderPresentCode { set; get; }
            [XmlElement("MotoInd", IsNullable = false)]
            public string MotoInd { set; get; }
            [XmlElement("AuthCode", IsNullable = false)]
            public string AuthCode { set; get; }
            [XmlElement("RetrefNum", IsNullable = false)]
            public string RetrefNum { set; get; }
            [XmlElement("BatchNum", IsNullable = false)]
            public string BatchNum { set; get; }
            [XmlElement("SequenceNum", IsNullable = false)]
            public string SequenceNum { set; get; }
            [XmlElement("ProvDate", IsNullable = false)]
            public string ProvDate { set; get; }
            [XmlElement("CardNumberMasked", IsNullable = false)]
            public string CardNumberMasked { set; get; }
            [XmlElement("CardHolderName", IsNullable = false)]
            public string CardHolderName { set; get; }
            [XmlElement("CardType", IsNullable = false)]
            public string CardType { set; get; }
            [XmlElement("HashData", IsNullable = false)]
            public string HashData { set; get; }
            [XmlElement("Description", IsNullable = false)]
            public string Description { set; get; }
            [XmlElement("Secure3D", IsNullable = false)]
            public Secure3D Secure3D { set; get; }
            [XmlElement("Response", IsNullable = false)]
            public Response Response { set; get; }
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
                InstallmentCnt = installment;
            }
        }
        public class Secure3D {
            [XmlElement("AuthenticationCode", IsNullable = false)]
            public string AuthenticationCode { set; get; }
            [XmlElement("SecurityLevel", IsNullable = false)]
            public string SecurityLevel { set; get; }
            [XmlElement("TxnID", IsNullable = false)]
            public string TxnId { set; get; }
            [XmlElement("Md", IsNullable = false)]
            public string Md { set; get; }
        }
        public class Order {
            [XmlElement("OrderID", IsNullable = false)]
            public string OrderId { set; get; }
            [XmlElement("GroupID", IsNullable = false)]
            public string GroupId { set; get; }
            [XmlElement("AddressList", IsNullable = false)]
            public AddressList AddressList { set; get; }
            public void SetOrderId(string orderid) {
                OrderId = orderid;
            }
        }
        public class AddressList {
            [XmlElement("Address", IsNullable = false)]
            public Address Address { set; get; }
        }
        public class Address {
            [XmlElement("Type", IsNullable = false)]
            public string Type { set; get; }
            [XmlElement("Name", IsNullable = false)]
            public string Name { set; get; }
            [XmlElement("LastName", IsNullable = false)]
            public string LastName { set; get; }
            [XmlElement("Company", IsNullable = false)]
            public string Company { set; get; }
            [XmlElement("Text", IsNullable = false)]
            public string Text { set; get; }
            [XmlElement("Country", IsNullable = false)]
            public string Country { set; get; }
            [XmlElement("City", IsNullable = false)]
            public string City { set; get; }
            [XmlElement("District", IsNullable = false)]
            public string District { set; get; }
            [XmlElement("PostalCode", IsNullable = false)]
            public string PostalCode { set; get; }
            [XmlElement("PhoneNumber", IsNullable = false)]
            public string PhoneNumber { set; get; }
            [XmlElement("GsmNumber", IsNullable = false)]
            public string GsmNumber { set; get; }
            [XmlElement("FaxNumber", IsNullable = false)]
            public string FaxNumber { set; get; }
        }
        public class Response {
            [XmlElement("Source", IsNullable = false)]
            public string Source { set; get; }
            [XmlElement("Code", IsNullable = false)]
            public string Code { set; get; }
            [XmlElement("ReasonCode", IsNullable = false)]
            public string ReasonCode { set; get; }
            [XmlElement("Message", IsNullable = false)]
            public string Message { set; get; }
            [XmlElement("ErrorMsg", IsNullable = false)]
            public string ErrorMsg { set; get; }
            [XmlElement("SysErrMsg", IsNullable = false)]
            public string SysErrMsg { set; get; }
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
        public GVPSResponse Auth(GVPSRequest data) {
            data.Transaction.Type = "sales";
            data.Terminal.Id = ClientId;
            data.Terminal.MerchantId = Username;
            data.Terminal.UserId = "PROVAUT";
            data.Terminal.ProvUserId = "PROVAUT";
            data.Terminal.HashData = SHA1Encrypt(data.Order.OrderId + data.Terminal.Id + data.Card.Number + data.Transaction.Amount + SHA1Encrypt(Password + data.Terminal.Id.PadLeft(9, '0')).ToUpperInvariant()).ToUpperInvariant();
            return _Transaction(data);
        }
        public GVPSResponse Cancel(GVPSRequest data) {
            data.Card = null;
            data.Transaction.Type = "void";
            data.Terminal.Id = ClientId;
            data.Terminal.MerchantId = Username;
            data.Terminal.UserId = "PROVRFN";
            data.Terminal.ProvUserId = "PROVRFN";
            data.Terminal.HashData = SHA1Encrypt(data.Order.OrderId + data.Terminal.Id + data.Card.Number + data.Transaction.Amount + SHA1Encrypt(Password + data.Terminal.Id.PadLeft(9, '0')).ToUpperInvariant()).ToUpperInvariant();
            return _Transaction(data);
        }
        public GVPSResponse Refund(GVPSRequest data) {
            data.Card = null;
            data.Transaction.Type = "refund";
            data.Terminal.Id = ClientId;
            data.Terminal.MerchantId = Username;
            data.Terminal.UserId = "PROVRFN";
            data.Terminal.ProvUserId = "PROVRFN";
            data.Terminal.HashData = SHA1Encrypt(data.Order.OrderId + data.Terminal.Id + data.Card.Number + data.Transaction.Amount + SHA1Encrypt(Password + data.Terminal.Id.PadLeft(9, '0')).ToUpperInvariant()).ToUpperInvariant();
            return _Transaction(data);
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
        public static string JsonString<T>(T data) where T : class {
            return JsonSerializer.Serialize(data, new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, WriteIndented = true });
        }
    }
}