using Class.Repository.Base;
using ClassDomain.Entities.Bill;
using ClassInfrutructure;

namespace Class.Repository.Bill;

public class Billrepository:GenericRepository<ClassDomain.Entities.Bill.Bill>,IBillRepository
{
    public Billrepository(ApplicationDbContext DbContext) : base(DbContext)
    {
    }

    public bool IsExists(BillID Id)
    {
        
        return DbContext.Bills.Any(x => x.Id == Id);

    }

}