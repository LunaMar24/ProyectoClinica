Public Interface IRepositorio(Of T)
  Function GetAll(Optional filtros As Dictionary(Of String, Object) = Nothing) As List(Of T)
  Function GetById(id As Integer) As T
  Function Insert(entity As T) As Integer
  Function Update(entity As T) As Integer
  Function Delete(id As Integer) As Integer
End Interface