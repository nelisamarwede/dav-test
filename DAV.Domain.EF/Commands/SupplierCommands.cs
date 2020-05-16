using DAV.Domain.EF.Context;
using DAV.Domain.Entities;

namespace DAV.Domain.EF.Commands
{
    public class SupplierCommands : CommandBase
    {
        public SupplierCommands(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public int AddSupplier(Supplier supplier)
        {
            _context.Add(supplier);
            _context.SaveChanges();
            return supplier.Id.Value;
        }

        public bool UpdateSuppliert(Supplier supplier)
        {
            _context.Attach(supplier);
            _context.SaveChanges();

            return true;
        }

        public bool DeleteSupplier(Supplier supplier)
        {
            _context.Attach(supplier);
            _context.Remove(supplier);

            return true;
        }
    }
}
