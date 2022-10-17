### Requirement: 

1. Make all test cases pass
2. Don't delete and create database when application run again
3. Add migration code for each entity created
4. Add unit test for CompanyService


#### Tips:


1. use Entity Framework Core tools create migration code 
```
dotnet ef migrations add InitialCreate
```
2. use Entity Framework Core tools execute migration code
```
dotnet ef database update
```
3. view table structure with MySQL Workbench

