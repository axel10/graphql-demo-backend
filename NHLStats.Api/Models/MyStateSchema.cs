using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;

namespace NHLStats.Api.Models
{
    public class MyStateSchema:Schema
    {
        public MyStateSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<MyStateQuery>();
        }
    }
}
