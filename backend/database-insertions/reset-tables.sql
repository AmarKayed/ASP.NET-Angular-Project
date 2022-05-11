delete from students
where id in (
	select id from students
);

DBCC CHECKIDENT (students, RESEED, 0);




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





delete from teachers
where id in (
	select id from teachers
);

DBCC CHECKIDENT (teachers, RESEED, 0);





delete from studentteachers
where id in (
	select id from studentteachers
);

DBCC CHECKIDENT (studentteachers, RESEED, 0);










