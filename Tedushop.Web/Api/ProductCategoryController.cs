using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tedushop.Model.Model;
using Tedushop.Service;
using Tedushop.Web.Infrastructure.Core;
using Tedushop.Web.Models;

namespace Tedushop.Web.Api
{
    [RoutePrefix("api/productcategory")]
    public class ProductCategoryController : ApiControllerBase
    {     
        IProductCategoryService _productCategoryService;
        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService) : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }
        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _productCategoryService.GetAll();

                totalRow = model.Count(); //Lấy về số bản ghi
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize); //page ban đầu = 0 => skip: 0 , lấy về 20 bản ghi đầu

                var responseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(query);

                var paginationSet = new PaginationSet<ProductCategoryViewModel>()
                {
                    Items = responseData, //Items chính là mảng các Danh mục sản phẩm chả ra
                    Page = page,    
                    TotalCount = totalRow, //Số bản ghi
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize) //Số trang = số danh mục / pageSize(20), Math.Ceiling: làm tròn lên 
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }
    }
}
