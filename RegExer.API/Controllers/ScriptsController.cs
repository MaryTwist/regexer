using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using RegExer.API.Models;

namespace RegExer.API.Controllers
{
    public class ScriptsController : ApiController
    {
        // GET: api/Script
        public IHttpActionResult Get()
        {
            return Json(DbHelper.GetScripts().ToArray());
        }

        // GET: api/Script/5
        public IHttpActionResult Get(int id)
        {
            return Json(DbHelper.GetScript(id));
        }

        // POST: api/Script
        public int Post([FromBody]Script s)
        {
            return DbHelper.AddScript(s);
        }

        // PUT: api/Script/5
        public void Put(int id, [FromBody]Script s)
        {
            DbHelper.UpdateScript(id, s);
        }

        // DELETE: api/Script/5
        public void Delete(int id)
        {
            DbHelper.DeleteScript(id);
        }
    }
}
