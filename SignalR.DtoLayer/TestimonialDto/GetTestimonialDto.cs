﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.TestimonialDto 
{
    public class GetTestimonialDto
    {
        public int TestimonialId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }
    }
}
