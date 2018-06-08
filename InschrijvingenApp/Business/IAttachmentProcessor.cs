using InschrijvingPietieterken.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InschrijvingPietieterken.Business
{
    public interface IAttachmentProcessor
    {

        byte[] GetExcel(List<ChildPrintModel> inschrijvingen, string key);
    }
}
