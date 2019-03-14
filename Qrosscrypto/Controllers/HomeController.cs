using Newtonsoft.Json.Linq;
using Qrosscrypto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Qrosscrypto.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            JObject Bitcoinpricehistory = null;
            JObject BitcoinCurrentPrice = null;
            JObject EthereumCurrentPrice = null;

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var BitcoinPriceHistoryjson = await httpClient.GetStringAsync("https://blockchain.info/charts/market-price?timespan=50days&format=json");
                    var BitcoinCurrentPricejson = await httpClient.GetStringAsync("https://min-api.cryptocompare.com/data/price?fsym=BTC&tsyms=USD");
                    var EthereumCurrentPricejson = await httpClient.GetStringAsync("https://min-api.cryptocompare.com/data/price?fsym=ETH&tsyms=USD");

                    Console.WriteLine(BitcoinPriceHistoryjson);
                    // Now parse with JSON.Net
                    Bitcoinpricehistory = JObject.Parse(BitcoinPriceHistoryjson);
                    // Now parse with JSON.Net
                    BitcoinCurrentPrice = JObject.Parse(BitcoinCurrentPricejson);

                    EthereumCurrentPrice = JObject.Parse(EthereumCurrentPricejson);

                }
            }
                    

            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            ViewData["Bitcoinpricehistory"] = Bitcoinpricehistory;
            ViewData["BitcoinCurrentPrice"] = BitcoinCurrentPrice;
            ViewData["EthereumCurrentPrice"] = EthereumCurrentPrice;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(ContactModel contactModel, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                contactModel.FirstName = collection["FirstName"] + "";
                contactModel.LastName = collection["LastName"] + "";
                contactModel.Email = collection["Email"] + "";
                contactModel.PhoneNo = collection["PhoneNo"] + "";
                contactModel.Message = collection["Message"] + "";

                string notifyMessage = "<p>New Buy Order Form Has Been Submitted:</p>"
                                     + "<p>=======================================</p>"
                                     + "<p>Submitted by:    " + contactModel.FirstName + " " + contactModel.LastName + "</p>"
                                     + "<p>Email:    " + contactModel.Email + "</p>"
                                     + "<p>Phpne No:    " + contactModel.PhoneNo + "</p>"
                                     + "<p>Message:    "
                                     + "<p>========</p>"
                                     + "<p>" + contactModel.Message + "</p>"
                                     + "<p>===============================================</p>";

                await SendNotification(notifyMessage, contactModel.Email,  "Qrosscrypto@gmail.com");

                return RedirectToAction("Index", "Home");
            }
            ViewBag.Message = "Your contact page.";

            return View(contactModel);
        }

        [HttpGet]
        public ActionResult BuyOrder()
        {
            ViewBag.Message = "Your buyOrder description page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> BuyOrder(OrderFormModel orderFormModel,FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                orderFormModel.ECurrency = collection["ECurrency"] + "";
                orderFormModel.AmountUSD = collection["AmountUSD"] + "";
                orderFormModel.AmountNaira = collection["AmountNaira"] + "";
                orderFormModel.AccountName = collection["AccountName"] + "";
                orderFormModel.WalletAddress = collection["WalletAddress"] + "";
                orderFormModel.BankName = collection["BankName"] + "";
                orderFormModel.PaymentMethod = collection["PaymentMethod"] + "";
                orderFormModel.FullName = collection["FullName"] + "";
                orderFormModel.Email = collection["Email"] + "";
                orderFormModel.PhoneNo = collection["PhoneNo"] + "";

                string notifyMessage = "<p>New Buy Order Form Has Been Submitted:</p>"
                                     + "<p>=======================================</p>"
                                     + "<p>Submitted by:    " + orderFormModel.FullName + "</p>"
                                     + "<p>Email:    " + orderFormModel.Email + "</p>"
                                     + "<p>E-Currency:    " + orderFormModel.ECurrency + "</p>"
                                     + "<p>Amount in USD:    " + orderFormModel.AmountUSD + "</p>"
                                     + "<p>Amount in Naira:    " + orderFormModel.AmountNaira + "</p>"
                                     + "<p>Account Name:    " + orderFormModel.AccountName + "</p>"
                                     + "<p>Wallet Address:    " + orderFormModel.WalletAddress + "</p>"
                                     + "<p>Bank Name:    " + orderFormModel.BankName + "</p>"
                                     + "<p>Payment Method:    " + orderFormModel.PaymentMethod + "</p>"
                                     + "<p>===============================================</p>";

                await SendNotification(notifyMessage, orderFormModel.Email, "Qrosscrypto@gmail.com");

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "Your BuyOrder description page.";

            return View(orderFormModel);
        }

        [HttpGet]
        public ActionResult SellOrder()
        {
            ViewBag.Message = "Your SellOrder description page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SellOrder(OrderFormModel orderFormModel, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                orderFormModel.ECurrency = collection["ECurrency"] + "";
                orderFormModel.AmountUSD = collection["AmountUSD"] + "";
                orderFormModel.AmountNaira = collection["AmountNaira"] + "";
                orderFormModel.AccountName = collection["AccountName"] + "";
                orderFormModel.WalletAddress = collection["WalletAddress"] + "";
                orderFormModel.BankName = collection["BankName"] + "";
                orderFormModel.PaymentMethod = collection["PaymentMethod"] + "";
                orderFormModel.FullName = collection["FullName"] + "";
                orderFormModel.Email = collection["Email"] + "";
                orderFormModel.PhoneNo = collection["PhoneNo"] + "";

                string notifyMessage = "<p>New Sell Order Form Has Been Submitted:</p>"
                                     + "<p>=======================================</p>"
                                     + "<p>Submitted by:    " + orderFormModel.FullName + "</p>"
                                     + "<p>Email:    " + orderFormModel.Email + "</p>"
                                     + "<p>E-Currency:    " + orderFormModel.ECurrency + "</p>"
                                     + "<p>Amount in USD:    " + orderFormModel.AmountUSD + "</p>"
                                     + "<p>Amount in Naira:    " + orderFormModel.AmountNaira + "</p>"
                                     + "<p>Account Name:    " + orderFormModel.AccountName + "</p>"
                                     + "<p>Wallet Address:    " + orderFormModel.WalletAddress + "</p>"
                                     + "<p>Bank Name:    " + orderFormModel.BankName + "</p>"
                                     + "<p>Payment Method:    " + orderFormModel.PaymentMethod + "</p>"
                                     + "<p>===============================================</p>";

                await SendNotification(notifyMessage, orderFormModel.Email, "Qrosscrypto@gmail.com");

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "Your SellOrder description page.";

            return View(orderFormModel);
        }

        public ActionResult Payment()
        {
            ViewBag.Message = "Your Payment description page.";

            return View();
        }

        public ActionResult FAQS()
        {
            ViewBag.Message = "Your FAQS page.";

            return View();
        }

        public async Task<ActionResult> SendNotification(string NotificationMessage, string NotifyFrom, string NotifyTo)
        {
            var body = "<p>Form Submitted to: {0} by ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            string ToEmail = NotifyTo.Trim();
            message.To.Add(new MailAddress(ToEmail));  // replace with valid value 
            message.From = new MailAddress(NotifyFrom);  // replace with valid value
            message.Subject = "New Form Submitted - Notification";
            message.Body = string.Format(body, "QrossCrypto", NotifyFrom, NotificationMessage);
            message.IsBodyHtml = true;

            try
            {
                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "Qrosscrypto@gmail.com",  // replace with valid value
                        Password = "Usman@4lyf"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}