using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Busist
{
    public partial class _Default : Page
    {
        protected int _zoom = 13;
        protected void Page_Load(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            DataTable dt = new DataTable();
            dt = db.returnStop();
            foreach(DataRow dr in dt.Rows)
            {
                ListItem li = new ListItem(dr.ItemArray[1].ToString(), dr.ItemArray[0].ToString());
                Customer_Locations.Items.Add(li);
                Destinations.Items.Add(li);
                
            }
           
        }
    }
}