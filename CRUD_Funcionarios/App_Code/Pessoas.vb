Imports System.ComponentModel.DataAnnotations.Schema
Imports Microsoft.VisualBasic

Public Class Pessoas

    Private idValue As Integer
    Public Property Id() As Integer
        Get
            Return idValue
        End Get
        Set(ByVal value As Integer)
            idValue = value
        End Set
    End Property

    Public nomeValue As String
    Public Property Nome() As String
        Get
            Return nomeValue
        End Get
        Set(ByVal value As String)
            nomeValue = value
        End Set
    End Property

    Private dataValue As Date
    Public Property Data() As Date
        Get
            Return dataValue
        End Get
        Set(ByVal value As Date)
            dataValue = value
        End Set
    End Property

    Private emailValue As String
    Public Property Email() As String
        Get
            Return emailValue
        End Get
        Set(ByVal value As String)
            emailValue = value
        End Set
    End Property

    Private telefoneValue As String
    Public Property Telefone() As String
        Get
            Return telefoneValue
        End Get
        Set(ByVal value As String)
            telefoneValue = value
        End Set
    End Property
End Class

