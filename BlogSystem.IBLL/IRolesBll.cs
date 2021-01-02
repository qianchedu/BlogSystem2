using BlogSystem.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.IBLL
{
    public interface IRolesBll
    {
        Task<int> AddRolesAsync(string title);
        
        Task<int> EditRolesAsync(Guid id, string title);

        Task<int> DeleteRolesAsync(Guid id);

        Task<int> GetRolesCountAsync(string title);

        Task<bool> IsExistsAsync(string title);

        Task<List<RolesDto>> GetRolesListByPageAsync(int pageSize, int pageIndex, string title,bool isAsc);

        Task<RolesDto> GetRolesAsync(Guid id);



    }
}
