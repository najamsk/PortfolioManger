using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BigApp.Domain.Entities;

using BigApp.Domain.Abstract;

namespace BigApp.Domain.Concrete
{ 
    public class TagRepository : ITagRepository
    {
        BigAppContext context = new BigAppContext();

        public IQueryable<Tag> All
        {
            get { return context.Tags; }
        }

        public IQueryable<Tag> AllIncluding(params Expression<Func<Tag, object>>[] includeProperties)
        {
            IQueryable<Tag> query = context.Tags;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Tag Find(int id)
        {
            return context.Tags.Find(id);
        }

        public void InsertOrUpdate(Tag tag)
        {
            if (tag.TagId == default(int)) {
                // New entity
                context.Tags.Add(tag);
            } else {
                // Existing entity
                context.Entry(tag).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var tag = context.Tags.Find(id);
            context.Tags.Remove(tag);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

   
}



namespace BigApp.Domain.Abstract
{
 public interface ITagRepository : IRepository<Tag>
    {
        
    }
}