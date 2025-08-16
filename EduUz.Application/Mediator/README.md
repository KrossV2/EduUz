# School Management System - Mediator Handlers

This document provides an overview of all the mediator handlers implemented for the comprehensive school management system based on the requirements.

## System Overview

The system implements a hierarchical role-based access control:
- **Admin** → **Director** → **Teacher** → **Student/Parent**
- Only registered users can access the system (no sign-up, only sign-in)
- All activities are logged for audit purposes

## Teacher APIs

### Grades Management

#### `GetClassGradesQuery`
- **Purpose**: Get grades for a specific class
- **Access**: Teacher must have access to the class
- **Parameters**: `ClassId`, `TeacherId`
- **Returns**: List of grades with student and subject information

#### `GetStudentGradesQuery`
- **Purpose**: Get grades for a specific student
- **Access**: Teacher must have access to the student
- **Parameters**: `StudentId`, `TeacherId`
- **Returns**: List of grades for the student

#### `GetSubjectGradesQuery`
- **Purpose**: Get grades for a specific subject
- **Access**: Teacher must have access to the subject
- **Parameters**: `SubjectId`, `TeacherId`
- **Returns**: List of grades for the subject

#### `AddGradeCommand`
- **Purpose**: Add a new grade for a student
- **Access**: Teacher must have access to student and subject
- **Validation**: Grade value must be between 1-5
- **Features**: 
  - Activity logging
  - Access control validation
- **Parameters**: `StudentId`, `SubjectId`, `TeacherId`, `GradeType`, `Value`, `Date`, `Comment`

#### `UpdateGradeCommand`
- **Purpose**: Request grade change (requires director approval)
- **Access**: Teacher can only update their own grades
- **Features**:
  - Creates approval request for director
  - Activity logging
  - Reason tracking
- **Parameters**: `GradeId`, `TeacherId`, `NewValue`, `Reason`

### Attendance Management

#### `GetClassAttendanceQuery`
- **Purpose**: Get attendance for a specific class on a specific date
- **Access**: Teacher must have access to the class
- **Parameters**: `ClassId`, `TeacherId`, `Date`
- **Returns**: List of attendance records

#### `GetStudentAttendanceQuery`
- **Purpose**: Get attendance for a specific student
- **Access**: Teacher must have access to the student
- **Parameters**: `StudentId`, `TeacherId`, `StartDate`, `EndDate`
- **Returns**: List of attendance records

#### `AddAttendanceCommand`
- **Purpose**: Add attendance records for a class
- **Access**: Teacher must have access to the class
- **Features**:
  - Bulk attendance entry
  - Automatic parent notification for consecutive absences (3+ days)
  - Activity logging
- **Parameters**: `ClassId`, `TeacherId`, `Date`, `Records[]`

### Homework Management

#### `GetHomeworksQuery`
- **Purpose**: Get homework list for teacher
- **Access**: Teacher's own homework
- **Parameters**: `TeacherId`, `ClassId?`, `SubjectId?`
- **Returns**: List of homework with materials

#### `AddHomeworkCommand`
- **Purpose**: Create new homework assignment
- **Access**: Teacher must have access to class and subject
- **Features**:
  - Support for multiple file attachments
  - Due date tracking
  - Activity logging
- **Parameters**: `TeacherId`, `ClassId`, `SubjectId`, `Title`, `Description`, `DueDate`, `Materials[]`

### Student Management (Class Teachers Only)

#### `AddStudentCommand`
- **Purpose**: Add new student to class
- **Access**: Only class teachers can add students
- **Features**:
  - Username format: `Ism_Familiya_Sinf` (e.g., `Ali_Akbarov_7A`)
  - Email validation
  - Password hashing
  - Activity logging
- **Parameters**: `TeacherId`, `ClassId`, `FirstName`, `LastName`, `Email`, `Username`, `Password`, `BirthDate`, `PhoneNumber`

#### `AddParentCommand`
- **Purpose**: Add new parent
- **Access**: Any teacher can add parents
- **Features**:
  - Email as username
  - Random password generation
  - Activity logging
- **Parameters**: `TeacherId`, `FirstName`, `LastName`, `Email`, `PhoneNumber`, `Relationship`

#### `LinkParentToStudentCommand`
- **Purpose**: Link parent to student
- **Access**: Class teacher must have access to student
- **Features**:
  - Prevents duplicate links
  - Activity logging
- **Parameters**: `TeacherId`, `ParentId`, `StudentId`

## Student APIs

### `GetMyGradesQuery`
- **Purpose**: Get student's own grades
- **Access**: Student can only see their own grades
- **Parameters**: `StudentId`, `SubjectId?`, `GradeType?`
- **Returns**: List of grades with teacher information

### `GetMyAttendanceQuery`
- **Purpose**: Get student's own attendance
- **Access**: Student can only see their own attendance
- **Parameters**: `StudentId`, `StartDate?`, `EndDate?`
- **Returns**: List of attendance records

### `GetMyTimetableQuery`
- **Purpose**: Get student's class timetable
- **Access**: Student can only see their class timetable
- **Parameters**: `StudentId`
- **Returns**: Weekly timetable with subjects and teachers

### `GetMyHomeworksQuery`
- **Purpose**: Get homework assignments for student
- **Access**: Student can only see homework for their class
- **Features**:
  - Shows completion status
  - Includes submission dates
  - File attachments
- **Parameters**: `StudentId`, `SubjectId?`, `IsCompleted?`
- **Returns**: List of homework with completion status

### `SubmitHomeworkCommand`
- **Purpose**: Submit homework assignment
- **Access**: Student can only submit homework for their class
- **Features**:
  - Due date validation
  - File upload support
  - Prevents duplicate submissions
  - Activity logging
- **Parameters**: `HomeworkId`, `StudentId`, `Comment`, `Files[]`

## Parent APIs

### `GetChildrenQuery`
- **Purpose**: Get list of parent's children
- **Access**: Parent can only see their linked children
- **Parameters**: `ParentId`
- **Returns**: List of children with school and class information

### `GetChildGradesQuery`
- **Purpose**: Get child's grades
- **Access**: Parent must be linked to the child
- **Parameters**: `ParentId`, `ChildId`, `SubjectId?`, `GradeType?`
- **Returns**: List of grades with teacher information

### `GetChildAttendanceQuery`
- **Purpose**: Get child's attendance
- **Access**: Parent must be linked to the child
- **Parameters**: `ParentId`, `ChildId`, `StartDate?`, `EndDate?`
- **Returns**: List of attendance records

### `SubmitExcuseCommand`
- **Purpose**: Submit excuse for child's absence
- **Access**: Parent must be linked to the child
- **Features**:
  - Document upload support
  - Prevents duplicate excuses
  - Activity logging
- **Parameters**: `ParentId`, `ChildId`, `AttendanceId`, `Reason`, `DocumentUrl?`

## Common APIs

### File Management

#### `UploadFileCommand`
- **Purpose**: Upload files to the system
- **Features**:
  - File size validation (max 10MB)
  - File type validation
  - Unique filename generation
  - Activity logging
- **Supported Types**: PDF, DOC, DOCX, JPG, JPEG, PNG, MP4, AVI, MOV
- **Parameters**: `UserId`, `UserType`, `FileName`, `FileType`, `FileSize`, `FileContent`, `Description`

### Notifications

#### `GetNotificationsQuery`
- **Purpose**: Get user notifications
- **Features**:
  - Pagination support
  - Read/unread filtering
  - Type-based categorization
- **Parameters**: `UserId`, `UserType`, `IsRead?`, `Page?`, `PageSize?`
- **Returns**: List of notifications

#### `MarkNotificationAsReadCommand`
- **Purpose**: Mark notification as read
- **Access**: User can only mark their own notifications
- **Parameters**: `NotificationId`, `UserId`, `UserType`

### Behavior Management

#### `AddBehaviorRecordCommand`
- **Purpose**: Add behavior record for student
- **Access**: Teacher must have access to student
- **Features**:
  - Positive/negative behavior tracking
  - Point system
  - Automatic parent notification for negative behavior
  - Evidence documentation
  - Activity logging
- **Parameters**: `StudentId`, `TeacherId`, `Type`, `Points`, `Description`, `Date`, `Evidence?`

#### `GetBehaviorRecordQuery`
- **Purpose**: Get behavior record details
- **Access**: Based on user type and relationships
- **Features**:
  - Role-based access control
  - Full record details
- **Parameters**: `RecordId`, `UserId`, `UserType`
- **Returns**: Behavior record with student and teacher information

## Key Features Implemented

### Security & Access Control
- Role-based access control (Admin → Director → Teacher → Student/Parent)
- Teacher access validation for classes, subjects, and students
- Parent-child relationship validation
- Student self-access restrictions

### Activity Logging
- All actions are logged with user information
- Detailed descriptions for audit trails
- Timestamp tracking

### Notifications
- Email notifications for parents
- Automatic absence notifications (3+ consecutive days)
- Behavior record notifications
- Multi-channel support (Email, Telegram bot ready)

### Data Validation
- Grade value validation (1-5 scale)
- File type and size validation
- Date range validation
- Duplicate prevention

### Business Logic
- Grade change approval workflow
- Consecutive absence tracking
- Homework submission tracking
- Behavior point system
- Parent excuse system

## Usage Examples

### Teacher Adding Grade
```csharp
var command = new AddGradeCommand
{
    StudentId = 123,
    SubjectId = 456,
    TeacherId = 789,
    GradeType = GradeType.Daily,
    Value = 5,
    Date = DateTime.Today,
    Comment = "Excellent work!"
};

var gradeId = await mediator.Send(command);
```

### Student Getting Grades
```csharp
var query = new GetMyGradesQuery
{
    StudentId = 123,
    SubjectId = 456,
    GradeType = GradeType.Quarter
};

var grades = await mediator.Send(query);
```

### Parent Submitting Excuse
```csharp
var command = new SubmitExcuseCommand
{
    ParentId = 456,
    ChildId = 123,
    AttendanceId = 789,
    Reason = "Medical appointment",
    DocumentUrl = "https://example.com/medical-certificate.pdf"
};

var success = await mediator.Send(command);
```

This mediator implementation provides a comprehensive, secure, and scalable foundation for the school management system with proper separation of concerns and business logic encapsulation.