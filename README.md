sendgridjp-fsharp-example
=========================

本コードは[SendGrid公式.NETライブラリ](https://github.com/sendgrid/sendgrid-csharp)の利用サンプルです。

## 使い方

```bash
git clone http://github.com/sendgridjp/sendgridjp-fsharp-example.git
cd sendgridjp-fsharp-example
copy org.App.config App.config
# sendgridjp-fsharp-example.slnファイル開きます。
# App.configファイルを編集してください
# 実行(F5キー)します。
```

## App.configファイルの編集
App.configファイルは以下のような内容になっています。

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <startup> 
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5" />
  </startup>
  <appSettings>
    <add key="SENDGRID_USERNAME" value="YOUR_SENDGRID_USERNAME" />
    <add key="SENDGRID_PASSWORD" value="YOUR_SENDGRID_PASSWORD" />
    <add key="TOS" value="you@youremail.com,friend1@friendemail.com,friend2@friendemail.com" />
    <add key="FROM" value="you@youremail.com" />
  </appSettings>
</configuration>
```
SENDGRID_USERNAME:SendGridのユーザ名を指定してください。  
SENDGRID_PASSWORD:SendGridのパスワードを指定してください。  
TOS:宛先をカンマ区切りで指定してください。  
FROM:送信元アドレスを指定してください。  
