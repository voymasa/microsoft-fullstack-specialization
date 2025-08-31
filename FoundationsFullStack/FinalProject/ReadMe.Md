## Project Requirements
### Project Objective
The objective of this console application is to create a Student grade management system that allows the user to add new students, assign grades for different subjects, calculate the average grade for each studnet, and display student records with their grades.

### Functional Requirements
1. **Add New Student**: The application should allow the user to add a new student by providing the student's name and a unique ID.
2. **Assign Grades**: The application should allow the user to assign grades for different subjects to a student using their unique ID.
3. **Calculate Average Grade**: The application should be able to calculate and display the average grade for each student.
4. **Display Student Records**: The application should display a list of all students along with their grades and average grade.

### Non-Functional Requirements
1. **User Interface**: The application should have a simple and user-friendly console interface.
2. **Data Storage**: The application should store student records in memory (no need for persistent storage).
3. **Error Handling**: The application should handle errors gracefully, such as attempting to assign grades to a non-existent student or entering invalid data.
4. **Performance**: The application should be able to handle a reasonable number of students and grades without significant performance degradation.
5. **Code Quality**: The code should be well-structured, commented, and follow best practices for readability and maintainability.

## Design Outline (tasks, code needs, variables, etc)
### Classes and Data Structures
1. **Student Class**: A class to represent a student with attributes such as name, ID, and a list of grades.
   - Attributes:
        - Name: string
        - ID: string (unique identifier)
        - Grades: List<Grade>
2. **Grade Class**: A class to represent a subject and corresponding grade
    - Attributes:
        - Subject: string
        - Score: float
3. **StudentManager Class**: A class to manage the collection of students and provide methods to add students, assign grades, calculate averages, and display records.
    - Attributes:
          - Students: Dictionary<string, Student> (keyed by student ID)
    - Methods:
          - AddStudent(string name, string id)
          - AssignGrade(string id, string subject, float score)
          - CalculateAverage(string id): float
          - DisplayRecords(): void

### Console Interface
1. **Main Menu**: A simple text-based menu to navigate through different functionalities.
   - Options:
        - Add New Student
        - Assign Grades
        - Calculate Average Grade
        - Display Student Records
        - Exit
2. **Input Handling**: Methods to handle user input and validate data.
3. **Error Messages**: Display appropriate error messages for invalid operations.

### Variables
1. **studentManager**: An instance of StudentManager to manage student records.
2. **userChoice**: Variable to store the user's menu choice.
3. **inputName**: Variable to store the student's name input.
4. **inputID**: Variable to store the student's ID input.
5. **inputSubject**: Variable to store the subject name input.
6. **inputScore**: Variable to store the grade score input.
7. **averageGrade**: Variable to store the calculated average grade for a student.

### Error Handling
1. **Invalid Input**: Check for valid data types and ranges when accepting user input.
2. **Non-Existent Student**: Handle cases where grades are assigned to a student ID that does not exist in the system.
3. **Duplicate Student ID**: Prevent adding a student with an ID that already exists in the system.

### Performance Considerations
1. **Efficient Data Structures**: Use a dictionary for student records to allow O(1) average time complexity for lookups.
2. **Scalability**: Ensure the application can handle a reasonable number of students and grades without significant performance degradation.

### Code Quality
1. **Modular Design**: Break down the code into smaller, reusable methods and classes.
2. **Comments and Documentation**: Provide comments and documentation for classes, methods, and complex logic.
3. **Consistent Naming Conventions**: Use consistent and meaningful names for variables, methods, and classes.


### Example Workflow
1. User starts the application and is presented with the main menu.
2. User selects "Add New Student" and inputs the student's name and ID.
3. User selects "Assign Grades" and inputs the student ID, subject, and grade score.
4. User selects "Calculate Average Grade" to view the average grade for a specific student.
5. User selects "Display Student Records" to view all students with their grades and average grades.
6. User selects "Exit" to close the application.
