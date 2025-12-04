using System.Collections;

public static class TestDataProvider
{
    public static IEnumerable Cases
    {
        get
        {
            yield return new TestCaseData("Alice", "alice@example.com", 201);
            yield return new TestCaseData("Bob", "bob@example.com", 201);
            yield return new TestCaseData("BadEmail", "invalid", 400);
            yield return new TestCaseData("Duplicate", "existing@example.com", 409);
        }
    }
}
