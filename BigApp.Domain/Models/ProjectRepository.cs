using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BigApp.Domain.Entities;

using BigApp.Domain.Abstract;
using System.Data.Objects;

namespace BigApp.Domain.Concrete
{ 
    public class ProjectRepository : IProjectRepository
    {
        BigAppContext context = new BigAppContext();

        public IQueryable<Project> All
        {
            get { return context.Projects; }
        }

        public IQueryable<Project> AllIncluding(params Expression<Func<Project, object>>[] includeProperties)
        {
            IQueryable<Project> query = context.Projects;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Project Find(int id)
        {
            return context.Projects.Find(id);
        }

        public void InsertOrUpdate(Project project)
        {
            if (project.ProjectId == default(int)) {
                // New entity
                foreach (var tag in project.Tags)
                {
                    context.Entry(tag).State = EntityState.Unchanged;
                }
                context.Projects.Add(project);
            } else {             
                //project.Tags.Clear();
                //context.Entry(project).State = EntityState.Modified;
                //Save();           
                //context.Entry(project).State = EntityState.Modified;
                // Reload project with all tags from DB
                //var projectInDb = context.Projects.Include(p => p.Tags)
                //    .Single(p => p.ProjectId == project.ProjectId);

                //projectInDb.Tags.Clear();

                //foreach (var tag in project.Tags)
                //{
                //    context.Tags.Attach(tag);
                //    projectInDb.Tags.Add(tag);
                   
                //}



                // Reload project with all tags from DB
                var projectInDb = context.Projects.Include(p => p.Tags)
                    .Single(p => p.ProjectId == project.ProjectId);

                // Update scalar properties of the project
                context.Entry(projectInDb).CurrentValues.SetValues(project);

                // Check if tags have been removed, if yes: remove from loaded project tags
                foreach (var tagInDb in projectInDb.Tags.ToList())
                {
                    if (!project.Tags.Any(t => t.TagId == tagInDb.TagId))
                        projectInDb.Tags.Remove(tagInDb);
                }

                // Check if tags have been added, if yes: add to loaded project tags
                foreach (var tag in project.Tags)
                {
                    if (!projectInDb.Tags.Any(t => t.TagId == tag.TagId))
                    {
                        context.Tags.Attach(tag);
                        projectInDb.Tags.Add(tag);
                    }
                }

            }
        }

        public void Delete(int id)
        {
            var project = context.Projects.Find(id);
            context.Projects.Remove(project);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }

   
}



namespace BigApp.Domain.Abstract
{
 public interface IProjectRepository : IRepository<Project>
    {
        
    }
}