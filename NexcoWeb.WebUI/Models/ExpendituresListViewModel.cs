using NexcoWeb.Domain.Entities;
using System.Collections.Generic;

namespace NexcoWeb.WebUI.Models
{
    public class ExpendituresListViewModel
    {
        public IEnumerable<Expenditure> Expenditures { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentDescription { get; set; }
    }
}