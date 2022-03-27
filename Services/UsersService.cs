using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UsersService
    {
        private readonly ChatDbContext _context;

        public UsersService(ChatDbContext context)
        {
            _context = context;
        }

        public List<Users> GetAll()
        {
            return _context.Users.ToList();    
        }
    }
}
