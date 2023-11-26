using System.ComponentModel.DataAnnotations;

namespace EasyMeds.WebAPI.Core.Entities;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
}