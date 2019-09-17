using ACoreX.Core.BaseExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACoreX.Infrastructure.BaseExtensions
{
    public class CustomException : Exception
    {
        public IEnumerable<ValidationError> Errors { get; set; }

        public int? Code { get; set; }
        public string ReferenceDocumentLink { get; set; }

        public CustomException(string message,
                            int? code = null,
                            IEnumerable<ValidationError> errors = null,
                            string refLink = "") :
            base(message)
        {
            this.Errors = errors;
            this.Code = code;
            this.ReferenceDocumentLink = refLink;
        }

        public CustomException(Exception ex, int? code = null) : base(ex.Message)
        {
            Code = code;
        }
    }
}
