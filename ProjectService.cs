using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace npgsql_test
{
  public class ProjectService
  {
    private readonly DataContext _context;

    public ProjectService(DataContext context)
    {
      _context = context;
    }

    public async Task<List<Project>> GetProjectsAsync(List<Guid> orgaIds, CancellationToken cancellationToken = default)
    {
      return await _context.Project.Where(p => orgaIds.Contains(p.OrganisationId)).ToListAsync(cancellationToken);
    }
  }
}
