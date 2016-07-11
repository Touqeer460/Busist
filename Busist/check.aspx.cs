using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Busist
{
    public partial class check : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var q = Request.QueryString["q"];
            if (1==1)
                Response.Write("hello");
        }
    }
}