using System;

namespace informatica_fstival.Models
{
    public class Person
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
