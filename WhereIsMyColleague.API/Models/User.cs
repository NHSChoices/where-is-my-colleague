namespace WhereIsMyColleague.API.Models
{
  using System.ComponentModel.DataAnnotations;
  using Microsoft.WindowsAzure.Storage.Table;

  public class User : TableEntity
  {
    public User(string partitionKey, string rowKey)
    {
      PartitionKey = partitionKey;
      RowKey = rowKey;
    }

    public User()
    {
    }

    [Required]
    public string Duration { get; set; }
  }
}