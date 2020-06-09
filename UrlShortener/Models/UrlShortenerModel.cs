using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UrlShortener.Models
{
    public class UrlShortenerModel
    {
        // url id
        [Key]
        public int Id { get; set; }

        // original url
        public string OriginUrl { get; set; }
        
        // short url
        public string ShortLink { get; set; }
    }
}