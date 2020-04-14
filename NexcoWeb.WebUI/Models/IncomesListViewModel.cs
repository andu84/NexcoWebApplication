using NexcoWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace NexcoWeb.WebUI.Models
{
    public class IncomesListViewModel
    {
        public IEnumerable<Income> Incomes { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentDescription{ get; set; }
    }
}