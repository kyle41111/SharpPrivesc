using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;
using System.ServiceProcess;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;
using System.Security.AccessControl;
using System.Collections;
using System.Threading;
using System.DirectoryServices;
using GetGroup;
using Privesc.Commands;
using Privesc2.Check;
using Privesc3.Check;
using Privesc.check;



namespace Privesc.Commands
{
    public class Dcsync : ICommand
    {
        public static string CommandName => "dcsync";


        public void Execute(Dictionary<string, string> arguments)
        {

            Forest f = Forest.GetCurrentForest();
            string cmd = "";
            DomainCollection domains = f.Domains;

            foreach (Domain d in domains)
            {
                 string DomainName = d.Name.ToString();
                string[] dc = DomainName.Split('.');
                 for (int i = 0; i < dc.Length; i++)
    {
        dc[i] = "DC=" + dc[i];
    }

    string DomainDN = String.Join(",", dc);

    dcsync p = new dcsync();
    Thread dcsync = new Thread(() => { cmd += p.GetDCSyncTargets(DomainDN); });
    dcsync.Start();
    dcsync.Join();

}

Console.WriteLine(cmd);
            }
        }
    }
