using DataAccess;
using DataAccess.Query;
using InschrijvenPietieterken.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace InschrijvingPietieterken.Business
{
    public class LoginManager : ILoginManager
    {
        private readonly IUowProvider _uowProvider;

        public LoginManager(IUowProvider uowProvider)
        {
            _uowProvider = uowProvider ?? throw new ArgumentNullException(nameof(uowProvider));
        }

        public async Task<bool> Login(string paswoord)
        {
            var user = "Admin";
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repo = uow.GetRepository<Auth>();

                var filter = new WhereFilter<Auth>(x => x.User == user);

                var result = (await repo.QueryAsync(filter.Expression)).FirstOrDefault();

                return PasswordMatchesAndIsNotNull(paswoord, result);
            }
        }

        private bool PasswordMatchesAndIsNotNull(string paswoord, Auth result)
        {
            return (result?.Password == paswoord);
        }

        public async Task ResetPasswoord(string paswoord)
        {
            var user = "Admin";
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repo = uow.GetRepository<Auth>();

                var filter = new WhereFilter<Auth>(x => x.User == user);

                var result = (await repo.QueryAsync(filter.Expression)).FirstOrDefault();
                if (result == null)
                {
                    repo.Add(new Auth() { User = user, Password = paswoord });
                    await uow.SaveChangesAsync();
                }
                else
                {
                    result.Password = paswoord;
                    repo.Update(result);
                    await uow.SaveChangesAsync();
                }
            }
        }
    }
}
