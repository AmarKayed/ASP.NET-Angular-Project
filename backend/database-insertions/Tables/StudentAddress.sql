delete from studentaddresses
where id in (
	select id from studentaddresses
);

DBCC CHECKIDENT (studentaddresses, RESEED, 0);

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