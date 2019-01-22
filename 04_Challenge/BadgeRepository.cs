using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Challenge
{
    public class BadgeRepository
    {
        Dictionary<int, List<string>> _badges = new Dictionary<int, List<string>>();

        //public void AddBadge(int badgeID, List<string> doorName)
        //{
        //    _badges.Add(badgeID, doorName);
        //}

        public Dictionary<int, List<string>> GetBadgeInfo()
        {
            return _badges;
        }

        public void AddBadge(Badge badge)
        {
            _badges.Add(badge.BadgeID, badge.DoorName);
        }

        public void RemoveBadgeAccess(Badge badge)
        {
          //  _badges.Remove(badge.DoorName);
        }

        public void RemoveDoorAccess(Badge badge)
        {
            foreach (KeyValuePair<int, List<string>> badge in _badges)
            {
                Console.WriteLine("Badge ID#\t\t Door Access");
                Console.Write($" {badge.Key}\t\t");
                foreach (string door in badge.Value)
                {
                    Console.Write($"\t\t{door}");
                }
            }
            Console.ReadLine();
        }
    }
}
