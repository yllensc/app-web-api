using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
    public class EstadoController: BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper _mapper;

    public EstadoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EstadoDto>>> Get()
    {
        var Estados = await this.unitOfWork.Estados.GetAllAsync();
        return this._mapper.Map<List<EstadoDto>>(Estados);
    }

    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EstadoDto>> Get(int id)
    {
        var estado = await this.unitOfWork.Estados.GetByIdAsync(id);
        if(estado == null){
            return NotFound();
        }
        return this._mapper.Map<EstadoDto>(estado);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Estado>> Post(EstadoDto estadoDto)
    {
        var estado = this._mapper.Map<Estado>(estadoDto);
        this.unitOfWork.Estados.Add(estado);
        await this.unitOfWork.SaveAsync();
        if(estado == null){
            return BadRequest();
        }
        estadoDto.EstadoId = estado.Id;
        return CreatedAtAction(nameof(Post), new { id = estadoDto.EstadoId }, estadoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<EstadoDto>> Put(int id, [FromBody]EstadoDto EstadoDto)
    {
        if(EstadoDto == null){
            return NotFound();
        }
        var Estado = this._mapper.Map<Estado>(EstadoDto);
        this.unitOfWork.Estados.Update(Estado);
        await this.unitOfWork.SaveAsync();
        return EstadoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var estado = await this.unitOfWork.Estados.GetByIdAsync(id);
        if(estado == null){
            return NotFound();
        }
        this.unitOfWork.Estados.Remove(estado);
        await this.unitOfWork.SaveAsync();
        return NoContent();
    }
}