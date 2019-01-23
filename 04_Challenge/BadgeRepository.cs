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

        public Dictionary<int, List<string>> GetBadgeInfo()
        {
            return _badges;
        }

        public void AddBadge(Badge badge)
        {
            _badges.Add(badge.BadgeID, badge.DoorName);
        }

        //public void RemoveDoorAccess(int badgeID)
        //{
        //    foreach (KeyValuePair<int, List<string>> badge in _badges)
        //    {
        //        foreach (string door in badge.Value)
        //        {
        //            if (_badges.ContainsKey(badgeID))
        //            {
        //                badge.Value.Remove(string);
        //            }
        //        }
        //    }

        //}
    }
}
