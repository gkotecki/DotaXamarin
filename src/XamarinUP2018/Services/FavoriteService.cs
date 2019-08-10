using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinUP2018.Models;
using XamarinUP2018.Repositories;


namespace XamarinUP2018.Services
{
    public interface IFavoriteService
    {
        Task Add(Hero hero);
        Task Edit(Hero hero);
        Task Delete(Hero hero);
        Task<List<Hero>> GetAll();
        Task<Hero> GetById(string id);
        Task<bool> Exists(Hero hero);
    }

    public sealed class FavoriteService : IFavoriteService
    {
        private readonly ILocalDataBaseRepository localDataBaseRepository;

        public FavoriteService(ILocalDataBaseRepository localDataBaseRepository)
        {
            this.localDataBaseRepository = localDataBaseRepository;
        }

        public Task Add(Hero hero) => Task.Run(() => localDataBaseRepository.Add(hero));

        public Task Edit(Hero hero) => Task.Run(() => localDataBaseRepository.Edit(hero));

        public Task Delete(Hero hero) => Task.Run(() => localDataBaseRepository.Delete(hero));

        public Task<List<Hero>> GetAll() => Task.Run(() => localDataBaseRepository.GetAll());

        public Task<Hero> GetById(string id) => Task.Run(() => localDataBaseRepository.GetById(id));

        public Task<bool> Exists(Hero hero) => Task.Run(() => localDataBaseRepository.Exists(hero));
    }
}
