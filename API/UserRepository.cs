using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _contex;
        private readonly IMapper _mapper;
        public UserRepository(DataContext contex, IMapper mapper)
        {
            _mapper = mapper;
            _contex = contex;
        }

        public async Task<MemberDto> GetMemberAsync(string username)
        {
            return await _contex.Users
                .Where(x => x.UserName == username)
                .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await _contex.Users
            .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _contex.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _contex.Users
            .Include(p => p.Photos)
            .SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _contex.Users
            .Include(p => p.Photos)
            .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _contex.SaveChangesAsync() > 0;
        }

        public void Update(AppUser user)
        {
            _contex.Entry(user).State = EntityState.Modified;
        }
    }
}