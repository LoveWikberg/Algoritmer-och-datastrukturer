using System;
using System.Collections.Generic;
using System.Text;

namespace Inlämningsuppgift3
{
    static class Search
    {
        static public T[] CustomWhere<T>(this T[] members, Func<T, bool> selector)
        {
            List<T> searchResult = new List<T>();
            for (int i = 0; i < members.Length; i++)
            {
                if (selector(members[i]))
                {
                    searchResult.Add(members[i]);
                }
            }

            return searchResult.ToArray();
        }
    }
}
