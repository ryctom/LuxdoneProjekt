using System;
using System.Text;

namespace CurrencyProject.Exceptions
{
    public class NotSupportedCurrencyException : Exception
    {
        public readonly string _defaultMessage = "{0} currency is not supported by this service";
        private readonly string _exceptionMessage;

        public NotSupportedCurrencyException(string code)
        {
            _exceptionMessage = new StringBuilder().AppendFormat(_defaultMessage, code).ToString();
        }

        public override string Message
        {
            get { return _exceptionMessage; }
        }
    }
}
