CREATE TABLE clients (
    id INT NOT NULL PRIMARY KEY IDENTITY,
    name NVARCHAR (100) NOT NULL,
    passportData VARCHAR(20) NOT NULL UNIQUE,
    email NVARCHAR (150) NOT NULL UNIQUE,
    phone VARCHAR(20) NOT NULL UNIQUE,
    gender NVARCHAR(1) NOT NULL
);

INSERT INTO clients (name, passportData, email, phone, gender)
VALUES
('Громов Данил Евгеньевич', '4128 423398', 'gromov@microsoft.com', '+7 (984) 238-52-60', 'м'),
('Ефимова Вера Семёновна', '4092 935782', 'gazeland@gmail.com', '+7 (928) 969-26-54', 'ж'),
('Шевцов Матвей Григорьевич', '4762 585973', 'straceya@gmail.com', '+7 (923) 782-46-42', 'м'),
('Андреева Анастасия Ярославовна', '4692 287744', 'jacom@gmail.com', '+7 (982) 929-86-62', 'ж'),
('Власова Елизавета Георгиевна', '4777 859174', 'erron@mail.ru', '+7 (959) 117-59-94', 'ж'),
('Семин Арсений Миронович', '4268 764032', 'jenisley@gmail.com', '+7 (956) 671-20-99', 'м');