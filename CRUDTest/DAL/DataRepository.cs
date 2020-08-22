using CRUDTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace CRUDTest.DAL
{

    public class DataRepository : IDataRepository
    {
        private CRUDdbContext db = null;
        public DataRepository(CRUDdbContext cRUDdbContext)
        {
            db = cRUDdbContext;
        }
        public CRUDModel CreateData(CRUDModel cRUDModel)
        {
            db.CRUDModels.Add(cRUDModel);

            db.SaveChanges();
            return cRUDModel;
        }

        public CRUDModel DeleteData(int id)
        {
            CRUDModel cRUDModel = db.CRUDModels.Find(id);
            if (cRUDModel != null)
            {
                db.CRUDModels.Remove(cRUDModel);
                db.SaveChanges();
                return cRUDModel;
            }
            else return null;
            
            
        }

      

        public IQueryable<CRUDModel> GetAllData()
        {
            return db.CRUDModels;
        }

        public CRUDModel GetDataById(int id)
        {
            return db.CRUDModels.Find(id);
        }

        public void UpdateData(CRUDModel cRUDModel)
        {
            db.Entry(cRUDModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }


        public bool CRUDModelExists(int id)
        {
            return db.CRUDModels.Count(e => e.CrudId == id) > 0;
        }

    }
}