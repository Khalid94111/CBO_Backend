﻿using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data.Helpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CBO
{
    public class DataSourceLoadOptionsBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var loadOptions = new DataSourceLoadOptions();
            DataSourceLoadOptionsParser.Parse(loadOptions, key => bindingContext.ValueProvider.GetValue(key).FirstOrDefault());
            bindingContext.Result = ModelBindingResult.Success(loadOptions);
            return Task.CompletedTask;
        }
    }
}
