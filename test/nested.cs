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


namespace Privesc.Commands
{
    public class nested : ICommand
    {
        public static string CommandName => "nested";

        public void Execute(Dictionary<string, string> arguments)
        {
            Console.WriteLine("checking for nested groups");


            
            string group = arguments["/group"];
            string domain = arguments["/domain"];

            Class2 pp = new Class2();
            pp.GetAllMembers(group, domain);


            

        }

    }
}
