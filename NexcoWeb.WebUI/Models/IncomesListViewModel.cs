using NexcoWeb.Domain.Entities;
using System.Collections.Generic;

namespace NexcoWeb.WebUI.Models
{
    public class IncomesListViewModel
    {
        public IEnumerable<Income> Incomes { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentDescription { get; set; }
    }
}