using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;

namespace API.Helper
{
    public class Pagination<T> where T : class
    {
        public Pagination(int pageIndex, int pageSize, IReadOnlyList<T> data, int productsCount)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Data = data;
            Count = productsCount;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<T> Data { get; set; }
    }
}