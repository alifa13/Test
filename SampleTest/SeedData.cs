public static class SeedData
{
    public static IEnumerable<User> Users = new List<User>
    {
        new() { Name = "Reza", Email = "Reza@example.com" },
        new() { Name = "Ali", Email = "Ali@example.com" },
        new() { Name = "Asghar", Email = "Asghar@example.com" },
    }
}
