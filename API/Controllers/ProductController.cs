using API.Controllers.Base;
using BusinessLayer.DTOs;
using BusinessLayer.DTOs.BookingDTOs;
using BusinessLayer.Interfaces.BookingServices;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[ApiExplorerSettings(GroupName = "HotelRoomsV1")]
[Route("[controller]")]
public sealed class ProductController : BaseApiController
{
    private readonly IProductServices _productServices;

    public ProductController(IProductServices productServices)
    {
        _productServices = productServices;
    }

    /// <summary>Create product.</summary>
    /// <param name="product">Product to create DTO.</param>
    /// <response code="200">Returns new product ID.</response>
    /// <response code="500">Returns error details.</response>
    /// <response code="400">Returns property error details.</response>
    [ProducesResponseType(typeof(GenericHttpExceptionDTO), 500)]
    [ProducesResponseType(typeof(ValidationHttpExceptionDTO), 400)]
    [ProducesResponseType(typeof(string), 200)]
    [HttpPost]
    public async Task<IActionResult> CreateProductAsync(CreateProductDTO product)
    {
        return HandleResult(await _productServices.CreateProductAsync(product));
    }

    /// <summary>Get all products that will be displayed for client.</summary>
    /// <response code="200">Returns list of client side product DTO models.</response>
    /// <response code="500">Returns error details.</response>
    [ProducesResponseType(typeof(GenericHttpExceptionDTO), 500)]
    [ProducesResponseType(typeof(IEnumerable<ClientSideProductDTO>), 200)]
    [HttpGet]
    public async Task<IActionResult> GetAllAvailableClientSideProductsAsync(string startDate, string endDate, string? promoCode)
    {
        return HandleResult(await _productServices.GetAllAvailableClientSideProductsAsync(DateTime.Parse(startDate), DateTime.Parse(endDate), promoCode));
    }


}