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
using camp_v5;
using Microsoft.Web.WebView2.Core;

namespace camp_v5
{
    public partial class MainAppContainer : Form
    {
        private ModalAppContainer testDialog;

        public MainAppContainer()
        {
            InitializeComponent();
            AttachControlEventHandlers();
            testDialog = new ModalAppContainer("https://www.bing.de");

        }

        private void webView23_Click(object sender, EventArgs e)
        {

        }


        private void MainAppContainer_Load(object sender, EventArgs e)
        {

        }


        private void RedirectToModal(String uri)
        {
            //https://github.com/MicrosoftEdge/WebView2Feedback/issues/824
            this.webView.BeginInvoke(new MethodInvoker(() =>
            {
                this.testDialog.modalUri = uri;
                this.testDialog.navigate(uri);
                this.testDialog.ShowDialog(this);
                //this.testDialog.navigate(uri);

            }));


        }
        #region Event Handlers

        void AttachControlEventHandlers()
        {
            this.webView.CoreWebView2InitializationCompleted += WebView2Control_CoreWebView2InitializationCompleted;
            this.webView.NavigationStarting += WebView2Control_NavigationStarting;
            //control.NavigationCompleted += WebView2Control_NavigationCompleted;
            //control.SourceChanged += WebView2Control_SourceChanged;
            //control.KeyDown += WebView2Control_KeyDown;
            //control.KeyUp += WebView2Control_KeyUp;
        }

        private void WebView2Control_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs args)
        {
            String uri = args.Uri;
            if (!uri.StartsWith("https://www.google"))
            {
                //MessageBox.Show($"Navigation cancelled, redirecting...");
                args.Cancel = true;

                // ToDo: open modal window
                RedirectToModal(uri);
            }
        }
        private void WebView2Control_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            if (!e.IsSuccess)
            {
                MessageBox.Show($"WebView2 creation failed with exception = {e.InitializationException}");
                //UpdateTitleWithEvent("CoreWebView2InitializationCompleted failed");
                return;
            }
            else
            {
                //MessageBox.Show($"WebView2 creation succeded");

            }

            this.webView.CoreWebView2.SourceChanged += CoreWebView2_SourceChanged;
            //this.webView2Control.CoreWebView2.HistoryChanged += CoreWebView2_HistoryChanged;
            //this.webView2Control.CoreWebView2.DocumentTitleChanged += CoreWebView2_DocumentTitleChanged;
            //this.webView2Control.CoreWebView2.AddWebResourceRequestedFilter("*", CoreWebView2WebResourceContext.Image);
            //UpdateTitleWithEvent("CoreWebView2InitializationCompleted succeeded");
        }

        private void CoreWebView2_SourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
        {
            //MessageBox.Show($"source change: {this.webView.Source.AbsoluteUri}");

        }




        #endregion
    }




}
