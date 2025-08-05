-- Employee Table
INSERT INTO employees VALUES 
(1, 'Bob', 'Bob@gmail.com', '5131231234', '123 Calhoun Street', 'Cincinnati', 'Ohio', '45219'),
(2, 'Lisa', 'Lisa@gmail.com', '5131231245', '130 Clifton Ave', 'Cincinnati', 'Ohio', '45219'),
(3, 'Frank', 'Frank@gmail.com', '5131231256', '1001 McMillan Street', 'Cincinnati', 'Ohio', '45219');

-- Books Table
INSERT INTO books VALUES 
(1, 'The Great Gatsby', '1001', 'F. Scott Fitzgerald'),
(2, 'Frankenstein', '1002', 'Mary Shelley'),
(3, 'To Kill a Mockingbird', '1003', 'Harper Lee');

-- Movies Table
INSERT INTO movies VALUES 
(1, 'Jurassic Park', 'Steven Spielberg', '127', '1993-06-09', 'Science Fiction'),
(2, 'Avatar', 'James Cameron', '162', '2009-12-18', 'Science Fiction'),
(3, 'Titanic', 'James Cameron', '194', '1997-12-19', 'Romance');

-- Members Table
INSERT INTO members VALUES 
(1, 'Nancy', 'Nancy@gmail.com', '5135131234', '123 Newport St', 'Newport', 'Kentucky', '41071'),
(2, 'Chase', 'Chase@gmail.com', '2163456789', '6300 Kings Island Dr', 'Mason', 'Ohio', '45040'),
(3, 'George', 'George@gmail.com', '5135131333', '14 Stadium Dr', 'Ohio', 'Kentucky', '45202');

-- Library Cards Table
INSERT INTO library_cards VALUES 
(101, 1, '2023-07-15', '2025-07-15', 0.00),
(102, 2, '2022-03-10', '2024-03-10', 5.00),
(103, 3, '2025-01-13', '2027-01-13', 10.00);

-- Borrowed Movies Table
INSERT INTO borrowed_movies VALUES 
(101, 3, 1, '2023-10-10', '2023-11-10'),
(102, 1, 3, '2023-01-16', '2023-01-16'),
(103, 2, 2, '2025-02-14', '2025-01-14');

-- Borrowed Books Table
INSERT INTO borrowed_books VALUES 
(101, 1, '2025-02-10', '2025-01-24', 1),
(102, 2, '2023-01-20', '2023-01-01', 2),
(103, 3, '2026-01-24', '2025-12-20', 3);

-- Check Outs Table
INSERT INTO check_outs VALUES 
(101, 1, 1, '2024-12-10'),
(102, 1, 2, '2022-11-26'),
(103, 3, 3, '2024-10-29');
