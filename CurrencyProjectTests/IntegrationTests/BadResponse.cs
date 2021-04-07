using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyProjectTests.IntegrationTests
{
    public class BadResponseCode
    {
        public string Status { get; set; }
        public string Title { get; set; }
        public ErrorsList Errors { get; set; }
    }

    public class ErrorsList
    {
        public List<string> Code { get; set; }
    }

    public class BadResponseDateFormat
    {
        public string Status { get; set; }
        public string Title { get; set; }
        public ErrorsListFormat Errors { get; set; }
    }

    public class ErrorsListFormat
    {
        public List<string> StartDate { get; set; }
        public List<string> EndDate { get; set; }
    }
}
