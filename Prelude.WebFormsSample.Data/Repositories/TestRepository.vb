Imports Prelude.WebFormsSample.Core
Imports Prelude.WebFormsSample.Core.Interfaces

Public Class TestRepository
    Implements ITest

    Public Function GetTest() As String Implements ITest.GetTest
        Return "Hello World"
    End Function
End Class
