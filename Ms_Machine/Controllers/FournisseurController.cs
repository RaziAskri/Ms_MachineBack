using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ms_Machine.Domain.Poulina.MSmachine.Domain.IRepository;
using Ms_Machine.Domain.Poulina.MSmachine.Domain.Queries;
using Ms_Machine.Domain.Poulina.MSmachine.Domain.Handler;
using Ms_Machine.Domain.Poulina.MSmachine.Domain.Command;
using Ms_Machine.Domain.Poulina.MSmachine.Domain.Models;
using Ms_Machine.Domain.Poulina.MSmachine.Domain.Data;


namespace Ms_Fournisseur.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class FournisseurController : ControllerBase
    {
        private readonly PoulinaDbContext _context;

        private readonly IGenericRepository<Fournisseur> GenericRepository;

        public FournisseurController(PoulinaDbContext context, IGenericRepository<Fournisseur> repository)
        {
            this.GenericRepository = repository;
            _context = context;
        }

        // GET: api/Projet
        [HttpGet("GetFournisseur")]
        public async Task<IEnumerable<Fournisseur>> GetFournisseur()
        {
            var query = new GetListGenericQuery<Fournisseur>(condition: null, includes: null);
            var Handler = new GetListGenericHandler<Fournisseur>(GenericRepository);
            return await Handler.Handle(query, new CancellationToken());
        }

        // GET: api/Actione/5
        [HttpGet("GetFournisseurById")]
        public async Task<Fournisseur> GetFournisseurById(Guid id) =>
            await (new GetByIdGenericHandler<Fournisseur>(GenericRepository)).Handle(new GetByIdGenericQuery<Fournisseur>(condition: x => x.id_fournisseur.Equals(id), null), new CancellationToken());

        // PUT: api/Actione/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("PutFournisseur")]
        public async Task<string> PutFournisseur([FromBody] Fournisseur projet) =>
            await (new PutGenericHandler<Fournisseur>(GenericRepository)).Handle(new PutGenericCommand<Fournisseur>(projet), new CancellationToken());

        // POST: api/Actione
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("PostFournisseur")]
        public async Task<string> PostFournisseur([FromBody] Fournisseur action) =>
            await (new PostGenericHandler<Fournisseur>(GenericRepository)).Handle(new PostGenericCommand<Fournisseur>(action), new CancellationToken());
       

        // DELETE: api/Actione/5
        [HttpDelete("RemoveFournisseur")]
        public async Task<string> DeleteFournisseur(Guid id) =>
            await (new RemoveGenericHandler<Fournisseur>(GenericRepository)).Handle(new RemoveGenericCommand<Fournisseur>(id), new CancellationToken());
    }
}