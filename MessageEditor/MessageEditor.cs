//  <code-header>
//   <copyright file="MassageEditor.cs" company="Erdem TUZEN">
//   Copyright (c) 2015 All Rights Reserved
//   </copyright>
//   <author>Janissary - Erdem TUZEN</author>
//   <date>3/4/2015 11:57:21 AM </date>
//   <summary>Editor</summary>
//   <license href="license.txt">New License</license>
//   <revisions>
//     <revision initials="cw"></revision>
//   </revisions>
//  </code-header>


using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MessageEditor
{
    public partial class MessageEditor : Form
    {
        public MessageEditor()
        {
            InitializeComponent();

            FillFontComboBox();
            FillSizeComboBox();
        }

        private void FillFontComboBox()
        {
            var items = new[] { 
                                new { Text = "Yazı Tipi", Value = "Yazı Tipi"}, 
                                new { Text = "Arial", Value = "Arial" }, 
                                new { Text = "Courier", Value = "Courier" }, 
                                new { Text = "Times", Value = "Times" },
                                new { Text = "Verdana", Value = "Verdana" },
                                new { Text = "Wingdings", Value = "Wingdings" }
                               };

            FontComboBox.DataSource = items;
            FontComboBox.DisplayMember = "Text";
            FontComboBox.ValueMember = "Value";

            FontComboBox.SelectedIndex = 0;

        }

        private void FillSizeComboBox()
        {
            var items = new[] { 
                                new { Text = "Yazı Boyutu", Value =  "Yazı Boyutu" }, 
                                new { Text = "1", Value = "1" }, 
                                new { Text = "2", Value = "2" }, 
                                new { Text = "3", Value = "3" },
                                new { Text = "4", Value = "4" },
                                new { Text = "5", Value = "5" },
                                new { Text = "6", Value = "6" },
                                new { Text = "7", Value = "7" }
                               };

            SizeComboBox.DataSource = items;
            SizeComboBox.DisplayMember = "Text";
            SizeComboBox.ValueMember = "Value";

            SizeComboBox.SelectedIndex = 0;

        }

        private void ClickEvent(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button button = (Button)sender;
                switch (button.Name)
                {
                    case "ButtonSelectCopy":
                        TextBoxPostArea.Select();
                        TextBoxPostArea.SelectAll();
                        TextBoxPostArea.Copy();
                        break;
                    case "ButtonClear":
                        TextBoxPostArea.Text = string.Empty;
                        break;
                    case "ButtonPreview":
                        string html = BbCodeProcessor.Format(TextBoxPostArea.Text);
                        Preview preview = new Preview(html);
                        preview.ShowDialog();
                        break;
                    case "ButtonExport":
                        SaveFileDialog saveFileDialog = new SaveFileDialog();

                        saveFileDialog.Filter = "Metin dosyaları(*.txt)|*.txt|Tüm dosyalar(*.*)|*.*";
                        saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        saveFileDialog.AddExtension = true;
                        saveFileDialog.FilterIndex = 2;

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string path = saveFileDialog.FileName;
                            StreamWriter sw = new StreamWriter(path = path.Contains(".txt") ? path : path + ".txt");
                            sw.Write(TextBoxPostArea.Text);
                            sw.Close();
                        }


                        break;

                    case "ButtonImport":
                        OpenFileDialog openFileDialog = new OpenFileDialog();
                        openFileDialog.Filter = "Metin dosyaları(*.txt)|*.txt|Tüm dosyalar(*.*)|*.*";
                        openFileDialog.FilterIndex = 2;
                        openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        openFileDialog.SupportMultiDottedExtensions = true;
                        openFileDialog.Multiselect = true;

                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string path = openFileDialog.FileName;
                            StreamReader rd = new StreamReader(path);
                            TextBoxPostArea.Text = rd.ReadToEnd();
                            rd.Close();
                        }

                        break;
                    default:
                        break;
                }
            }
            else if (sender is Label)
            {
                Label label = (Label)sender;
                switch (label.Name)
                {
                    case "LabelWhite":
                        TextBoxPostArea.SelectedText = string.Format(" [WHITE]{0}[/FONT] ", TextBoxPostArea.SelectedText);
                        break;
                    case "LabelBlue":
                        TextBoxPostArea.SelectedText = string.Format(" [BLUE]{0}[/FONT] ", TextBoxPostArea.SelectedText);
                        break;
                    case "LabelGreen":
                        TextBoxPostArea.SelectedText = string.Format(" [GREEN]{0}[/FONT] ", TextBoxPostArea.SelectedText);
                        break;
                    case "LabelRed":
                        TextBoxPostArea.SelectedText = string.Format(" [RED]{0}[/FONT] ", TextBoxPostArea.SelectedText);
                        break;
                    case "LabelCyan":
                        TextBoxPostArea.SelectedText = string.Format(" [CYAN]{0}[/FONT] ", TextBoxPostArea.SelectedText);
                        break;
                    case "LabelOrange":
                        TextBoxPostArea.SelectedText = string.Format(" [ORANGE]{0}[/FONT] ", TextBoxPostArea.SelectedText);
                        break;
                    case "LabelBrown":
                        TextBoxPostArea.SelectedText = string.Format(" [BROWN]{0}[/FONT] ", TextBoxPostArea.SelectedText);
                        break;
                    case "LabelMagenta":
                        TextBoxPostArea.SelectedText = string.Format(" [MAGENTA]{0}[/FONT] ", TextBoxPostArea.SelectedText);
                        break;
                    case "LabelYellow":
                        TextBoxPostArea.SelectedText = string.Format(" [YELLOW]{0}[/FONT] ", TextBoxPostArea.SelectedText);
                        break;
                    case "LabelLimeGreen":
                        TextBoxPostArea.SelectedText = string.Format(" [LIMEGREEN]{0}[/FONT] ", TextBoxPostArea.SelectedText);
                        break;
                    default:
                        break;
                }
            }
            else if (sender is PictureBox)
            {
                PictureBox pictureBox = (PictureBox)sender;

                string pictureBoxName = pictureBox.Name;
                int pFrom = pictureBoxName.IndexOf("pictureBox") + "pictureBox".Length;

                switch (pictureBox.Name)
                {
                    case "pbBold":
                        TextBoxPostArea.SelectedText = string.Format(" [B]{0}[/B] ", TextBoxPostArea.SelectedText);
                        break;
                    case "pbItalic":
                        TextBoxPostArea.SelectedText = string.Format(" [I]{0}[/I] ", TextBoxPostArea.SelectedText);
                        break;
                    case "pbUnderLine":
                        TextBoxPostArea.SelectedText = string.Format(" [U]{0}[/U] ", TextBoxPostArea.SelectedText);
                        break;
                    case "pbUrl":
                        TextBoxPostArea.SelectedText = string.Format(" [URL={0}]{0}[/URL] ", TextBoxPostArea.SelectedText);
                        break;
                    case "pbEMail":
                        TextBoxPostArea.SelectedText = string.Format(" [EMAIL={0}]{0}[/EMAIL] ", TextBoxPostArea.SelectedText);
                        break;
                    case "pbCenter":
                        TextBoxPostArea.SelectedText = string.Format(" [CENTER]{0}[/CENTER] ", TextBoxPostArea.SelectedText);
                        break;
                    case "pbIndent":
                        TextBoxPostArea.SelectedText = string.Format("    {0} ", TextBoxPostArea.SelectedText);
                        break;
                    case "pbPicture":
                        TextBoxPostArea.SelectedText = string.Format(" [IMG]{0}[/IMG] ", TextBoxPostArea.SelectedText);
                        break;
                    default:
                        if (pictureBoxName.Contains("pictureBox"))
                            TextBoxPostArea.SelectedText = string.Format(" [IMG]http://www.cyber-warrior.org/Forum/smileys/{0}.gif[/IMG] ", pictureBoxName.Substring(pFrom));
                        break;
                }

            }
            else if (sender is ComboBox)
            {
                ComboBox comboBox = (ComboBox)sender;

                string value = comboBox.SelectedValue.ToString();

                if (!value.Contains("Yazı"))
                {
                    if (comboBox.Name.Contains("Font"))
                        TextBoxPostArea.SelectedText = string.Format(" [FONT={0}]{1}[/FONT] ", value, TextBoxPostArea.SelectedText);
                    else
                        TextBoxPostArea.SelectedText = string.Format(" [SIZE={0}]{1}[/FONT] ", value, TextBoxPostArea.SelectedText);
                }
            }
        }

        private string CreatePreviewHtml(string html)
        {
            //Helper.FormatHtmlIntoBBCode(html);
            return html;
        }

        private void PictureBoxAboutUs_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }
    }
}
