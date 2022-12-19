using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace EmployeeAPI_CRUD.Models;

public partial class Employee
{
    public Employee()
    {
    }

    public Guid Id { get; set; }

    public string? FullName { get; set; }

    [DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public int? Age { get; set; }

    public DateTime? DateCreated { get; set; }

    public bool? IsDeleted = false;
}
