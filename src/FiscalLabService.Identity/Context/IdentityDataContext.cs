using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FiscalLabService.Identity.Context;

public class IdentityDataContext : IdentityDbContext
{
    public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options)
    {
        
    }
}