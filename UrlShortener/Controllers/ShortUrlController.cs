using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrlShortener.Models;
using UrlShortener.DataRepository;
using UrlShortener.Utilities;

namespace UrlShortener.Controllers
{
    public class ShortUrlController : Controller
    {
        // get home
        public ActionResult Index(string id)
        {
            // get all db records
            UrlShortenerRepository urlShortRepo = new UrlShortenerRepository();

            if (id != null)
            {
                string originUrl = urlShortRepo.GetOneUrl(id);

                return Redirect(originUrl);
            }

            List<UrlShortenerModel> urlList = urlShortRepo.GetUrls();

            return View(urlList);
        }

        // post new url
        [HttpPost]
        public ActionResult Create(string url)
        {
            UrlShortenerRepository urlShortRepo = new UrlShortenerRepository();

            // insert into db
            // generate new short url
            string newShortUrl = ShortUrlGenerator.generateShortUrl();

            // check url is unique 
            while (urlShortRepo.urlIsUnique(newShortUrl))
            {
                newShortUrl = ShortUrlGenerator.generateShortUrl();
            }

            // insert urls into db
            UrlShortenerModel urls = new UrlShortenerModel();

            urls.OriginUrl = url;
            urls.ShortLink = newShortUrl;

            urlShortRepo.addNewUrl(urls);

            ViewBag.Link = "http://yorktown.cbe.wwu.edu/students/202/cooperz/ShortUrl/Index/" + newShortUrl;

            return View("Index", urlShortRepo.GetUrls());
        }

    }
}