using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using mstum.utils;
using ShareIt.Models;

namespace ShareIt.Controllers
{
    public class FeedsController : ApiController
    {
        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        // GET api/values
        public IEnumerable<Feed> GetAll()
        {
            var repository = Repository.Get<Feed>();
            return repository.All().ToList();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }
        
        // POST api/values
        public void Post(string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}