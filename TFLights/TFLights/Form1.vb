Public Class Form1

    ' Enums to easily track the light state
    Private Enum LightPhase
        Green
        Yellow
        LeftTurn
    End Enum

    ' State Tracking Variables
    Private currentIntersection As Integer = 1
    Private currentPhase As LightPhase = LightPhase.Green
    Private timeRemaining As Integer = GREEN_DURATION

    ' Signal Durations (in seconds)
    Private Const GREEN_DURATION As Integer = 10
    Private Const YELLOW_DURATION As Integer = 3
    Private Const LEFT_DURATION As Integer = 5

    ' Total time a single intersection cycle takes (18 seconds)
    Private Const TOTAL_CYCLE_TIME As Integer = GREEN_DURATION + YELLOW_DURATION + LEFT_DURATION
    ' Total time of the entire 3-intersection system loop (54 seconds)
    Private Const TOTAL_SYSTEM_TIME As Integer = TOTAL_CYCLE_TIME * 3

    ''' <summary>
    ''' Runs automatically the exact moment the window opens.
    ''' </summary>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateSystemLights()
        tmrTraffic.Interval = 1000
        tmrTraffic.Start()
    End Sub

    ''' <summary>
    ''' The core clock engine running every 1 second.
    ''' </summary>
    Private Sub tmrTraffic_Tick(sender As Object, e As EventArgs) Handles tmrTraffic.Tick
        ' Decrement the active phase timer
        timeRemaining -= 1

        ' System state transitions
        If timeRemaining <= 0 Then
            Select Case currentPhase
                Case LightPhase.Green
                    currentPhase = LightPhase.Yellow
                    timeRemaining = YELLOW_DURATION

                Case LightPhase.Yellow
                    currentPhase = LightPhase.LeftTurn
                    timeRemaining = LEFT_DURATION

                Case LightPhase.LeftTurn
                    ' Move to next intersection
                    currentIntersection += 1
                    If currentIntersection > 3 Then currentIntersection = 1

                    currentPhase = LightPhase.Green
                    timeRemaining = GREEN_DURATION
            End Select
        End If

        ' Refresh the screen visuals and calculations
        UpdateSystemLights()
    End Sub

    ' --- CONTINUOUS COUNTDOWN LOGIC ---

    ''' <summary>
    ''' Refreshes display colors and computes non-stop countdown values for every intersection.
    ''' </summary>
    Private Sub UpdateSystemLights()
        ' First reset all light colors to default Red/Off status
        For i As Integer = 1 To 3
            SetRed(i)
        Next

        ' Update the active intersection light states
        Select Case currentIntersection
            Case 1 : SetActiveVisuals(1, currentPhase)
            Case 2 : SetActiveVisuals(2, currentPhase)
            Case 3 : SetActiveVisuals(3, currentPhase)
        End Select

        ' Calculate and display continuous countdown times for all intersections
        For i As Integer = 1 To 3
            Dim continuousWaitTime As Integer = CalculateContinuousTime(i)
            UpdateCountdownLabel(i, continuousWaitTime)
        Next
    End Sub

    ''' <summary>
    ''' Computes exactly how many seconds remain before or during an intersection's cycle.
    ''' </summary>
    Private Function CalculateContinuousTime(intersectionNum As Integer) As Integer
        ' Calculate how many seconds have passed inside the current active intersection's phase
        Dim elapsedInCurrentPhase As Integer = 0
        Select Case currentPhase
            Case LightPhase.Green
                elapsedInCurrentPhase = GREEN_DURATION - timeRemaining
            Case LightPhase.Yellow
                elapsedInCurrentPhase = GREEN_DURATION + (YELLOW_DURATION - timeRemaining)
            Case LightPhase.LeftTurn
                elapsedInCurrentPhase = GREEN_DURATION + YELLOW_DURATION + (LEFT_DURATION - timeRemaining)
        End Select

        ' Calculate the distance from global step zero (Intersection 1 starting green)
        Dim globalElapsedSeconds As Integer = ((currentIntersection - 1) * TOTAL_CYCLE_TIME) + elapsedInCurrentPhase

        ' Find where target intersection starts relative to global step zero
        Dim targetStartSeconds As Integer = (intersectionNum - 1) * TOTAL_CYCLE_TIME

        ' Calculate the relative time remaining until that intersection finishes its active cycle
        Dim relativeTime As Integer = (targetStartSeconds + TOTAL_CYCLE_TIME) - globalElapsedSeconds

        ' Wrap the calculation mathematically within our total system timeframe loop
        If relativeTime <= 0 Then
            relativeTime += TOTAL_SYSTEM_TIME
        End If

        Return relativeTime
    End Function

    Private Sub SetActiveVisuals(intersectionNum As Integer, phase As LightPhase)
        Select Case phase
            Case LightPhase.Green : SetGreen(intersectionNum)
            Case LightPhase.Yellow : SetYellow(intersectionNum)
            Case LightPhase.LeftTurn : SetLeftTurn(intersectionNum)
        End Select
    End Sub

    ' --- LIGHT COLOR DEFINITIONS ---

    Private Sub SetRed(intersectionNum As Integer)
        SetLightColors(intersectionNum, Color.Red, Color.Olive, Color.DarkGreen, Color.DarkGray)
    End Sub

    Private Sub SetYellow(intersectionNum As Integer)
        SetLightColors(intersectionNum, Color.DarkRed, Color.Yellow, Color.DarkGreen, Color.DarkGray)
    End Sub

    Private Sub SetGreen(intersectionNum As Integer)
        SetLightColors(intersectionNum, Color.DarkRed, Color.Olive, Color.Lime, Color.DarkGray)
    End Sub

    Private Sub SetLeftTurn(intersectionNum As Integer)
        ' Left turn rule: Red light stays active, Arrow changes color
        SetLightColors(intersectionNum, Color.Red, Color.Olive, Color.DarkGreen, Color.Cyan)
    End Sub

    Private Sub SetLightColors(id As Integer, redClr As Color, yellowClr As Color, greenClr As Color, leftClr As Color)
        CType(Me.Controls.Find("picRed" & id, True)(0), PictureBox).BackColor = redClr
        CType(Me.Controls.Find("picYellow" & id, True)(0), PictureBox).BackColor = yellowClr
        CType(Me.Controls.Find("picGreen" & id, True)(0), PictureBox).BackColor = greenClr

        Dim picLeft As PictureBox = CType(Me.Controls.Find("picLeft" & id, True)(0), PictureBox)
        picLeft.BackColor = Color.FromArgb(30, 30, 30) ' Dark asphalt background box color
        picLeft.ForeColor = leftClr                     ' Set arrow color status
        picLeft.Invalidate()                            ' Tells the computer to redraw the arrow
    End Sub

    Private Sub UpdateCountdownLabel(id As Integer, secondsLeft As Integer)
        Dim lbl As Label = CType(Me.Controls.Find("lblCount" & id, True)(0), Label)
        lbl.Text = secondsLeft.ToString() & "s"
    End Sub

    ' --- VECTOR ARROW VECTOR DRAWING ENGINE ---

    Private Sub picLeft1_Paint(sender As Object, e As PaintEventArgs) Handles picleft1.Paint
        DrawLeftArrow(sender, e.Graphics)
    End Sub

    Private Sub picLeft2_Paint(sender As Object, e As PaintEventArgs) Handles picLeft2.Paint
        DrawLeftArrow(sender, e.Graphics)

    End Sub

    Private Sub picLeft3_Paint(sender As Object, e As PaintEventArgs) Handles picLeft3.Paint
        DrawLeftArrow(sender, e.Graphics)
    End Sub

    ''' <summary>
    ''' Dynamically draws a smooth, professional vector left-turn arrow onto the PictureBox surface.
    ''' </summary>
    Private Sub DrawLeftArrow(sender As Object, g As Graphics)
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Dim pBox As PictureBox = CType(sender, PictureBox)

        ' Create a pen using the color assigned in SetLightColors
        Using arrowBrush As New SolidBrush(pBox.ForeColor)
            ' Define geometry coordinates based on the current picture box size
            Dim w As Integer = pBox.Width
            Dim h As Integer = pBox.Height

            ' Construct coordinate points for a left pointing triangle arrow head
            Dim arrowPoints As Point() = {
                New Point(CInt(w * 0.2), CInt(h * 0.5)),
                New Point(CInt(w * 0.5), CInt(h * 0.25)),
                New Point(CInt(w * 0.5), CInt(h * 0.4)),
                New Point(CInt(w * 0.8), CInt(h * 0.4)),
                New Point(CInt(w * 0.8), CInt(h * 0.6)),
                New Point(CInt(w * 0.5), CInt(h * 0.6)),
                New Point(CInt(w * 0.5), CInt(h * 0.75))
            }

            g.FillPolygon(arrowBrush, arrowPoints)
        End Using
    End Sub

End Class
