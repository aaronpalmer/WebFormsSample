Imports System
Imports System.Web
Imports System.Web.UI
Imports Microsoft.Practices.Unity

Public Class UnityHttpModule
    Implements IHttpModule

    Private _application As HttpApplication

    Public Sub Init(ByVal context As HttpApplication) Implements IHttpModule.Init
        If context Is Nothing Then
            Throw New ArgumentNullException("context")
        End If

        _application = context
        AddHandler _application.PreRequestHandlerExecute, AddressOf OnPreRequestHandlerExecute
    End Sub

    Private Sub OnPreRequestHandlerExecute(ByVal sender As Object, ByVal e As EventArgs)
        Dim pg As Page = TryCast(HttpContext.Current.Handler, Page)

        If pg IsNot Nothing Then
            IoC.Inject(pg.GetType(), pg)
            AddHandler pg.InitComplete, AddressOf InjectUserControls
        End If
    End Sub

    Private Sub InjectUserControls(parent As Control, ByVal e As EventArgs)
        If parent.HasControls Then
            For Each ctrl As Control In parent.Controls
                If (TypeOf ctrl Is UserControl) Then
                    IoC.Inject(ctrl.GetType(), ctrl)
                End If

                If (ctrl.HasControls) Then
                    InjectUserControls(ctrl, e)
                End If
            Next
        End If
    End Sub

    Public Sub Dispose() Implements IHttpModule.Dispose
    End Sub

End Class
