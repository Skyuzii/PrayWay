using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrayWay.Domain.Entities
{
    [Table(nameof(Place))]
    public class Place
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public double Latitude { get; set; }
        
        public double Longitude { get; set; }
        
        public string Description { get; set; }
        
        public DateTime PublishDate { get; set; }
        
        public string Address { get; set; }  
    }
}