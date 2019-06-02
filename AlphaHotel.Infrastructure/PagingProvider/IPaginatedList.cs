using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaHotel.Infrastructure.PagingProvider
{
    public interface IPaginatedList<T>
    {
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
        int PageIndex { get; }
        int TotalPages { get; }
        List<T> Items { get; }
        string CurrentFilter { get; set; }
        Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize, string keyword);
    }
}