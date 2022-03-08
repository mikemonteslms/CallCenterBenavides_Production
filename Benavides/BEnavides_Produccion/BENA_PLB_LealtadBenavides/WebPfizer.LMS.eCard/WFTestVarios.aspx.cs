using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Net.NetworkInformation;
using System.Management; 

namespace WebPfizer.LMS.eCard
{
    public partial class WFTestVarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void DoGetHostAddresses(string hostname)
        {
            IPAddress[] ips;

            ips = Dns.GetHostAddresses(hostname);

            txtResultado.Text += hostname + "-";
            foreach (IPAddress ip in ips)
            {

                txtResultado.Text += ip + Environment.NewLine.ToString();
                #region MCADDRESS
                ManagementScope theScope = new ManagementScope("\\\\" + hostname + "\\root\\cimv2");

                try
                {
                    string theQueryBuilder = "";
                    theQueryBuilder = "SELECT * FROM Win32_NetworkAdapterConfiguration where IPEnabled=TRUE";
                    ObjectQuery theQuery = new ObjectQuery(theQueryBuilder.ToString());
                    ManagementObjectSearcher theSearcher = new ManagementObjectSearcher(theScope, theQuery);
                    ManagementObjectCollection theCollectionOfResults = theSearcher.Get();

                    foreach (ManagementObject theCurrentObject in theCollectionOfResults)
                    {
                        try
                        {

                            txtResultado.Text += theCurrentObject["MACAddress"].ToString() + Environment.NewLine.ToString();
                            txtResultado.Text += theCurrentObject["Caption"].ToString() + Environment.NewLine.ToString();
                        }
                        catch (Exception ex)
                        {
                            txtResultado.Text += ex.Message;
                        }
                    }
                }
                catch (Exception ex)
                {
                    txtResultado.Text += ex.Message;
                }

                #endregion

            }
        }


        protected void btnShowIPs_Click(object sender, EventArgs e)
        {
            //txtResultado.Text += "System.Net.Dns.GetHostName()" + System.Net.Dns.GetHostName();
            //txtResultado.Text += "Environment.MachineName" + Environment.MachineName;
            //txtResultado.Text += "HttpContext.Current.Request.UserHostAddress" + HttpContext.Current.Request.UserHostAddress; 
            //IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            //txtResultado.Text += "IPGlobalProperties.GetIPGlobalProperties()" + computerProperties.HostName.ToString();  
            //string strHostName = Request.ServerVariables["remote_addr"].ToString() ; 
            //txtResultado.Text += Request.ServerVariables["AUTH_USER"].ToString() + Environment.NewLine.ToString();
            //txtResultado.Text += Request.ServerVariables["LOCAL_ADDR"].ToString() + Environment.NewLine.ToString();
            //txtResultado.Text += Request.ServerVariables["LOGON_USER"].ToString() + Environment.NewLine.ToString();
            txtResultado.Text += Request.ServerVariables["REMOTE_ADDR"].ToString() + Environment.NewLine.ToString();
            //txtResultado.Text += Request.ServerVariables["REMOTE_HOST"].ToString() + Environment.NewLine.ToString();
            //txtResultado.Text += Request.ServerVariables["REMOTE_USER"].ToString() + Environment.NewLine.ToString();
            //txtResultado.Text += Request.ServerVariables["SERVER_NAME"].ToString() + Environment.NewLine.ToString();
            //txtResultado.Text += Request.ServerVariables["AUTH_USER"].ToString() + Environment.NewLine.ToString();
            //string strHostName = Request.ServerVariables["REMOTE_ADDR"].ToString();
            //DoGetHostAddresses(strHostName);
            txtResultado.Text += Request.UserHostName.ToString() + Environment.NewLine.ToString(); //Obtiene el nombre del equipo
            txtResultado.Text += System.Net.Dns.GetHostName() + Environment.NewLine.ToString(); //Obtiene el nombre del equipo
            txtResultado.Text += System.Net.Dns.GetHostAddresses(Request.ServerVariables["REMOTE_ADDR"].ToString()).GetValue(0).ToString() + Environment.NewLine.ToString(); //Obtiene la dirección IP del equipo


        }

    }
}
