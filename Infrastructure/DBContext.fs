module Infrastructure.DBContext

open FSharp.Data.Sql

[<Literal>]
let evaluationConnectionString = "Server=192.168.1.102;Initial Catalog=EvaluationSystemDB;Persist Security Info=False;User ID=Client;Password=+pk3pNh}cNs_MF8!;TrustServerCertificate=True"

type Sql = SqlDataProvider<Common.DatabaseProviderTypes.MSSQLSERVER, evaluationConnectionString, CaseSensitivityChange = Common.CaseSensitivityChange.ORIGINAL>
let Context = Sql.GetDataContext()