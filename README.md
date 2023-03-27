
# FerreInvent

This project uses Entity Framework to manage data in a database. Here's how to update the database:

## Updating the Database

To update the database, follow these steps:

1. Set up the database:
   - If you want to use a SQL Server database, make sure you have a database created in SQL Server Management Studio with the name "FerreInvent".
   - If you prefer to use an in-memory database, modify the value of the "UseInMemoryDataBase" property to "true" in the "appsettings.json" file.

2. Create a migration:
   - If you haven't created a migration yet, run the following command in the Package Manager Console to create the first migration:
     ```
     Add-Migration firstMigration
     ```
     This will generate a migration file in the "Migrations" folder of your project.

3. Update the database:
   - To apply the changes defined in the migration to the database, run the following command in the Package Manager Console:
     ```
     Update-Database
     ```
     This command will update the database with all pending migrations.

Note that to successfully update the database, you must ensure that your data model matches the structure of the database. If you make changes to the data model, you will need to generate a new migration and update the database again.

If you use an in-memory database, note that the data will be lost when the application is closed. If you need to keep the data, you will need to use a persistent database, such as SQL Server.
