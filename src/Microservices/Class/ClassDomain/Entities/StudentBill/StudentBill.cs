using ClassDomain.Entities.Bill;
using Common.Entity.Entity;
using Elasticsearch.Net.Specification.IndicesApi;

namespace ClassDomain.Entities.StudentBill;

public class StudentBill:BaseEntity<StudentBillID>
{
    
    public bool IsPayment { get; set; }
    public BillID BillId { get; set; }
    public Bill.Bill Bill { get; set; }
    public StudentClass.StudentClass StudentClass { get; set; }
    public StudentClass.StudentClassID StudentClassId { get; set; }
}