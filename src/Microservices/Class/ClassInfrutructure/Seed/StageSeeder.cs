using ClassDomain.Entities.Class;
using ClassDomain.Entities.Stage;

namespace ClassInfrutructure.Seed;

public static class StageSeeder
{
    public static async Task seedData(ApplicationDbContext context)
    {

        if (!context.Stages.Any())
        {
            List<Stage> stages = new List<Stage>()
            {

                new Stage()
                {
                    Name = "Primary Stage",
                    Classes = new List<Class>()
                    {
                        
                        new Class()
                        {
                            
                            Name = "First Class"
                        },
                        
                        new Class()
                        {
                            
                            Name = "Second Class"
                        },
                        new Class()
                        {
                            
                            Name = "Third Class"
                        },
                        new Class()
                        {
                            
                            Name = "Fifth Class"
                        },
                        new Class()
                        {
                            
                            Name = "Sexth Class"
                        },
                        
                    }
                    
                },

                new Stage()
                {
                    
                    Name = "Second Stage",
                    Classes = new List<Class>()
                    {
                        
                        new Class()
                        {
                            
                            Name = "7th Class"
                            
                        },
                        
                        new Class()
                        {
                            
                            Name = "8th Class"
                            
                        },
                        new Class()
                        {
                            
                            Name = "9th Class"
                            
                        }
                        
                    }
                    
                },
                new Stage()
                {
                    
                    Name = "Advanced Stage",
                    Classes = new List<Class>()
                    {
                        
                        
                        new Class()
                        {
                            
                            Name = "10th Class"
                            
                        },
                        
                        
                        new Class()
                        {
                            
                            Name = "11th Class"
                            
                        },
                        
                        new Class()
                        {
                            
                            Name = "12th Class"
                            
                        },
                        
                    }
                }

            };
            
            context.Stages.AddRange(stages);
            context.SaveChanges();
            

        }
        
    }

}