using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId.RelyingParty;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;

namespace ShareIt.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult LogOn(string from)
        {
            var openid = new OpenIdRelyingParty();
            IAuthenticationResponse response = openid.GetResponse();

            if (response != null)
            {
                switch (response.Status)
                {
                    case AuthenticationStatus.Authenticated:
                        var sreg = response.GetExtension<ClaimsResponse>();
                        if (sreg != null)
                        {
                            Session.Add("Email", sreg.Email);
                            Session.Add("FullName", sreg.FullName);
                        }
                        
                        FormsAuthentication.RedirectFromLoginPage(response.ClaimedIdentifier, false);
                        break;
                    case AuthenticationStatus.Canceled:
                        ModelState.AddModelError("loginIdentifier", "Login was cancelled at the provider");
                        break;
                    case AuthenticationStatus.Failed:
                        ModelState.AddModelError("loginIdentifier", "Login failed using the provided OpenID identifier");
                        break;
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult LogOn()
        {
            string loginIdentifier = Request.Form["openid_identifier"];
            if (!Identifier.IsValid(loginIdentifier))
            {
                ModelState.AddModelError("loginIdentifier", "The specified login identifier is invalid");
                return View();
            }
            else
            {
                var openid = new OpenIdRelyingParty();
                IAuthenticationRequest request = openid.CreateRequest(Identifier.Parse(loginIdentifier));

                // Require some additional data
                request.AddExtension(new ClaimsRequest
                {
                    Email = DemandLevel.Require,
                    FullName = DemandLevel.Require,
                    Nickname = DemandLevel.Require
                });

                return request.RedirectingResponse.AsActionResult();
            }
        }

    }
}
