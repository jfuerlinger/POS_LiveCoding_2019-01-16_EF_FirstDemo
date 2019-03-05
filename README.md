# POS LiveCoding (2019-01-16): EF-FirstDemo

## Cheat Sheet

Server Name:
```
(localdb)\MSSQLLocalDb
```

Connection String:
```xml
<add name="ApplicationDbContext" connectionString="data source=(LocalDb)\MSSQLLocalDB;initial catalog=EF_FirstDemo;integrated security=True;" providerName="System.Data.SqlClient" />
```

Important Commands:

```
Enable-Migrations
```

```
Add-Migration <Name>
```

```
Update-Database [-Verbose]
```
