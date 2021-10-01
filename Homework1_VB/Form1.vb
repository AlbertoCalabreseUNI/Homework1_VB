Imports Homework1_VB.Homework1_VB

Public Class Form1

    Public list As ArrayList
    Private random As Random
    Private timer As Timer = New Timer()

    Public Sub New()
        InitializeComponent()

        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)
        DoubleBuffered = True
        Me.UpdateStyles()

        random = New Random()

        list = New ArrayList()
        populate()

        timer.Enabled = True
        timer.Interval = 20
        timer.Stop()

        AddHandler timer.Tick, AddressOf Timer1_Tick
        AddHandler PictureBox1.Paint, AddressOf PictureBox1_Paint
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.timer.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.timer.Stop()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        timer.Stop()

        For Each ball As Ball In list
            ball.posX = random.[Next](0, Me.PictureBox1.Width / 2)
            ball.posY = random.[Next](0, Me.PictureBox1.Height / 2)
            ball.speedX = random.[Next](1, 10)
            ball.speedY = random.[Next](1, 10)
            ball.ballColor = New SolidBrush(Color.FromArgb(random.[Next](0, 255), random.[Next](0, 255), random.[Next](0, 255)))
        Next

        timer.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)
        Me.PictureBox1.Refresh()
    End Sub

    Public Sub populate()
        Dim size As Integer = 50

        For i As Integer = 0 To 10 - 1
            Dim startX As Integer = random.[Next](0, Me.PictureBox1.Width / 2)
            Dim startY As Integer = random.[Next](0, Me.PictureBox1.Height / 2)
            Dim speedX As Integer = random.[Next](1, 10)
            Dim speedY As Integer = random.[Next](1, 10)
            Dim ballColor As SolidBrush = New SolidBrush(Color.FromArgb(random.[Next](0, 255), random.[Next](0, 255), random.[Next](0, 255)))
            list.Add(New Ball(size, size, startX, startY, speedX, speedY, ballColor, Me.PictureBox1))
        Next
    End Sub

    Private Sub PictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim g As Graphics = e.Graphics

        For Each ball As Ball In list
            ball.Update()
            ball.Draw(g)
        Next
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.RichTextBox1.Text = "Hello! Welcome to Statistics!"
    End Sub
End Class
