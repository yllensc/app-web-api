using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiVersion("1.2")]
    public class PaisController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper _mapper;

    public PaisController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PaisDto>>> Get()
    {
        var paises = await this.unitOfWork.Paises.GetAllAsync();
        return this._mapper.Map<List<PaisDto>>(paises);
    }

    
    [HttpGet("{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PaisDto>> Get(int id)
    {
        var pais = await this.unitOfWork.Paises.GetByIdAsync(id);
        if(pais == null){
            return NotFound();
        }
        return this._mapper.Map<PaisDto>(pais);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PaisAllDataDto>>> GetAll()
    {
        var paises = await this.unitOfWork.Paises.GetAllAsync();
        return this._mapper.Map<List<PaisAllDataDto>>(paises);
    }

    [HttpGet]
    [MapToApiVersion("1.2")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PaisAllDataDto>>> Get12([FromQuery] Params paisParams)
    {
        var pais = await unitOfWork.Paises.GetAllAsync(paisParams.PageIndex,paisParams.PageSize,paisParams.Search);
        var lstPaisesDto = _mapper.Map<List<PaisAllDataDto>>(pais.registros);
        return new Pager<PaisAllDataDto>(lstPaisesDto,pais.totalRegistros,paisParams.PageIndex,paisParams.PageSize,paisParams.Search);
    }


    
    [HttpGet("{id}")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PaisAllDataDto>> GetAll(int id)
    {
        var pais = await this.unitOfWork.Paises.GetByIdAsync(id);
        if(pais == null){
            return NotFound();
        }
        return this._mapper.Map<PaisAllDataDto>(pais);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pais>> Post(PaisDto paisDto)
    {
        var pais = this._mapper.Map<Pais>(paisDto);
        this.unitOfWork.Paises.Add(pais);
        await this.unitOfWork.SaveAsync();
        if(pais == null){
            return BadRequest();
        }
        paisDto.PaisId = pais.Id;
        return CreatedAtAction(nameof(Post), new { id = paisDto.PaisId }, paisDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PaisDto>> Put(int id, [FromBody]PaisDto paisDto)
    {
        if(paisDto == null){
            return NotFound();
        }
        var pais = this._mapper.Map<Pais>(paisDto);
        this.unitOfWork.Paises.Update(pais);
        await this.unitOfWork.SaveAsync();
        return paisDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var pais = await this.unitOfWork.Paises.GetByIdAsync(id);
        if(pais == null){
            return NotFound();
        }
        this.unitOfWork.Paises.Remove(pais);
        await this.unitOfWork.SaveAsync();
        return NoContent();
    }
}