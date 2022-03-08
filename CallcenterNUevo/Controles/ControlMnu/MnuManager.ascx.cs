using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace MnuMain.Controles.ControlMnu
{
    public partial class MnuManager : System.Web.UI.UserControl
    {
        public string UserIdHD
        {
            get
            {
                return hidUserId.Value;
            }
            set
            {
                hidUserId.Value = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Membership.GetUser() != null)
                {
                    hidUserId.Value = Membership.GetUser().ProviderUserKey.ToString();
                }
            }
        }
        protected void RadMenu1_ItemDataBound(object sender, RadMenuEventArgs e)
        {
            DataRowView dataRow = e.Item.DataItem as DataRowView;
            if (dataRow != null)
            {
                e.Item.ToolTip = dataRow["alt"].ToString(); // TooTip                
                e.Item.NavigateUrl = dataRow["url"].ToString(); // Agrega la url
                e.Item.PostBack = false;
            }
        }
        protected void RadMenu1_ItemClick(object sender, Telerik.Web.UI.RadMenuEventArgs e)
        {
            Response.Write("You clicked: " + e.Item.Text);
        }
    }
}