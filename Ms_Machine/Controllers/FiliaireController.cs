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


namespace Ms_Filiaire.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class FiliaireController : ControllerBase
    {
        private readonly PoulinaDbContext _context;

        private readonly IGenericRepository<Filiaire> GenericRepository;

        public FiliaireController(PoulinaDbContext context, IGenericRepository<Filiaire> repository)
        {
            this.GenericRepository = repository;
            _context = context;
        }

        // GET: api/Projet
        [HttpGet("GetFiliaire")]
        public async Task<IEnumerable<Filiaire>> GetFiliaire()
        {
            var query = new GetListGenericQuery<Filiaire>(condition: null, includes: null);
            var Handler = new GetListGenericHandler<Filiaire>(GenericRepository);
            return await Handler.Handle(query, new CancellationToken());
        }

        // GET: api/Actione/5
        [HttpGet("GetFiliaireById")]
        public async Task<Filiaire> GetFiliaireById(Guid id) =>
            await (new GetByIdGenericHandler<Filiaire>(GenericRepository)).Handle(new GetByIdGenericQuery<Filiaire>(condition: x => x.id_filiaire.Equals(id), null), new CancellationToken());

        // PUT: api/Actione/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("PutFiliaire")]
        public async Task<string> PutFiliaire([FromBody] Filiaire projet) =>
            await (new PutGenericHandler<Filiaire>(GenericRepository)).Handle(new PutGenericCommand<Filiaire>(projet), new CancellationToken());

        // POST: api/Actione
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("PostFiliaire")]
        public async Task<string> PostFiliaire([FromBody] Filiaire action) =>
            await (new PostGenericHandler<Filiaire>(GenericRepository)).Handle(new PostGenericCommand<Filiaire>(action), new CancellationToken());
       
        // DELETE: api/Actione/5
        [HttpDelete("RemoveFiliaire")]
        public async Task<string> DeleteFiliaire(Guid id) =>
            await (new RemoveGenericHandler<Filiaire>(GenericRepository)).Handle(new RemoveGenericCommand<Filiaire>(id), new CancellationToken());
    }
}