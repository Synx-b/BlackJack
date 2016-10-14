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
        If CheckForAce() Then
            GetTotalScoreOfHandForAce()
        Else
            CalculateHandsValue()
        End If
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
        Dim valid_options() As String = {"1", "2", "q"}

        Dim choice As String
        Console.Write("[1] Stick [2] Twist [q] Quit- Option: ")
        choice = Console.ReadLine()
        While Not valid_options.Contains(choice)
            Console.Write("[1] Stick [2] Twist [q] Quit- Option: ")
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
            ElseIf choice = "q" Then
                Quit()
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

    Public Function CheckForAce() As Boolean
        For Each card In __hand
            If (card.Name = "Ace") Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub GetTotalScoreOfHandForAce()
        CalculateHandsValue()
        Dim first_score As Integer = CardScore
        If (first_score + 10) <= 21 Then
            For Each card In __hand
                If card.Name = "Ace" Then
                    card.Value = 11
                End If
            Next
            CalculateHandsValue()
        Else
            For Each card In __hand
                If card.Name = "Ace" Then
                    card.Value = 1
                End If
            Next
            CalculateHandsValue()
        End If

    End Sub

    Public Sub CalculateHandsValue()
        CardScore = 0
        For Each card In __hand
            CardScore += card.Value
        Next
    End Sub

    Public Sub Quit()
        Console.WriteLine("EndTurn")
    End Sub

#End Region

#Region "Get Set Modifiers"

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
