using BlogSystem.Dtos;
using BlogSystem.IBLL;
using BlogSystem.IDAL;
using BlogSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.BLL
{
    public class RolesBLL : IRolesBll
    {
        private IRolesDal _dal;
        public RolesBLL(IRolesDal dal)
        {
            _dal = dal;
        }


        public async Task<int> AddRolesAsync(string title)
        {
            return await _dal.AddAsync(new Roles()
            {
                Title = title
            });
        }

        public async Task<int> DeleteRolesAsync(Guid id)
        {
            var data = await _dal.QueryAsync(id);
            if(data == null)
            {
                return -2;
            }
            else
            {
                return await _dal.DeleteAsync(data);
            }
        }

        public async Task<int> EditRolesAsync(Guid id, string title)
        {
            var data = await _dal.QueryAsync(id);
           if (data == null)
            {
                return -2;      //-2代表的是数据不存在
            }
            else
            {
                data.Title = title;
                data.UpdateTime = DateTime.Now;
                return await _dal.EditAsync(data);
            }
        }

        public async Task<RolesDto> GetRolesAsync(Guid id)
        {
            var data = await _dal.QueryAsync(id);
            if(data == null)
            {
                return new RolesDto();
            }
            else
            {
                return new RolesDto()
                {
                    Id = data.Id,
                    Title = data.Title,
                    UpdateTime = data.UpdateTime
                };
            }
        }

        public async Task<int> GetRolesCountAsync(string title)
        {
            return await _dal.GetCountsAsync(r => r.Title.Contains(title));
        }

        public async Task<List<RolesDto>> GetRolesListByPageAsync(int pageSize, int pageIndex, string title, bool isAsc)
        {
            return _dal.QueryByPage(pageSize, pageIndex,
                r => r.Title.Contains(title), isAsc)
                .Select(
                r=>new RolesDto()
                    { 
                        Id = r.Id,
                        Title = r.Title,
                        UpdateTime = r.UpdateTime
                    }
                ).ToList();
        }

        public async Task<bool> IsExistsAsync(string title)
        {
            return await _dal.IsExistsAsync(r => r.Title.Equals(title));
        }
    }
}
