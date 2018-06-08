using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InschrijvingPietieterken.Business
{
    public interface ILoginManager
    {
        Task ResetPasswoord(string paswoord);
        Task<bool> Login(string paswoord);
    }
}
