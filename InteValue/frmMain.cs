using HtmlAgilityPack;
using System;
using System.Net;
using System.Windows.Forms;

namespace InteValue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                CookieContainer cookies = new CookieContainer();
                //string mySrc = HttpMethods.Get("https://github.com/session", "https://github.com/login", cookies); test get page
            
                string postData = String.Format("login={0}&password={1}",txtUsername.Text,txtPassword.Text);

                bool result = HttpMethods.Post("https://github.com/session", postData, "https://github.com/login", cookies); 
                
                if (result)
                {
                    txtResult.Text = "logged in!";
                }
                else
                {
                    txtResult.Text = "failed login..";
                }
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
            
           
            
            scrapData();
        }

        private void scrapData()
        {
            var webGet = new HtmlWeb();
            var doc = webGet.Load("https://www.facebook.com/");

            HtmlNode selectedNode = doc.DocumentNode.SelectSingleNode("//div[@id='reg_pages_msg']");

            if (selectedNode != null)
            {
                txtScrappingResult.Text = selectedNode.InnerHtml;
            }
            else
            {
                txtScrappingResult.Text = "no node found";
            }
        }
    }
}
