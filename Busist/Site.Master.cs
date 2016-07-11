using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Busist
{
    public partial class SiteMaster : MasterPage
    {
        protected int _zoom = 13;
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            zoom.Value = _zoom.ToString();
            DBConnect db = new DBConnect();
            DataTable dt = new DataTable();
            dt = db.returnCheck();
            int n = dt.Rows.Count;
            //Response.Write("<script>alert('"+n+"');</script>");

            
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            string str = Request.Url.AbsolutePath;
            str = str.Remove(str.IndexOf('/'), 1);
            if (str.Trim().ToLower() == "default.aspx")
            {
                HiddenField h1 = new HiddenField();
                h1.ID = "count";
                h1.Value = n.ToString();
                Form1.Controls.Add(h1);
                for (int i = 0; i < n; i++)
                {
                    HiddenField h = new HiddenField();
                    h.ID = "marker_" + i.ToString();
                    h.Value = dt.Rows[i].ItemArray[0] + "," + dt.Rows[i].ItemArray[1] + "|" + dt.Rows[i].ItemArray[2];
                    Form1.Controls.Add(h);
                }

            }
            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}