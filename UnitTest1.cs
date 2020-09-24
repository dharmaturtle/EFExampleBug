using System;
using Xunit;
using System.Linq;
using Npgsql;
using Dapper;
using NodaTime;
using System.Threading.Tasks;
using Dapper.NodaTime;
using System.Data;
using System.Data.SqlClient;

namespace XUnitTestProject1 {

  // from https://github.com/mj1856/Dapper-NodaTime/blob/master/src/Dapper.NodaTime/InstantHandler.cs
  public class InstantHandler : SqlMapper.TypeHandler<Instant> {
    private InstantHandler() {
    }

    public static readonly InstantHandler Default = new InstantHandler();

    public override void SetValue(IDbDataParameter parameter, Instant value) {
      parameter.Value = value.ToDateTimeUtc();

      if (parameter is SqlParameter sqlParameter) {
        sqlParameter.SqlDbType = SqlDbType.DateTime2;
      }
    }

    public override Instant Parse(object value) {
      if (value is DateTime dateTime) {
        var dt = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        return Instant.FromDateTimeUtc(dt);
      }

      if (value is DateTimeOffset dateTimeOffset) {
        return Instant.FromDateTimeOffset(dateTimeOffset);
      }

      throw new DataException("Cannot convert " + value.GetType() + " to NodaTime.Instant");
    }
  }

  public class UnitTest1 {
    [Fact]
    public async Task Test1() {
      new EFExampleBugDb()
        .alpha_beta_key
        .ToList();

      SqlMapper.AddTypeHandler(InstantHandler.Default);
      var conn = new NpgsqlConnection("Host=localhost;Database=CardOverflow;Username=postgres;");
      await conn.OpenAsync();
      var dateCounts = await conn.QueryAsync<object>("SELECT * FROM history WHERE created >= @yearishago", new { yearishago = SystemClock.Instance.GetCurrentInstant() });
    }

  }
}
