using Bogus;
using ClassDomain.Entities.Bill;
using ClassDomain.Entities.StudentBill;
using ClassDomain.Entities.StudentClass;

namespace ClassInfrutructure.Data;

public static class BillStudentFaker
{
    public static Faker<StudentBill> GetStudentBillFaker(List<Bill> bills, List<StudentClass> studentClasses)
    {

        var studentBill = new Faker<StudentBill>();
        Bill Bill=new Faker().PickRandom(bills);
        studentBill.RuleFor(x => x.Money, setter => setter.Random.Float(1, Bill.Money));
        studentBill.RuleFor(x => x.BillId, setter => Bill.Id);
        studentBill.RuleFor(x => x.StudentClassId, setter => setter.PickRandom(studentClasses).Id);
        return studentBill;

    }

}