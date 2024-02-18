using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureUdemyCourse.Domain.Validation
{
    public class DomainExceptoinValidation : Exception
    {
        public DomainExceptoinValidation(string error) : base(error)
        {
            
        }

        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomainExceptoinValidation(error);
        }
    }
}
