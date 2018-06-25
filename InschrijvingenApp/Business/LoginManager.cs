using InschrijvenPietieterken.Entities;
using InschrijvingPietieterken.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InschrijvingPietieterken.Business
{
    public class LoginManager : ILoginManager
    {
        private readonly EntityContext _context;

        public LoginManager(EntityContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> Login(string paswoord)
        {
            if (string.IsNullOrEmpty(paswoord)) return false;
            var user = "Admin";

            var admin = await _context.Authentication.Where(x => x.User == user).FirstOrDefaultAsync();
            return PasswordMatchesAndIsNotNull(paswoord, admin);
        }

        private bool PasswordMatchesAndIsNotNull(string paswoord, Auth result)
        {
            return (result?.Password == paswoord);
        }

        public async Task ResetPasswoord(string paswoord)
        {
            var user = "Admin";

            var result = await _context.Authentication.Where(x => x.User == user).FirstOrDefaultAsync();

            if (result == null)
            {
                await _context.AddAsync(new Auth() { User = user, Password = paswoord });
                await _context.SaveChangesAsync();
            }
            else
            {
                result.Password = paswoord;
                _context.Update(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}
