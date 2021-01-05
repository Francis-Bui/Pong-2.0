Public Class Form1

    Private animatedImage As Bitmap = Image.FromFile("C:\Users\Francis Bui\Documents\Visual Studio 2010\Projects\GPong Francis\GPong Francis\Resources\explosion.gif")

    'Physics'
    Dim ballxVel As Integer = 30
    Dim ballyVel As Integer = 30
    Dim padyVel As Integer = 20
    Dim velInc As Integer = 3
    Dim pdlInc As Integer = 10
    Dim lazerVel As Integer = 70
    Dim powerVel As Integer = 20

    'Flags'
    Dim padLUp As Boolean = False
    Dim padLDown As Boolean = False
    Dim padRUp As Boolean = False
    Dim padRDown As Boolean = False
    Dim shootL As Boolean = False
    Dim shootR As Boolean = False
    Dim start As Boolean = True
    Dim hit As Boolean = False
    Dim laserLClear As Boolean = True
    Dim laserRClear As Boolean = True
    Dim endRoundL As Boolean = False
    Dim endRoundR As Boolean = False

    'scoring'
    Dim scoreL As Integer = 0
    Dim scoreR As Integer = 0
    Dim shieldHpL As Integer = 0
    Dim shieldHpR As Integer = 0
    Dim padLHeight As Integer = 150
    Dim padRHeight As Integer = 150

    Dim rnd As New Random

    'Rectangles'
    Dim rBall As Rectangle
    Dim rPadL As Rectangle
    Dim rPadR As Rectangle
    Dim rTitle As Rectangle
    Dim rWinner As Rectangle
    Dim rStart As Rectangle
    Dim rQuit As Rectangle
    Dim rScoreL As Rectangle
    Dim rScoreR As Rectangle
    Dim rExplosion As Rectangle
    Dim rLaserL As Rectangle
    Dim rLaserR As Rectangle
    Dim rBackHPL As Rectangle
    Dim rBackHPR As Rectangle
    Dim rHPL As Rectangle
    Dim rHPR As Rectangle
    Dim rBackShotL As Rectangle
    Dim rShotL As Rectangle
    Dim rBackShotR As Rectangle
    Dim rShotR As Rectangle

    Private Sub pbCanvas_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles pbCanvas.Paint

        If start = False Then

            'Create info'

            e.Graphics.FillRectangle(Brushes.DarkRed, rBackHPL)
            e.Graphics.FillRectangle(Brushes.Red, rHPL)

            e.Graphics.FillRectangle(Brushes.DarkRed, rBackHPR)
            e.Graphics.FillRectangle(Brushes.Red, rHPR)

            If laserLClear = True Then
                e.Graphics.DrawImage(My.Resources.Loaded, rBackShotL)
                e.Graphics.DrawImage(My.Resources.LoadedRed, rShotL)
            ElseIf laserLClear = False Then
                e.Graphics.DrawImage(My.Resources.Empty, rShotL)
            End If

            If laserRClear = True Then
                e.Graphics.DrawImage(My.Resources.LoadedRed, rShotR)
                e.Graphics.DrawImage(My.Resources.Loaded, rBackShotR)
            ElseIf laserRClear = False Then
                e.Graphics.DrawImage(My.Resources.Empty, rShotR)
            End If

            'Create ball'
            e.Graphics.DrawImage(My.Resources.fireball, rBall)

            'Create Ships'
            If padLHeight > 30 Then
                e.Graphics.DrawImage(My.Resources.pongShipBlue, rPadL)
            End If

            If padRHeight > 30 Then
                e.Graphics.DrawImage(My.Resources.pongShipRed, rPadR)
            End If

            'Scoring'
            If scoreL = 0 Then
                e.Graphics.DrawImage(My.Resources._0, rScoreL)
            ElseIf scoreL = 1 Then
                e.Graphics.DrawImage(My.Resources._1, rScoreL)
            ElseIf scoreL = 2 Then
                e.Graphics.DrawImage(My.Resources._2, rScoreL)
            ElseIf scoreL = 3 Then
                e.Graphics.DrawImage(My.Resources._3, rScoreL)
            End If

            If scoreR = 0 Then
                e.Graphics.DrawImage(My.Resources._0, rScoreR)
            ElseIf scoreR = 1 Then
                e.Graphics.DrawImage(My.Resources._1, rScoreR)
            ElseIf scoreR = 2 Then
                e.Graphics.DrawImage(My.Resources._2, rScoreR)
            ElseIf scoreR = 3 Then
                e.Graphics.DrawImage(My.Resources._3, rScoreR)
            End If

            If scoreL > 3 Then
                start = True
                endRoundL = True
            End If

            If scoreR > 3 Then
                start = True
                endRoundR = True
            End If

            e.Graphics.DrawImage(My.Resources.explosion, rExplosion)

            'check if shot'
            If shootL = True Then
                e.Graphics.DrawRectangle(Pens.Blue, rLaserL)
                e.Graphics.FillRectangle(Brushes.White, rLaserL)
            End If

            If shootR = True Then
                e.Graphics.DrawRectangle(Pens.Red, rLaserR)
                e.Graphics.FillRectangle(Brushes.White, rLaserR)
            End If

        End If

        'display when start = true'
        If start = True Then

            e.Graphics.DrawImage(My.Resources.Title, rTitle)
            e.Graphics.DrawImage(My.Resources.Start, rStart)
            e.Graphics.DrawImage(My.Resources.Quit, rQuit)

            If endRoundL = True Then
                e.Graphics.DrawImage(My.Resources.Blue_Wins, rWinner)
            End If

            If endRoundR = True Then
                e.Graphics.DrawImage(My.Resources.Red_Wins, rWinner)
            End If

        End If

    End Sub


    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

        rBall.X += ballxVel
        rBall.Y += ballyVel

        rLaserL.X += lazerVel
        rLaserR.X -= lazerVel

        'Bottom'
        If rBall.Bottom >= pbCanvas.Bottom Then
            ballyVel *= -1
        End If

        'Top'
        If rBall.Top <= pbCanvas.Top Then
            ballyVel *= -1
        End If

        'Right'
        If rBall.Right >= pbCanvas.Right Then
            CentreBall()
            scoreL += 1
        End If

        'Left'
        If rBall.Left <= pbCanvas.Left Then
            CentreBall()
            scoreR += 1
        End If

        'check if the laser is off screen'
        If rLaserL.X >= pbCanvas.Right Then
            laserLClear = True
        End If

        If rLaserR.X <= pbCanvas.Left Then
            laserRClear = True
        End If


        'Paddle code'

        If padLUp = True And rPadL.Top > pbCanvas.Top Then
            rPadL.Y -= padyVel
        End If

        If padLDown = True And rPadL.Bottom < pbCanvas.Bottom Then
            rPadL.Y += padyVel
        End If

        'Right Paddle'
        If padRUp = True And rPadR.Top > pbCanvas.Top Then
            rPadR.Y -= padyVel
        End If

        If padRDown = True And rPadR.Bottom < pbCanvas.Bottom Then
            rPadR.Y += padyVel
        End If

        'Check if pad is dead'
        If padRHeight < 30 Then
            scoreR += 1
            CentreBall()
        End If

        If padLHeight < 30 Then
            scoreR += 1
            CentreBall()
        End If

        BlockCollide(rPadL)
        BlockCollide(rPadR)

        pbCanvas.Refresh()

    End Sub

    Private Sub Form1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        'Up W // Left Table'
        If e.KeyData = Keys.W Then
            padLUp = True
            padLDown = False
        End If

        'Down S// Left Table'
        If e.KeyData = Keys.S Then
            padLDown = True
            padLUp = False
        End If

        'Up Arrow // Right Table'
        If e.KeyData = Keys.Up Then
            padRUp = True
            padRDown = False
        End If

        'Down Arrow // Right Table'
        If e.KeyData = Keys.Down Then
            padRDown = True
            padRUp = False
        End If

        'Blue Laser Shoot'
        If e.KeyData = Keys.Space And laserLClear = True Then
            shootL = True
            My.Computer.Audio.Play(My.Resources.laser, AudioPlayMode.Background)
            rLaserL = New Rectangle(rPadL.X + 20, rPadL.Y + 60, 25, 10)
            laserLClear = False
        End If

        'Right Laser Shoot'
        If e.KeyData = Keys.NumPad0 And laserRClear = True Then
            shootR = True
            My.Computer.Audio.Play(My.Resources.laser, AudioPlayMode.Background)
            rLaserR = New Rectangle(rPadR.X + 20, rPadR.Y + 60, 25, 10)
            laserRClear = False
        End If

    End Sub

    Private Sub Form1_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp

        'Up W // Left Table'
        If e.KeyData = Keys.W Then
            padLUp = False
        End If

        'Down S // Left Table'
        If e.KeyData = Keys.S Then
            padLDown = False
        End If

        'Up Arrow // Right Table'
        If e.KeyData = Keys.Up Then
            padRUp = False
        End If

        'Down Arrow // Right Table'
        If e.KeyData = Keys.Down Then
            padRDown = False
        End If

    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'info'
        rBackHPL = New Rectangle(104, 27, 460, 67)
        rBackHPR = New Rectangle(1000, 27, 460, 67)

        rBackShotL = New Rectangle(12, 600, 99, 53)
        rShotL = New Rectangle(13, 605, 99, 53)
        rBackShotR = New Rectangle(1463, 600, 99, 53)
        rShotR = New Rectangle(1464, 605, 99, 53)

        'Ball'
        rBall = New Rectangle(50, 50, 50, 50)

        'Ships'
        rPadL = New Rectangle(60, pbCanvas.Height / 2 - 150, 60, 150)
        rPadR = New Rectangle(pbCanvas.Width - 120, 150, 60, 150)

        'title images'

        rTitle = New Rectangle(530, 50, 490, 115)
        rWinner = New Rectangle(510, 170, 530, 125)
        rStart = New Rectangle(400, 400, 203, 94)
        rQuit = New Rectangle(980, 400, 203, 94)
        rScoreL = New Rectangle(31, 25, 48, 56)
        rScoreR = New Rectangle(1504, 25, 48, 56)

    End Sub

    Private Sub CentreBall()

        'Centres ball and generates random direction'
        rBall.Location = New Point(pbCanvas.Width / 2, pbCanvas.Height / 2)
        ballxVel = rnd.Next(-25, 25)
        ballyVel = rnd.Next(-10, 10)

        padLHeight = 150
        padRHeight = 150
        rPadL = New Rectangle(rPadL.X, rPadL.Y, 60, padLHeight)
        rPadR = New Rectangle(rPadR.X, rPadR.Y, 60, padRHeight)

        rHPL = New Rectangle(115, 30, padLHeight * 3, 60)
        rHPR = New Rectangle(1000, 30, padRHeight * 3, 60)

        'ensures ball isnt too slow'
        Do While ballxVel >= -12 And ballxVel <= 13 Or ballyVel >= -7 And ballyVel <= 8

            ballxVel = rnd.Next(-25, 25)
            ballyVel = rnd.Next(-10, 10)

        Loop

    End Sub

    Private Sub BlockCollide(rect As Rectangle)

        'Where to create explosion'
        If rBall.IntersectsWith(rect) Then
            rExplosion = New Rectangle(rBall.X, rBall.Y, 70, 70)
        End If

        If rLaserL.IntersectsWith(rect) Then
            laserLClear = True
            rExplosion = New Rectangle(rect.X, rect.Y, 60, 60)
        End If

        If rLaserR.IntersectsWith(rect) Then
            laserLClear = True
            rExplosion = New Rectangle(rect.X, rect.Y, 60, 60)
        End If


        'check for a collision first.  If yes, then...
        If rBall.IntersectsWith(rect) Or rLaserL.IntersectsWith(rect) Or rLaserR.IntersectsWith(rect) Then


            'from the left?
            If rBall.Right >= rect.Left And rBall.Left < rect.Left Then
                ballxVel *= -1
            End If

            'from the right?
            If rBall.Left <= rect.Right And rBall.Right > rect.Right Then
                ballxVel *= -1
            End If

            'from the top
            If rBall.Bottom >= rect.Top And rBall.Top < rect.Top Then
                ballyVel *= -1
            End If

            'from the bottom
            If rBall.Top <= rect.Bottom And rBall.Bottom > rect.Bottom Then
                ballyVel *= -1
            End If

            My.Computer.Audio.Play(My.Resources.Explosion1, AudioPlayMode.Background)

            'Health Degrading'
            'Speed Increment'
            If rPadL.IntersectsWith(rBall) Then
                ballxVel += velInc
                padLHeight -= pdlInc
            End If

            If rPadR.IntersectsWith(rBall) Then
                ballxVel -= velInc
                padRHeight -= pdlInc
            End If

            If rPadL.IntersectsWith(rLaserR) Then
                padLHeight -= pdlInc
            End If

            If rPadR.IntersectsWith(rLaserL) Then
                padRHeight -= pdlInc
            End If

            'Give shield health'
            ' shieldHpL = rPadL.Height
            'shieldHpR = rPadR.Height

            'tbShieldL.Text = shieldHpL
            'tbShieldR.Text = shieldHpR

            rPadL = New Rectangle(rPadL.X, rPadL.Y, 60, padLHeight)
            rPadR = New Rectangle(rPadR.X, rPadR.Y, 60, padRHeight)

            rHPL = New Rectangle(115, 30, (padLHeight - 30) * 3, 60)
            rHPR = New Rectangle(1000, 30, (padRHeight - 30) * 3, 60)

        End If
    End Sub


    Private Sub Reset()
        start = False
        scoreL = 0
        scoreR = 0
        shieldHpL = 0
        shieldHpR = 0
        endRoundL = False
        endRoundR = False
        CentreBall()
    End Sub


    Private Sub pbCanvas_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles pbCanvas.MouseDown

        If rStart.Contains(e.Location) Then
            Reset()
            Timer1.Enabled = True
        End If

        If rQuit.Contains(e.Location) Then
            End
        End If

    End Sub

End Class
