using vn.edu.payment.qr.Models;

namespace vn.edu.payment.qr.Services
{
    public class ContextService
    {
        public readonly databaseContext databaseContext;
        public ContextService(databaseContext dbContext)
        {
            this.databaseContext = dbContext;
        }
    }
}
