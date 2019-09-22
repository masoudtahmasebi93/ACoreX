using ACoreX.Extensions.Base.Abstractions;
using System.Collections.Generic;

namespace ACoreX.WebAPI
{
    public class ApiError
    {
        public bool IsError { get; set; }
        public string ExceptionMessage { get; set; }
        public string Details { get; set; }
        public string ReferenceErrorCode { get; set; }
        public string ReferenceDocumentLink { get; set; }
        public IEnumerable<ValidationError> ValidationErrors { get; set; }

        public ApiError(string message)
        {
            ExceptionMessage = message;
            IsError = true;
        }


    }
}
