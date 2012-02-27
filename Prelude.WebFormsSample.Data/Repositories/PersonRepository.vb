Imports Prelude.WebFormsSample.Core.Interfaces
Imports Prelude.WebFormsSample.Core.PersonSection

Namespace Repositories

    Public Class PersonRepository
        Implements IPersonRepository

        Private ReadOnly ctx As IPersonEntities

        Public Sub New(context As Func(Of IPersonEntities))
            ctx = context()
        End Sub

        Public Function GetAddressByID(id As Integer) As Address Implements IPersonRepository.GetAddressByID

            Return ctx.Address.Where(Function(addr) addr.AddressID = id).FirstOrDefault()

        End Function

    End Class

End Namespace
