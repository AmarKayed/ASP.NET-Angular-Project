delete from teachers
where id in (
	select id from teachers
);

DBCC CHECKIDENT (teachers, RESEED, 0);

insert into teachers(name, course)
values
('Nicolas', 'Intro To Computer Science'),
('Jimmy', 'Phyilosophy'),
('Jamey', 'Geopolitics'),
('Randy', 'Advanced Algorithms'),
('Roman', 'Polynomial Probabilities'),
('Seth', 'Quantum Physics');