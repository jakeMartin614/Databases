SET FOREIGN_KEY_CHECKS = 0;

DELETE FROM check_outs;
DELETE FROM borrowed_books;
DELETE FROM borrowed_movies;
DELETE FROM library_cards;
DELETE FROM members;
DELETE FROM movies;
DELETE FROM books;
DELETE FROM employees;

SET FOREIGN_KEY_CHECKS = 1;
