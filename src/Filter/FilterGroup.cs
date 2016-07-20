using System;
using System.Collections.Generic;

namespace De.Apck.Tools.Filter
{ 
    public class FilterGroup
    {
        private List<FilterOperator> _allowedOperators;
        private string _operator;
        public FilterGroup()
        {
            _allowedOperators = new List<FilterOperator>{
                new FilterOperator{ Name = "and", Expression = "and" },
                new FilterOperator{ Name = "or", Expression = "or" }
            };
            Filters = new List<Filter>();
        }
        public string Operator 
        { 
            get { return _operator; }
            set { 
                if(_allowedOperators.Find(o => o.Name == value) == null)
                    throw new ArgumentOutOfRangeException("Invalid group operator: " + value);
                _operator = value; 
            } 
        }
        public List<Filter> Filters { get; set; }
    }
}
