namespace WhereIsMyColleague.API.Models
{
  using Microsoft.WindowsAzure.Storage.Table;
  using System.ComponentModel.DataAnnotations;

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