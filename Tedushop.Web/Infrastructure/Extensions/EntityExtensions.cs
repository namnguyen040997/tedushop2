using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tedushop.Model.Model;
using Tedushop.Web.Models;

namespace Tedushop.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        //Mỗi khi sử dụng đối tương PostCategory (vd trong COntroller) , chỉ cần khai báo đối tượng .UpdatePostCategory
        //=>Nó sẽ copy giá trị của ViewModel(ở dưới) đẩy vào giá trị postCategory(ở dưới)
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryVM)
        {
            postCategory.ID = postCategoryVM.ID;
            postCategory.Name = postCategoryVM.Name;
            postCategory.Alias = postCategoryVM.Alias;
            postCategory.Description = postCategoryVM.Description;
            postCategory.ParentID = postCategoryVM.ParentID;
            postCategory.DisplayOrder = postCategoryVM.DisplayOrder;
            postCategory.Image = postCategoryVM.Image;
            postCategory.HomeFlag = postCategoryVM.HomeFlag;
            postCategory.CreatedDate = postCategoryVM.CreatedDate;
            postCategory.CreateBy = postCategoryVM.CreateBy;
            postCategory.UpdateDate = postCategoryVM.UpdateDate;
            postCategory.UpdateBy = postCategoryVM.UpdateBy;
            postCategory.MetaKeyword = postCategoryVM.MetaKeyword;
            postCategory.MetaDesciption = postCategoryVM.MetaDesciption;
            postCategory.Status = postCategoryVM.Status;
    }
        public static void UpdatePost(this Post post, PostViewModel postVM)
        {
            post.ID = postVM.ID;
            post.Name = postVM.Name;
            post.ALias = postVM.ALias;
            post.CategoryID = postVM.CategoryID;
            post.Image = postVM.Image;
            post.Description = postVM.Description;
            post.Content = postVM.Content;
            post.HomeFlag = postVM.HomeFlag;
            post.HotFlag = postVM.HotFlag;
            post.ViewCount = postVM.ViewCount;
            post.Status = postVM.Status;
        }
    }
}