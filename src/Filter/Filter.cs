using System;
using System.Collections.Generic;

namespace De.Apck.Tools.Filter
{ 
    public class Filter
    {
        private const string STRING_PRE_POST_FIX = "\"";
        private const string DATETIME_PREFIX = "DateTime(\"";
        private const string DATETIME_POSTFIX = "\")";
        private List<FilterOperator> _operators;
        private Dictionary<string, FilterValueType> _valueType;
        private string _criteria;
        private string _operator;
        private string _value;
        public string Criteria { 
            get { return _criteria; } 
            set { 
                if(string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Criteria missing");
                _criteria = value;
            } 
        }
        public string Operator { 
            get { return _operators.Find(o => o.Name == _operator).Expression; } 
            set { 
                if(string.IsNullOrEmpty(value) || _operators.Find(o => o.Name == value) == null)
                    throw new ArgumentOutOfRangeException("Inavlid filter operator: " + value);
                _operator = value;
            } 
        }
        public string Value { 
            get { 
                switch(_valueType[Criteria])
                {
                    case FilterValueType.String:
                        return STRING_PRE_POST_FIX + _value + STRING_PRE_POST_FIX;
                    case FilterValueType.Int:
                        return _value;
                    case FilterValueType.Date:
                        return DATETIME_PREFIX + _value +  DATETIME_POSTFIX;                        
                }            
                throw new ArgumentNullException("Value missing!");
            } 
            set {
                if(string.IsNullOrEmpty(value))
                    throw new  ArgumentNullException("Value missing!");
                _value = value;
            } 
        }
        public Filter()
        {
            _operators = new List<FilterOperator>{
                new FilterOperator{ Name = "Equals", Expression = "=" },
                new FilterOperator{ Name = "NotEquals", Expression = "!=" },
                new FilterOperator{ Name = "GreaterThan", Expression = ">" },
                new FilterOperator{ Name = "LessThan", Expression="<" },
                new FilterOperator{ Name = "Between" }
            };
            _valueType = new Dictionary<string, FilterValueType>();
            _valueType.Add("Value", FilterValueType.Int);
            _valueType.Add("Type", FilterValueType.String);
            _valueType.Add("Category", FilterValueType.String);
            _valueType.Add("Date", FilterValueType.Date);
        }
    }
}
