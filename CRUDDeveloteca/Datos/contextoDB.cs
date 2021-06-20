using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUDDeveloteca.Models;

namespace CRUDDeveloteca.Datos
{
    public class contextoDB:DbContext
    {
        public contextoDB( DbContextOptions<contextoDB> options ) : base(options)
        {

        }

        public DbSet<CitaModel> citas { get; set; }
    }
}
