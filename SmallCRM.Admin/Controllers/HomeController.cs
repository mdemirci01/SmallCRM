using SmallCRM.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SmallCRM.Admin.Controllers
{
   // [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "İletişim";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(AdminContactViewModel model)
        {
         
            if (ModelState.IsValid)
            {
                try
                {
                    System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
               
                    mailMessage.From = new System.Net.Mail.MailAddress("noreply.smallcrm@gmail.com", "Admin");
                    mailMessage.Subject = "İletişim Formu: " + model.FirstName + " " + model.LastName;

                    mailMessage.To.Add("noreply.smallcrm@gmail.com");

                    string body;
                    body = "Ad : " + model.FirstName + "<br />";
                    body += "Soyad : " + model.LastName + "<br />";
                    body += "Telefon: " + model.Phone + "<br />";
                    body += "E-posta: " + model.Email + "<br />";
                    body += "Mesaj: " + model.Message + "<br />";
                    body += "Tarih: " + DateTime.Now.ToString("dd MMMM yyyy HH:mm") + "<br />";

                    mailMessage.IsBodyHtml = true;
                    mailMessage.Body = body;

                    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                    //giriş yapılıyor
                    smtp.Credentials = new System.Net.NetworkCredential("noreply.smallcrm@gmail.com", "Wissen2018");
                       smtp.EnableSsl = true;
                    smtp.Send(mailMessage);
                    ViewBag.Success = "Mesajınız gönderildi. Teşekkür ederiz.";
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Form gönderimi başarısız oldu. Lütfen daha sonra tekrar deneyiniz.";
                }
            }

            //validasyon başarılı değilse form tekrar görüntülenip hata mesajları gösterilecek
            //model yazıldığında dolu gelmesini sağlar.
            return View(model);
        }

        public ActionResult Team()
        {
            ViewBag.Message = "Takım";

            return View();
        }
    }
}