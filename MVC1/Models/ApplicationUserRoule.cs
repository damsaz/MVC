// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace MVC1.Models
{
    public class ApplicationUserRoule
    {
        public string UserId { get; set; }

        public string RoleId { get; set; }

     
        }
    public class ApplicationUserRouleVM
        {

        public IList<ApplicationUserRoule> ApplicationUserRoules;
        }
    }