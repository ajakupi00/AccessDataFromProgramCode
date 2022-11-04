CREATE TABLE Course
(
	[Id]	INT PRIMARY KEY IDENTITY(1,1),
	[Name]	NVARCHAR(50) NOT NULL,
	[ECTS]	INT NOT NULL
)
GO

CREATE OR ALTER PROC AddCourse
@name NVARCHAR(50), @ECTS INT, @id INT OUT
AS
INSERT INTO Course([Name], [ECTS])
VALUES (@name, @ECTS)
SET @id = SCOPE_IDENTITY()
GO

CREATE OR ALTER PROC GetAllCourse
AS
SELECT * FROM Course
GO

CREATE OR ALTER PROC UpdateCourse
@Id INT, @Name NVARCHAR(50), @ECTS INT
AS
UPDATE Course
SET [Name] =  @Name, [ECTS] = @ECTS
WHERE Id = @Id
GO

CREATE OR ALTER PROC DeleteCourse
@Id INT
AS
DELETE FROM StudentCourse
WHERE CourseId = @Id

DELETE FROM ProfessorCourse
WHERE CourseId = @Id

DELETE FROM Course
WHERE Id = @Id
GO

CREATE TABLE Student
(
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[JMBAG] NVARCHAR(20) NOT NULL,
	[Picture] VARBINARY(MAX)
)
GO

CREATE OR ALTER PROC GetAllStudent
AS
SELECT * FROM Student
GO

CREATE OR ALTER PROC AddStudent
@FirstName NVARCHAR(50), @LastName NVARCHAR(50), @JMBAG NVARCHAR(20), @Image VARBINARY(MAX), @Id INT OUT
AS
INSERT INTO Student([FirstName], [LastName], [JMBAG], [Picture])
VALUES (@FirstName, @LastName, @JMBAG, @Image)

SET @Id = SCOPE_IDENTITY()
GO

CREATE OR ALTER PROC UpdateStudent
@Id INT, @FirstName NVARCHAR(50), @LastName NVARCHAR(50), @JMBAG NVARCHAR(20), @Image VARBINARY(MAX)
AS
UPDATE Student
SET FirstName = @FirstName, LastName = @LastName, JMBAG = @JMBAG, Picture = @Image
WHERE Id = @Id
GO

CREATE OR ALTER PROC DeleteStudent
@Id INT
AS
DELETE FROM Student
WHERE Id = @Id

DELETE FROM StudentCourse
WHERE StudentId = @Id
GO


CREATE TABLE StudentCourse
(
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[StudentId] INT FOREIGN KEY REFERENCES Student(Id) NOT NULL,
	[CourseId] INT FOREIGN KEY REFERENCES Course(Id) NOT NULL,
)
GO

CREATE OR ALTER PROC GetAllStudentCourse
@id INT
AS
SELECT c.*
FROM StudentCourse AS sc
INNER JOIN Student AS s ON s.Id = sc.StudentId
INNER JOIN Course AS c ON c.Id = sc.CourseId
GO

CREATE OR ALTER PROC StudentAddCourse
@StudentId INT, @CourseId INT
AS
INSERT INTO StudentCourse([StudentId], [CourseId])
VALUES(@StudentId, @CourseId)
GO

CREATE OR ALTER PROC StudentRemoveCourse
@StudentId INT, @CourseId INT
AS
DELETE FROM StudentCourse
WHERE StudentId = @StudentId AND CourseId = @CourseID
GO

CREATE TABLE Professor
(
	[Id]		INT PRIMARY KEY IDENTITY(1,1),
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName]	NVARCHAR(50) NOT NULL,
	[Email]		NVARCHAR(50)
)
GO

CREATE OR ALTER PROC GetAllProfessor
AS
SELECT * FROM Professor
GO

CREATE OR ALTER PROC AddProfessor
@FirstName NVARCHAR(50), @LastName NVARCHAR(50), @Email NVARCHAR(50), @Id INT OUT
AS
INSERT INTO Professor([FirstName], [LastName], [Email])
VALUES (@FirstName, @LastName, @Email)

SET @Id = SCOPE_IDENTITY()
GO

CREATE OR ALTER PROC UpdateProfessor
@Id INT, @FirstName NVARCHAR(50), @LastName NVARCHAR(50), @Email NVARCHAR(50)
AS
UPDATE Professor
SET FirstName = @FirstName, LastName = @LastName, Email = @Email
WHERE Id = @Id
GO

CREATE OR ALTER PROC DeleteProfessor
@Id INT
AS
DELETE FROM ProfessorCourse
WHERE ProfessorId = @Id

DELETE FROM Professor
WHERE Id = @Id


GO


CREATE TABLE ProfessorCourse
(
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[ProfessorId] INT FOREIGN KEY REFERENCES Professor(Id) NOT NULL,
	[CourseId] INT FOREIGN KEY REFERENCES Course(Id) NOT NULL,
)
GO

CREATE OR ALTER PROC GetAllProfessorCourse
@id INT
AS
SELECT c.*
FROM ProfessorCourse AS pc
INNER JOIN Professor AS p ON p.Id = pc.ProfessorId
INNER JOIN Course AS c ON c.Id = pc.CourseId
GO

CREATE OR ALTER PROC ProfessorAddCourse
@ProfessorId INT, @CourseId INT
AS
INSERT INTO ProfessorCourse([ProfessorId], [CourseId])
VALUES(@ProfessorId, @CourseId)
GO

CREATE OR ALTER PROC ProfessorRemoveCourse
@ProfessorId INT, @CourseId INT
AS
DELETE FROM ProfessorCourse
WHERE ProfessorId = @ProfessorId AND CourseId = @CourseID
GO