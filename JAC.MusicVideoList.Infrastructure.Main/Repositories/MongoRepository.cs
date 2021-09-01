using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Domain.Core.Entities.Repository;
using JAC.MusicVideoList.Domain.Core.Interfaces.Repository;
using JAC.MusicVideoList.Infrastructure.Main.Data.ContextMongoDB;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Infrastructure.Main.Repositories
{
    public class MongoRepository<TDocument> : IRepository<TDocument> where TDocument : IDocument
    {
        protected readonly IMongoContext Context;
        private readonly IMongoCollection<TDocument> _collection;
        // public MongoRepository(IMongoContext context)
        public MongoRepository(IMongoSettings settings)
        {
            // Context = context;
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DataBase);
            _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));

            // var db = new MongoClient(options.ConnectionString).GetDatabase(options.DataBase);
            // _collection = Context.GetCollection<TDocument>(typeof(TDocument).Name);
        }
        private static protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault())?.CollectionName;
        }

        public virtual IQueryable<TDocument> AsQueryable()
        {
            return _collection.AsQueryable();
        }

        public virtual IEnumerable<TDocument> FilterBy(
            Expression<Func<TDocument, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).ToEnumerable();
        }

        public virtual IEnumerable<TProjected> FilterBy<TProjected>(
            Expression<Func<TDocument, bool>> filterExpression,
            Expression<Func<TDocument, TProjected>> projectionExpression)
        {
            return _collection.Find(filterExpression).Project(projectionExpression).ToEnumerable();
        }

        public virtual TDocument FindOne(Expression<Func<TDocument, bool>> filterExpression)
        {
            return _collection.Find(filterExpression).FirstOrDefault();
        }

        public virtual Task<TDocument> FindOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => _collection.Find(filterExpression).FirstOrDefaultAsync());
        }

        public virtual TDocument FindById(string id)
        {
            // var objectId = new ObjectId(id);
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
            return _collection.Find(filter).SingleOrDefault();
        }

        public virtual Task<TDocument> FindByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                // var objectId = new ObjectId(id);
                var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
                return _collection.Find(filter).SingleOrDefaultAsync();
            });
        }


        public virtual void InsertOne(TDocument document)
        {
            // probar asi a ver que pasa y si lo necesita async colocarlo en los demás metodos:
            // Context.AddCommand(async () => await _collection.InsertOneAsync(document));

            _collection.InsertOneAsync(document);
            // Context.AddCommand(() => _collection.InsertOneAsync(document));
            // _collection.InsertOne(document);
        }

        public virtual Task InsertOneAsync(TDocument document)
        {
            return Task.Run(() => _collection.InsertOneAsync(document));
        }

        public void InsertMany(ICollection<TDocument> documents)
        {
            _collection.InsertMany(documents);
            // Context.AddCommand(() => _collection.InsertManyAsync(documents));
        }


        public virtual async Task InsertManyAsync(ICollection<TDocument> documents)
        {
            await _collection.InsertManyAsync(documents);
        }

        public void ReplaceOne(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            _collection.FindOneAndReplace(filter, document);
            // Context.AddCommand(() => _collection.ReplaceOneAsync(Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id), document));
        }

        public virtual async Task ReplaceOneAsync(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, document.Id);
            await _collection.FindOneAndReplaceAsync(filter, document);
        }

        public void DeleteOne(Expression<Func<TDocument, bool>> filterExpression)
        {
            // _collection.FindOneAndDelete(filterExpression);
            Context.AddCommand(() => _collection.DeleteOneAsync(filterExpression));
        }

        public Task DeleteOneAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => _collection.FindOneAndDeleteAsync(filterExpression));
        }

        public void DeleteById(string id)
        {
            // var objectId = new ObjectId(id);
            var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
            _collection.FindOneAndDelete(filter);
            // Context.AddCommand(() => _collection.DeleteOneAsync(Builders<TDocument>.Filter.Eq(doc => doc.Id, id)));
        }

        public Task DeleteByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                // var objectId = new ObjectId(id);
                var filter = Builders<TDocument>.Filter.Eq(doc => doc.Id, id);
                _collection.FindOneAndDeleteAsync(filter);
            });
        }

        public void DeleteMany(Expression<Func<TDocument, bool>> filterExpression)
        {
            Context.AddCommand(async () => await _collection.DeleteManyAsync(filterExpression));
        }

        public Task DeleteManyAsync(Expression<Func<TDocument, bool>> filterExpression)
        {
            return Task.Run(() => _collection.DeleteManyAsync(filterExpression));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
