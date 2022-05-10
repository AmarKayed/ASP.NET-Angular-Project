delete from deadlines
where id in (
	select id from deadlines
);

DBCC CHECKIDENT (deadlines, RESEED, 0);

insert into deadlines(title, daysleft, studentid)
values
('Math Project', 15, 1),
('Geography Homework', 3, 1),
('Physics Exam', 14, 1),
('Algebra Test', 42, 2),
('Job Interview', 7, 2),
('Olympiad Enrollment', 5, 3),
('Volunteering Event', 19, 4);