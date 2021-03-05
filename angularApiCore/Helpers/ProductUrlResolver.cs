using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using angularApiCore.Dtos;
using AutoMapper;
using Core.Models;
using Microsoft.Extensions.Configuration;

namespace angularApiCore.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturn, string>
    {

        private readonly IConfiguration _config;
        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductToReturn destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}
