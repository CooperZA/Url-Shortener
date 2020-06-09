using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Dapper;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

using UrlShortener.Models;

namespace UrlShortener.DataRepository
{
    public class UrlShortenerRepository
    {
        private string connectionStrName = "UrlShortener";
        private string connection;

        // constructor
        public UrlShortenerRepository()
        {
            connection = ConfigurationManager.ConnectionStrings[connectionStrName].ToString();
        }

        // retrieve all from db
        public List<UrlShortenerModel> GetUrls()
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                string sql = @"SELECT * FROM Link";

                List<UrlShortenerModel> search = db.Query<UrlShortenerModel>(sql).ToList();

                return search;

            }
        }

        // find one in db
        public string GetOneUrl(string query)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                string sql = @"SELECT OriginUrl FROM Link WHERE ShortLink = @query";

                string search = db.Query<string>(sql, new { query }).SingleOrDefault().ToString();

                return search;
            }
        }

        // insert into db
        public void addNewUrl(UrlShortenerModel urlShortener)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                string sql = @"INSERT INTO Link (OriginUrl, ShortLink) VALUES (@originUrl, @shortLink)";

                db.Execute(sql, new { originUrl = urlShortener.OriginUrl, shortLink = urlShortener.ShortLink });
            }
        }

        // Check unique Url
        public bool urlIsUnique(string query)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                string sql = @"SELECT ShortLink FROM Link WHERE ShortLink = @query";

                bool notUnique = db.ExecuteScalar<bool>(sql, new { query });

                return notUnique;
            }

        }
    }
}