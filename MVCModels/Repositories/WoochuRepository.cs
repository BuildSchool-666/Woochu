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
            var roomComment = _context.Comments.Where(c => c.RoomId == roomId).ToList();

            roomComment.ForEach(cs =>
            {
                if(!(double.IsNaN(cs.Cleanliness) || double.IsNaN(cs.Accuracy) || double.IsNaN(cs.CheckIn) || double.IsNaN(cs.Communication) || double.IsNaN(cs.Cp) || double.IsNaN(cs.Location)))
                {
                    score += cs.Cleanliness;
                    score += cs.Accuracy;
                    score += cs.CheckIn;
                    score += cs.Communication;
                    score += cs.Cp;
                    score += cs.Location;
                }
                
            });

            var person = roomComment.Count;
            if (person > 0 ) {
                score = score / 6.0 / person;
                return score;
            }
            else
            {
                return double.NaN;
            }
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
