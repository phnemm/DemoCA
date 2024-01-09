using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Stores.GetStores
{
    public class GetStoreQuery : IRequest<List<StoreDto>>
    {
    }
}
