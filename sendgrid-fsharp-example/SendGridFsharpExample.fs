open System.Net
open System.Net.Mail
open System.Configuration
open SendGridMail

[<EntryPoint>]
let main argv = 
    let sendGridUserName = ConfigurationManager.AppSettings.Item("SENDGRID_USERNAME")
    let sendGridPassword = ConfigurationManager.AppSettings.Item("SENDGRID_PASSWORD")
    let tos = ConfigurationManager.AppSettings.Item("TOS").Split(',')
    let from = ConfigurationManager.AppSettings.Item("FROM")

    let smtpapi = new Smtpapi.Header()
    smtpapi.SetTo(tos)
    smtpapi.AddSubstitution("fullname", [| "田中 太郎"; "佐藤 次郎"; "鈴木 三郎" |])
    smtpapi.AddSubstitution("familyname", [| "田中"; "佐藤"; "鈴木" |])
    smtpapi.AddSubstitution("place", [| "office"; "home"; "office" |])
    smtpapi.AddSection("office", "中野")
    smtpapi.AddSection("home", "目黒")
    smtpapi.SetCategory("カテゴリ1")

    let email = SendGrid.GetInstance()
    email.AddTo(from)  // SmtpapiのSetTo()を使用しているため、実際にはこのアドレスにはメールは送信されない
    email.From <- new MailAddress(from, "送信者名")
    email.Subject <- "[sendgrid-c#-example] フクロウのお名前はfullnameさん"
    email.Text <- "familyname さんは何をしていますか？\r\n 彼はplaceにいます。"
    email.Html <- "<strong> familyname さんは何をしていますか？</strong><br />彼はplaceにいます。"
    email.Headers.Add("X-Smtpapi", smtpapi.JsonString())
    email.AddAttachment(@"..\..\gif.gif")

    let credentials = new NetworkCredential(sendGridUserName, sendGridPassword)
    let web = Web.GetInstance(credentials)
    web.Deliver(email)

    0 // 整数の終了コードを返します
