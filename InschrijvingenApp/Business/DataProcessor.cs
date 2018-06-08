using AutoMapper;
using DataAccess;
using DataAccess.Query;
using InschrijvingPietieterken.Controllers;
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
        private readonly IUowProvider _uowProvider;

        public DataProcessor(IUowProvider uowProvider)
        {
            _uowProvider = uowProvider ?? throw new ArgumentNullException(nameof(uowProvider));
        }

        public async Task<List<ChildPrintModel>> GetChildList(string key)
        {
            var kleuters = await GetListOfGroep(key);

            var excelListModel = kleuters.Select(k => Mapper.Map<ChildPrintModel>(k)).ToList();

            return excelListModel;
        }
       

        private async Task<List<Inschrijving>> GetListOfGroep(string key)
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repo = uow.GetRepository<Inschrijving>();
                var includes = GetIncludesForInschrijving();
                var query = GetWhereQueryForInschrijving(key);

                return (await repo.QueryAsync(query.Expression, includes: includes.Expression)).ToList(); ;
            }
        }

        private WhereFilter<Inschrijving> GetWhereQueryForInschrijving(string key)
        {
            var geboorteJaren = LeeftijdenGroepen.GetGeboorteJarenGroepen(key);

            var result = new WhereFilter<Inschrijving>(null);
            result.AddExpression(i => i.Kind.GeboorteDatum >= geboorteJaren.Item1 && i.Kind.GeboorteDatum <= geboorteJaren.Item2);

            return result;
        }

        private Includes<Inschrijving> GetIncludesForInschrijving()
        {
            var includes = new Includes<Inschrijving>(query =>
            {
                query = query.Include(i => i.Kind);
                query = query.Include(i => i.Kind).ThenInclude(k => k.Persoon);
                query = query.Include(i => i.Ouders);
                query = query.Include(i => i.Ouders).ThenInclude(o => o.Adres);

                return query;
            });
            return includes;
        }

        public async Task<List<SearchKindModel>> SearchByName(string voornaam)
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repo = uow.GetRepository<Inschrijving>();

                var includes = new Includes<Inschrijving>(query =>
                {
                    query = query.Include(x => x.Kind);
                    query = query.Include(x => x.Kind).ThenInclude(k => k.Persoon);
                    return query;
                    
                });
                var filter = new WhereFilter<Inschrijving>(x => x.Kind.Persoon.Voornaam.ToLower().Contains(voornaam.ToLower()));

                return (await repo.QueryAsync(filter.Expression, includes: includes.Expression)).Select(x => Mapper.Map<SearchKindModel>(x)).ToList();
            }
        }

        public async Task<InschrijvingModel> GetChild(int id)
        {
            using (var uow = _uowProvider.CreateUnitOfWork())
            {
                var repo = uow.GetRepository<Inschrijving>();
                var includes = IncludesForDetail;
                var filter = new WhereFilter<Inschrijving>(q => q.Id == id);

                var result =  (await repo.QueryAsync(filter.Expression, includes: includes.Expression)).FirstOrDefault();

                return Mapper.Map<InschrijvingModel>(result);
            }
        }

        private Includes<Inschrijving> IncludesForDetail { get {
                return new Includes<Inschrijving>(query =>
                {
                    query = query.Include(x => x.Kind);
                    query = query.Include(x => x.Kind).ThenInclude(k => k.Persoon);
                    query = query.Include(x => x.Ouders);
                    query = query.Include(x => x.Ouders).ThenInclude(o => o.Adres);
                    query = query.Include(x => x.Ouders).ThenInclude(o => o.Ouder1);
                    query = query.Include(x => x.Ouders).ThenInclude(o => o.Ouder2);
                    query = query.Include(x => x.Medisch);

                    return query;
                });
            }
        }
    }
}
