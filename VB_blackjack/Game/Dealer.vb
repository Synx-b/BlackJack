Public Class Dealer
    Inherits Player

#Region "Dealer Methods"

    Public Sub Deal(ByVal player As Player, ByVal player2 As Player)
        Dim card As Card = New Card()

        For x As Integer = 0 To 1
            card = cardStack.Pop
            __hand.Add(card)
            card = cardStack.Pop
            player2.__hand.Add(card)
            card = cardStack.Pop
            player.__hand.Add(card)
        Next

    End Sub

    Public Overloads Sub ProcessChoice()
        If CardScore < 21 Then
            Twist()
        End If
    End Sub

    Public Overloads Sub Twist()
        Dim card As Card = cardStack.Pop
        __hand.Add(card)
        GetTotalScoreOfHand()
        If Not __STICK Then
            If CardScore < 21 Then
                Twist()
            ElseIf CardScore >= 16 And CardScore <= 21 Then
                Stick()
            Else
                __BUST = True
            End If
        End If


    End Sub

    Public Sub WhoWins(ByVal player As Player, ByVal player2 As Player)
        If CardScore = 21 Then
            Console.WriteLine("Dealer Wins")
        ElseIf __BUST And player.__BUST And player2.__BUST Then
            Console.WriteLine("No One Wins")
        ElseIf __BUST And Not player.__BUST And player2.__BUST Then
            Console.WriteLine("Player 1 Wins")
        ElseIf __BUST And player.__BUST And Not player2.__BUST Then
            Console.WriteLine("Player 2 Wins")
        ElseIf Not __BUST And player.__BUST And player2.__BUST Then
            Console.WriteLine("Dealer Wins")
        ElseIf __BUST And Not player.__BUST And Not player2.__BUST Then
            If player.CardScore > player2.CardScore Then
                Console.WriteLine("Player 1 Wins")
            ElseIf player.CardScore = player2.CardScore Then
                Console.WriteLine("Player 1 and 2 Wins")
            Else
                Console.WriteLine("Player 2 Wins")
            End If
        ElseIf Not __BUST And player.__BUST And Not player2.__BUST Then
            If CardScore > player2.CardScore Then
                Console.WriteLine("Dealer Wins")
            Else
                Console.WriteLine("Player 2 Wins")
            End If
        ElseIf Not __BUST And Not player.__BUST And player2.__BUST Then
            If CardScore > player.CardScore Then
                Console.WriteLine("Dealer Wins")
            Else
                Console.WriteLine("Player 1 Wins")
            End If
        Else
            If CardScore > player.CardScore And CardScore > player2.CardScore Then
                Console.WriteLine("Dealer Wins")
            ElseIf CardScore = player.CardScore And CardScore = player2.CardScore Then
                Console.WriteLine("Dealer Wins")
            ElseIf player.CardScore > CardScore And player.CardScore > player2.CardScore Then
                Console.WriteLine("Player 1 Wins")
            ElseIf player2.CardScore > CardScore And player2.CardScore > player.CardScore Then
                Console.WriteLine("Player 2 Wins")
            End If
        End If
    End Sub
#End Region
End Class
