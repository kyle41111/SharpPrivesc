using System;
using Microsoft.Win32;
using System.ServiceProcess;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;


namespace Privesc.Commands
{
    public class unquoted2
    {


        public void Unquoted2()
        {


            ServiceController[] scs = ServiceController.GetServices();
            foreach (ServiceController s in scs)
            {

                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\" + s.ServiceName);
                string path = key.GetValue("ImagePath").ToString();




                if (path[0] != '"' && !path.Contains("System32") && !path.Contains("system32"))
                {

                    Console.WriteLine(s.ServiceName);
                    Console.WriteLine(path);
                }
            }

            //Console.ReadKey();



        }
    }

}
