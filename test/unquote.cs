using System;
using System.Collections.Generic;
using Microsoft.Win32;
using System.ServiceProcess;
using System;
using Microsoft.Win32;
using System.ServiceProcess;
using System.ServiceProcess;
using System.Diagnostics;
using System.Threading;



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
                        RegistryKey rkey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\" + s.ServiceName);

                        string path = rkey.GetValue("ImagePath").ToString();



                        if (path[0] != '"' && !path.Contains("system32") && !path.Contains("System32"))
                        {
                            Console.WriteLine(s.ServiceName);
                            Console.WriteLine(path);

                        }
                    }
                    

                }

            }

        }
    

