using HotelProject.EntityLayer.Concreate;
using HotelProject.WebUI.DTOs.LoginDto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HotelProject.WebUI.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(LoginUserDto model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var result = await _signInManager.PasswordSignInAsync(model.UserName,model.Password,false,true);
			if(result.Succeeded)
			{
				return RedirectToAction("Index","Default");
			}
			return View();
		}

		public IActionResult GoogleLogin(string ReturnUrl)
		{
			string redirectUrl = Url.Action("ExternalResponse", "User", new { ReturnUrl = ReturnUrl });
			//Google'a yapılan Login talebi neticesinde kullanıcıyı yönlendirmesini istediğimiz url'i oluşturuyoruz.
			AuthenticationProperties properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
			//Bağlantı kurulacak harici platformun hangisi olduğunu belirtiyor ve bağlantı özelliklerini elde ediyoruz.
			return new ChallengeResult("Google", properties);
			//ChallengeResult; kimlik doğrulamak için gerekli olan tüm özellikleri kapsayan AuthenticationProperties nesnesini alır ve ayarlar.
		}
		public async Task<IActionResult> ExternalResponse(string ReturnUrl = "/")
		{
			ExternalLoginInfo loginInfo = await _signInManager.GetExternalLoginInfoAsync();
			//Kullanıcıyla ilgili dış kaynaktan gelen tüm bilgileri taşıyan nesnedir.
			//Bu nesnesnin 'LoginProvider' propertysinin değerine göz atarsanız eğer hangi dış kaynaktan geliniyorsa onun bilgisinin yazdığını göreceksiniz.
			if (loginInfo == null)
				return RedirectToAction("Login");
			else
			{
				Microsoft.AspNetCore.Identity.SignInResult loginResult = await _signInManager.ExternalLoginSignInAsync(loginInfo.LoginProvider, loginInfo.ProviderKey, true);
				//Giriş yapıyoruz.
				if (loginResult.Succeeded)
					return Redirect(ReturnUrl);
				else
				{
					//Eğer ki akış bu bloğa girerse ilgili kullanıcı uygulamamıza kayıt olmadığından dolayı girişi başarısız demektir.
					//O halde kayıt işlemini yapıp, ardından giriş yaptırmamız gerekmektedir.
					AppUser user = new AppUser
					{
						Email = loginInfo.Principal.FindFirst(ClaimTypes.Email).Value,
						UserName = loginInfo.Principal.FindFirst(ClaimTypes.Email).Value
					};
					//Dış kaynaktan gelen Claimleri uygun eşlendikleri propertylere atıyoruz.
					IdentityResult createResult = await _userManager.CreateAsync(user);
					//Kullanıcı kaydını yapıyoruz.
					if (createResult.Succeeded)
					{
						//Eğer kayıt başarılıysa ilgili kullanıcı bilgilerini AspNetUserLogins tablosuna kaydetmemiz gerekmektedir ki
						//bir sonraki dış kaynak login talebinde Identity mimarisi ilgili kullanıcının hangi dış kaynaktan geldiğini anlayabilsin.
						IdentityResult addLoginResult = await _userManager.AddLoginAsync(user, loginInfo);
						//Kullanıcı bilgileri dış kaynaktan gelen bilgileriyle AspNetUserLogins tablosunda eşleştirilmek suretiyle kaydedilmiştir.
						if (addLoginResult.Succeeded)
						{
							await _signInManager.SignInAsync(user, true);
							//await _signInManager.ExternalLoginSignInAsync(loginInfo.LoginProvider, loginInfo.ProviderKey, true);
							return Redirect(ReturnUrl);
						}
					}

				}
			}
			return Redirect(ReturnUrl);
		}
	}
}
