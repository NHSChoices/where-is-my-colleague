namespace WhereIsMyColleague.API.Repositories
{
  using Microsoft.WindowsAzure;
  using Microsoft.WindowsAzure.Storage;
  using Microsoft.WindowsAzure.Storage.Table;
  using Models;
  using System.Collections.Generic;
  using System.Linq;

  public class UserRepository : IUserRepository
  {
    private static CloudStorageAccount _storageAccount;
    private static CloudTableClient _tableClient;

    public UserRepository()
      : this("StorageConnectionString")
    {
    }

    public UserRepository(string connectionString)
    {
      if (_storageAccount == null)
        _storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting(connectionString));

      if (_tableClient == null)
        _tableClient = _storageAccount.CreateCloudTableClient();
    }

    public IEnumerable<UserDTO> GetAll()
    {
      var table = Table("whereIsMyColleagueTestStorage");
      var results = (from user in table.CreateQuery<UserDTO>()
        select user).ToList();
      return results;
    }

    public void Register(UserDTO user)
    {
      var table = Table("whereIsMyColleagueTestStorage");

      TableQuery<UserDTO> query = new TableQuery<UserDTO>()
        .Where(TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, user.RowKey));

      var queryList = table.ExecuteQuery(query).ToList();

      if (queryList.Count() != 0)
      {
        foreach (UserDTO entity in queryList)
        {
          TableOperation deleteOperation = TableOperation.Delete(entity);
          table.Execute(deleteOperation);

          TableOperation insertOperation = TableOperation.Insert(user);
          table.Execute(insertOperation);
        }
      }
      else
      {
        TableOperation insertOperation = TableOperation.Insert(user);
        table.Execute(insertOperation);
      }
    }

    public void Delete(string id)
    {
      var table = Table("whereIsMyColleagueTestStorage");
      var retrievedUser = (from user in table.CreateQuery<UserDTO>()
        select user).Where(u => u.RowKey == id).ToList();

      string rowKey = id;
      string partitionKey = "";
      foreach (var user in retrievedUser)
      {
        partitionKey = user.PartitionKey;
      }

      TableOperation retrieveOperation = TableOperation.Retrieve<UserDTO>(partitionKey, rowKey);
      TableResult retrievedResult = table.Execute(retrieveOperation);
      UserDTO deleteEntity = (UserDTO) retrievedResult.Result;
      if (deleteEntity != null)
      {
        TableOperation deleteOperation = TableOperation.Delete(deleteEntity);
        table.Execute(deleteOperation);
      }
    }

    public CloudTable Table(string tableName)
    {
      var table = _tableClient.GetTableReference(tableName);
      table.CreateIfNotExists();

      return table;
    }
  }
}