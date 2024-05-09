using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/[controller]/[action]/{id?}")]
    public class AdminMailController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(AdminMailViewModel model)
		{
			MimeMessage mimeMessage= new MimeMessage();
			MailboxAddress mailBoxAdressFrom = new MailboxAddress("HotelAdmin","mhmmtklnc15@gmail.com");
			mimeMessage.From.Add(mailBoxAdressFrom);

			MailboxAddress mailboxAddressTo = new MailboxAddress("User",model.RecieverMail);
			mimeMessage.To.Add(mailboxAddressTo);
			var bodyBuilder = new BodyBuilder();	
			bodyBuilder.TextBody= model.Body;
			mimeMessage.Body = bodyBuilder.ToMessageBody();
			mimeMessage.Subject = model.Subject;
			
			SmtpClient client = new SmtpClient();
			client.Connect("smtp.gmail.com",587,false);

			client.Authenticate("mhmmtklnc15@gmail.com", "sfrbrlsxzxosxgsv");
			client.Send(mimeMessage);
			client.Disconnect(true);

			// Gönderilen Mailin Veri Tabanına Kaydedilmesi
			return View();
		}
	}
}
