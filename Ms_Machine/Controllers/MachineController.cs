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
using Microsoft.EntityFrameworkCore;

namespace Ms_Machine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
        public class MachineController : ControllerBase
        {
            private readonly PoulinaDbContext _context;
            private readonly IMapper mapper;
        
        private readonly IMediator mediator;

        private readonly IGenericRepository<Machine> GenericRepository;

            public MachineController(PoulinaDbContext context, IGenericRepository<Machine> repository, IMapper mapper, IMediator mediator)
            {
                this.GenericRepository = repository;
            _context = context;
            this.mediator = mediator;
            this.mapper = mapper;
        }

            // GET: api/Projet
            [HttpGet("GetMachine")]
            public async Task<IEnumerable<Machine>> GetMachine()
            {
                var query = new GetListGenericQuery<Machine>(condition: null, includes: null);
                var Handler = new GetListGenericHandler<Machine>(GenericRepository);
                return await Handler.Handle(query, new CancellationToken());
            }

        [HttpGet("GetMachineEnPanne")]
        public async Task<IEnumerable<Machine>> GetMachineEnPanne()
        {
            var query = new GetListGenericQuery<Machine>((x => x.etat_machine.Equals("en panne")), null);
            var Handler = new GetListGenericHandler<Machine>(GenericRepository);
            return await Handler.Handle(query, new CancellationToken());
        }

        [HttpGet("GetMachineFonctionne")]
        public async Task<IEnumerable<Machine>> GetMachineFonctionne()
        {
            var query = new GetListGenericQuery<Machine>((x => !(x.etat_machine.Equals("en panne"))), null);
            var Handler = new GetListGenericHandler<Machine>(GenericRepository);
            return await Handler.Handle(query, new CancellationToken());
        }

        // GET: api/Actione/5
        [HttpGet("GetMachineById")]
            public async Task<Machine> GetMachineById(Guid id) =>
                await (new GetByIdGenericHandler<Machine>(GenericRepository)).Handle(new GetByIdGenericQuery<Machine>(condition: x => x.id_machine.Equals(id), null), new CancellationToken());

        [HttpGet("GetMachineDTO")]
        public async Task<IEnumerable<MachineDTO>> GetMachineDTO()
        {

                var listtype =
                 mediator.Send(new GetListGenericQuery<Machine>
                    (null, includes: a => a
                    .Include(machine => machine.Fournisseur))
                   ).Result.Select(v => mapper.Map<MachineDTO>(v)
                  );

                return listtype;
        }


            // PUT: api/Actione/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("PutMachine")]
            public async Task<string> PutMachine([FromBody] Machine projet) =>
                await (new PutGenericHandler<Machine>(GenericRepository)).Handle(new PutGenericCommand<Machine>(projet), new CancellationToken());

            // POST: api/Actione
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for
            // more details see https://aka.ms/RazorPagesCRUD.
            [HttpPost("PostMachine")]
            public async Task<string> PostMachine([FromBody] Machine action) =>
                await (new PostGenericHandler<Machine>(GenericRepository)).Handle(new PostGenericCommand<Machine>(action), new CancellationToken());
            
            // DELETE: api/Actione/5
            [HttpDelete("RemoveMachine")]
            public async Task<string> DeleteMachine(Guid id) =>
                await (new RemoveGenericHandler<Machine>(GenericRepository)).Handle(new RemoveGenericCommand<Machine>(id), new CancellationToken());
        }
    }