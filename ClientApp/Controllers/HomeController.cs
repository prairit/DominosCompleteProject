using paytm;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace DominosFrontEnd.Controllers
{
    /// <summary>
    /// This class is the home controller for the website
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// This class returns the home page of the website
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This method returns the checkout page of the website
        /// </summary>
        [Authorize]
        public ActionResult Checkout()
        {
            return View();
        }
        /// <summary>
        /// This method returns the pizza menu of the website
        /// </summary>
        [Authorize]
        public ActionResult PizzaMenu()
        {
            return View();
        }
        /// <summary>
        /// This method returns the Order completion page of the website
        /// </summary>
        public ActionResult OrderCompletion()
        {
            return View();
        }

        public void PaytmGateway()
        {
            var rnd = new Random();
            string merchantKey = "cGb1WUa9umc6ds0#";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("MID", "qRhfGq94735000540451");
            parameters.Add("CHANNEL_ID", "WEB");
            parameters.Add("INDUSTRY_TYPE_ID", "Retail");
            parameters.Add("WEBSITE", "WEBSTAGING");
            parameters.Add("EMAIL", "shivamverma64@gmail.com");
            parameters.Add("MOBILE_NO", "9717245991");
            parameters.Add("CUST_ID", "cust1");
            parameters.Add("ORDER_ID",rnd.Next(1,999999).ToString());
            parameters.Add("TXN_AMOUNT", rnd.Next(99, 999).ToString());
            parameters.Add("CALLBACK_URL", "https://localhost:44380/Home/ordercompletion");

            string checksum = CheckSum.generateCheckSum(merchantKey, parameters);

            string paytmURL = "https://securegw-stage.paytm.in/theia/processTransaction";

            string outputHTML = "<html>";
            outputHTML += "<head>";
            outputHTML += "<title>Merchant Check Out Page</title>";
            outputHTML += "</head>";
            outputHTML += "<body>";
            outputHTML += "<center><h1>Please do not refresh this page...</h1></center>";
            outputHTML += "<form method='post' action='" + paytmURL + "' name='f1'>";
            outputHTML += "<table border='1'>";
            outputHTML += "<tbody>";
            foreach (string key in parameters.Keys)
            {
                outputHTML += "<input type='hidden' name='" + key + "' value='" + parameters[key] + "'>";
            }
            outputHTML += "<input type='hidden' name='CHECKSUMHASH' value='" + checksum + "'>";
            outputHTML += "</tbody>";
            outputHTML += "</table>";
            outputHTML += "<script type='text/javascript'>";
            outputHTML += "document.f1.submit();";
            outputHTML += "</script>";
            outputHTML += "</form>";
            outputHTML += "</body>";
            outputHTML += "</html>";
            Response.Write(outputHTML);
        }

        public void SendEmail()
        {
            string senderEmail = "prairit360@gmail.com";
            string senderPassword = "";
            string toEmail = "prairit360@gmail.com";
            string subject = "Test Email";
            string emailBody = "<p>This is a test email that is sent as validation of the fact that this is working.</p>";

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Timeout = 1000000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(senderEmail, senderPassword);

            MailMessage mailMessage = new MailMessage(senderEmail,toEmail,subject,emailBody);
            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = UTF8Encoding.UTF8;
            client.Send(mailMessage);
        }

        public void SendSms()
        {
            TwilioClient.Init("ACb7af6bb0ef3d83a99b82b2b765092293", "d4448443a4c0310f9f7956277c96044c");
            MessageResource.Create(
                    to: new PhoneNumber("+919170560222"),
                    from: new PhoneNumber("+12057828281"),
                    body: "Ahoy from Twilio!");
        }
    }
}