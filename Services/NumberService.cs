using HangFirePOC.Models;
using HangFirePOC.Repositories;

namespace HangFirePOC.Services
{
    public class NumberService : INumberService
    {
        private readonly MyDbContext _dbContext;

        public NumberService (MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<NumberDraw> GenerateRandomNumberDrawn()
        {
            var randomNumber = new Random().Next();
            var numberDraw = new NumberDraw
            {
                Number = randomNumber
            };

            await _dbContext.NumberDraws.AddAsync(numberDraw);
            await _dbContext.SaveChangesAsync();
            return numberDraw;
        }
    }


    public interface INumberService
    {
        Task<NumberDraw> GenerateRandomNumberDrawn();
    }
}
