//  <code-header>
//   <copyright file="MassageEditor.cs" company="Erdem TUZEN">
//   Copyright (c) 2015 All Rights Reserved
//   </copyright>
//   <author>Janissary - Erdem TUZEN</author>
//   <date>3/4/2015 11:57:21 AM </date>
//   <summary>Preview</summary>
//   <license href="license.txt">License</license>
//  </code-header>

using System;
using System.Text;
using System.Windows.Forms;

namespace MessageEditor
{
    public partial class Preview : Form
    {
        public Preview()
        {
            InitializeComponent();
        }
        public Preview(string html)
        {
            InitializeComponent();
            StringBuilder _html = new StringBuilder();
            _html.Append("<html><head><title>Mesaj Editör</title></head><body>");
            _html.Append(html);
            _html.Append("</body></html>");
            WebBrowserPreview.DocumentText = _html.ToString();

        }
        private void Preview_Load(object sender, EventArgs e)
        {

        }
    }
}
