using System;
using System.Collections.Generic;

namespace De.Apck.Tools.Filter
{
     public class FilterDefinition
    {
        const string GROUP_START = "(";
        const string GROUP_END = ")"; 
        const string SPACE = " ";
        public FilterDefinition()
        {
            FilterGroups = new List<FilterGroup>();
        }
        public string Operator { get; set; }
        public List<FilterGroup> FilterGroups { get; set; }

        public string ToSql()
        {
            // TODO: Use StringBuilder
            string sql = "";
            int numberOfGroups = FilterGroups.Count;
            foreach (var filterGroup in FilterGroups)
            {
                int numberOfFilter = filterGroup.Filters.Count;
                bool grouping = numberOfFilter > 1 ? true : false;
                if(grouping) sql += GROUP_START;

                foreach (var filter in filterGroup.Filters)
                {
                    // Filter Criteria
                    sql += GROUP_START + filter.Criteria;
                    // Filter operator
                    sql += " " + filter.Operator;
                    // Filter value
                    sql += " " + filter.Value + GROUP_END;
                    // Group operator
                    if(numberOfFilter > 1)
                        sql += SPACE + filterGroup.Operator + SPACE;
                    numberOfFilter--;
                }
                if(grouping) sql += GROUP_END;
                if(numberOfGroups > 1)
                        sql += SPACE + this.Operator + SPACE;
                    numberOfGroups--;
            }

            return sql;
        }
    }
}
