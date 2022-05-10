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
('Kanye', 'Music');