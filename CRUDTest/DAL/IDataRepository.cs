using CRUDTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDTest.DAL
{
    interface IDataRepository
    {
        IQueryable<CRUDModel> GetAllData();
        CRUDModel GetDataById(int id);
        void UpdateData(CRUDModel cRUDModel);
        CRUDModel CreateData(CRUDModel cRUDModel);
        CRUDModel DeleteData(int id);
        bool CRUDModelExists(int id);
    }

}
