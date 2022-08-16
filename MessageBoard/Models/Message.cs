using System.ComponentModel.DataAnnotations;
using System;

namespace MessageBoard.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    [Required]
    [StringLength(30)]
    public string Name { get; set; }
    [Required]
    public string Comment { get; set; }
    [Required]
    [StringLength(30, ErrorMessage = "A username is needed to post")]
    public string User { get; set; }
    public string PostDate { get; set; }
      }
}