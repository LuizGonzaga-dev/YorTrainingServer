using Microsoft.EntityFrameworkCore;
using YorTrainingServer.Models;

namespace YorTrainingServer.Data
{
    public class SeedData
    {
        public static void Iniciallizar(IServiceProvider serviceProvider)
        {
            using (var context = new YourTrainingDbContext(
               serviceProvider.GetRequiredService<DbContextOptions<YourTrainingDbContext>>()))
            {
                // Verifica se o banco tem alguma academia cadastrada
                if (!context.Academias.Any())
                {
                    context.Academias.Add(
                        new Academia { Name = "Padrao" }
                    );
                    context.SaveChanges();
                }

                context.SaveChanges();
            }
        }
    }
}
