using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace npgsql_test
{
  class Program
  {
    static async Task<int> Main(string[] args)
    {
      try
      {
        var orgaIds = new List<Guid> { Guid.Parse("cdaac8b3-57ff-471d-a75e-c262e9d2d89f") };
        var context = new DataContext("...");
        var service = new ProjectService(context);
        var result = await service.GetProjectsAsync(orgaIds);
        Console.WriteLine($"Loaded {result.Count} projects");

        return 0;
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error loading projects {ex.Message}", ex);
        return 1;
      }
    }
  }
}
