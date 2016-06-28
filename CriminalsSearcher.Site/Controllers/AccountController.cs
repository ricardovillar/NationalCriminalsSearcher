using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using CriminalsSearcher.Model.Entities;
using CriminalsSearcher.Model.Repositories;
using CriminalsSearcher.Site.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace CriminalsSearcher.Site.Controllers {
    public class AccountController : Controller {
        private readonly IUserRepository _userRepository;

        private const int PBKDF2IterCount = 1000;
        private const int PBKDF2SubkeyLength = 256 / 8;
        private const int SaltSize = 128 / 8;


        public AccountController(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl) {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl) {
            if (!ModelState.IsValid) {
                return View(model);
            }
            var user = _userRepository.GetUserByEmail(model.Email);
            if (user != null) {
                if (VerifyEncryptedPassword(user.Password, model.Password)) {
                    SetUserAuth(user);
                    return RedirectToLocal(returnUrl);
                }
                else {
                    ModelState.AddModelError("", "Invalid password.");
                }
            }
            else {
                ModelState.AddModelError("", "Invalid email.");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff() {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult Register() {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model) {
            if (ModelState.IsValid) {
                if (ValidateRegistration(model)) {
                    _userRepository.Create(model.Name, model.Email, EncryptPassword(model.Password));
                    return Login(new LoginViewModel { Email = model.Email, Password = model.Password }, null);
                }
            }
            return View(model);
        }

        private ActionResult RedirectToLocal(string returnUrl) {
            if (Url.IsLocalUrl(returnUrl)) {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Search", "Home");
        }

        private void SetUserAuth(User user) {
            var ident = new ClaimsIdentity(new[] { 
                  new Claim(ClaimTypes.NameIdentifier, user.Email),
                  new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),
                  new Claim(ClaimTypes.Name, user.Name)
                },
                DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);
        }

        private IAuthenticationManager AuthenticationManager {
            get {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private bool ValidateRegistration(RegisterViewModel model) {
            if (_userRepository.GetUserByEmail(model.Email) != null) {
                ModelState.AddModelError("", "Sorry, there's already a user registered with this email.");
                return false;
            }
            return true;
        }

        private static string EncryptPassword(string plainTextPassword) {
            byte[] salt;
            byte[] subkey;
            using (var deriveBytes = new Rfc2898DeriveBytes(plainTextPassword, SaltSize, 1000)) {
                salt = deriveBytes.Salt;
                subkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
            }
            byte[] outputBytes = new byte[1 + SaltSize + PBKDF2SubkeyLength];
            Buffer.BlockCopy(salt, 0, outputBytes, 1, SaltSize);
            Buffer.BlockCopy(subkey, 0, outputBytes, 1 + SaltSize, PBKDF2SubkeyLength);
            return Convert.ToBase64String(outputBytes);
        }

        public static bool VerifyEncryptedPassword(string encryptedPassword, string plainTextPassword) {
            var hashedPasswordBytes = Convert.FromBase64String(encryptedPassword);
            if (hashedPasswordBytes.Length != (1 + SaltSize + PBKDF2SubkeyLength) || hashedPasswordBytes[0] != 0x00) {
                return false;
            }
            var salt = new byte[SaltSize];
            Buffer.BlockCopy(hashedPasswordBytes, 1, salt, 0, SaltSize);
            var storedSubkey = new byte[PBKDF2SubkeyLength];
            Buffer.BlockCopy(hashedPasswordBytes, 1 + SaltSize, storedSubkey, 0, PBKDF2SubkeyLength);
            byte[] generatedSubkey;
            using (var deriveBytes = new Rfc2898DeriveBytes(plainTextPassword, salt, PBKDF2IterCount)) {
                generatedSubkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
            }
            return storedSubkey.SequenceEqual(generatedSubkey);
        }


    }
}