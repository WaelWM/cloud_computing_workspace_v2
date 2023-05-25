using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MVCFlowerShopWeek3.Areas.Identity.Data;

// Add profile data for application users by adding properties to the MVCFlowerShopWeek3User class
public class MVCFlowerShopWeek3User : IdentityUser

{
    [PersonalData]
    public string CustomerName { get; set; }

    [PersonalData]
    public string CustomerAddress { get; set; }

    [PersonalData]
    public int CustomerAge { get; set; }

    [PersonalData]
    public DateTime CustomerDOB { get; set; }
}

