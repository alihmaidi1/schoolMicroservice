using ClassDomain.Dto.Bill;
using ClassDomain.Dto.Semester;
using ClassDomain.Dto.Student;

namespace ClassDomain.Dto.ClassYear;

public class GetClassYearResponse
{
    
    
    public Guid Id { get; set; }
    
    public string ClassName { get; set; }
    
    public string YearName { get; set; }
    
    public List<GetSemesterResponse> Semesters { get; set; }
    public List<GetBillResponse> Bills { get; set; }
    public List<GetStudentClassResponse> Students { get; set; }
}