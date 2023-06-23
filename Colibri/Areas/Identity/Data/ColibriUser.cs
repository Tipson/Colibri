using Microsoft.AspNetCore.Identity;

namespace Colibri.Areas.Identity.Data;

public class ColibriUser : IdentityUser
{
    public ColibriUser(string userName) : base(userName)
    {
        
    }
}
