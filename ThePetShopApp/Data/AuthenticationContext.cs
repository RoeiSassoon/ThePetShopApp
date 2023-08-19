﻿namespace ThePetShopApp.Data
{
	public class AuthenticationContext: IdentityDbContext<IdentityUser>
	{

        public AuthenticationContext(DbContextOptions<AuthenticationContext> options) : base(options)
        {
        }
    }
}
