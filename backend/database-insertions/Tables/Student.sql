delete from students
where id in (
	select id from students
);

DBCC CHECKIDENT (students, RESEED, 0);

insert into students(name, major)
values
('Michael', 'Math'),
('Franklin', 'History'),
('Trevor', 'Anatomy'),
('Richard', 'Geography'),
('Kanye', 'Music'),
('Daniel', 'History'),
('Bryan', 'Music'),
('John', 'Physics'),
('Alex', 'Math'),
('William', 'Geography'),
('Michael', 'Physics'),
('Steven', 'Chemistry'),
('Bill', 'Social Sciences'),
('Jeff', 'Humanities'),
('Allan', 'Arts'),
('Rachael', 'Math'),
('Jessica', 'Humanities'),
('Kim', 'Chemistry'),
('Michelle', 'Social Sciences'),
('Ronald', 'Math'),
('Donald', 'Business');