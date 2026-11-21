using System.ComponentModel.DataAnnotations;

namespace StudentCourseRegistration.Models;

public class Student
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Course is required.")]
    [StringLength(60, MinimumLength = 2, ErrorMessage = "Course must be between 2 and 60 characters.")]
    public string Course { get; set; } = string.Empty;

    [Required(ErrorMessage = "Semester is required.")]
    [Range(1, 8, ErrorMessage = "Semester must be a number from 1 to 8.")]
    public int? Semester { get; set; }
}