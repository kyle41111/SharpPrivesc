using System;
using System.DirectoryServices.AccountManagement;


namespace GetGroup
{
    public class Class2
    {


        public void GetAllMembers(string GroupName, string domainName)
        {


            PrincipalContext p = new PrincipalContext(ContextType.Domain, domainName);
            GroupPrincipal gp = GroupPrincipal.FindByIdentity(p, GroupName);
            foreach (Principal group in gp.GetMembers())
            {
                if (group.StructuralObjectClass == "user")
                {
                    Console.WriteLine("Users: {0}", group.Name);
                }
                if (group.StructuralObjectClass == "group")
                {
                    Console.WriteLine("Group {0} is memberOf {1}", group.Name, GroupName);
                }

            }
        }
    }
}
