Navigate into `RI.Auth.DataAccess\` and run:

```
dotnet ef --startup-project ..\RI.Auth.Api\ migrations add <migration_name>
```

```
dotnet ef database update --startup-project ..\RI.Auth.Api\
```