﻿namespace SignalR.EntityLayer.Entities
{
    public class Testimonial
    {
        public int TestimonialId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Title  { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }
        public int Rating { get; set; }

    }
}
