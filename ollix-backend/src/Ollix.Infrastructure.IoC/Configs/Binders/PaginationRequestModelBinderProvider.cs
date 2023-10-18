using Microsoft.AspNetCore.Mvc.ModelBinding;
using Ollix.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Infrastructure.IoC.Configs.Binders
{
    public class PaginationRequestModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(PaginationRequest))
            {
                return new PaginationRequestModelBinder();
            }

            return null;
        }
    }
}
