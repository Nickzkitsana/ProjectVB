Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnok.Click
        Dim txt As String = ""
        Dim Sugar As Double
        Dim pH As Double
        Dim Alcohol As Double

        Try
            Sugar = CDbl(txtSugar.Text)
            pH = CDbl(txtpH.Text)
            Alcohol = CDbl(txtAlcohol.Text)

            If Double.TryParse(txtSugar.Text, 0) = False Then
                MessageBox.Show("กรุณากรอกปริมาณของน้ำตาลเป็นตัวเลข" & vbNewLine & "Ex. 0-999", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSugar.Text = ""
                txtpH.Text = ""
                txtAlcohol.Text = ""
                Exit Sub
            ElseIf Double.TryParse(txtpH.Text, 0) = False Then
                MessageBox.Show("กรุณากรอกค่า pH เป็นตัวเลข" & vbNewLine & "Ex. 0-999", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSugar.Text = ""
                txtpH.Text = ""
                txtAlcohol.Text = ""
                Exit Sub
            ElseIf Double.TryParse(txtAlcohol.Text, 0) = False Then
                MessageBox.Show("กรุณากรอกค่า Alcohol เป็นตัวเลข" & vbNewLine & "Ex. 0-999", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSugar.Text = ""
                txtpH.Text = ""
                txtAlcohol.Text = ""
                Exit Sub
            End If

            If Alcohol <= 10.5 Then
                If Sugar <= 9.5 Then
                    txt = "Low"
                Else
                    txt = "Mid"
                End If
            ElseIf Alcohol >= 10.6 Or Alcohol <= 12.5 Then
                If pH <= 3.5 Then
                    If Sugar <= 2.5 Then
                        txt = "Mid"
                    Else
                        txt = "Low"
                    End If
                End If
            End If

            If Alcohol > 12.5 Then
                MessageBox.Show("ปริมาณ Alcohol ควรน้อยกว่าหรือเท่ากับ 12.5", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAlcohol.Text = ""
            ElseIf pH > 3.5 Then
                MessageBox.Show("ปริมาณ pH ควรน้อยกว่าหรือเท่ากับ 3.5", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtpH.Text = ""
            ElseIf Sugar > 100 Then
                MessageBox.Show("ปริมาณของน้ำตาล ควรน้อยกว่า 100", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtSugar.Text = ""
            Else
                MessageBox.Show("ปริมาณของน้ำตาล :  " & txtSugar.Text & vbNewLine &
                        "ค่า pH  " & txtpH.Text & vbNewLine &
                        "ค่า Alcohol  " & txtAlcohol.Text & vbNewLine &
                        "คุณภาพระดับ  " & txt, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtSugar.Text = ""
                txtpH.Text = ""
                txtAlcohol.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show("Error with : " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnreset.Click
        txtSugar.Text = ""
        txtpH.Text = ""
        txtAlcohol.Text = ""
        btnok.Enabled = False
        btnok.BackColor = Color.Bisque
        btnreset.BackColor = Color.Bisque
    End Sub

    Private Sub txtSugar_TextChanged(sender As Object, e As EventArgs) Handles txtSugar.TextChanged, txtpH.TextChanged, txtAlcohol.TextChanged

        If txtAlcohol.Text <> "" And txtpH.Text <> "" And txtSugar.Text <> "" Then
            btnok.Enabled = True
            btnok.BackColor = Color.Lime
        ElseIf txtAlcohol.Text <> "" Or txtpH.Text <> "" Or txtSugar.Text <> "" Then
            btnreset.Enabled = True
            btnreset.BackColor = Color.PaleVioletRed
        Else
            btnok.Enabled = False
            btnreset.Enabled = False
            btnok.BackColor = Color.Bisque
            btnreset.BackColor = Color.Bisque
        End If

    End Sub

    Dim btnClicked As Boolean = False
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If btnClicked = True Then
            lblpH.Text = ""
            lblsugar.Text = ""
            lblalcohol.Text = ""
            btnClicked = False
        Else
            lblpH.Text = "ค่า pH ควรน้อยกว่าหรือเท่ากับ 3.5"
            lblalcohol.Text = "ค่า Alcohol ควรน้อยกว่าหรือเท่ากับ 12.5"
            lblsugar.Text = "ค่าปริมาณน้ำตาล ควรน้อยกว่าหรือเท่ากับ 100"
            btnClicked = True
        End If
    End Sub
End Class
