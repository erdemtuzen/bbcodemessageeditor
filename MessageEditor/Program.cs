//  <code-header>
//   <copyright file="Program.cs" company="Erdem TUZEN">
//   Copyright (c) 2015 All Rights Reserved
//   </copyright>
//   <author>Janissary - Erdem TUZEN</author>
//   <date>3/4/2015 11:57:21 AM </date>
//   <summary>Program</summary>
//   <license href="license.txt">License</license>
//  </code-header>

using System;
using System.Windows.Forms;

namespace MessageEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MessageEditor());
        }
    }
}
