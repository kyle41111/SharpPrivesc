using System;

namespace Privesc2.Check
{
    public static class Info
    {
        public static void ShowLogo()
        {
            Console.WriteLine("\r\n Test Banner Here \n");
            
        }

        public static void ShowUsage()
        {
            string usage = @"Check for nested groups, and your group members:
allinone.exe nested <group> <domain>

Check for unquoted service paths: 
allinone.exe unquoted ";

            Console.WriteLine(usage);
        }
    }
}
