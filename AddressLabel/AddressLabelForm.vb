'Fallon Smith
'RCET0265
'Spring 2022
'Address label program
'

Public Class AddressLabelForm
    Function ValidateInput() As Boolean
        Dim Vaild As Boolean = True
        Dim UserZip As Integer

        ''If LastNameTextBox.Text = "" Then
        ''    AccumulateMessage("Age is required")
        ''    AgeTextBox.Focus()
        ''End If

        Try
            UserZip = CInt(ZipCodeTextBox.Text)
        Catch ex As Exception
            AccumulateMessage("ZipCode must be a number")
            ZipCodeTextBox.Focus()
            Vaild = False
        End Try

        If CityTextBox.Text = "" Then
            AccumulateMessage("City is required")
            CityTextBox.Focus()
            Vaild = False
        End If

        If StateTextBox.Text = "" Then
            AccumulateMessage("State is required")
            StateTextBox.Focus()
            Vaild = False
        End If

        If StreetAddressTextBox.Text = "" Then
            AccumulateMessage("Street Address is required")
            StreetAddressTextBox.Focus()
            Vaild = False
        End If

        If LastNameTextBox.Text = "" Then
            AccumulateMessage("Last Name is required")
            LastNameTextBox.Focus()
            Vaild = False
        End If

        If FirstNameTextBox.Text = "" Then
            AccumulateMessage("First Name is required")
            FirstNameTextBox.Focus()
            Vaild = False
        End If

        If AccumulateMessage() <> "" Then
            MsgBox(AccumulateMessage())
            AccumulateMessage(, True)
            Vaild = False
        End If
        Return Vaild

    End Function
    Private Function AccumulateMessage(Optional NewMessage As String = "", Optional clear As Boolean = False) As String
        Static _message As String

        Select Case clear
            Case False
                If NewMessage <> "" Then
                    _message &= NewMessage & vbCrLf
                End If
            Case Else
                _message = ""
        End Select

        Return _message
    End Function
    ''' <summary>
    ''' Stores formatted  data records
    ''' </summary>
    ''' <param name="addRecord"></param>
    ''' <returns>Formatted summary as string</returns>
    Private Function summary(Optional addRecord As Boolean = True) As String
        Static _summary As String
        'example of a formatted record
        'Name: First Name, Last Name
        'Street address
        'City, State Zipcode
        '----------------------------------
        If addRecord Then

            _summary &= $" {FirstNameTextBox.Text} {LastNameTextBox.Text}" & vbNewLine
            _summary &= $" {StreetAddressTextBox.Text}" & vbNewLine
            _summary &= $"{CityTextBox.Text},{StateTextBox.Text} {ZipCodeTextBox.Text}"
        End If
        Return _summary
    End Function

    Private Sub rest()
        'Once display is pressed then all the text boxes will clear
        FirstNameTextBox.Text = ""
        LastNameTextBox.Text = ""
        CityTextBox.Text = ""
        StateTextBox.Text = ""
        ZipCodeTextBox.Text = ""
        DisplayLabel.Text = ""
        AccumulateMessage(, True)

    End Sub


    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub DisplayButton_Click(sender As Object, e As EventArgs) Handles DisplayButton.Click
        If ValidateInput() Then
            summary()
            DisplayButton.Enabled = True
            rest()
        End If
        DisplayLabel.Text = summary(False)
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        rest()
    End Sub


End Class
