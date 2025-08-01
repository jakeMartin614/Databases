
-- Employee Table--
-- employee_id, name, email, phonenumber, street, city, state, zip --
INSERT INTO employees VALUES ( 01, "Bob", "Bob@gmail.com", "5131231234", "123 Calhoun Street", "Cincinnati", "Ohio", "45219" );
INSERT INTO employees VALUES ( 02, "Lisa", "Lisa@gmail.com", "5131231245", "130 Clifton Ave", "Cincinnati", "Ohio", "45219" );
INSERT INTO employees VALUES ( 03, "Frank", "Frank@gmail.com", "5131231256", "1001 McMillan Street", "Cincinnati", "Ohio", "45219" );

-- Books Table--
-- book_id, book_name, isbn, author --
INSERT INTO books VALUES ( 01, "The Great Gatsby", 1001,"F. Scott Fitzgerald" );
INSERT INTO books VALUES ( 02, "Frankenstein", 1002,"Mary Shelley" );
INSERT INTO books VALUES ( 03, "To Kill a Mockingbird", 1003,"Harper Lee" );

-- Movies Table-- 
-- movie_id, title, director, durration, release_date (YYYY-MM-DD), genre --
INSERT INTO movies VALUES ( 01, "Jurassic Park","Steven Spielberg", 127, 1993-06-09, "Science Fiction" );
INSERT INTO movies VALUES ( 02, "Avatar", "James Cameron", 162, 2009-12-18, "Science Fiction" );
INSERT INTO movies VALUES ( 03, "Titanic", "James Cameron", 194, 1997-12-19, "Romance" );

-- Members Table--
-- member_id, name, email, phone_number, street, city, state, zip --
INSERT INTO members VALUES ( 01, "Nancy", "Nancy@gmail.com", 5135131234, "123 Newport St", "Newport", "Kentucky", "41071");
INSERT INTO members VALUES ( 02, "Chase", "Chase@gmail.com", 2163456789, "6300 Kings Island Dr", "Mason", "Ohio", "45040");
INSERT INTO members VALUES ( 03, "George", "George@gmail.com", 5135131333, "14 Stadium Dr", "Ohio", "Kentucky", "45202");

-- Library Cards Table--
-- library_card_id, member_id, creation_date, experation_date, fees --
INSERT INTO library_cards VALUES ( 101, 01, 2023-07-15, 2025-07-15, 0.00);
INSERT INTO library_cards VALUES ( 102, 02, 2022-03-10, 2024-03-10, 5.00);
INSERT INTO library_cards VALUES ( 103, 03, 2025-01-13, 2027-01-13, 10.00);

-- Borrowed Movies Table--
-- borrowed_movies_id, movie_id, member_id, return_date, due_date --
INSERT INTO borrowed_movies VALUES ( 101, 03, 01, 2023-10-10, 2023-11-10);
INSERT INTO borrowed_movies VALUES ( 102, 01, 03, 2023-01-16, 2023-01-16);
INSERT INTO borrowed_movies VALUES ( 103, 02, 02, 2025-02-14, 2025-01-14);

-- Borrowed Books Table--
-- borrowed_book_id, member_id, due_date, return_date, book_id --
INSERT INTO borrowed_books VALUES ( 101, 01, 2025-02-10, 2025-1-24, 01);
INSERT INTO borrowed_books VALUES ( 102, 02, 2023-01-20, 2023-01-01, 02);
INSERT INTO borrowed_books VALUES ( 103, 03, 2026-01-24, 2025-12-20, 03);

-- check_outs Table--
-- check_outs_id, employee_id, member_id, check_out_date --
INSERT INTO check_outs VALUES ( 101, 01, 01, 2024-12-10);
INSERT INTO check_outs VALUES ( 102, 01, 02, 2022-11-26);
INSERT INTO check_outs VALUES ( 103, 03, 03, 2024-10-29);

