using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{

    public class Vector2D
    {

        private int ListId;
        private int elementId;
        private IList<IList<int>> lists;

        public Vector2D(IList<IList<int>> vec2d)
        {
            lists = vec2d;
            ListId = 0;
            elementId = 0;
        }

        public bool HasNext()
        {

            if (lists == null || lists.Count == 0) return false;

            if (ListId == lists.Count - 1 && elementId == (lists[lists.Count - 1].Count)) return false;

            if (elementId == (lists[ListId].Count))
            {
                ListId++;
                while (ListId < lists.Count && (lists[ListId] == null || lists[ListId].Count == 0))
                {
                    ListId++;
                }

                if (ListId == lists.Count) return false;
                else
                {
                    elementId = 0;
                }
            }

            return true;
        }

        public int Next()
        {

            IList<int> currentList = lists[ListId];
            return currentList[elementId++];
        }
    }

    /**
     * Your Vector2D will be called like this:
     * Vector2D i = new Vector2D(vec2d);
     * while (i.HasNext()) v[f()] = i.Next();
     */
}
