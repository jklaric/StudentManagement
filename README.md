# StudentManagement

First compulsory assignment for EASV SD Bachelors.

Database Migration Strategies

This README details two common migration strategies used for database schema changes in the context of Entity Framework (EF): EF Code-First and State-based migration.
We also discuss how and why destructive vs. non-destructive schema changes are implemented.

1.  EF Code-First Migration Strategy
    The EF Code-First approach focuses on creating a class-based schema representation in C# code, and then generating migration scripts based on changes to the model.
    As schema changes occur, EF generates migration scripts that are applied incrementally to bring the database in sync with the latest version of the model.

    First step is to make a change in the models in the code.
    The next step would be running the command "dotnet ef migrations add AddNewTable". This command generates the migration file that details how to update the database.
    Then we run the command "dotnet ef migrations script OldMigrationName NewMigrationName", this generates the script/artifact that can be used to update the database.

    This approach only generates a script that changes the database from the old migration to the new, ignoring any steps that are assumed to have been done already in the previous migration.
    This way of handling migration allows us to save every step taken to achieve the final state of the database and allows us to incrementally update the tables.

2.  State-based Migration Strategy
    In the state-based approach, migrations are based on the final desired schema state. This means that the migration script contains the full set of changes necessary to reach the end state of the schema.
    In state-based migrations, you are specifying how the final schema should look, without relying on incremental migrations.

    The first step is to create all models that the database is based on.
    Then we would run the same command "dotnet ef migrations add AddNewTable".
    After that, we would run almost the same command as before, "dotnet ef migrations script", with one clear difference, we are not specifying the two migrations we are migrating from, and to.
    What this achieves is that the generated script will create the final desired state of the database with all the steps in between. This means that instead of only updating one table for example,
    we will instead run every SQL command to generate the whole database according to the schema and the desired state.

Destructive vs Non-Destructive Schema Changes

    When making changes to your database schema, you must consider whether the changes will require data loss (destructive) or whether the changes can be applied without losing data (non-destructive).

    A destructive change involves removing or modifying existing schema elements in a way that causes data loss. These changes could involve:
    Dropping a column
    Dropping a table
    Changing the type of a column in a way that leads to loss of information.

    An example of a destructive change is when we renamed the Grade column to FinalGrade, because it breaks the existing queries and can lead to data loss.

Non-Destructive Changes

    Non-destructive changes involve modifying the schema without causing any loss of existing data. These changes can include:

    Adding new columns or tables.
    Changing the data type of a column in a way that preserves existing data

    An example of a non destructive change is when we added a new column called MiddleName to the Student table, it does not result in data loss and does not break existing queries.
