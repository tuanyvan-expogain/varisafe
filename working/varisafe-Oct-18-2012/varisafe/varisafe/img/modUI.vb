Imports System.Data.SqlClient
Imports System.Data.SqlTypes



Module modUI


    Function checkdate(ByVal strdate)
        ' checks dates in dd/mm/yyyy format
        Dim boolGoodDate As Boolean = False

        strdate = LTrim(strdate)
        strdate = RTrim(strdate)

        Dim StrArray() As String
        StrArray = strdate.Split("/")
        Dim strNewdate As String

        If IsNumeric(StrArray(0).ToString) And IsNumeric(StrArray(1).ToString) And IsNumeric(StrArray(2).ToString) Then

            Dim Intday As Integer = CInt(StrArray(0).ToString)
            Dim intmonth As Integer = CInt(StrArray(1).ToString)
            Dim intYear As Integer = CInt(StrArray(2).ToString)

            strNewdate = "#" & intmonth & "/" & Intday & "/" & intYear & "#"

            If IsDate(strNewdate) Then
                boolGoodDate = True
            End If

        End If

        Return boolGoodDate
    End Function



    Function Formatdate(ByVal strdate)
        ' reformats dates entered in dd/mm/yyyy format to mm/dd/yyyy format

        Dim newdate As String
        strdate = LTrim(strdate)
        strdate = RTrim(strdate)

        Dim StrArray() As String
        StrArray = strdate.Split("/")

        Dim strday As String = StrArray(0).ToString

        'If Len(strday) = 1 Then
        '    strday = "0" & strday
        'End If
        
        Dim strmonth As String = StrArray(1).ToString

        'If Len(strmonth) = 1 Then
        '    strmonth = "0" & strmonth
        'End If

        Dim strYear As String = StrArray(2).ToString
       
        newdate = "#" & strmonth & "/" & strday & "/" & strYear & "#"

        Return newdate
    End Function


    Function CheckNullString(ByVal str As SqlString) As String

        'Check string value for null and replace null w/""
        'Params: 1. Numeric value to check
        If str.IsNull Then
            Return ""
        Else
            Return str.Value
        End If
    End Function

    Public Sub AddDelConfirmHandler(ByVal objDG As DataGrid, ByVal intColumn As Integer)

        'Add Delete Confirmation Prompt to datagrid delete column
        'Params: 1. Datagrid displayed on page
        '2. Index of delete column
        Dim i As Integer

        With objDG
            For i = 0 To .Items.Count - 1
                If .Items(i).ItemType <> ListItemType.Header And _
                     .Items(i).ItemType <> ListItemType.Footer Then
                    'Now, reference the LinkButton control that the Delete ButtonColumn 
                    'has been rendered to
                    Dim deleteButton As LinkButton = .Items(i).Cells(intColumn).Controls(0)

                    'We can now add the onclick event handler
                    deleteButton.Attributes("onclick") = "javascript:return " & _
                               "confirm('Are you sure you want to delete this item?')"
                End If
            Next
        End With

    End Sub

    Public Function stripXML(ByVal strText As String) As String

        Dim lastchar As Integer
        Dim strFinal As String

        lastchar = InStr(strText, ">") + 1
        strFinal = Mid(strText, lastchar)

        Return strFinal

    End Function

    Public Sub FillCombo(ByVal objCbo As DropDownList, ByVal objRdr As SqlDataReader, ByVal strValueFld As String, ByVal strTextFld As String)

        'Populate Combo from Lookup query
        'Params: 1. Combo to fill
        '2: DataReader w/lookup values
        '3: Combo Value Field
        '4: Combo Text Field

        With objCbo
            .DataSource = objRdr
            .DataValueField = strValueFld
            .DataTextField = strTextFld
            .DataBind()
            .Items.Insert(0, "--Select--")
            .Items(0).Value = 0
        End With

    End Sub

    Public Sub FillCombo(ByVal objCbo As DropDownList, ByVal dTable As DataTable, ByVal strValueFld As String, ByVal strTextFld As String)

        'Populate Combo from Lookup query
        'Params: 1. Combo to fill
        '2: DataTable w/lookup values
        '3: Combo Value Field
        '4: Combo Text Field

        With objCbo
            .DataSource = dTable
            .DataValueField = strValueFld
            .DataTextField = strTextFld
            .DataBind()
            .Items.Insert(0, "<--Select-->")
            .Items(0).Value = 0
        End With

    End Sub

    Public Sub FillCombo(ByVal objCbo As DropDownList, ByVal dView As DataView, ByVal strValueFld As String, ByVal strTextFld As String)

        'Populate Combo from Lookup query
        'Params: 1. Combo to fill
        '2: DataView w/lookup values
        '3: Combo Value Field
        '4: Combo Text Field

        With objCbo
            .DataSource = dView
            .DataValueField = strValueFld
            .DataTextField = strTextFld
            .DataBind()
            .Items.Insert(0, "<--Select-->")
            .Items(0).Value = 0
        End With

    End Sub

    Public Sub SetComboIndex(ByVal objCbo As DropDownList, ByVal intValue As Integer)

        'Set Selected Value of Cbo to current Record's value
        'Params: 1. Combo to set
        '2: Current record values

        Dim i As Integer

        For i = 0 To objCbo.Items.Count - 1
            If Trim(objCbo.Items(i).Value.ToString()) = CStr(intValue) Then
                objCbo.SelectedIndex = i
                Exit Sub
            End If
        Next

    End Sub

    Public Sub SetComboIndex2(ByVal objCbo As DropDownList, ByVal strValue As String)

        'Set Selected Value of Cbo to current Record's value
        'Params: 1. Combo to set
        '2: Current record values

        Dim i As Integer

        For i = 0 To objCbo.Items.Count - 1
            If Trim(objCbo.Items(i).Value.ToString()) = strValue Then
                objCbo.SelectedIndex = i
                Exit Sub
            End If
        Next

    End Sub

    Function CheckNullNum(ByVal Num As Object) As Double

        'Check numeric value for null and replace null w/0
        'Params: 1. Numeric value to check
        If Num Is System.DBNull.Value Then
            Return 0
        Else
            If CStr(Num) = "" Then
                Return 0
            Else
                Return Num
            End If
        End If

    End Function

    Sub FillCheckBoxList(ByVal objChk As CheckBoxList, ByVal dTable As DataTable, ByVal strValueFld As String, ByVal strTextFld As String, ByVal bolSelected As Boolean)

        Dim i As Integer

        With objChk
            .DataSource = dTable
            .DataValueField = strValueFld
            .DataTextField = strTextFld
            .DataBind()

            For i = 0 To .Items.Count - 1
                .Items(i).Selected = bolSelected
            Next
        End With

    End Sub

    Sub FillCheckBoxList(ByVal objChk As CheckBoxList, ByVal dView As DataView, ByVal strValueFld As String, ByVal strTextFld As String, ByVal bolSelected As Boolean)

        Dim i As Integer

        With objChk
            .DataSource = dView
            .DataValueField = strValueFld
            .DataTextField = strTextFld
            .DataBind()

            For i = 0 To .Items.Count - 1
                .Items(i).Selected = bolSelected
            Next
        End With

    End Sub

    Public Function FormatPhone(ByVal strPhone As String) As String
        Dim strStrippedPhone As String = StripPhone(strPhone)
        Dim strFinal As String = ""

        If Len(strStrippedPhone) = 10 Then
            strFinal = "(" & Left(strStrippedPhone, 3) & ") " & Mid(strStrippedPhone, 4, 3) & "-" & Right(strStrippedPhone, 4)
        Else
            strFinal = strPhone
        End If

        Return strFinal

    End Function

    Public Function StripPhone(ByVal strPhone As String) As String

        Dim strFinal As String = ""

        strFinal = Replace(strPhone, "(", "")
        strFinal = Replace(strFinal, ")", "")
        strFinal = Replace(strFinal, " ", "")
        strFinal = Replace(strFinal, "-", "")
        strFinal = Replace(strFinal, ".", "")

        Return strFinal

    End Function

    Public Sub FillProvinceCombo(ByVal countryID As String, ByVal objCbo As DropDownList)
        'Populate Province / State Combo from Lookup query
        'Params: 1. Combo to fill
        Dim objAddress As New BusinessRules.Caddress()
        With objAddress
            If Len(countryID) > 0 And IsNumeric(countryID) Then
                .listProvinces(CInt(countryID))
            Else
                .listProvinces(0)
            End If

        End With

        With objCbo
            .DataSource = objAddress.Provinces
            .DataValueField = "ID"
            .DataTextField = "Code"
            .DataBind()
            .Items.Insert(0, "-Select-")
            .Items(0).Value = 0
        End With

    End Sub

    Public Sub FillCountryCombo(ByVal objcbo As DropDownList)
        'Populate Province / State Combo from Lookup query
        'Params: 1. Combo to fill
        Dim objAddress As New BusinessRules.Caddress()
        With objAddress
            .listCountries()
        End With

        With objcbo
            .DataSource = objAddress.Countries
            .DataValueField = "ID"
            .DataTextField = "Name"
            .DataBind()
            .Items.Insert(0, "-Select-")
            .Items(0).Value = 0

        End With

    End Sub

    Function StripNoiseWords(ByVal strInput As String, ByVal quotes As Boolean)

        ''Dim strOut As String = ""

        ''Dim nw() As String = {"about", "after", "all", "also", "and", "another", "an", "any", "are", "as", "at", "be", "$", "because", "been", "before", "being", "between", "both", "but", "by", "came", "can", "come", "could", "did", "do", "each", "for", "from", "get", "got", "has", "had", "he", "have", "her", "here", "him", "himself", "his", "how", "if", "in", "into", "is", "it", "its", "just", "like", "make", "many", "me", "might", "more", "most", "much", "must", "my", "never", "now", "of", "on", "only", "or", "other", "our", "out", "over", "re", "said", "same", "see", "should", "since", "so", "some", "still", "such", "take", "than", "that", "the", "their", "them", "then", "there", "these", "they", "this", "those", "through", "to", "too", "under", "up", "use", "very", "want", "was", "way", "we", "well", "were", "what", "where", "which", "while", "who", "with", "would", "you", "your", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}

        ' ''remove quotes and possible sql comment characters to prevent messing with the db

        ''Dim StrStripped As String = Replace(strInput, """", "")
        ''StrStripped = Trim(StrStripped)
        ''StrStripped = Replace(StrStripped, "'", "''")
        ''StrStripped = Replace(StrStripped, "-", "")
        ''StrStripped = Replace(StrStripped, "%", "")


        ''If Len(StrStripped) > 0 Then
        ''    If StrStripped.Contains(" ") Then

        ''        Dim StrArray() As String
        ''        StrArray = StrStripped.Split(" ")
        ''        ' need to strip out any noise words

        ''        For i As Integer = 0 To StrArray.Length - 1
        ''            ' check lenght if ok check noise words
        ''            If Len(StrArray(i)) > 0 Then

        ''                ' check for single quotes and ''s es
        ''                'If Right(StrArray(i), 2) = "'s" Then
        ''                '    StrArray(i) = StrArray(i).Remove(StrArray(i).Length - 2, 2)
        ''                '    StrArray(i) = StrArray(i) + "*"
        ''                'End If



        ''                '' remove any remaining single quotes
        ''                'StrArray(i) = Replace(StrArray(i), "'", "")


        ''                If Len(StrArray(i)) > 7 Then
        ''                    If Len(strOut) < 1 Then
        ''                        If quotes = True Then
        ''                            strOut = "'FORMSOF(INFLECTIONAL, """" " & StrArray(i).ToString & """"") '"
        ''                        Else
        ''                            strOut = "FORMSOF(INFLECTIONAL, """" " & StrArray(i).ToString & " """" )"
        ''                        End If

        ''                    Else
        ''                        If quotes = True Then
        ''                            strOut = strOut & " and FORMSOF(INFLECTIONAL, """" " & StrArray(i).ToString & """"") '"
        ''                        Else
        ''                            strOut = strOut & " and " & "FORMSOF(INFLECTIONAL, """" " & StrArray(i).ToString & " """" ) "
        ''                        End If
        ''                    End If
        ''                Else
        ''                    Dim badWord As Boolean = False
        ''                    For x As Integer = 0 To nw.Length - 1
        ''                        If StrArray(i).ToLower = nw(x).ToLower Then
        ''                            badWord = True
        ''                            Exit For
        ''                        End If
        ''                    Next
        ''                    If badWord = False Then
        ''                        If Len(strOut) < 1 Then
        ''                            If quotes = True Then
        ''                                strOut = "'FORMSOF(INFLECTIONAL, """" " & StrArray(i).ToString & """"")'"
        ''                            Else
        ''                                strOut = "FORMSOF(INFLECTIONAL, """" " & StrArray(i).ToString & " """" )"
        ''                            End If

        ''                        Else
        ''                            If quotes = True Then
        ''                                strOut = strOut & " and 'FORMSOF(INFLECTIONAL, """" " & StrArray(i).ToString & """"")'"
        ''                            Else
        ''                                strOut = strOut & " and FORMSOF(INFLECTIONAL, """" " & StrArray(i).ToString & " """" )"
        ''                            End If
        ''                        End If
        ''                    End If

        ''                End If


        ''            End If
        ''        Next

        ''    Else
        ''        ' just check the one word
        ''        ' check for ending '' s and replace apostrophy and s with *
        ''        'If Right(StrStripped, 2) = "'s" Then
        ''        '    StrStripped = StrStripped.Remove(StrStripped.Length - 2, 2)
        ''        '    StrStripped = StrStripped + "*"
        ''        'End If

        ''        '' remove any remaining single quotes
        ''        'StrStripped = Replace(StrStripped, "'", "")

        ''        If Len(StrStripped) > 7 Then
        ''            If quotes Then
        ''                strOut = "' FORMSOF(INFLECTIONAL, """" " & StrStripped & """"")'"
        ''            Else
        ''                strOut = "FORMSOF(INFLECTIONAL, """" & StrStripped & """")"
        ''            End If

        ''        Else
        ''            Dim badWord As Boolean = False
        ''            For x As Integer = 0 To nw.Length - 1
        ''                If StrStripped.ToLower = nw(x).ToLower Then
        ''                    badWord = True
        ''                    Exit For
        ''                End If
        ''            Next

        ''            If badWord = False Then
        ''                If quotes Then
        ''                    strOut = "'FORMSOF(INFLECTIONAL, """" " & StrStripped & """"")'"
        ''                Else
        ''                    strOut = "FORMSOF(INFLECTIONAL, """" & StrStripped & """")"
        ''                End If
        ''            End If


        ''        End If

        ''    End If
        ''End If ' end if len strstripped > 1


        Dim strOut As String = ""

        Dim nw() As String = {"about", "after", "all", "also", "and", "another", "an", "any", "are", "as", "at", "be", "$", "because", "been", "before", "being", "better", "between", "both", "but", "by", "came", "can", "come", "could", "did", "do", "each", "for", "from", "get", "got", "has", "had", "he", "have", "her", "here", "him", "himself", "his", "how", "if", "in", "into", "is", "it", "its", "just", "like", "make", "many", "me", "might", "more", "most", "much", "must", "my", "never", "now", "of", "on", "only", "or", "other", "our", "out", "over", "re", "said", "same", "see", "should", "since", "so", "some", "still", "such", "take", "taking", "than", "that", "the", "their", "them", "then", "there", "these", "they", "this", "those", "through", "to", "too", "under", "up", "use", "very", "want", "was", "way", "we", "well", "were", "what", "where", "which", "while", "who", "with", "would", "you", "your", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}
        'Dim nw() As String = {"about", "after", "all", "also", "and", "another", "an", "any", "are", "as", "at", "be", "$", "because", "been", "before", "being", "between", "both", "but", "by", "came", "can", "come", "could", "did", "do", "each", "for", "from", "get", "got", "has", "had", "he", "have", "her", "here", "him", "himself", "his", "how", "if", "in", "into", "is", "it", "its", "just", "like", "make", "many", "me", "might", "more", "most", "much", "must", "my", "never", "now", "of", "on", "only", "other", "our", "out", "over", "re", "said", "same", "see", "should", "since", "so", "some", "still", "such", "take", "taking", "than", "that", "the", "their", "them", "then", "there", "these", "they", "this", "those", "through", "to", "too", "under", "up", "use", "very", "want", "was", "way", "we", "well", "were", "what", "where", "which", "while", "who", "with", "would", "you", "your", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}

        'remove quotes and possible sql comment characters to prevent messing with the db

        Dim StrStripped As String = Replace(strInput, """", "")
        StrStripped = Trim(StrStripped)
        StrStripped = Replace(StrStripped, "'", "''")
        StrStripped = Replace(StrStripped, "-", "")
        StrStripped = Replace(StrStripped, "%", "")
        'StrStripped = Replace(StrStripped, ".", "")


        If Len(StrStripped) > 0 Then

            If StrStripped.Contains(" ") Then
                ' if more than one word

                Dim StrArray() As String
                StrArray = StrStripped.Split(" ")
                ' need to strip out any noise words

                For i As Integer = 0 To StrArray.Length - 1
                    ' check lenght if ok check noise words
                    If Len(StrArray(i)) > 0 Then

                        If Len(StrArray(i)) > 7 Then
                            ' the the word has more than 7 characters it can't be a noise word
                            If Len(strOut) < 1 Then
                                strOut = "FORMSOF(INFLECTIONAL, "" " & StrArray(i).ToString & " "" )"
                            Else
                                'strOut = strOut & " and " & "FORMSOF(INFLECTIONAL, ""  " & StrArray(i).ToString & " "" ) "

                                If InStr(strInput.ToLower, " or ") > 0 Then
                                    strOut = strOut & " or " & "FORMSOF(INFLECTIONAL, ""  " & StrArray(i).ToString & " "" ) "
                                Else
                                    strOut = strOut & " and " & "FORMSOF(INFLECTIONAL, ""  " & StrArray(i).ToString & " "" ) "
                                End If
                            End If
                        Else

                            Dim badWord As Boolean = False

                            For x As Integer = 0 To nw.Length - 1
                                If StrArray(i).ToLower = nw(x).ToLower Then
                                    badWord = True
                                    Exit For
                                End If
                            Next

                            If badWord = False Then
                                If Len(strOut) < 1 Then
                                    strOut = "FORMSOF(INFLECTIONAL, "" " & StrArray(i).ToString & " "" )"
                                Else
                                    'strOut = strOut & " and FORMSOF(INFLECTIONAL, "" " & StrArray(i).ToString & " "" )"

                                    If InStr(strInput.ToLower, " or ") > 0 Then
                                        strOut = strOut & " or FORMSOF(INFLECTIONAL, "" " & StrArray(i).ToString & " "" )"
                                    Else
                                        strOut = strOut & " and FORMSOF(INFLECTIONAL, "" " & StrArray(i).ToString & " "" )"
                                    End If

                                End If
                        End If

                        End If


                    End If
                Next

            Else

                If Len(StrStripped) > 7 Then
                   
                    strOut = "FORMSOF(INFLECTIONAL, "" " & StrStripped & " "" )"
              
                Else
                Dim badWord As Boolean = False
                For x As Integer = 0 To nw.Length - 1
                    If StrStripped.ToLower = nw(x).ToLower Then
                        badWord = True
                        Exit For
                    End If
                Next

                If badWord = False Then
                  
                        strOut = "FORMSOF(INFLECTIONAL, "" " & StrStripped & " "")"

                End If


            End If

            End If
        End If ' end if len strstripped > 1




        Return strOut

    End Function


    'Function GetQueryValue(ByVal QueryString As String, ByVal Parameter As String)

    '    Dim pos1 As Integer
    '    Dim pos2 As Integer
    '    Dim qString As String
    '    Dim value As String


    '    qString = "&" & QueryString & "&"
    '    pos1 = qString.IndexOf(Parameter & "=", 1)

    '    If pos1 > 0 Then
    '        pos1 = pos1 + Parameter.Length + 1
    '        pos2 = qString.IndexOf("&", pos1)
    '        If pos2 > 0 Then
    '            value = Server.UrlDecode(qString.Substring(pos1, pos2 - pos1))
    '        Else
    '            value = Nothing
    '        End If

    '    Else
    '        value = Nothing
    '    End If
    '    Return value

    'End Function


    Public Function ValidateCreditCard(ByVal number As String, ByVal type As String, ByVal expiryMonth As String, ByVal expiryYear As String, ByVal cvd As String)
        Dim m_strError As String

        'number should be 16 digits number only
        'number should be digits only
        'type Visa should start with a 4
        'type Mastercard should start with a 5
        'expiry date should be greater than the current date

        'Check number
        If number.Length <> 16 Then

            If number.Length = 15 And type.ToUpper = "AMEX" Then
                'Amex cards are 15 
            Else
                m_strError = "Credit Card number should be 16 digits long"
                Return m_strError
            End If

        End If

        If Not IsNumeric(number) Then
            m_strError = "Credit Card number should be numbers only"
            Return m_strError
        End If

        If type.Trim = "" Then
            m_strError = "Please select a value for your credit card type"
            Return m_strError
        End If

        If expiryMonth.Trim = "" Then
            m_strError = "Please select a value for your credit cards expiry month"
            Return m_strError
        End If

        If expiryYear.Trim = "" Then
            m_strError = "Please select a value for your credit cards expiry year"
            Return m_strError
        End If

        If number.Substring(0, 1) = "4" And type.ToUpper <> "VISA" Then
            m_strError = "Credit card type ""Visa's"" credit card number starts with a 4"
            Return m_strError
        End If

        If number.Substring(0, 1) = "5" And type.ToUpper <> "MASTERCARD" Then
            m_strError = "Credit card type ""Mastercard's"" credit card number starts with a 5"
            Return m_strError
        End If

        If number.Substring(0, 1) = "3" And type.ToUpper <> "AMEX" Then
            m_strError = "Credit card type ""American Express's"" credit card number starts with a 3"
            Return m_strError
        End If

        'Check cvd
        If type.ToUpper = "MASTERCARD" And cvd.Trim.Length <> 3 Then
            m_strError = "Card Security Number should be 3 digits"
            Return m_strError
        End If

        If type.ToUpper = "VISA" And cvd.Trim.Length <> 3 Then
            m_strError = "Card Security Number should be 3 digits"
            Return m_strError
        End If


        If type.ToUpper = "AMEX" And cvd.Trim.Length <> 4 Then
            m_strError = "Card Security Number should be 4 digits"
            Return m_strError
        End If

        'Check expiry
        If IsNumeric(expiryMonth) Then
            If CType(expiryMonth, Integer) > 0 And CType(expiryMonth, Integer) <= 12 Then
                'Month is good.
            Else
                m_strError = "Credit card expiry month should between 1 and 12"
                Return m_strError
            End If
        Else
            m_strError = "Credit card expiry month should be a number"
            Return m_strError
        End If


        Dim dtToday As DateTime = DateTime.Now
        Dim dtCreditCardExpiry As DateTime = DateTime.Parse("20" & expiryYear & "/" & expiryMonth & "/01")

        If Date.Compare(dtToday, dtCreditCardExpiry) > 0 Then
            m_strError = "Credit Card expiry date has expired"
            Return m_strError
        End If

        Return ""

    End Function

End Module
