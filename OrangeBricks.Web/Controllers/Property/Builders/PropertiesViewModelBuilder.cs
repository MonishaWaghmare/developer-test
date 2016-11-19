using System;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System.Collections.Generic;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class PropertiesViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public PropertiesViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public PropertiesViewModel Build(PropertiesQuery query, string currentUserId)
        {
            var properties = _context.Properties
                .Where(p => p.IsListedForSale && p.SellerUserId != currentUserId);

            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                properties = properties.Where(x => (x.StreetName.Contains(query.Search)
                    || x.Description.Contains(query.Search)) && x.SellerUserId != currentUserId);
            }

            

            return new PropertiesViewModel
            {
                Properties = properties
                    .ToList()
                    .Select(MapViewModel)
                    .ToList(),
                Search = query.Search
            };
        }

       
        public static PropertyViewModel MapViewModel(Models.Property property)
        {
            return new PropertyViewModel
            {
                Id = property.Id,
                StreetName = property.StreetName,
                Description = property.Description,
                NumberOfBedrooms = property.NumberOfBedrooms,
                PropertyType = property.PropertyType,
                SellerUserId = property.SellerUserId,
                
            };
        }
    }
}