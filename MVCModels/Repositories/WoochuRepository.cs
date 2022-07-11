using Microsoft.EntityFrameworkCore;
using MVCModels.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCModels.Repositories
{
    public class WoochuRepository
    {
        private WoochuContext _context;
        public WoochuRepository(WoochuContext context)
        {
            if (context == null) { throw new ArgumentNullException(); }
            _context = context;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public void Create<T>(T value) where T : class
        {
            _context.Entry(value).State = EntityState.Added;
        }
        public void Update<T>(T value) where T : class
        {
            _context.Entry(value).State = EntityState.Modified;
        }
        public void Delete<T>(T value) where T : class
        {
            _context.Entry(value).State = EntityState.Deleted;
        }
        public IQueryable<T> GetAll<T>() where T : class
        {
            return _context.Set<T>();
        }
        public double CalStar(int roomId)
        {
            double score = 0;
            _context.Comments.Where(c => c.RoomId == roomId).ToList().ForEach(c =>
            {
                score += (double)c.Cleanliness;
                score += (double)c.Accuracy;
                score += (double)c.CheckIn;
                score += (double)c.Communication;
                score += (double)c.Cp;
            });
            int person = _context.Comments.Count(c => c.RoomId == roomId);

            score = score / 5 / person;
            return score;
        }
    }
}
