delete from studentteachers
where id in (
	select id from studentteachers
);

DBCC CHECKIDENT (studentteachers, RESEED, 0);

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