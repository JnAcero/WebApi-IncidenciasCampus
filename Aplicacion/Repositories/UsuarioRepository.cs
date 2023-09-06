using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Persistencia;

namespace Aplicacion.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuario
    {
        public UsuarioRepository(ApiIncidenciasDbContext context) : base(context)
        {
        }

        public async Task<Usuario> FindByUserNameAndPassword(string username, string password)
        {
            var user = await _context.Usuarios
            .Where(u =>u.NombreUsuario.ToLower() == username.ToLower() && u.Password == password)
            .Include(u =>u.UsuariosRoles)
            .FirstOrDefaultAsync();
            return user;
        }

        public async Task<Usuario> FindUserByUserName(string userName)
        {
           var user = await _context.Usuarios
           .Where( u => u.NombreUsuario.ToLower() == userName.ToLower() )
           .Include(u =>u.UsuariosRoles)
                .ThenInclude(ur =>ur.Rol)
           .FirstOrDefaultAsync()
           ;
           return user;
        }
        public override async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            var users = await _context.Usuarios
            .Include(u =>u.UsuariosRoles)
            .ThenInclude(ur => ur.Rol).ToListAsync();
            return users;
        }
        

       
    }
}