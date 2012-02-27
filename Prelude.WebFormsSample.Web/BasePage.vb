Imports Prelude.WebFormsSample.Core.PersonSection

Public Class BasePage
    Inherits System.Web.UI.Page

    Public PersonEntities As IPersonEntities

    Public Sub New()
        PersonEntities = IoC.Resolve(Of IPersonEntities)()
    End Sub

End Class
