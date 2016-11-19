using System;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System.Collections.Generic;
using OrangeBricks.Web.Controllers.Offers.ViewModels;
using OrangeBricks.Web.Controllers.Property.Builders;

namespace OrangeBricks.Web.Controllers.Offers.Builders
{
    public class OffersViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public OffersViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public OffersViewModel Build(PropertiesQuery query, string buyerUserId)
        {

            List<Offer> offers = _context.Offers.Where(o => o.BuyerUserId == buyerUserId).ToList();
               

            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                //TODO:
            } 

            return new OffersViewModel
            {
                Offers = offers.Select(o => new OfferViewModel()
                        {
                            Amount = o.Amount,
                            Status = ((OfferStatus)o.Status).ToString(),
                            Property = PropertiesViewModelBuilder.MapViewModel(o.ProperyRef)
                            
                        }).ToList(),
                Search = query.Search
            };
            
        }

       
    }
}