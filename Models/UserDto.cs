using System.ComponentModel.DataAnnotations;

namespace Users.Models;

public record UserDto(Guid Id, string Name, string Email, int Age, DateTimeOffset RegistrationTime);

public record CreateUserDto
{
    [Required]
    public required string Name { get; init; }

    [Required]
    public required string Email { get; init; }

    [Required]
    [Range(0, 100)]
    public required int Age { get; init; }
}

public record UpdateUserDto
{
    [Required]
    public required string Name { get; init; }

    [Required]
    public required string Email { get; init; }

    [Required]
    [Range(0, 100)]
    public required int Age { get; init; }
}