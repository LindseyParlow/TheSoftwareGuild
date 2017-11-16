using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class SalesInfoVM
    {
        public Purchase Purchase { get; set; }
        public List<SelectListItem> StateItems { get; set; }
        public List<SelectListItem> PurchaseTypeItems { get; set; }

        public SalesInfoVM()
        {
            StateItems = new List<SelectListItem>();
            PurchaseTypeItems = new List<SelectListItem>();
            Purchase = new Purchase();
        }

        public void SetStateItems(IEnumerable<State> states)
        {
            foreach (var state in states)
            {
                StateItems.Add(new SelectListItem()
                {
                    Value = state.StateId.ToString(),
                    Text = state.StateName,
                });
            }
        }

        public void SetPurchaseTypeItems(IEnumerable<PurchaseType> purchaseTypes)
        {
            foreach (var type in purchaseTypes)
            {
                PurchaseTypeItems.Add(new SelectListItem()
                {
                    Value = type.PurchaseTypeId.ToString(),
                    Text = type.PurchaseTypeDescription,
                });
            }
        }
    }
}
