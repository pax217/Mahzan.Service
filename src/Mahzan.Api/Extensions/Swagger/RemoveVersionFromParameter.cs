﻿using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace Mahzan.Api.Extensions.Swagger
{
    public class RemoveVersionFromParameter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (!operation.Parameters.Any())
                return;

            var versionParameter = operation.Parameters
                .FirstOrDefault(p => p.Name.ToLower() == "version");

            if (versionParameter != null)
                operation.Parameters.Remove(versionParameter);
        }
    }

}