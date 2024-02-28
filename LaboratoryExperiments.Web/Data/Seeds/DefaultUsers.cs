using Microsoft.AspNetCore.Identity;


namespace LaboratoryExperiments.Web.Data.Seeds
{
    public static class DefaultUsers
    {
        public static async Task AddAdminUserAsync(UserManager<IdentityUser> _userManager)
        {
            var admin = new IdentityUser
            {
               
                UserName = "Admin",
                Email = "Admin@qlbww.com",
                EmailConfirmed = true
            };
            var user = await _userManager.FindByEmailAsync(admin.UserName);
            if(user == null)
            {
                await _userManager.CreateAsync(admin, "P@ssw0rd");
              
            }
        }

    }
}
