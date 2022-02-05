Use DiplomCovid19DB
go

CREATE TRIGGER countVaccinationCourses

ON EmployeeVaccineJunctions

AFTER INSERT, UPDATE
AS
	BEGIN

		DECLARE @empId int, @countCourses int

			SET @empId = (select EmployeeId from inserted);
			SET @countCourses = (SELECT COUNT(*) FROM EmployeeVaccineJunctions as evj
								 WHERE evj.EmployeeId = @empId);
			IF (select DateSecondComponent from inserted) IS NOT NULL
				UPDATE Employees SET CountCourseVaccination = @countCourses
				WHERE Employees.Id = @empId;
	END


CREATE TRIGGER countVaccinationCoursesOnDelete

ON EmployeeVaccineJunctions

AFTER DELETE
AS
	BEGIN

		DECLARE @empId int, @countCourses int

			SET @empId = (select EmployeeId from deleted);
			SET @countCourses = (SELECT COUNT(*) FROM EmployeeVaccineJunctions as evj
								 WHERE evj.EmployeeId = @empId);
			IF (select DateSecondComponent from deleted) IS NOT NULL
				UPDATE Employees SET CountCourseVaccination = @countCourses
				WHERE Employees.Id = @empId;
	END