using System;
using CasaDoCodigo.Areas.Identity.Data;
using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CasaDoCodigo.Areas.Identity.IdentityHostingStartup))]
namespace CasaDoCodigo.Areas.Identity
{
    //PRECISAMOS TRADUZIR AS MENSAGENS DE ERRO DE SENHAS:

    //ORIGINAL:
    //=========
    //Passwords must have at least one non alphanumeric character.
    //Passwords must have at least one lowercase('a' - 'z').
    //Passwords must have at least one uppercase('A' - 'Z').

    //PT-BR:
    //=========
    //A senha deve ter pelo menos um caractere alfanumérico.
    //A senha deve ter pelo menos uma letra minúscula('a' - 'z').
    //A senha deve ter pelo menos uma letra minúscula('a' - 'z').
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<AppIdentityContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("AppIdentityContextConnection")));

                services.AddDefaultIdentity<AppIdentityUser>(options =>
                    {
                        options.Password.RequireNonAlphanumeric = 
                        options.Password.RequireLowercase = 
                        options.Password.RequireUppercase = false;
                    })
                    .AddErrorDescriber<IdentityErrorDescriberPtBr>()
                    .AddEntityFrameworkStores<AppIdentityContext>();
            });
        }
    }

    internal class IdentityErrorDescriberPtBr : IdentityErrorDescriber
    {
        public override IdentityError ConcurrencyFailure()
        {
            return base.ConcurrencyFailure();
        }

        public override IdentityError DefaultError()
        {
            return base.DefaultError();
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return base.DuplicateEmail(email);
        }

        public override IdentityError DuplicateRoleName(string role)
        {
            return base.DuplicateRoleName(role);
        }

        public override IdentityError DuplicateUserName(string userName)
        {
            return base.DuplicateUserName(userName);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override IdentityError InvalidEmail(string email)
        {
            return base.InvalidEmail(email);
        }

        public override IdentityError InvalidRoleName(string role)
        {
            return base.InvalidRoleName(role);
        }

        public override IdentityError InvalidToken()
        {
            return base.InvalidToken();
        }

        public override IdentityError InvalidUserName(string userName)
        {
            return base.InvalidUserName(userName);
        }

        public override IdentityError LoginAlreadyAssociated()
        {
            return base.LoginAlreadyAssociated();
        }

        public override IdentityError PasswordMismatch()
        {
            return base.PasswordMismatch();
        }

        public override IdentityError PasswordRequiresDigit()
        {
            return base.PasswordRequiresDigit();
        }

        public override IdentityError PasswordRequiresLower()
        {
            //A senha deve ter pelo menos uma letra minúscula('a' - 'z').
            return new IdentityError
            {
                Code = nameof(PasswordRequiresLower),
                Description = "A senha deve ter pelo menos uma letra minúscula('a' - 'z')."
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresNonAlphanumeric),
                Description = "A senha deve ter pelo menos um caractere alfanumérico."
            };
        }

        public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
        {
            return base.PasswordRequiresUniqueChars(uniqueChars);
        }

        public override IdentityError PasswordRequiresUpper()
        {
            //A senha deve ter pelo menos uma letra minúscula('a' - 'z').
            return new IdentityError
            {
                Code = nameof(PasswordRequiresUpper),
                Description = "A senha deve ter pelo menos uma letra maiúscula('A' - 'Z')."
            };
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return base.PasswordTooShort(length);
        }

        public override IdentityError RecoveryCodeRedemptionFailed()
        {
            return base.RecoveryCodeRedemptionFailed();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override IdentityError UserAlreadyHasPassword()
        {
            return base.UserAlreadyHasPassword();
        }

        public override IdentityError UserAlreadyInRole(string role)
        {
            return base.UserAlreadyInRole(role);
        }

        public override IdentityError UserLockoutNotEnabled()
        {
            return base.UserLockoutNotEnabled();
        }

        public override IdentityError UserNotInRole(string role)
        {
            return base.UserNotInRole(role);
        }
    }
}