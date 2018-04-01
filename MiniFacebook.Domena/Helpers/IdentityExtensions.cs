using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MiniFacebook.Domena.Helpers
{
    public static class IdentityExtensions
    {
        public static string GetFirstName(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }

            var ci = identity as ClaimsIdentity;
            if(ci != null)
            {
                return ci.FindFirstValue("FirstName");
            }
            return null;

        }

        public static string GetLastName(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }

            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                return ci.FindFirstValue("LastName");
            }
            return null;

        }

        //public static string GetUserPhoto(this IIdentity identity)
        //{
        //    if (identity == null)
        //    {
        //        throw new ArgumentNullException("identity");
        //    }

        //    var ci = identity as ClaimsIdentity;
        //    if (ci != null)
        //    {
        //        return ci.FindFirstValue("UserPhoto");
        //    }
        //    return null;

        //}
    }
}
