Imports Microsoft.EntityFrameworkCore
Imports System.ComponentModel.DataAnnotations

Public Class Book
    <Key>
    Public Property Id As Integer
    Public Property Title As String
    <Precision(10, 2)>
    Public Property Price As Decimal
    Public Property CategoryId As Integer
    Public Property Category As Category

    Public Overrides Function ToString() As String
        Return Title
    End Function
End Class

Public Class Category
    <Key>
    Public Property CategoryId As Integer
    Public Property Description As String
    Public Property Books As List(Of Book)
End Class
