using System;
using System.Collections.Generic;

namespace Hitay.Common
{
    public class ServiceResult<T>
    {
        public ServiceResult()
        {
            ValidationMessages = new List<string>();
        }

        public bool HasError { get; set; }
        public Exception Exception { get; set; }
        public List<string> ValidationMessages { get; set; }
        public T Result { get; set; }
        public int TotalItemCount { get; set; }
    }
}
