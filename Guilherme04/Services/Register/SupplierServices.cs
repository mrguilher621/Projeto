using Model.Register;
using Persistence.DAL.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Register
{
   public class SupplierServices
    {
        private SupplierDAL supplierDAL = new SupplierDAL();

        public IQueryable<Supplier>GetSuppliersClassifiedsByName()
        {
            return supplierDAL.GetSuppliersClassifiedsByName();
        }


        public Supplier GetSupplierById(long id)
        {
            return supplierDAL.GetSupplierById(id);
        }

        public void SaveSupplier(Supplier supplier)
        {
            supplierDAL.SaveSupplier(supplier);
        }

        public Supplier RemoveSupplierById(long id)
        {
            return supplierDAL.RemoveSuppliertBy(id);
        }
    }
}
