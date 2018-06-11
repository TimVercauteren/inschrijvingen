using AutoMapper;
using InschrijvingPietieterken.Controllers;
using InschrijvingPietieterken.DataAccess;
using InschrijvingPietieterken.Entities;
using InschrijvingPietieterken.Models;
using InschrijvingPietieterken.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InschrijvingPietieterken.Business
{
    public class DataProcessor : IDataProcessor
    {
        private readonly EntityContext _context;

        public DataProcessor(EntityContext entityContext)
        {
            _context = entityContext ?? throw new ArgumentNullException(nameof(entityContext));
        }

        public async Task<List<ChildPrintModel>> GetChildList(string key)
        {
            var kleuters = await GetListOfGroep(key);

            var excelListModel = kleuters.Select(k => Mapper.Map<ChildPrintModel>(k)).ToList();

            return excelListModel;
        }


        private async Task<List<Inschrijving>> GetListOfGroep(string key)
        {
            var geboorteJaren = LeeftijdenGroepen.GetGeboorteJarenGroepen(key);

            var groepsLijst = _context.Inschrijvingen
                .Where(i => i.Kind.GeboorteDatum >= geboorteJaren.Item1 && i.Kind.GeboorteDatum <= geboorteJaren.Item2)
                .Include(i => i.Kind)
                .Include(i => i.Kind).ThenInclude(k => k.Persoon)
                .Include(i => i.Ouders)
                .Include(i => i.Ouders).ThenInclude(o => o.Adres)
                .OrderBy(i => i.Kind.Persoon.Naam);

            return await groepsLijst.ToListAsync();

        }


        public async Task<List<SearchKindModel>> Search(string zoekTekst, string param)
        {
            if (param == "voornaam")
            {
                var lijst = await _context.Inschrijvingen.Where(x => x.Kind.Persoon.Voornaam == zoekTekst)
                                .Include(x => x.Kind)
                                .Include(x => x.Kind).ThenInclude(k => k.Persoon)
                                .Select(x => Mapper.Map<SearchKindModel>(x))
                                .ToListAsync();
                return lijst;
            }
            else
            {
                var lijst =  await _context.Inschrijvingen.Where(x => x.Kind.Persoon.Naam == zoekTekst)
                                .Include(x => x.Kind)
                                .Include(x => x.Kind).ThenInclude(k => k.Persoon)
                                .Select(x => Mapper.Map<SearchKindModel>(x))
                                .ToListAsync();
                return lijst;
            }
        }

        public async Task<InschrijvingModel> GetChild(int id)
        {

            var result = await _context.Inschrijvingen.Where(c => c.Id == id)
                .Include(x => x.Kind)
                .Include(x => x.Kind).ThenInclude(k => k.Persoon)
                .Include(x => x.Ouders)
                .Include(x => x.Ouders).ThenInclude(o => o.Adres)
                .Include(x => x.Ouders).ThenInclude(o => o.Ouder1)
                .Include(x => x.Ouders).ThenInclude(o => o.Ouder2)
                .Include(x => x.Medisch).FirstOrDefaultAsync();

            if (result != null)
            {
                return Mapper.Map<InschrijvingModel>(result);
            }
            throw new NotFoundException($"Kind met id {id} niet gevonden");
        }
    }
}
