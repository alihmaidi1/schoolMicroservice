using Class.Repository.Base;
using ClassDomain.Entities.Bill;

namespace Class.Repository.Bill;

public interface IBillRepository:IgenericRepository<ClassDomain.Entities.Bill.Bill>
{


    public bool IsExists(BillID Id);
}