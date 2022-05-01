using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResidenceManagement.Application.Responses
{
    public class BaseDataResponse<T>
    {

        public BaseDataResponse(bool status)
        {
            Status = status;
        }

        public BaseDataResponse(bool status, T entity) : this(status)
        {

            Entity = entity;
        }
        public bool Status { get; set; }
        public T Entity { get; set; }
    }
}
