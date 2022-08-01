using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebAPI.Core.Extensions.Exceptions
{
    public class ValidationErrorDetails : ErrorDetails
    {
        public IEnumerable<ValidationFailure> Errors { get; set; }

        public override string ToString()
        {
            var message = JsonSerializer.Serialize(this);
            return message;
        }
    }
}
