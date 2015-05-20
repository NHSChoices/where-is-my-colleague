namespace WhereIsMyColleague.API.Models
{
  using Microsoft.WindowsAzure.Storage.Table;

  public class UserDTO : TableEntity
  {
    public UserDTO(string partitionKey, string rowKey)
    {
      PartitionKey = partitionKey;
      RowKey = rowKey;
    }

    public UserDTO()
    {
    }

    public string Duration { get; set; }
    public string SecondLocation { get; set; }
    public string TimeStamp { get; set; }
    public bool IsHalfDay { get; set; }
  }
}