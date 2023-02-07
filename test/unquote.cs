using System;
using System.Collections.Generic;
using Microsoft.Win32;
using System.ServiceProcess;




namespace Privesc.Commands
{
    public class unquoted : ICommand
    {
        public static string CommandName => "unquoted";
       

public void Execute(Dictionary<string, string> arguments)
        {

            Console.WriteLine("Potential Unquoted Service Path: \n");

            ServiceController[] scs = ServiceController.GetServices();


            foreach (ServiceController s in scs)
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\" + s.ServiceName);

                string path = key.GetValue("ImagePath").ToString();


                if (path[0] != '"' && !path.Contains("System32") && !path.Contains("system32"))
                Console.WriteLine(s.ServiceName);
                Console.WriteLine(path);
            }
            //Console.ReadKey();

        }

    }
}
