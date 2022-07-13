using Microsoft.EntityFrameworkCore;
using MVCModels.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Front.Models.ViewModels.RoomDetail;

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
        public double CalRoomStar(int roomId)
        {
            double score = 0;
            _context.Comments.Where(c => c.RoomId == roomId).ToList().ForEach(cs =>
            {
                score += cs.Cleanliness;
                score += cs.Accuracy;
                score += cs.CheckIn;
                score += cs.Communication;
                score += cs.Cp;
                score += cs.Location;
            });
            double person = _context.Comments.Count(c => c.RoomId == roomId);

            score = score / 6.0 / person;
            return score;
        }
        public double CalPersonStar(double CleanlinessStar, double AccuracyStar, double CommunicationStar, double LocationStar, double CheckInStar, double ValueStar)
        {
            double score =
                CleanlinessStar
                + AccuracyStar
                + CommunicationStar
                + LocationStar
                + CheckInStar
                + ValueStar;

            score /= 6;
            decimal.Round((decimal)score, 1);
            return score;
        }
    }
}
