using LiteDB;
using System.Collections.Generic;
using System.Linq;
using XamarinUP2018.Models;
using XamarinUP2018.Services;

namespace XamarinUP2018.Repositories
{
    public sealed class LocalDataBaseRepository : ILocalDataBaseRepository
    {
        private const string COLLECTION_NAME = "heros";

        private readonly LiteCollection<Hero> liteCollection;
        private readonly IDataBaseAccessService dataBaseAccessService;

        public LocalDataBaseRepository(IDataBaseAccessService dataBaseAccessService)
        {
            this.dataBaseAccessService = dataBaseAccessService;
            liteCollection = GetCollection();
        }

        public void Add(Hero hero) => liteCollection.Insert(hero);

        public void Delete(Hero hero) => liteCollection.Delete(hero.Id);

        public void Edit(Hero hero) => liteCollection.Update(hero);

        public List<Hero> GetAll() => liteCollection.FindAll().ToList();

        public Hero GetById(string id) => liteCollection.FindById(id);

        public bool Exists(Hero hero) => liteCollection.FindById(hero.Id) != null;

        private LiteCollection<Hero> GetCollection()
        {
            var db = GetOrCreateLiteDatabase();
            return db.GetCollection<Hero>(COLLECTION_NAME);
        }

        private LiteDatabase GetOrCreateLiteDatabase()
        {
            var dbPath = dataBaseAccessService.GetDataBasePath();
            return new LiteDatabase($@"{dbPath}");
        }
    }
}
