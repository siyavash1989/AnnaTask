using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Seed
{
    public static class IdentityContextSeed
    {
         public static async Task SeedUserAsync(UserManager<AppUser> userManager){
            if(!userManager.Users.Any()){
                var user = new AppUser{
                    DisplayName = "Bob",
                    Email = "Bob@bob.com",
                    UserName = "Bob@bob.com",
                    Address = new Address{
                        City = "Tehran",
                        FirstName ="Bob",
                        LastName = "Bobity",
                        Street = "First Street"
                    }
                };

                var request = await userManager.CreateAsync(user,"P@ssw0rd");    
            }
        }
    }
}