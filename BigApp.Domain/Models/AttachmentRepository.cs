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
    public class AttachmentRepository : IAttachmentRepository
    {
        BigAppContext context = new BigAppContext();

        public IQueryable<Attachment> All
        {
            get { return context.Attachments; }
        }

        public IQueryable<Attachment> AllIncluding(params Expression<Func<Attachment, object>>[] includeProperties)
        {
            IQueryable<Attachment> query = context.Attachments;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Attachment Find(int id)
        {
            return context.Attachments.Find(id);
        }

        public void InsertOrUpdate(Attachment attachment)
        {
            if (attachment.Id == default(int)) {
                // New entity
                context.Attachments.Add(attachment);
            } else {
                // Existing entity
                context.Entry(attachment).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var attachment = context.Attachments.Find(id);
            context.Attachments.Remove(attachment);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

   
}



namespace BigApp.Domain.Abstract
{
 public interface IAttachmentRepository : IRepository<Attachment>
    {
        
    }
}