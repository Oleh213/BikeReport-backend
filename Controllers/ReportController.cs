using Microsoft.AspNetCore.Mvc;
using task_backend.Interfaces;

namespace task_backend.Controllers;

[ApiController]
[Route("api/ReportController")]
public class ReportController: ControllerBase
{

    private readonly IReportActionsBL _reportActionsBL;

    public ReportController(IReportActionsBL reportActionsBL)
    {
        _reportActionsBL = reportActionsBL;
    }

    [HttpGet("GetAllBikeTypes")]
    public async Task<IActionResult> GetAllBikeTypes()
    {
        try
        {
            var bikeTypes = await _reportActionsBL.GetBikeTypes();

            return bikeTypes != null ? Ok(bikeTypes) : NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("GetAllBikeBrands")]
    public async Task<IActionResult> GetAllBikeBrands()
    {
        try
        {
            var bikeBrands = await _reportActionsBL.GetBikeBrand();

            return bikeBrands != null ? Ok(bikeBrands) : NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("GetAllServiceComponents")]
    public async Task<IActionResult> GetAllServiceComponents()
    {
        try
        {
            var serviceComponents = await _reportActionsBL.GetServiceComponents();

            return serviceComponents != null ? Ok(serviceComponents) : NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("GetAllGetServicePackages")]
    public async Task<IActionResult> GetAllGetServicePackages()
    {
        try
        {
            var servicePackages = await _reportActionsBL.GetServicePackages();

            return servicePackages != null ? Ok(servicePackages) : NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost("AddDataToDataBase")]
    public async Task<IActionResult> AddDataToDataBase()
    {
        try
        {
            await _reportActionsBL.AddData();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}

