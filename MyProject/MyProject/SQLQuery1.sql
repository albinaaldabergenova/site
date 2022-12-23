CREATE TABLE clients (
    id INT NOT NULL PRIMARY KEY IDENTITY,
    name NVARCHAR (100) NOT NULL,
    passportData VARCHAR (10) NOT NULL UNIQUE,
    email VARCHAR (50) NOT NULL UNIQUE,
    phone VARCHAR(20) NOT NULL UNIQUE,
    gender NVARCHAR(1) NULL,
);

INSERT INTO clients (name, passportData, email, phone, gender)
VALUES
('Мосенцова Татьяна Валерьевна', '4270845618', 'tatyana9026@yandex.ru', '+7 (971) 268-89-75', 'ж'),
('Явчуновский Павел Алексеевич', '4431569013', 'pavel1961@hotmail.com', '+7 (975) 362-63-57', 'м'),
('Андропов Герман Арсеньевич', '4624343052', 'yurin92@rambler.ru', '+7 (930) 666-17-25', 'м'),
('Чуприн Федот Феликсович', '4922685913', 'fedot23051996@yandex.ru', '+7 (977) 924-18-74', 'м'),
('Огарков Венедикт Максимович', '4828410582', 'venedikt17111992@outlook.com', '+7 (993) 366-75-94', 'м'),
('Лощилов Василий Давидович', '4837107272', 'vasiliy81@outlook.com', '+7 (970) 395-49-22', 'м');