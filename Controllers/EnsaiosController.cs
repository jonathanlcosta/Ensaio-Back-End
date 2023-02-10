using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EnsaioBack.DataTransfer;
using EnsaioBack.Entidades;
using Microsoft.AspNetCore.Mvc;
using NHibernate;
using ISession = NHibernate.ISession;

namespace EnsaioBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnsaiosController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ISession session;
        public EnsaiosController(IMapper mapper, ISession session)
        {
            this.mapper = mapper;
            this.session = session;
        }

        [HttpGet]
        public IList<Ensaio> ListarEnsaios()
        {
            IQueryable<Ensaio> query = session.Query<Ensaio>();
            IList<Ensaio> ensaios = query.ToList();
            return ensaios;
        }
        [HttpPost]
        public void InserirEnsaios(EnsaioInserirRequest ensaioRequest)
        {
            Ensaio ensaio = mapper.Map<Ensaio>(ensaioRequest);
            ITransaction transaction = session.BeginTransaction();
            try{
                session.Save(ensaio);
                transaction.Commit();
            }
            catch {
                transaction.Rollback();
            }
            
         }
        [HttpPut("{id}")]
        public void EditarEnsaio(int id, [FromBody]EnsaioInserirRequest ensaioRequest){
            Ensaio ensaio = session.Get<Ensaio>(id);
            ITransaction transaction = session.BeginTransaction();
            try{
                ensaio.Lider = ensaioRequest.Lider;
                ensaio.Cancoes = ensaioRequest.Cancoes;
                ensaio.Integrantes = ensaioRequest.Integrantes;
                ensaio.Data = ensaioRequest.Data;
                ensaio.Horario = ensaioRequest.Horario;
                session.Update(ensaio);
                transaction.Commit();
            } 
            catch
            {
                transaction.Rollback();
            }
           
        }
        [HttpDelete("{id}")]
        public void ExcluirEnsaio(int id)
        {
           Ensaio ensaio = session.Get<Ensaio>(id);
           ITransaction transaction = session.BeginTransaction();
           try
           {
            session.Delete(ensaio);
            transaction.Commit();
           }
           catch
           {
            transaction.Rollback();
           }
        }
        [HttpGet("{id}")]
        public Ensaio RecuperarPorId(int id)
        {
            Ensaio ensaio = session.Get<Ensaio>(id);
            return ensaio;        }
    }
}