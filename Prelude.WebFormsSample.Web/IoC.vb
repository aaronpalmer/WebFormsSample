Imports Microsoft.Practices.Unity
Imports Microsoft.Practices.Unity.Configuration
Imports Prelude.WebFormsSample.Core

Public Class IoC

    Private Shared _container As IUnityContainer

    Public Shared Sub Initialize(ByVal container As IUnityContainer)
        _container = container
        Dim section As UnityConfigurationSection = CType(ConfigurationManager.GetSection("unity"), UnityConfigurationSection)
        section.Configure(_container)
    End Sub

    Public Shared Function Resolve(Of T)() As T
        Return _container.Resolve(Of T)()
    End Function

    Public Shared Function Resolve(Of T)(ByVal name As String) As T
        Return _container.Resolve(Of T)(name)
    End Function

    Public Shared Function Resolve(ByVal type As Type)
        Return _container.Resolve(type)
    End Function

    Public Shared Function Resolve(ByVal type As Type, ByVal name As String)
        Return _container.Resolve(type, name)
    End Function

    Public Shared Function DependencyOverrideResolve(Of T, S)(ByVal obj As Object) As T
        Return _container.Resolve(Of T)(New DependencyOverride(Of S)(CType(obj, S)))
    End Function

    Public Shared Sub Inject(ByVal existing As Object)
        _container.BuildUp(existing)
    End Sub

    Public Shared Sub Inject(ByVal type As Type, ByVal existing As Object)
        _container.BuildUp(type, existing)
    End Sub

    Public Shared Sub Dispose()
        If _container IsNot Nothing Then
            _container.Dispose()
        End If
    End Sub

End Class
