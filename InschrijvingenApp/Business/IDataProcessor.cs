using System.Collections.Generic;
using System.Threading.Tasks;
using InschrijvingPietieterken.Controllers;
using InschrijvingPietieterken.Models;

namespace InschrijvingPietieterken.Business
{
    public interface IDataProcessor
    {
        Task<List<ChildPrintModel>> GetChildList(string key);
        Task<List<SearchKindModel>> Search(string zoekTekst, string param);
        Task<InschrijvingModel> GetChild(int id);
    }
}