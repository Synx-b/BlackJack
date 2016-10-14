Module Module1

    Sub Main()

        Dim player As Player = New Player()
        Dim player2 As Player = New Player()
        Dim dealer As Dealer = New Dealer()

        dealer.Deal(player, player2)

        Console.WriteLine(" -------- Player 1 -------- ")
        player.ShowHand()
        player.ProcessChoice()

        Console.WriteLine(" -------- Player 2 -------- ")

        player2.ShowHand()
        player2.ProcessChoice()

        Console.WriteLine(" -------- Dealer -------- ")

        dealer.ProcessChoice()
        dealer.ShowHand()

        Console.Write(vbNewLine)
        Console.WriteLine(" -------- Winner -------- ")
        dealer.WhoWins(player, player2)
        Console.WriteLine(" ------------------------")

        Console.ReadKey()

    End Sub

End Module
