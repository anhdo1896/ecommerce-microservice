using AutoMapper;
using Ecommerce.Service.ProductAPI.Data;
using Ecommerce.Service.ProductAPI.Dtos;
using Ecommerce.Service.ProductAPI.Helpers;
using Ecommerce.Service.ProductAPI.Models;
using Ecommerce.Service.ProductAPI.Service.IService;
using Ecommerce.Service.ProductAPI.Specification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace Ecommerce.Service.ProductAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        private readonly IGenericService<Product> _repoProduct;
        private readonly IGenericService<Brand> _repoBrand;
        private readonly IGenericService<Category> _repoCategory;
        private readonly IGenericService<Photo> _repoPhoto;
        //private readonly DataContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public ProductAPIController(IGenericService<Product> repoProduct,
        IGenericService<Brand> repoBrand,
        IGenericService<Category> repoCategory, IGenericService<Photo> repoPhoto, IMapper mapper)
        {
            _repoProduct = repoProduct;
            _repoBrand = repoBrand;
            _repoCategory= repoCategory;
            _repoPhoto = repoPhoto;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public async Task<ResponseDto> Get([FromQuery] ProductSpecParams productSpecParams)
        {
            try
            {
                var spec = new ProductsWithTypesAndBrandsSpecification(productSpecParams);

                var countSpec = new ProductWithFiltersForCountSpecification(productSpecParams);

                var totalItems = await _repoProduct.CountAsync(countSpec);

                var products = await _repoProduct.ListAsync(spec);

                

                for(int i=0; i < products.Count; i++)
                {
                    var specPhoto = new PhotoWithProductSpecification(products[i].Id);
                    var photos = await _repoPhoto.ListAsync(specPhoto);
                    if(photos != null)
                    {
                        products[i].Images = photos;

                    }
                }

                var data = _mapper.Map<IReadOnlyList<Product>,
                  IReadOnlyList<ProductDto>>(products);

                _response.Data = new Pagination<ProductDto>(productSpecParams.PageIndex, productSpecParams.PageSize,
                                        totalItems,
                                        data);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ResponseDto>> Get(int id)
        {
            try
            {   
                var spec = new ProductsWithTypesAndBrandsSpecification(id);

                var product = await _repoProduct.GetEntityWithSpec(spec);

                if (product == null)
                    return NotFound();


               
                var specPhoto = new PhotoWithProductSpecification(product.Id);
                var photos = await _repoPhoto.ListAsync(specPhoto);
                if (photos != null)
                {
                    product.Images = photos;

                }
               
                _response.Data = _mapper.Map<Product, ProductDto>(product); 


            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Post([FromForm] ProductDto productDto)
        {
            try
            {
                Product product = _mapper.Map<Product>(productDto);

               int id =  _repoProduct.Add(product);

                if (productDto.ImagePhotos != null && productDto.ImagePhotos.Count() > 0)
                {
                    for (int i = 0; i < productDto.ImagePhotos.Count; i++)
                    {
                        var photo = new Photo();
                        string fileName = id +"_" +DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss-tt") + i + Path.GetExtension(productDto.ImagePhotos[i].FileName);
                        string filePath = @"wwwroot\ProductImages\" + fileName;

                        // if condition to remove the any image with same name if that exist in the folder by any change
                        var directoryLocation = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                        FileInfo file = new FileInfo(directoryLocation);
                        if (file.Exists)
                        {
                            file.Delete();
                        }

                        var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                        using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
                        {
                            productDto.ImagePhotos[i].CopyTo(fileStream);
                        }
                        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                        photo.Url = baseUrl + "/ProductImages/" + fileName;
                        photo.IsMain = false;
                        photo.Product = product;
                        photo.Description = productDto.PhotoDescription;
                        photo.PublicId = "admin";
                        photo.ProductId = id;
                        _repoPhoto.Add(photo);
                    }

                }

                _response.Data = id;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromForm] ProductDto productDto)
        {
            try
            {
                Product product = _mapper.Map<Product>(productDto);

                int id = _repoProduct.Update(product);

                if (productDto.ImagePhotos != null && productDto.ImagePhotos.Count() > 0)
                {
                    for (int i = 0; i < productDto.ImagePhotos.Count; i++)
                    {
                        var photo = new Photo();
                        string fileName = id + "_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss-tt") + Path.GetExtension(productDto.ImagePhotos[i].FileName);
                        string filePath = @"wwwroot\ProductImages\" + fileName;

                        // if condition to remove the any image with same name if that exist in the folder by any change
                        var directoryLocation = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                        FileInfo file = new FileInfo(directoryLocation);
                        if (file.Exists)
                        {
                            file.Delete();
                        }

                        var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), filePath);
                        using (var fileStream = new FileStream(filePathDirectory, FileMode.Create))
                        {
                            productDto.ImagePhotos[i].CopyTo(fileStream);
                        }
                        var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}{HttpContext.Request.PathBase.Value}";
                        photo.Url = baseUrl + "/ProductImages/" + fileName;
                        photo.IsMain = false;
                        photo.Product = product;
                        photo.Description = productDto.PhotoDescription;
                        photo.PublicId = "admin";
                        photo.ProductId = id;
                        _repoPhoto.Add(photo);
                    }

                }

                _response.Data = id;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                Product product = await _repoProduct.GetByIdAsync(id);

                _repoProduct.Delete(product);

                var spec = new PhotoWithProductSpecification(id);

                var photos = await _repoPhoto.GetEntityWithSpec(spec);

                _repoPhoto.Delete(photos);

                if (product.Images != null)
                {
                    for (int i = 0; i < product.Images.Count; i++)
                    {
                        var filePathDirectory = Path.Combine(Directory.GetCurrentDirectory(), 
                            product.Images.ElementAt(i).Url);

                        FileInfo file = new FileInfo(filePathDirectory);

                        if (file.Exists)
                        {
                            file.Delete();
                        }
                    }
                }

                _response.Data = product;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("brands")]
        public async Task<ActionResult<ResponseDto>> GetListBrands()
        {
            try
            {
                var brands = await _repoBrand.GetListAsync();
                _response.Data = brands;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
           
            return _response;
        }

        [HttpPost("brands")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto CreateBrand(Brand brand)
        {
            _repoBrand.Add(brand);

            return _response;
        }

        [HttpPut("brands")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto UpdateBrand(Brand brand)
        {
           _repoBrand.Update(brand);

            return _response;
        }


        [HttpDelete("brands")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ResponseDto> DeleteBrand(int id)
        {
            Brand brand = await _repoBrand.GetByIdAsync(id);

            _repoBrand.Delete(brand);

            return _response;
        }



        [HttpGet("categories")]
        public async Task<ActionResult<ResponseDto>> GetListProductTypes()
        {
            try
            {
                var types = await _repoCategory.GetListAsync();
                _response.Data = types;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpPost("categories")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto CreateCategory(Category category)
        {
            _repoCategory.Add(category);

            return _response;
        }

        [HttpPut("categories")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto UpdateCategory(Category category)
        {
            _repoCategory.Update(category);

            return _response;
        }


        [HttpDelete("categories")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ResponseDto> DeleteCategory(int id)
        {
            Category category = await _repoCategory.GetByIdAsync(id);

            _repoCategory.Delete(category);

            return _response;
        }



    }



}
