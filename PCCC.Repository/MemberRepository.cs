﻿using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using PCCC.Common.DTOs.Users;
using PCCC.Common.Utils;
using PCCC.Data;
using PCCC.Data.Entities;
using PCCC.Repository;
using PCCC.Repository.Interfaces;

namespace PCCC.Repository
{
    public class MemberRepository : BaseRepository<User>, IMemberRepository
    {
        public MemberRepository(PcccContext dbContext) : base(dbContext)
        {

        }

        public async Task<IPagedList<UserModel>> GetMembers(UserSearchPageResults param)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var model = (from u in DbContext.Users
                                 where (u.IsDelete && u.Level == PCCCConsts.Member && !string.IsNullOrEmpty(param.SearchKey) ? (u.UserName.Contains(param.SearchKey) || u.Phone.Contains(param.SearchKey)) : true)
                                 && (param.IsActive.HasValue ? u.IsActive == param.IsActive : true)
                                 select new UserModel
                                 {
                                     Id = u.Id,
                                     Email = u.Email,
                                     Phone = u.Phone,
                                     UserName = u.UserName,  
                                     IsActive = u.IsActive,
                                     FullName = u.FullName,
                                     Address = u.Address,
                                     Amount = u.Amount,
                                     Sex = u.Sex,
                                     CreatorUserName = u.CreatorUserName,
                                     Password = u.Password,
                                     CreationTime = u.CreationTime,

                                 }).AsQueryable().ToPagedList(param.page, param.perPage);
                    return model;   
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
