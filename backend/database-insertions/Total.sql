delete from studentteachers
where id in (
	select id from studentteachers
);

DBCC CHECKIDENT (studentteachers, RESEED, 0);




delete from teachers
where id in (
	select id from teachers
);

DBCC CHECKIDENT (teachers, RESEED, 0);




delete from studentaddresses
where id in (
	select id from studentaddresses
);

DBCC CHECKIDENT (studentaddresses, RESEED, 0);




delete from deadlines
where id in (
	select id from deadlines
);

DBCC CHECKIDENT (deadlines, RESEED, 0);




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




insert into studentaddresses(city, country, studentid)
values
('Bucharest', 'Romania', 1),
('Madrid', 'Spain', 2),
('London', 'UK', 3),
('Paris', 'France', 4),
('Berlin', 'Germany', 5),
('Warsaw', 'Poland', 6),
('Moscow', 'Russia', 7),
('Kiev', 'Ukraine', 8),
('Stockholm', 'Sweden', 9),
('Oslo', 'Norway', 10);





insert into deadlines(title, daysleft, studentid)
values
('Math Project', 15, 1),
('Geography Homework', 3, 1),
('Physics Exam', 14, 1),
('Algebra Test', 42, 2),
('Job Interview', 7, 2),
('Olympiad Enrollment', 5, 3),
('Volunteering Event', 19, 4);




insert into teachers(name, course)
values
('Nicolas', 'Intro To Computer Science'),
('Jimmy', 'Phyilosophy'),
('Jamey', 'Geopolitics'),
('Randy', 'Advanced Algorithms'),
('Roman', 'Polynomial Probabilities'),
('Seth', 'Quantum Physics');




insert into studentteachers(studentid, teacherid)
values
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(2, 1),
(2, 2),
(2, 3),
(3, 5);




