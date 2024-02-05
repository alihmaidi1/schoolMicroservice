namespace Domain.Dto.Teacher;

public class GetTeacherResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }
    public string Name { get; set; }

    public List<Warning>? Warnings { get; set; }
    
    public List<Vacation>? Vacations { get; set; }
    
    
    
    
}

public class  Warning
{
    
    public Guid Id { get; set; }
    
    public string Reason { get; set; }

    public string ManagerName { get; set; }
    
}

public class Vacation
{
    
    
    public Guid Id { get; set; }
    public string Reason { get; set; }
    public string ManagerName { get; set; }
    public bool ?Status { get; set; }
    public string Year { get; set; }
    
}