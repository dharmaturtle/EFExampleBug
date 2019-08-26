using System;
using Xunit;
using System.Linq;

namespace XUnitTestProject1 {
  public class UnitTest1 {
    [Fact]
    public void Test1() {
      new EFExampleBugDb()
        .Comment
        .GroupBy(x => x.Post.BlogId)
        .ToList();
    }
  }
}
