
Public Module DbInitializer
    Sub Initialize(ByVal pContext As ApplicationDbContext)
        If pContext.Students.Any() Then
            Return
        End If

        Dim students = New Student() {
            New Student With {
            .FirstMidName = "Carson",
            .LastName = "Alexander",
            .EnrollmentDate = DateTime.Parse("2019-09-01")
        },
        New Student With {
            .FirstMidName = "Meredith",
            .LastName = "Alonso",
            .EnrollmentDate = DateTime.Parse("2017-09-01")
        },
        New Student With {
            .FirstMidName = "Arturo",
            .LastName = "Anand",
            .EnrollmentDate = DateTime.Parse("2018-09-01")
        },
        New Student With {
            .FirstMidName = "Gytis",
            .LastName = "Barzdukas",
            .EnrollmentDate = DateTime.Parse("2017-09-01")
        },
        New Student With {
            .FirstMidName = "Yan",
            .LastName = "Li",
            .EnrollmentDate = DateTime.Parse("2017-09-01")
        },
        New Student With {
            .FirstMidName = "Peggy",
            .LastName = "Justice",
            .EnrollmentDate = DateTime.Parse("2016-09-01")
        },
        New Student With {
            .FirstMidName = "Laura",
            .LastName = "Norman",
            .EnrollmentDate = DateTime.Parse("2018-09-01")
        },
        New Student With {
            .FirstMidName = "Nino",
            .LastName = "Olivetto",
            .EnrollmentDate = DateTime.Parse("2019-09-01")
        }}
        pContext.Students.AddRange(students)
        pContext.SaveChanges()
        Dim courses = New Course() {
            New Course With {
            .CourseID = 1050,
            .Title = "Chemistry",
            .Credits = 3
        },
        New Course With {
            .CourseID = 4022,
            .Title = "Microeconomics",
            .Credits = 3
        },
        New Course With {
            .CourseID = 4041,
            .Title = "Macroeconomics",
            .Credits = 3
        },
        New Course With {
            .CourseID = 1045,
            .Title = "Calculus",
            .Credits = 4
        },
        New Course With {
            .CourseID = 3141,
            .Title = "Trigonometry",
            .Credits = 4
        },
        New Course With {
            .CourseID = 2021,
            .Title = "Composition",
            .Credits = 3
        },
        New Course With {
            .CourseID = 2042,
            .Title = "Literature",
            .Credits = 4
        }}
        pContext.Courses.AddRange(courses)
        pContext.SaveChanges()
        Dim enrollments = New Enrollment() {
            New Enrollment With {
            .StudentID = 1,
            .CourseID = 1050,
            .Grade = Grade.A
        },
        New Enrollment With {
            .StudentID = 1,
            .CourseID = 4022,
            .Grade = Grade.C
        },
        New Enrollment With {
            .StudentID = 1,
            .CourseID = 4041,
            .Grade = Grade.B
        },
        New Enrollment With {
            .StudentID = 2,
            .CourseID = 1045,
            .Grade = Grade.B
        },
        New Enrollment With {
            .StudentID = 2,
            .CourseID = 3141,
            .Grade = Grade.F
        },
        New Enrollment With {
            .StudentID = 2,
            .CourseID = 2021,
            .Grade = Grade.F
        },
        New Enrollment With {
            .StudentID = 3,
            .CourseID = 1050
        },
        New Enrollment With {
            .StudentID = 4,
            .CourseID = 1050
        },
        New Enrollment With {
            .StudentID = 4,
            .CourseID = 4022,
            .Grade = Grade.F
        },
        New Enrollment With {
            .StudentID = 5,
            .CourseID = 4041,
            .Grade = Grade.C
        },
        New Enrollment With {
            .StudentID = 6,
            .CourseID = 1045
        },
        New Enrollment With {
            .StudentID = 7,
            .CourseID = 3141,
            .Grade = Grade.A
        }}
        pContext.Enrollments.AddRange(enrollments)
        pContext.SaveChanges()
    End Sub
End Module
