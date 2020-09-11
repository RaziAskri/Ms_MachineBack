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
using Ms_Machine.Domain.Poulina.MSmachine.Domain.Models.DTO;

using Poulina.ProjectManagmentMS.Data.Repository;
using Microsoft.Win32;
using Poulina.MSmachine.Domain.DTO;
using System.Security.Cryptography.X509Certificates;

namespace Ms_Fournisseur.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class FournisseurController : ControllerBase
    {
        private readonly PoulinaDbContext _context;

        private readonly IGenericRepository<Fournisseur> GenericRepository;
        private readonly IGenericRepository<Machine> MachineRepository;
        public FournisseurController(PoulinaDbContext context, IGenericRepository<Fournisseur> repository, IGenericRepository<Machine> machinerepository)
        {
            this.MachineRepository = machinerepository;
            this.GenericRepository = repository;
            _context = context;
           // this.mediator = Mediator;

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

        [HttpGet("GetNombreFournisseurparMachine")]
        public IEnumerable<NbrMachineDTO> GetNombreFournisseurparMachine()
        {
            var query = new GetListGenericQuery<Fournisseur>(condition: null, includes: null);
            var Handler = new GetListGenericHandler<Fournisseur>(GenericRepository);
            var fournisseurs = Handler.Handle(query, new CancellationToken()).Result.ToList();
            var query2 = new GetListGenericQuery<Machine>(condition: null, includes: null);
            var Handler2 = new GetListGenericHandler<Machine>(MachineRepository);
            var machines = Handler2.Handle(query2, new CancellationToken()).Result.ToList();
            var list = new List<NbrMachineDTO>();
            foreach(var fournisseur in fournisseurs)
            {
                var nbrmachine = new NbrMachineDTO();
                nbrmachine.nbrMachine = machines.Count(x =>x.id_fournisseur == fournisseur.id_fournisseur);
                nbrmachine.label = fournisseur.label;
                nbrmachine.id_fournisseur = fournisseur.id_fournisseur;
                list.Add(nbrmachine);
            }
            return list;
        }

    }
}