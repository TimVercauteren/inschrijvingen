using AutoMapper;
using InschrijvingPietieterken.Controllers;
using InschrijvingPietieterken.DataAccess;
using InschrijvingPietieterken.Entities;
using System;
using System.Threading.Tasks;

namespace InschrijvingPietieterken.Business
{
    public class InschrijvingsProcessor : IInschrijvingsProcessor
    {
        private readonly EntityContext _context;

        public InschrijvingsProcessor(EntityContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public async Task<bool> CreateInschrijving(InschrijvingModel model)
        {
            var map = Mapper.Map<Inschrijving>(model);
            if (map != null)
            {
                try
                {
                    await _context.Inschrijvingen.AddAsync(map);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return false;
        }
    }
}
