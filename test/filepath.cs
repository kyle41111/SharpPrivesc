using System;
using Microsoft.Win32;
using System.ServiceProcess;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;


namespace unquoted2
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




                if (path[0] != '"' && !path.Contains("System32") && !path.Contains("system32") && !path.Contains("svchost.exe"))
                {

                    Console.WriteLine(s.ServiceName);
                    Console.WriteLine(key.GetValue("ImagePath"));
                }
            }

            //Console.ReadKey();



        }
    }

}
