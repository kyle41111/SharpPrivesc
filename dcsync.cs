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


namespace dcsync
{
    public class Program3
    {


        public string GetDCSyncTargets(string DomainDN)
        {
            string results;
            StringWriter sq = new StringWriter();
            Hashtable ht = new Hashtable();
            ht.Add("DS-Replication-Get-Changes", "1131f6aa-9c07-11d1-f79f-00c04fc2dcd2");
            ht.Add("DS-Replication-Get-Changes-All", "1131f6ad-9c07-11d1-f79f-00c04fc2dcd2");
            ht.Add("DS-Replication-Get-Changes-In-Filtered-Set", "89e95b76-444d-4c62-991a-0facbeda640c");
            ht.Add("DS-Replication-Manage-Topology", "1131f6ac-9c07-11d1-f79f-00c04fc2dcd2");
            ht.Add("DS-Replication-Monitor-Topology", "f98340fb-7c5b-4cdb-a00b-2ebdfa115a96");
            ht.Add("DS-Replication-Synchronize", "1131f6ab-9c07-11d1-f79f-00c04fc2dcd2");

            DirectoryEntry de = new DirectoryEntry("LDAP://" + DomainDN);
            DirectorySearcher searcher = new DirectorySearcher();
            searcher.SearchRoot = de;
            try
            {
                foreach (SearchResult sr in searcher.FindAll())
                {

                    DirectoryEntry temp = sr.GetDirectoryEntry();
                    ActiveDirectorySecurity ads = temp.ObjectSecurity;

                    AuthorizationRuleCollection arc = ads.GetAccessRules(true, true, typeof(NTAccount));


                    if (DomainDN.Contains(temp.Name))
                    {


                        foreach (ActiveDirectoryAccessRule a in arc)
                        {
                            foreach (DictionaryEntry d in ht)
                            {
                                if (d.Value.ToString() == a.ObjectType.ToString())
                                {
                                    sq.WriteLine(a.IdentityReference);
                                    //sq.WriteLine(a.ObjectType);
                                    sq.WriteLine(d.Key.ToString());
                                    sq.WriteLine();
                                }
                            }
                        }



                    }
                }


            }
            catch { }
            results = sq.ToString();
            return results;
        }
    }
}
