Imports Prelude.WebFormsSample.Core.PersonSection
Imports System.Data.Entity.Infrastructure
Imports Prelude.WebFormsSample.Core.Interfaces

Public Class Site
    Inherits System.Web.UI.MasterPage

    Public PersonEntities As IPersonEntities

    Public Sub New()
        MyBase.New()

        PersonEntities = IoC.Resolve(Of IPersonEntities)()
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IoC.Resolve(Of IAddressRepository).GettAddressFromContext(234)
    End Sub

End Class