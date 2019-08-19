using SmallCRM.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
namespace SmallCRM.Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext db;
        private readonly DbSet<T> entities;
        private readonly HttpContext httpContext;
        public Repository(ApplicationDbContext context, HttpContext httpContext)
        {
            this.db = context;
            this.entities = context.Set<T>();
            this.httpContext = httpContext;
        }
        public bool Any(Expression<Func<T, bool>> where)
        {
            return entities.Where(where).Any();
        }

        public int Count(Expression<Func<T, bool>> where)
        {
            return entities.Where(where).Count();
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedAt = DateTime.Now;
            entity.DeletedBy = httpContext.User.Identity.GetUserId();
            entity.IpAddress = httpContext.Request.UserHostAddress;
            entity.UserAgent = httpContext.Request.UserAgent;
            entity.Location = ""; // ip veritabanı indirilip üzerinde sorgu yapılarak lokasyon belirlenecek
            Update(entity);
        }

        public T Get(Guid id, bool asNoTracking = false)
        {
            if (asNoTracking == true)
            {
                return entities.Where(x => x.Id == id).AsNoTracking().FirstOrDefault();
            }
            return entities.Where(x => x.Id == id).FirstOrDefault();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return entities.Where(where).FirstOrDefault();
        }

        public T Get(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderBy, bool desc = false)
        {
            return (desc == false ? entities.Where(where).OrderBy(orderBy).FirstOrDefault() : entities.Where(where).OrderByDescending(orderBy).FirstOrDefault());
        }

        public IEnumerable<T> GetAll()
        {
            return entities.Where(x => 1 == 1).OrderBy(o => o.CreatedAt).ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> where)
        {
            return entities.Where(where).OrderBy(o => o.CreatedAt).ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, object>> orderBy, bool desc = false)
        {
            return (desc == false ? entities.Where(x => 1 == 1).OrderBy(orderBy).ToList() : entities.Where(x => 1 == 1).OrderByDescending(orderBy).ToList());
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderBy, bool desc = false)
        {
            return (desc == false ? entities.Where(where).OrderBy(orderBy).ToList() : entities.Where(where).OrderByDescending(orderBy).ToList());
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderBy, bool desc = false, int skip = 0, int take = 10)
        {
            return (desc == false ? entities.Where(where).OrderBy(orderBy).Skip(skip).Take(take).ToList() : entities.Where(where).OrderByDescending(orderBy).Skip(skip).Take(take).ToList());
        }

        public void Insert(T entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.Now;
            entity.CreatedBy = httpContext.User.Identity.GetUserId();
            entity.UpdatedAt = entity.CreatedAt;
            entity.UpdatedBy = entity.CreatedBy;
            entity.IpAddress = HttpContext.Current.Request.UserHostAddress;
            entity.UserAgent = HttpContext.Current.Request.UserAgent;
            entity.Location = "";
            entities.Add(entity);
        }

        public long LongCount(Expression<Func<T, bool>> where)
        {
            return entities.Where(where).LongCount();
        }

        public void Update(T entity)
        {
            var orginalEntity = Get(entity.Id, true);
            entity.CreatedAt = orginalEntity.CreatedAt;
            entity.CreatedBy = orginalEntity.CreatedBy;
            entity.DeletedAt = orginalEntity.DeletedAt;
            entity.DeletedBy = orginalEntity.DeletedBy;
            entity.IsDeleted = orginalEntity.IsDeleted;
            entity.UpdatedAt = DateTime.Now;
            entity.UpdatedBy = httpContext.User.Identity.GetUserId();
            entity.IpAddress = HttpContext.Current.Request.UserHostAddress;
            entity.UserAgent = HttpContext.Current.Request.UserAgent;
            entity.Location = "";
            db.Entry(entity).State = EntityState.Modified; // entity'yi güncellemek üzere işaretle
        }
    }

    public interface IRepository<T> where T: BaseEntity
    {
        // birden fazla kayıt döndüren metotlar:
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll(Expression<Func<T, object>> orderBy, bool desc = false);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderBy, bool desc = false);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderBy, bool desc = false, int skip = 0, int take = 10);

        // belirtilen koşula uyan kayıt sayısını döndüren metotlar:
        int Count(Expression<Func<T, bool>> where);
        long LongCount(Expression<Func<T, bool>> where);

        // koşula uyan ilk kaydı döndüren metotlar:
        T Get(Guid id, bool asNoTracking = false);
        T Get(Expression<Func<T, bool>> where);
        T Get(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderBy, bool desc = false);

        // ekleme işlemi
        void Insert(T entity);

        // güncelleme işlemi
        void Update(T entity);

        // silme işlemi
        void Delete(T entity);

        // koşulan uyan bir kayıt var mı?
        bool Any(Expression<Func<T, bool>> where);
    }
}
