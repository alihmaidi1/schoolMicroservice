using ClassDomain.Entities.Year;

namespace ClassInfrutructure.Seed;

public class YearSeeder
{
    public static async Task seedData(ApplicationDbContext context)
    {

        if (!context.Years.Any())
        {
            
            List<Year> Years=new List<Year>()
            {
              
                new Year()
                {
                    Id = new Guid("3e04f8b1-b014-4922-baf8-f44fe14ecaf0"),
                    Name = "2020"
                },
                new Year()
                {
                    Id = new Guid("4b245774-7ffc-46c1-a90b-a707c0aa9e60"),
                    Name = "2021"
                    
                },
                new Year()
                {
                    
                    Id = new Guid("ebade91d-e102-4039-9b4f-b9c311e948ba"),
                    Name = "2022"
                }
                
                
            };
            
            context.Years.AddRange(Years);
            context.SaveChanges();
            

        }
        
    }

}