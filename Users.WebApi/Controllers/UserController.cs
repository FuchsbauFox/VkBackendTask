using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Users.Application.Users.Commands.Create;
using Users.Application.Users.Commands.Delete;
using Users.Application.Users.Queries.GetAll;
using Users.Application.Users.Queries.GetBy;
using Users.WebApi.Dtos;

namespace Users.WebApi.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper) => _mapper = mapper;

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateUserDto createUserDto)
        {
            Console.WriteLine("Create");
            var command = _mapper.Map<CreateUserCommand>(createUserDto);
            var id = await Mediator.Send(command);
            return Ok(id);
        }

        [HttpGet]
        public async Task<ActionResult<UserListVm>> GetAll()
        {
            Console.WriteLine("GetAll");
            var query = new GetAllQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetailsVm>> Get(Guid id)
        {
            Console.WriteLine("Get");
            var query = new GetByIdQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id)
        {
            Console.WriteLine("Update");
            var command = new DeleteUserCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return Ok(id);
        }
    }
}