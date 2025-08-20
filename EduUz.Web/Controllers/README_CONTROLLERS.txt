Admin, Director, Teacher, Student, Parent controller endpoints wired to MediatR requests.

- AdminController (api/admin):
  - GET regions -> GetAllRegionQuery
  - Cities: POST/PUT/DELETE using CreateCityCommand, UpdateCityCommand, DeleteCityCommand
  - Subjects: GET/POST/PUT/DELETE using GetAllSubjectsQuery, CreateSubjectCommand, UpdateSubjectCommand, DeleteSubjectCommand
  - Schools: GET/POST/PUT/DELETE using GetAllSchoolsQuery, CreateSchoolCommand, UpdateSchoolCommand, DeleteSchoolCommand
  - Users: GET all/by id, PUT update, DELETE, POST teacher/director, GET search -> respective commands/queries

- DirectorController (api/director):
  - Classes: GET all, POST create, PUT update, DELETE, GET students by class id
  - Timetables: GET all, POST create, PUT update, DELETE
  - Grade requests: GET all, POST approve/reject, GET report by student id
  - Teachers: GET all, POST create, PUT update, DELETE, GET subjects by id, POST add subject
  - Statistics: GET classes/teachers/attendance

- TeacherController (api/teacher):
  - Homeworks: GET all/by id, POST create, PUT update, DELETE, POST materials
  - Grades: POST create, PUT update, GET by student/class/subject
  - Attendance: POST create, PUT update, GET by class/student, GET reports
  - Tutor: POST create parent (with UserId), POST create student, POST link parent-student

- StudentController (api/student):
  - GET attendances, grades, homeworks, timetables
  - GET behaviors by studentId, GET notifications by userId
  - POST submit homework (path homeworkId, body: StudentId, FileUrl, Comment)

- ParentController (api/parent):
  - Child data: GET attendances/behaviors/grades/timetables by childId
  - POST excuse for child (body: Reason, Date)

Notes:
- StatisticsController import namespaces fixed to EduUz.Application.Mediatr.Statistics.*
- Common/Auth will be added later.