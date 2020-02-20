using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionEventos.models
{
    public class MyDBcontext : DbContext
    {
        public MyDBcontext(DbContextOptions<MyDBcontext> options) : base(options)
        {

        }
        public DbSet<Invitados> invitados { get; set; }
    }
    public class Invitados
    {
        [Key]
        public int  idInvitados { get; set; }
        public string  invitados { get; set; }
        
    }
}
