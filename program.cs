using System;
using Microsoft.Win32;
using System.ServiceProcess;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;
using System.Security.AccessControl;
using System.IO;
using System.Collections;
using System.Threading;
using System.DirectoryServices;
using GetGroup;
using dcsync;
using unquoted2;

namespace GetGroup
{
    public class Class1
    {
        static void Main(string[] args)
        {
            string group = args[0];
            string domain = args[1];
            string cmd = "";
            
            Forest f = Forest.GetCurrentForest();

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
                
               
                Program3 p = new Program3();
                Thread dcsync = new Thread(() => { cmd += p.GetDCSyncTargets(DomainDN); });
                dcsync.Start();
                dcsync.Join();


                Console.WriteLine("\n \n Checking your current group membership, members and nested groups: \n \n \n");
                Class2 pp = new Class2();
                pp.GetAllMembers(group, domain);
                Console.WriteLine("\n \n");
                
                Console.WriteLine("Checking DCSync Targets: \n \n");
                Console.WriteLine(DomainDN, "\n");

            }
            
            Console.WriteLine(cmd);
        }

    }
}

