﻿namespace DefensieTrainer.Domain.DTO.OUT;


public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }

    public string Email { get; set; }
    public float Weight { get; set; }
    public float Length { get; set; }
    public DateTime ArrivalDate { get; set; }
    public string ArmedForce { get; set; }
}

