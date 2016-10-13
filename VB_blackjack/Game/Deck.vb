Imports System.Security.Cryptography

Public Class Deck
    Inherits Card
#Region "DeckMembers"
    Private __deck As List(Of Card) = New List(Of Card)
    Private cardCount As Integer = 0
    Protected cardStack As Stack = New Stack()

#End Region

#Region "DeckMethods"

    Private Sub GenerateDeck()
        For Each a In __suits
            For x As Integer = 0 To 12
                Dim card As Card = New Card
                card.Suit = a
                card.Postition = x + 1
                card.Value = Math.Min(10, x + 1)
                card.Name = __names(x)
                __deck.Add(card)
                cardCount += 1
            Next
        Next
    End Sub

    Private Sub OutputDeck()
        For I As Integer = 0 To __deck.Count - 1
            Console.WriteLine(vbNewLine)
            Console.WriteLine("Card Suit: {0}", __deck(I).Suit)
            Console.WriteLine("Card Name: {0}", __deck(I).Name)
            Console.WriteLine("Card Value: {0}", __deck(I).Value)
            Console.WriteLine("Card Position: {0}", __deck(I).Postition)
        Next
    End Sub

    Private Sub ShuffleDeck()
        Dim rng As RNGCryptoServiceProvider = New RNGCryptoServiceProvider()
        Dim card_count As Integer = __deck.Count

        While card_count > 1
            Dim box() As Byte = New Byte() {1}
            Do
                rng.GetBytes(box)
            Loop While Not (box(0) < card_count * (Byte.MaxValue / card_count))
            Dim k As Integer = (box(0) Mod card_count)
            card_count -= 1
            Dim card As Card = __deck(k)
            __deck(k) = __deck(card_count)
            __deck(card_count) = card
        End While

    End Sub

    Protected Sub PopulateCardStack()
        GenerateDeck()
        ShuffleDeck()
        For Each card In __deck
            cardStack.Push(card)
        Next
    End Sub
#End Region

End Class
