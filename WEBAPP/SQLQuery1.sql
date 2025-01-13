CREATE TABLE categories (
  id INT NOT NULL PRIMARY KEY IDENTITY,
  name VARCHAR(100) NOT NULL,
  description VARCHAR(100) 
);

INSERT INTO categories(name,description) 
VALUES
('BEVERAGE','COLD'),
('COFFEE','HOT');