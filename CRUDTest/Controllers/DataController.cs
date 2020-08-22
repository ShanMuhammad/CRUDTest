using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using CRUDTest.DAL;
using CRUDTest.Models;

namespace CRUDTest.Controllers
{
    [EnableCors("*","*","*")]
    public class DataController : ApiController
    {
        IDataRepository repo = new DataRepository(new CRUDdbContext());

        // GET: api/Data
        public IQueryable<CRUDModel> GetAllData()
        {
            return repo.GetAllData();
        }

        [HttpGet]
        public IHttpActionResult GetDataById(int id)
        {
            CRUDModel cRUDModel = repo.GetDataById(id);
            if (cRUDModel == null)
            {
                return NotFound();
            }

            return Ok(cRUDModel);
        }

        [HttpPost]
        public IHttpActionResult UpdateData( CRUDModel cRUDModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (cRUDModel.CrudId == 0)
            {
                return BadRequest();
            }

            try
            {
                repo.UpdateData(cRUDModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CRUDModelExists(cRUDModel.CrudId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        public IHttpActionResult CreateData(CRUDModel cRUDModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            cRUDModel = repo.CreateData(cRUDModel);

            return CreatedAtRoute("DefaultApi", new { id = cRUDModel.CrudId }, cRUDModel);
        }

        
        
        [HttpGet]
        public IHttpActionResult DeleteData(int id)
        {

            CRUDModel cRUDModel = repo.DeleteData(id);
            return Ok(cRUDModel);
        }

       
        private bool CRUDModelExists(int id)
        {
            return repo.CRUDModelExists(id);
        }
    }
}