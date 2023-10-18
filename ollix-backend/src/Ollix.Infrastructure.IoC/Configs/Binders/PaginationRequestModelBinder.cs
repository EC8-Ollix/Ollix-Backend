using Microsoft.AspNetCore.Mvc.ModelBinding;
using Ollix.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Infrastructure.IoC.Configs.Binders
{
    public class PaginationRequestModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var page = bindingContext.ValueProvider.GetValue("page").FirstValue;
            var pageSize = bindingContext.ValueProvider.GetValue("pageSize").FirstValue;

            if(string.IsNullOrEmpty(page) || string.IsNullOrEmpty(pageSize))
            {
                page = bindingContext.ValueProvider.GetValue("PaginationRequest.page").FirstValue;
                pageSize = bindingContext.ValueProvider.GetValue("PaginationRequest.pageSize").FirstValue;
            }

            var paginationRequest = new PaginationRequest
            {
                Page = string.IsNullOrEmpty(page) ? 1 : int.Parse(page),
                PageSize = string.IsNullOrEmpty(pageSize) ? 10 : int.Parse(pageSize)
            };

            paginationRequest.NormalizePager();

            bindingContext.Result = ModelBindingResult.Success(paginationRequest);
            return Task.CompletedTask;
        }
    }
}
