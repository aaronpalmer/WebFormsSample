'------------------------------------------------------------------------------
' <auto-generated>
'    This code was generated from a template.
'
'    Manual changes to this file may cause unexpected behavior in your application.
'    Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Namespace PersonSection

    Partial Public Class Address
        Public Property AddressID As Integer
        Public Property AddressLine1 As String
        Public Property AddressLine2 As String
        Public Property City As String
        Public Property StateProvinceID As Integer
        Public Property PostalCode As String
        Public Property rowguid As System.Guid
        Public Property ModifiedDate As Date
    
        Public Overridable Property StateProvince As StateProvince
    
    End Class

End Namespace
