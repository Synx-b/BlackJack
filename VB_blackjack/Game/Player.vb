Public Class Player
    Inherits Deck
#Region "PlayerMembers"
    Public __hand As List(Of Card) = New List(Of Card)
    Public __cardScore As Integer
    Public __STICK As Boolean = False
    Public __BUST As Boolean = False
#End Region

#Region "PlayerMethods"
    Public Sub New()
        PopulateCardStack()
    End Sub

    Public Sub GetTotalScoreOfHand()
        CardScore = 0
        For Each card In __hand
            CardScore += card.Value
        Next
    End Sub

    Public Sub ShowTotalCardScore()
        Console.WriteLine("Card Score: {0}", CardScore)
    End Sub

    Public Sub ShowHand()
        Me.GetTotalScoreOfHand()
        For x As Integer = 0 To __hand.Count - 1
            Console.WriteLine("Card Name:  {0} {1}", __hand(x).Name, __hand(x).Suit)
        Next
        ShowTotalCardScore()
    End Sub

    Public Function GetChoice() As String
        Dim valid_options() As String = {"1", "2"}

        Dim choice As String
        Console.Write("[1] Stick [2] Twist - Option: ")
        choice = Console.ReadLine()
        While Not valid_options.Contains(choice)
            Console.Write("[1] Stick [2] Twist - Option: ")
            choice = Console.ReadLine()
        End While
        Return choice
    End Function

    Public Sub ProcessChoice()
        If Not Me.__STICK Then
            Dim choice As String = GetChoice()
            If choice = "2" Then
                Twist()
            ElseIf choice = "1" Then
                Stick()
            End If
        End If
    End Sub

    Public Sub Twist()
        Dim card As Card = cardStack.Pop
        __hand.Add(card)
        Me.GetTotalScoreOfHand()
        If Me.CardScore > 21 Then
            Me.ShowHand()
            __BUST = True
            Console.WriteLine("BUST")
        ElseIf Me.CardScore = 21 Then
            Me.ShowHand()
            Me.__STICK = True
        Else
            Me.ShowHand()
            Me.ProcessChoice()
        End If


    End Sub

    Public Sub Stick()
        Me.__STICK = True
    End Sub

    Public Property CardScore()
        Get
            Return __cardScore
        End Get
        Set(value)
            __cardScore = value
        End Set
    End Property

#End Region

End Class
