using ClassDomain.Entities.Bill;
using ClassDomain.Entities.StudentBill;
using ClassDomain.Entities.StudentClass;
using ClassInfrutructure.Data;

namespace ClassInfrutructure.Seed;

public static class StudentBillSeeder
{

    public static async Task seedData(ApplicationDbContext context)
    {

        if (!context.StudentBills.Any())
        {

            List<Bill> bills = context.Bills.ToList();
            List<StudentClass> studentClasses = context.StudentClasses.ToList();
            List<StudentBill> studentBills = BillStudentFaker
                    .GetStudentBillFaker(bills, studentClasses)
                    .Generate(15)
                    .DistinctBy(x=>new {x.BillId,x.StudentClassId})
                    .ToList();
            context.StudentBills.AddRange(studentBills);
            context.SaveChanges();
            

        }
    }

}