Public Class Card

    Protected __names() As String = {"Ace", "2", "3", "4", "5", "6", "7",
                                    "8", "9", "10", "Jack", "Queen", "King"}
    Protected __suits() As String = {"Diamonds", "Hearts", "Clubs", "Spades"}

    Protected __name As String
    Protected __value As Integer
    Protected __suit As String
    Protected __position As Integer

    Public Property Name() As String
        Get
            Return __name
        End Get
        Set(value As String)
            __name = value
        End Set
    End Property

    Public Property Value() As Integer
        Get
            Return __value
        End Get
        Set(value As Integer)
            __value = value
        End Set
    End Property

    Public Property Suit() As String
        Get
            Return __suit
        End Get
        Set(value As String)
            __suit = value
        End Set
    End Property

    Public Property Postition() As Integer
        Get
            Return __position
        End Get
        Set(value As Integer)
            __position = value
        End Set
    End Property

End Class
