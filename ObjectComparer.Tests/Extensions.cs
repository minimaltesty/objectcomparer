using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ObjectComparer.Tests
{
    public static class Extensions
    {

        public static List<MemberInfo> GetMemberInfo(this object o, string name)
        {
            return o.GetType().GetMember(name ).ToList();
        }

        public static List<MemberInfo> GetMemberInfo(this object o, string name, BindingFlags bindingFlags)
        {
            return o.GetType().GetMember(name, bindingFlags).ToList();
        }

    }
}
