﻿namespace DbApp1.Models;

public class Classroom
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}