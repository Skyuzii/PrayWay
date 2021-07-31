using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrayWay.Application.Common.Dto;
using PrayWay.Application.Place.Commands.CreatePlace;
using PrayWay.Application.Place.Commands.UpdatePlace;
using PrayWay.Application.Place.Queries.GetPlace;
using PrayWay.Application.Place.Queries.GetPlaceList;

namespace PrayWay.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlaceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<QueryResultDto<PlaceListDto>> Get([FromQuery] GetPlaceListQuery request)
        {
            return await _mediator.Send(request);
        }
        
        [HttpGet("{id}")]
        public async Task<PlaceDto> Get([FromQuery] int id)
        {
            return await _mediator.Send(new GetPlaceQuery {Id = id});
        }
        

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromForm] CreatePlaceCommand command)
        {
            var placeId = await _mediator.Send(command);
            HttpContext.Response.StatusCode = StatusCodes.Status201Created;
            return placeId;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdatePlaceCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}