using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.OAuth;
using Owin;
using GyanParikshaWebApi.Providers;
using GyanPariksha.Model;
using GyanPariksha.Data;
using System.Threading.Tasks;
using System.Security.Claims;


namespace GyanParikshaWebApi
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }

        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(GyanParikshaDBContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Configure the application for OAuth based flow
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),//path to the authorization server from where application gets bearer token.
                Provider = new ApplicationOAuthProvider(PublicClientId),//validate the credentials and create a claims identity
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");

            //app.UseFacebookAuthentication(
            //    appId: "851726168257137",
            //    appSecret: "1b717ef6c10cdf6bde572b55558eaa38");
            var facebookOptions = new Microsoft.Owin.Security.Facebook.FacebookAuthenticationOptions
            {
                AppId = "141483643194730",
                AppSecret = "af2d1f54e45cad5fc2c50027cf4de1e9",
               //BackchannelHttpHandler = new FacebookBackChannelHandler(),
                //UserInformationEndpoint = "https://graph.facebook.com/v2.4/me?fields=id,name,email,first_name,last_name"
                //Provider = new FacebookAuthenticationProvider()
                //{
                //    OnAuthenticated = (context) =>
                //    {
                //        try
                //        {
                //            context.Identity.AddClaim(new System.Security.Claims.Claim("urn:facebook:access_token", context.AccessToken, ClaimValueTypes.String, "Facebook"));
                //            context.Identity.AddClaim(new System.Security.Claims.Claim("urn:facebook:email", context.Email, ClaimValueTypes.Email, "Facebook"));
                //            return Task.FromResult(0);
                //        }
                //        catch (Exception ex)
                //        {

                //        }
                //    }
                //},
            };
            facebookOptions.Scope.Add("email");
            facebookOptions.UserInformationEndpoint= "https://graph.facebook.com/v2.4/me?fields=id,name,email,first_name,last_name";
            app.UseFacebookAuthentication(facebookOptions);
            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "1056403495788-ohcpfdvvrh56sgr2fmbaphev5gsp4uc7.apps.googleusercontent.com",
                ClientSecret = "1acmtm1BYVb-G7ydOtcTUs-s"
            });
        }
    }
}
