﻿using System;

namespace NexcoWeb.WebUI.Models
{
    public class PagingInfo
    {
        public int Total { get; set; }
        public int PerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)Total /
                    PerPage);
            }
        }
    }
}