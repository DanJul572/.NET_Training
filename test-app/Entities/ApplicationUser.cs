using Microsoft.AspNetCore.Identity;

namespace test_app.Entities;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; } = string.Empty;
}