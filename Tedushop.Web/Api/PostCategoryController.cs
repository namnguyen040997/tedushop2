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
using Tedushop.Web.Infrastructure.Extensions;

namespace Tedushop.Web.Api
{
    [RoutePrefix("api/postcategory")] //Khai báo để điều hướng phương thức
    public class PostCategoryController : ApiControllerBase //Viết 4 phương thức để CRUD theo API
    {
        IPostCategoryService _postCategoryService;
        //Viết lại constructor của ApiControllerBase 
        //Autofac sẽ tự inject IErrorService ,  IPostCategoryService 
        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) : base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }

        [Route("getall")] //VD khai báo api/postcategory/getall sẽ chạy vào
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                //Trước khi mapping class:
                //var listCategory2 = _postCategoryService.GetAll();
                //HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategory2);

                //Sau khi mapping class:
                //Nếu valid thành công thì dùng cái service để add cái postCategory vào
                var lstCategory = _postCategoryService.GetAll();
                //Đối tương mapper có thể nhận về 1 List<>
                var lstPostCategoryVM = Mapper.Map<List<PostCategoryViewModel>>(lstCategory);

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, lstPostCategoryVM); //OK: Thành công
                return response;
            });
        }

        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategoryViewModel postCategoryVM)
        {
            //Trước khi mapping class:

            ////Nếu valid thành công thì dùng service để add cái postCategory vào database
            //var category = _postCategoryService.Add(postCategory);
            //_postCategoryService.Save();
            ////add xong thì trả về category để làm những công việc tiếp
            //response = request.CreateResponse(HttpStatusCode.Created, category);

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                //Valid theo tiêu chí ở Tedushop.Model
                if (ModelState.IsValid)
                {
                    //Nếu valid thất bại sẽ xuất ra lỗi 400
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState); //Lỗi 400
                }
                else
                {
                    //Sau khi mapping class:

                    PostCategory newPostCategory = new PostCategory();
                    newPostCategory.UpdatePostCategory(postCategoryVM);
                    //Nếu valid thành công thì dùng service để add cái postCategory vào database
                    var category = _postCategoryService.Add(newPostCategory);
                    _postCategoryService.Save();

                    //add xong thì trả về category để làm những công việc tiếp
                    response = request.CreateResponse(HttpStatusCode.Created, category);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postCategoryVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                //Valid theo tiêu chí ở Tedushop.Model
                if (ModelState.IsValid)
                {
                    //Nếu valid thất bại sẽ xuất ra lỗi 400
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState); //Lỗi 400
                }
                else
                {
                    //Lấy từ DB
                    var postCategoryDB = _postCategoryService.GetById(postCategoryVM.ID);
                    postCategoryDB.UpdatePostCategory(postCategoryVM);
                    //Nếu valid thành công thì dùng cái service để add cái postCategory vào
                    _postCategoryService.Update(postCategoryDB);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK); //OK: Thành công
                }
                return response;
            });
        }

        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                //Valid theo tiêu chí ở Tedushop.Model
                if (ModelState.IsValid)
                {
                    //Nếu valid thất bại sẽ xuất ra lỗi 400
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState); //Lỗi 400
                }
                else
                {
                    //Nếu valid thành công thì dùng cái service để add cái postCategory vào
                    _postCategoryService.Delete(id);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK); //OK: Thành công
                }
                return response;
            });
        }
    }
}