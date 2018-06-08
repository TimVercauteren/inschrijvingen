using InschrijvingPietieterken.Controllers;
using System.Threading.Tasks;

namespace InschrijvingPietieterken.Business
{
    public interface IInschrijvingsProcessor
    {
        Task<bool> CreateInschrijving(InschrijvingModel model);
    }
}