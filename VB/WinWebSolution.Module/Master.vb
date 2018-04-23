Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.Xpo.Metadata
Imports System.Collections

Namespace WinWebSolution.Module
	<DefaultClassOptions, DeferredDeletion(False)> _
	Public Class Master
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		<Association("Master-Children"), Aggregated> _
		Public ReadOnly Property Children() As XPCollection(Of Child)
			Get
				Return GetCollection(Of Child)("Children")
			End Get
		End Property
		Private _name As String
		Public Property Name() As String
			Get
				Return _name
			End Get
			Set(ByVal value As String)
				SetPropertyValue("Name", _name, value)
			End Set
		End Property
		Protected Overrides Sub OnDeleting()
			Dim objs As ICollection = Session.CollectReferencingObjects(Me)
			If objs.Count > 0 Then
				For Each mi As XPMemberInfo In ClassInfo.CollectionProperties
					If mi.IsAggregated AndAlso mi.IsCollection AndAlso mi.IsAssociation Then
						For Each obj As IXPObject In objs
							If (CType(mi.GetValue(Me), XPBaseCollection)).BaseIndexOf(obj) < 0 Then
								Throw New InvalidOperationException("The object cannot be deleted. Other objects have references to it.")
							End If
						Next obj
					End If
				Next mi
			End If
			MyBase.OnDeleting()
		End Sub
	End Class
End Namespace