# Library Database Final Project (CS4092) - README
This database structure manages a library system with books, movies, members, employees, and borrowing transactions.
## Contributors
- Abby Kraft
- Veronica Malusky
- Jake Martin
- Sophia Munoz
## Database Tables Overview
1. Employees
- Employee_ID (PK)
- Employee_Name
- Email_Address
- Street, City, State, Zip
- Related: Employee_Phone_Numbers (separate table for multiple phone numbers)

2. Books
- BookID (PK)
- Book_Name
- ISBN
- Author

3. Movies
- MovieID (PK)
- Movie_Title
- Director
- Duration
- Release_Date
- Genre

4. Members
- memberID (PK)
- Name
- Email
- Street, City, State, Zip
- Related: Member_Phone_Numbers (separate table for multiple phone numbers)

5. Library Cards
- cardID (PK)
- memberID (FK to Members)
- creationDate
- expirationDate
- fees

6. Borrowed Books
- borrowed_book_id (PK)
- bookID (FK to Books)
- memberID (FK to Members)
- due_date
- return_date

7. Borrowed Movies
- borrowed_movies_id (PK)
- MovieID (FK to Movies)
- memberID (FK to Members)
- due_date
- return_date

8. Checkouts
- check_outs_id (PK)
- memberID (FK to Members)
- employeeID (FK to Employees)
- checkout_date

## Key Relationships
- Members can borrow multiple books/movies (one-to-many)
- Each member has exactly one library card (one-to-one)
- Employees process checkouts for members (many-to-many)
- Books and movies maintain borrowing history with members

This structure supports all core library operations including inventory management, member services, and transaction tracking.
