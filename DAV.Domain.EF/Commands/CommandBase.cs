using DAV.Domain.EF.Context;

namespace DAV.Domain.EF.Commands
{
    public abstract class CommandBase
    {
        #region Locals

        protected readonly ApplicationContext _context;

        #endregion


        public CommandBase(ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }

    }
}
