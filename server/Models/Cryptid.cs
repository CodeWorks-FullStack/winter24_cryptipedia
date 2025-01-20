using System.ComponentModel.DataAnnotations;

namespace cryptipedia.Models;

public class Cryptid : RepoItem<int> // int is the type of id
{
  // id, createdAt, updatedAt inherited from repo item
  public string Name { get; set; }
  [MaxLength(10000)] public string Description { get; set; }
  [Url, MaxLength(3000)] public string ImgUrl { get; set; }
  [Range(0, 10)] public int ThreatLevel { get; set; }
  [Range(0, 10)] public int Size { get; set; }
  public string Origin { get; set; }
  public string DiscovererId { get; set; }
  public Profile Discoverer { get; set; }
}