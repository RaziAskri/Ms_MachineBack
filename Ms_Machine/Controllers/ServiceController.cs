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

namespace Ms_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ServiceController : ControllerBase
    {
        private readonly PoulinaDbContext _context;

        private readonly IGenericRepository<Service> GenericRepository;
        private readonly IMapper mapper;

        private readonly IMediator mediator;
        public ServiceController(PoulinaDbContext context, IGenericRepository<Service> repository
            ,IMapper mapper, IMediator mediator)
        {
            this.GenericRepository = repository;
            _context = context;
            this.mediator = mediator;
            this.mapper = mapper;
        }

        // GET: api/Projet
        [HttpGet("GetService")]
        public async Task<IEnumerable<Service>> GetService()
        {
            var query = new GetListGenericQuery<Service>(condition: null, includes: null);
            var Handler = new GetListGenericHandler<Service>(GenericRepository);
            return await Handler.Handle(query, new CancellationToken());
        }

        // GET: api/Actione/5
        [HttpGet("GetServiceById")]
        public async Task<Service> GetServiceById(Guid id) =>
            await (new GetByIdGenericHandler<Service>(GenericRepository)).Handle(new GetByIdGenericQuery<Service>(condition: x => x.id_service.Equals(id), null), new CancellationToken());

        [HttpGet("GetServiceDTO")]
        public async Task<IEnumerable<serviceDTO>> GetServiceDTO()
        {

            var listtype =
             mediator.Send(new GetListGenericQuery<Service>
                (null, includes: a => a
                .Include(service => service.Filiaire))
               ).Result.Select(v => mapper.Map<serviceDTO>(v)
              );

            return listtype;
        }






        // PUT: api/Actione/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("PutService")]
        public async Task<string> PutService([FromBody] Service projet) =>
            await (new PutGenericHandler<Service>(GenericRepository)).Handle(new PutGenericCommand<Service>(projet), new CancellationToken());

        // POST: api/Actione
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("PostService")]
        public async Task<string> PostService([FromBody] Service action) =>
            await (new PostGenericHandler<Service>(GenericRepository)).Handle(new PostGenericCommand<Service>(action), new CancellationToken());
        
        // DELETE: api/Actione/5
        [HttpDelete("RemoveService")]
        public async Task<string> DeleteService(Guid id) =>
            await (new RemoveGenericHandler<Service>(GenericRepository)).Handle(new RemoveGenericCommand<Service>(id), new CancellationToken());
    }
}
