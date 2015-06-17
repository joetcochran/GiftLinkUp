Imports Microsoft.VisualBasic
Imports System.net
Imports System.IO
Imports System.Net.Mail


Public Class Helper
    Private Const LILLIANVERNON_TOKEN As String = "<removed>"
    Private Const LILLIANVERNON_MERCHANTID As String = "<removed>"

    Public Shared Function InjectAffiliateInfo(ByVal sURL As String) As String
        If sURL.ToLower.Contains("amazon.com/") Then
            sURL = Helper.ConvertAmazonLink(sURL)
        ElseIf sURL.ToLower.Contains("walmart.com/") Then
            sURL = Helper.ConvertWalmartLink(sURL)
        ElseIf sURL.ToLower.Contains("lillianvernon.com/") Then
            sURL = Helper.ConvertLillianVernonLink(sURL)
        End If
        Return sURL
    End Function
    Public Shared Function ConvertAmazonLink(ByVal URL As String) As String
        Try
            Return GenerateAmazonLink(ExtractAmazonASIN(ReadPage(URL)))
        Catch ex As Exception
            Return URL
        End Try
    End Function

    Public Shared Function ConvertLillianVernonLink(ByVal URL As String) As String
        Try
            Return LinkGeneratorService(LILLIANVERNON_TOKEN, LILLIANVERNON_MERCHANTID, URL)
        Catch ex As Exception
            Return URL
        End Try
    End Function
    Public Shared Function ConvertWalmartLink(ByVal URL As String) As String
        Try
            Return GenerateWalmartLink(ExtractWalmartProductID(ReadPage(URL)))
        Catch ex As Exception
            Return URL
        End Try
    End Function

    Private Shared Function LinkGeneratorService(ByVal Token As String, ByVal MerchantID As String, ByVal URL As String) As String
        Return ReadPage("http://feed.linksynergy.com/createcustomlink.shtml?token=" & Token & "&mid=" & MerchantID & "&murl=" & URL)
    End Function

    Private Shared Function ReadPage(ByVal URL As String) As String
        Dim HTMLSource As String = ""
        Dim Request As HttpWebRequest = WebRequest.Create(URL)
        Dim Response As HttpWebResponse = Request.GetResponse
        Dim SR As StreamReader
        SR = New StreamReader(Response.GetResponseStream)
        HTMLSource = SR.ReadToEnd
        SR.Close()
        Return HTMLSource
    End Function

    Private Shared Function ExtractWalmartProductID(ByVal s As String) As String
        Dim target As String = "name=""product_id"""
        Dim loc As Integer = s.IndexOf(target)
        Dim i As Integer

        Dim openTagloc As Integer
        Dim closeTagloc As Integer
        For i = loc To 0 Step -1
            If s.Chars(i) = "<" Then
                openTagloc = i
                Exit For
            End If
        Next

        For i = loc To s.Length
            If s.Chars(i) = ">" Then
                closeTagloc = i + 1
                Exit For
            End If
        Next

        Dim tag As String = s.Substring(openTagloc, (closeTagloc - openTagloc))

        target = "value="""
        loc = tag.IndexOf(target)
        Dim valueattribute As String = tag.Substring(loc + Len(target))

        Dim finalProductID As String = ""
        i = 0
        Do Until valueattribute.Chars(i) = """"
            finalProductID = finalProductID & valueattribute.Chars(i)
            i = i + 1
        Loop

        Return finalProductID
    End Function


    Private Shared Function ExtractAmazonASIN(ByVal s As String) As String
        Dim target As String = "name=""ASIN"""
        Dim loc As Integer = s.IndexOf(target)
        Dim i As Integer

        Dim openTagloc As Integer
        Dim closeTagloc As Integer
        For i = loc To 0 Step -1
            If s.Chars(i) = "<" Then
                openTagloc = i
                Exit For
            End If
        Next

        For i = loc To s.Length
            If s.Chars(i) = ">" Then
                closeTagloc = i + 1
                Exit For
            End If
        Next

        Dim tag As String = s.Substring(openTagloc, (closeTagloc - openTagloc))

        target = "value="""
        loc = tag.IndexOf(target)
        Dim valueattribute As String = tag.Substring(loc + Len(target))

        Dim finalASIN As String = ""
        i = 0
        Do Until valueattribute.Chars(i) = """"
            finalASIN = finalASIN & valueattribute.Chars(i)
            i = i + 1
        Loop

        Return finalASIN
    End Function

    Private Shared Function GenerateAmazonLink(ByVal ASIN As String) As String
        Return "http://www.amazon.com/gp/product/" & ASIN & "?ie=UTF8&tag=<removed>&linkCode=as2&camp=1789&creative=9325&creativeASIN=" & ASIN
    End Function

    Private Shared Function GenerateWalmartLink(ByVal ProductID As String) As String
        Return "http://linksynergy.walmart.com/fs-bin/click?id=Vhd4RcFM7Pc&offerid=100143&type=10&tmpid=1081&RD_PARM1=http%253A%252F%252Fwww.walmart.com%252Fcatalog%252Fproduct.do%253Fproduct_id%253D" & ProductID
    End Function

    Public Shared Sub SendMail(ByVal EmailTo As String, ByVal Subject As String, ByVal Content As String)
        Dim mailServerName As String = "relay-hosting.secureserver.net"
        'Content = "Email Intended for " & EmailTo & vbCrLf & vbCrLf & Content

        Dim message As MailMessage = New MailMessage("admin@giftlinkup.com", EmailTo, Subject, Content)

        Dim mailClient As SmtpClient = New SmtpClient

        mailClient.Host = mailServerName

        mailClient.Port = 25

        mailClient.Send(message)

        message.Dispose()

    End Sub


    Public Shared Function ValidateUsername(ByVal strUsername As String, ByRef Message As String) As Boolean
        If Trim(strUsername) = "" Then
            Message = Message & "<BR>" & "You did not enter a username."
            ValidateUsername = False
        ElseIf Trim(strUsername).Length < 6 Then
            Message = Message & "<BR>" & "Username must be at least 6 characters long."
            ValidateUsername = False
        End If


        Dim strTmp As String
        strTmp = strUsername
        For Each c As Char In strUsername.ToCharArray()
            If Not Char.IsLetterOrDigit(c) Then
                Message = Message & "<BR>" & "Username must consist of only letters or numbers."
                ValidateUsername = False
                Exit For
            End If
        Next

        If Message <> "" Then
            Message = Right(Message, Len(Message) - 4)           'trim off first <BR>
        End If

    End Function


    Public Shared Function ValidateEmail(ByVal strEmail As String, ByRef Emsg As String) As Boolean
        Dim strTmp As String, n As Long, sEXT As String

        Emsg = ""         'reset on open for good form 
        ValidateEmail = True          'Assume true on init 

        sEXT = strEmail
        Do While InStr(1, sEXT, ".") <> 0
            sEXT = Right(sEXT, Len(sEXT) - InStr(1, sEXT, "."))
        Loop

        If strEmail = "" Then
            ValidateEmail = False
            Emsg = Emsg & "<BR>You did not enter an email address."
        ElseIf InStr(1, strEmail, "@") = 0 Then
            ValidateEmail = False
            Emsg = Emsg & "<BR>Your email address does not contain an @ sign."
        ElseIf InStr(1, strEmail, "@") = 1 Then
            ValidateEmail = False
            Emsg = Emsg & "<BR>Your @ sign can not be the first character in your email address."
        ElseIf InStr(1, strEmail, "@") = Len(strEmail) Then
            ValidateEmail = False
            Emsg = Emsg & "<BR>Your @sign can not be the last character in your email address."
        ElseIf EXTisOK(sEXT) = False Then
            ValidateEmail = False
            Emsg = Emsg & "<BR>Your email address is not carrying a valid ending."
            Emsg = Emsg & "<BR>It must be one of the following..."
            Emsg = Emsg & "<BR>.com, .net, .gov, .org, .edu, .biz, .tv, <br>Or the country's assigned country code."
        ElseIf Len(strEmail) < 6 Then
            ValidateEmail = False
            Emsg = Emsg & "<BR>Your email address is shorter than 6 characters."
        End If
        strTmp = strEmail
        Do While InStr(1, strTmp, "@") <> 0
            n = 1
            strTmp = Right(strTmp, Len(strTmp) - InStr(1, strTmp, "@"))
        Loop
        If n > 1 Then
            ValidateEmail = False            'found more than one @ sign 
            Emsg = Emsg & "<BR>You have more than 1 @ sign in your email address."
        End If

        If Emsg <> "" Then
            Emsg = Right(Emsg, Len(Emsg) - 4)         'trim off first <BR>
        End If


    End Function


    Public Shared Function EXTisOK(ByVal sEXT As String) As Boolean
        Dim EXT As String = ""
        EXTisOK = False
        If Left(sEXT, 1) <> "." Then sEXT = "." & sEXT
        sEXT = UCase(sEXT)        'just to avoid errors 
        EXT = EXT & ".COM.EDU.GOV.NET.BIZ.ORG.TV.PRO"
        EXT = EXT & ".AF.AL.DZ.As.AD.AO.AI.AQ.AG.AP.AR.AM.AW.AU.AT.AZ.BS.BH.BD.BB.BY"
        EXT = EXT & ".BE.BZ.BJ.BM.BT.BO.BA.BW.BV.BR.IO.BN.BG.BF.MM.BI.KH.CM.CA.CV.KY"
        EXT = EXT & ".CF.TD.CL.CN.CX.CC.CO.KM.CG.CD.CK.CR.CI.HR.CU.CY.CZ.DK.DJ.DM.DO"
        EXT = EXT & ".TP.EC.EG.SV.GQ.ER.EE.ET.FK.FO.FJ.FI.CS.SU.FR.FX.GF.PF.TF.GA.GM.GE.DE"
        EXT = EXT & ".GH.GI.GB.GR.GL.GD.GP.GU.GT.GN.GW.GY.HT.HM.HN.HK.HU.IS.IN.ID.IR.IQ"
        EXT = EXT & ".IE.IL.IT.JM.JP.JO.KZ.KE.KI.KW.KG.LA.LV.LB.LS.LR.LY.LI.LT.LU.MO.MK.MG"
        EXT = EXT & ".MW.MY.MV.ML.MT.MH.MQ.MR.MU.YT.MX.FM.MD.MC.MN.MS.MA.MZ.NA"
        EXT = EXT & ".NR.NP.NL.AN.NT.NC.NZ.NI.NE.NG.NU.NF.KP.MP.NO.OM.PK.PW.PA.PG.PY"
        EXT = EXT & ".PE.PH.PN.PL.PT.PR.QA.RE.RO.RU.RW.GS.SH.KN.LC.PM.ST.VC.SM.SA.SN.SC"
        EXT = EXT & ".SL.SG.SK.SI.SB.SO.ZA.KR.ES.LK.SD.SR.SJ.SZ.SE.CH.SY.TJ.TW.TZ.TH.TG.TK"
        EXT = EXT & ".TO.TT.TN.TR.TM.TC.TV.UG.UA.AE.UK.US.UY.UM.UZ.VU.VA.VE.VN.VG.VI"
        EXT = EXT & ".WF.WS.EH.YE.YU.ZR.ZM.ZW"
        EXT = UCase(EXT)          'just to avoid errors 
        If InStr(EXT, sEXT, vbBinaryCompare) <> 0 Then EXTisOK = True
    End Function



End Class
