Imports System
Imports System.Windows.Forms
Imports System.Drawing

Namespace Homework1_VB
    Public Class Ball
        Public Property width As Integer
        Public Property height As Integer
        Public Property posX As Integer
        Public Property posY As Integer
        Public Property speedX As Integer
        Public Property speedY As Integer
        Public Property ballColor As Brush
        Private borderColor As Pen = Pens.Black
        Private pictureBox As PictureBox

        Public Sub New(ByVal w As Integer, ByVal h As Integer, ByVal x As Integer, ByVal y As Integer, ByVal sX As Integer, ByVal sY As Integer, ByVal color As Brush, ByVal pb As PictureBox)
            Me.width = w
            Me.height = h
            Me.posX = x
            Me.posY = y
            Me.speedX = sX
            Me.speedY = sY
            Me.ballColor = color
            Me.pictureBox = pb
        End Sub

        Public Sub Draw(ByVal g As Graphics)
            g.FillEllipse(Me.ballColor, Me.posX, Me.posY, Me.width, Me.height)
            g.DrawEllipse(Me.borderColor, Me.posX, Me.posY, Me.width, Me.height)
        End Sub

        Public Sub Update()
            Me.posX += Me.speedX
            Me.posY += Me.speedY
            If Me.posX < 0 OrElse Me.posX + Me.width > Me.pictureBox.Width Then Me.speedX = -Me.speedX
            If Me.posY < 0 OrElse Me.posY + Me.height > Me.pictureBox.Height Then Me.speedY = -Me.speedY
        End Sub
    End Class
End Namespace
