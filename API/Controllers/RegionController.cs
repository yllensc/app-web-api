using API.Dtos;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
    public class RegionController: BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper _mapper;

    public RegionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RegionDto>>> Get()
    {
        var Regiones = await this.unitOfWork.Regiones.GetAllAsync();
        return this._mapper.Map<List<RegionDto>>(Regiones);
    }

    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RegionDto>> Get(int id)
    {
        var Region = await this.unitOfWork.Regiones.GetByIdAsync(id);
        if(Region == null){
            return NotFound();
        }
        return this._mapper.Map<RegionDto>(Region);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Region>> Post(RegionDto regionDto)
    {
        var region = this._mapper.Map<Region>(regionDto);
        this.unitOfWork.Regiones.Add(region);
        await this.unitOfWork.SaveAsync();
        if(region == null){
            return BadRequest();
        }
        regionDto.RegionId = region.Id;
        return CreatedAtAction(nameof(Post), new { id = regionDto.RegionId }, regionDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RegionDto>> Put(int id, [FromBody]RegionDto regionDto)
    {
        if(regionDto == null){
            return NotFound();
        }
        var Region = this._mapper.Map<Region>(regionDto);
        this.unitOfWork.Regiones.Update(Region);
        await this.unitOfWork.SaveAsync();
        return regionDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var region = await this.unitOfWork.Regiones.GetByIdAsync(id);
        if(region == null){
            return NotFound();
        }
        this.unitOfWork.Regiones.Remove(region);
        await this.unitOfWork.SaveAsync();
        return NoContent();
    }
}