using DAV.Domain.EF.Context;
using DAV.Domain.Entities;
using DAV.Domain.Utilities;
using System.Linq;

namespace DAV.Domain.EF.Commands
{
    public class OrderCommands : CommandBase
    {
        public OrderCommands(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public Order AddOrder(Order order)
        {

            order.DateTime = System.DateTime.UtcNow;
            order.StatusId = OrderStatus.New;

            _context.Add(order);
            _context.SaveChanges();
            return order;
        }

        public bool UpdateOrder(Order order)
        {
            DeleteOrderInActiveOrderLines(order);

            _context.Attach(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.Update(order);

            _context.AttachRange(order.ProductLines.Where(i => i.Id > 0 && i.IsActive == true));
            _context.UpdateRange(order.ProductLines.Where(i => i.Id > 0 && i.IsActive == true));

            _context.SaveChanges();

            return true;
        }

        public void DeleteOrderInActiveOrderLines(Order order)
        {
            foreach (var line in order.ProductLines.Where(i => i.IsActive == false).ToList())
            {
                _context.Attach(line).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            }

        }

    }
}
