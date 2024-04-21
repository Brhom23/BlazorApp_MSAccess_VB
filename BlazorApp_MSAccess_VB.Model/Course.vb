Imports System.ComponentModel.DataAnnotations.Schema
Public Class Course
    '<DatabaseGenerated(DatabaseGeneratedOption.None)>
    Public Property CourseID As Integer
    Public Property Title As String
    Public Property Credits As Integer
    Public Property Enrollments As ICollection(Of Enrollment)
End Class

