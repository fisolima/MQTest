using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MQService;

namespace WinApp
{
    public partial class main : Form
    {
        private Dictionary<string,Color> _appColors = new Dictionary<string, Color>();

        public MessageService _messageService;

        public main()
        {
            InitializeComponent();
        }

        private void AppNameChanged(object sender, EventArgs e)
        {
            _startApp.Enabled = !String.IsNullOrWhiteSpace(_appName.Text) && (_messageService == null || !_messageService.Running);
        }

        private void StartApp(object sender, EventArgs e)
        {
            _messageService = new MessageService(_appName.Text, OnMessage, OnError);

            _messageService.Start();

            _startApp.Enabled = _messageService.Running;
            _appName.Enabled = _messageService.Running;
            _appName.Text = _messageService.AppName;
        }

        private Color GetAppColor(string appName)
        {
            if (_appColors.ContainsKey(appName))
                return _appColors[appName];

            var rand = new Random();

            var color = Color.FromArgb(255, rand.Next(120), rand.Next(120), rand.Next(120));

            _appColors.Add(appName, color);

            return color;
        }

        private void AppendMessage(string msg, Color color)
        {
            _messages.SelectionStart = _messages.TextLength;
            _messages.SelectionLength = 0;

            _messages.SelectionColor = color;
            _messages.AppendText(msg);
            _messages.SelectionColor = Color.Black;
            _messages.AppendText("\n");

            _messages.SelectionStart = _messages.Text.Length;
            _messages.ScrollToCaret();
        }

        private void OnMessage(string appName, string message)
        {
            var msg = string.Format("{0} - [{1}] {2}", DateTime.UtcNow.ToString("hh:mm:ss"), appName, message);
            var color = GetAppColor(appName);

            Invoke((MethodInvoker) delegate
            {
                AppendMessage(msg, color);
            });
        }

        private void OnError(string error)
        {
            var msg = string.Format("{0} - {1}", DateTime.UtcNow.ToString("hh:mm:ss"), error);
            Invoke((MethodInvoker)delegate
            {
                AppendMessage(msg, Color.Red);
            });
        }

        private void main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_messageService != null)
                _messageService.Stop();
        }
    }
}
