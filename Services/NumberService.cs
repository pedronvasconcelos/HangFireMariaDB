using Hangfire;
using HangFirePOC.Models;
using HangFirePOC.Repositories;

namespace HangFirePOC.Services
{
    [DisableConcurrentExecution(60)]
    public class NumberService : INumberService
    {
        private readonly MyDbContext _dbContext;

        public NumberService (MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<NumberDraw> GenerateRandomNumberDrawn()
        {
            Task.Delay(30000).Wait();

            var randomNumber = new Random().Next();
            var numberDraw = new NumberDraw
            {
                Number = randomNumber,
                Date = DateTime.Now 
            };

            await _dbContext.NumberDraws.AddAsync(numberDraw);
            await _dbContext.SaveChangesAsync();
            return numberDraw;
        }
    }

    [DisableConcurrentExecution(60)]
    public interface INumberService2
    {
        Task<NumberDraw> GenerateRandomNumberDrawn();
    }

    public class NumberService2 : INumberService2
    {
        private readonly MyDbContext _dbContext;

        public NumberService2(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<NumberDraw> GenerateRandomNumberDrawn()
        {
            Task.Delay(30000).Wait();   
            var randomNumber = new Random().Next();
            var numberDraw = new NumberDraw
            {
                Number = randomNumber,
                Date = DateTime.Now
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
