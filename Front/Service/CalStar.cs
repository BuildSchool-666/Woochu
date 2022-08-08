using Front.Models.DTOModels;
using MVCModels.DataModels;
using MVCModels.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Front.Service
{
    public static class CalStar
    {
        //private readonly WoochuRepository _repo;

        //public CalStar(WoochuRepository repo)
        //{
        //    _repo = repo;
        //}

        public static double CalRoomStar(WoochuRepository _repo, int roomId)
        {
            double score = 0;
            var roomComment = _repo.GetAll<MVCModels.DataModels.Comment>().Where(c => c.RoomId == roomId).ToList();

            roomComment.ForEach(cs =>
            {
                List<double> stars = new List<double> { cs.Cleanliness, cs.Accuracy, cs.CheckIn, cs.Communication, cs.Location, cs.Cp };
                if (!( stars.Any(s => double.IsNaN(s))))
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
            if (person > 0)
            {
                score = score / 6.0 / person;
                return score;
            }
            else
            {
                return double.NaN;
            }
        }
        public static double CalPersonStar(double CleanlinessStar, double AccuracyStar, double CommunicationStar, double LocationStar, double CheckInStar, double ValueStar)
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
