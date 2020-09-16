using System;
using Xunit;
using System.Linq;
using Npgsql;

namespace XUnitTestProject1 {
  public class UnitTest1 {
    [Fact]
    public void Test1() {
      NpgsqlConnection.GlobalTypeMapper.UseNodaTime();
      new EFExampleBugDb()
        .alpha_beta_key
        .ToList();
    }
  }
}
