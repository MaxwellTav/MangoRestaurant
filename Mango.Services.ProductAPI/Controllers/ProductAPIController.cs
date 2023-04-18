using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDto _response;
        IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
                _response.IsSuccess = true;
                _response.Result = productDtos;
            }
            catch (Exception error)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { error.Message };
            }

            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ProductDto productDto = await _productRepository.GetProductById(id);
                _response.IsSuccess = true;
                _response.Result = productDto;
            }
            catch (Exception error)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { error.Message };
            }

            return _response;
        }
    }
}
