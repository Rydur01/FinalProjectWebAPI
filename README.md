# FinalProject
Assignment InstructionsDevelop a ASP.NETWebAPI, using Git as a code repository.Each member of your team should have at least one commit to the project. I would recommend splitting the project into equal parts(the best you can).The WebAPI should conform to the following specifications.

* Use the latest version of dotnet core
* Connect to a database using Entity Framework Core
* The API should consist of four controllers. Each attaching to its own table
  * At least one of the tables should consist of the following information:
    * Team member full name
    * Birthdate (datetime)
    * College Program
    * Year in program: Freshman, Sophomore, etc.
  * 3 other tables are your choice. Hobby, favorite breakfast foods, etc.  Foreign key relationships not needed. But each table mustconsist of at least 5 columns, including the primary key column
  * Each Controller should consist of all CRUD operations to interact with the underlying table (Create, Read [single or multiple, see below], Update, Delete).
  * The Read operation for each method should take in a nullable id (int). If null or zero is provided for the id, return the first five results from the table.
* Use NSwag package library as a means to view each controller and its actions

<ins>Note: Follow Acceptance Criteria for each assignment. Incomplete Acceptance Criteria will not be graded and need to be re-submitted with a late penalty attached.</ins>

## Acceptance Criteria
  1. Link to your Git repository.
  2. A 5 (maximum) minute team presentation of your web application (you can use Teams and simply record your session or use any screen capture of your choice.)
     * Make sure each team member has a speaking portion.
     * I recommend each member speaks on their contribution to the project.
