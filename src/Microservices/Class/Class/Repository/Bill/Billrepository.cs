using Class.Repository.Base;
using ClassDomain.Entities.Bill;
using ClassInfrutructure;
using Microsoft.EntityFrameworkCore;

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

    public bool Delete(BillID Id)
    {

        DbContext.Bills.Where(x => x.Id==Id).ExecuteUpdate(setter=>setter.SetProperty(x=>x.DateDeleted,DateTime.Now));
        DbContext.SaveChanges();
        return true;

    }

}