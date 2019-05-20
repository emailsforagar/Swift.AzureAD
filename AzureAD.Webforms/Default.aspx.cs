using System;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AzureAD.Webforms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Request.IsAuthenticated)
                {
                    HttpContext.Current.GetOwinContext().Authentication.Challenge(
                        new AuthenticationProperties { RedirectUri = "/" },
                        OpenIdConnectAuthenticationDefaults.AuthenticationType);
                }
                else
                {
                    var userClaims = User.Identity as System.Security.Claims.ClaimsIdentity;
                    Session["UserName"] = userClaims?.FindFirst(System.IdentityModel.Claims.ClaimTypes.Name)?.Value;
                }
            }

            catch (OperationCanceledException ex)
            {

            }
            catch (Exception ex)
            {

            }
           

        }
        protected void Page_Unload(object sender, EventArgs e)
        {
            try
            {
                var userClaims = User.Identity as System.Security.Claims.ClaimsIdentity;

                Session["Name"] = userClaims?.FindFirst("name")?.Value;

                Session["UserName"] = userClaims?.FindFirst(System.IdentityModel.Claims.ClaimTypes.Name)?.Value;
            }
            catch (Exception ex)
            {

            }
        }
    }
}