# Statistics API Implementation with MediatR Pattern

## Overview
This document describes the implementation of Statistics API endpoints using the MediatR pattern in the EduUz application.

## Implemented Features

### 1. MediatR Queries
Three MediatR queries have been created for different types of statistics:

#### GetClassStatisticsQuery
- **Location**: `EduUz.Application/Mediator/Statistics/GetClassStatistics/GetClassStatisticsQuery.cs`
- **Purpose**: Retrieves class statistics including total students, average grades, and attendance percentage
- **Handler**: `GetClassStatisticsQueryHandler` uses `IStatisticsRepository`

#### GetTeacherStatisticsQuery
- **Location**: `EduUz.Application/Mediator/Statistics/GetTeacherStatistics/GetTeacherStatisticsQuery.cs`
- **Purpose**: Retrieves teacher statistics including total subjects, total classes, and average student grades
- **Handler**: `GetTeacherStatisticsQueryHandler` uses `IStatisticsRepository`

#### GetAttendanceStatisticsQuery
- **Location**: `EduUz.Application/Mediator/Statistics/GetAttendanceStatistics/GetAttendanceStatisticsQuery.cs`
- **Purpose**: Retrieves attendance statistics including present, absent, late counts and attendance rate
- **Handler**: `GetAttendanceStatisticsQueryHandler` uses `IStatisticsRepository`

### 2. StatisticsController
- **Location**: `EduUz.Web/Controllers/StatisticsController.cs`
- **Endpoints**:
  - `GET /api/statistics/classes` - Sinflar statistikasi
  - `GET /api/statistics/teachers` - O'qituvchilar statistikasi
  - `GET /api/statistics/attendance` - Davomat statistikasi
- **Features**: Proper error handling with try-catch blocks and appropriate HTTP status codes

### 3. StatisticsRepository
- **Location**: `EduUz.Application/Repositories/StatisticsRepository.cs`
- **Features**:
  - Uses proper EF Core navigation properties
  - Optimized queries with Include and ThenInclude
  - Handles null values with DefaultIfEmpty()
  - Calculates percentages and averages correctly

### 4. Statistics Models
Three statistics models have been implemented:

#### ClassStatistics
```csharp
public class ClassStatistics
{
    public int ClassId { get; set; }
    public string ClassName { get; set; }
    public int TotalStudents { get; set; }
    public double AverageGrade { get; set; }
    public int AttendancePercentage { get; set; }
}
```

#### TeacherStatistics
```csharp
public class TeacherStatistics
{
    public int TeacherId { get; set; }
    public string TeacherName { get; set; }
    public int TotalSubjects { get; set; }
    public int TotalClasses { get; set; }
    public double AverageStudentGrade { get; set; }
}
```

#### AttendanceStatistics
```csharp
public class AttendanceStatistics
{
    public int ClassId { get; set; }
    public string ClassName { get; set; }
    public int PresentCount { get; set; }
    public int AbsentCount { get; set; }
    public int LateCount { get; set; }
    public double AttendanceRate { get; set; } // Percentage (0-100)
}
```

### 5. Dependency Injection Configuration
- **Location**: `EduUz.Application/DiContainer/DiContainer.cs`
- **Features**:
  - MediatR is properly configured with `AddMediatR()`
  - StatisticsRepository is registered as scoped service
  - All necessary dependencies are properly injected

## API Endpoints

### GET /api/statistics/classes
Returns statistics for all classes including:
- Class ID and name
- Total number of students
- Average grade across all students
- Attendance percentage

**Response Example**:
```json
[
  {
    "classId": 1,
    "className": "9-A",
    "totalStudents": 25,
    "averageGrade": 4.2,
    "attendancePercentage": 85
  }
]
```

### GET /api/statistics/teachers
Returns statistics for all teachers including:
- Teacher ID and full name
- Total number of subjects taught
- Total number of classes taught
- Average student grade across all subjects

**Response Example**:
```json
[
  {
    "teacherId": 1,
    "teacherName": "John Doe",
    "totalSubjects": 3,
    "totalClasses": 5,
    "averageStudentGrade": 4.1
  }
]
```

### GET /api/statistics/attendance
Returns attendance statistics for all classes including:
- Class ID and name
- Count of present students
- Count of absent students
- Count of late students
- Overall attendance rate as percentage

**Response Example**:
```json
[
  {
    "classId": 1,
    "className": "9-A",
    "presentCount": 22,
    "absentCount": 2,
    "lateCount": 1,
    "attendanceRate": 88.0
  }
]
```

## Error Handling
All endpoints include comprehensive error handling:
- Try-catch blocks for exception handling
- Returns 500 status code with error message for server errors
- Proper error response format with message and error details

## Database Relationships
The implementation uses proper EF Core navigation properties:
- `Class.Students` - One-to-many relationship
- `Student.Grades` - One-to-many relationship
- `Student.AttendanceRecords` - One-to-many relationship
- `Teacher.TeacherSubjects` - One-to-many relationship
- `Teacher.User` - One-to-one relationship

## Testing
HTTP test file has been created at `EduUz.Web/EduUz.Web.http` with test requests for all three endpoints.

## Technical Improvements Made
1. **Fixed duplicate navigation properties** in Student and Teacher models
2. **Optimized EF Core queries** with proper Include and ThenInclude statements
3. **Improved null handling** with DefaultIfEmpty() for average calculations
4. **Enhanced error handling** with proper exception management
5. **Cleaned up code** by removing unnecessary comments and improving formatting

## Dependencies
- MediatR 13.0.0
- Entity Framework Core 8.0.17
- AutoMapper 12.0.0
- .NET 8.0

## Usage
The Statistics API is ready to use and provides comprehensive statistics for classes, teachers, and attendance. All endpoints follow RESTful conventions and return JSON responses with proper error handling.