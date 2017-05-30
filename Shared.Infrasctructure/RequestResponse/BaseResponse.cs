using System;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Infrasctructure.RequestResponse
{
    public class BaseResponse<TReturnType> : BaseResponse
    {
        public TReturnType Result { get; set; }
    }

    public class BaseResponse
    {
        public List<Enum> Exceptions { get; set; } = new List<Enum>();
        public bool Success => !Exceptions.Any();
        public string ErrorsMessage => string.Join("; ", Exceptions);
    }
}
