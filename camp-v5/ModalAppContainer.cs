using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace camp_v5
{
    public partial class ModalAppContainer : Form
    {
        public string modalUri { get; set; }

        public ModalAppContainer(String uri)
        {
            InitializeComponent();
            modalUri = uri;
            this.webViewModal.CoreWebView2InitializationCompleted += WebView2Control_CoreWebView2InitializationCompleted;

            //this.webViewModal.CoreWebView2.Navigate();
        }

        private void webViewModal_Click(object sender, EventArgs e)
        {

        }

        public void navigate(String inputUri) 
        {
            //MessageBox.Show($"navigate to = {inputUri}");

            var rawUrl = inputUri;
            Uri uri = null;

            if (Uri.IsWellFormedUriString(rawUrl, UriKind.Absolute))
            {
                uri = new Uri(rawUrl);
            }
            else if (!rawUrl.Contains(" ") && rawUrl.Contains("."))
            {
                // An invalid URI contains a dot and no spaces, try tacking http:// on the front.
                uri = new Uri("http://" + rawUrl);
            }
            else
            {
                // Otherwise treat it as a web search.
                uri = new Uri("https://bing.com/search?q=" +
                    String.Join("+", Uri.EscapeDataString(rawUrl).Split(new string[] { "%20" }, StringSplitOptions.RemoveEmptyEntries)));
            }

            this.webViewModal.Source = uri;
        }
        private void WebView2Control_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            if (!e.IsSuccess)
            {
                MessageBox.Show($"WebView2 (modal) creation failed with exception = {e.InitializationException}");
                return;
            }
            else
            {
                //MessageBox.Show($"NOICE = {modalUri}");
                navigate(modalUri);

            }

        }

    }
}
