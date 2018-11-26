# EfCoreMultipleOwnedEntitiesIssue

Sample project for [EFCore issue #14010](https://github.com/aspnet/EntityFrameworkCore/issues/14010)

#### Repro Steps:
1. Create a migration: `dotnet ef migrations add initial`
2. Run the migration: `dotnet ef database update`
3. You will get the following error message: "The property 'AccountId' on entity type 'MigrationBugRepro.Models.Account.MainAddress#MigrationBugRepro.Models.Address' cannot be marked as nullable/optional because it has been included in a key {'AccountId'}."

If you change the TargetFramework to `netcoreapp2.1` and repeat steps 1 to 3, it will work without issue.
