﻿namespace EasyMeds.WebAPI.Core.Entities;

public class Medicine : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string SideEffects { get; set; }
    public string Interactions { get; set; }
    public List<Medication> Medications { get; set; }
}