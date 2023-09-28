namespace Users.Models;

public record User
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string Name { get; init; }
    public required string Email { get; init; }
    public required int Age { get; init; }
    public DateTimeOffset RegistrationTime { get; init; } = DateTimeOffset.UtcNow;
}