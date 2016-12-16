using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarRestSharp.RestApiCalls.Requests
{
    internal class JsonPredicate
    {
        public JsonPredicate(string propertyName, QueryOperator queryOperator, string value, string fromValue, string toValue)
        {
            PropertyName = propertyName;
            Operator = queryOperator;
            Value = value;
            FromValue = fromValue;
            ToValue = toValue;
        }

        public string PropertyName { get; set; }

        public QueryOperator Operator { get; set; }

        public string Value { get; set; }

        public string FromValue { get; set; }

        public string ToValue { get; set; }

        public bool IsNumeric { get; set; }
    }
}
