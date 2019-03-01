using System.Collections.Generic;
using System.Linq;

namespace Experiments.Collections
{
    public class RecursiveElement
    {
        public int Id { get; set; }
        public List<int> SubElementIds { get; set; }
        public List<RecursiveElement> AllDescendants { get; set; }

        public void SetAllDescendants(List<RecursiveElement> allElements)
        {
            AllDescendants = GetAllDescendants(allElements);
        }

        public List<RecursiveElement> GetAllDescendants(List<RecursiveElement> allElements)
        {
            var allDescendants = new List<RecursiveElement>();

            foreach (var subElementId in SubElementIds)
            {
                var subElement = allElements.FirstOrDefault(e => e.Id == subElementId);
                if (subElement == null) continue;

                allDescendants.Add(subElement);
                allDescendants.AddRange(subElement.GetAllDescendants(allElements));
            }

            return allDescendants.Distinct().OrderBy(e => e.Id).ToList();
        }
    }
}