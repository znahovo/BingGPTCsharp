# BingGptCSharp

## Nuget包名 BingGPTCsharp
PM 安装 Install-Package BingGPTCsharp

using BingGPTCsharp


怎么获得 Cookie\
How Get Cookie\
      Edge/Chromium 安装插件 Cookie Editor，导出 Export as Json\


samples:

```c#
using BingGPTCsharp;
//if not woking 
//using EdgeGPTCsharp

ChatBot bot = new ChatBot("C:\\YouCookie.txt");
while (true)
{
    var Text = await bot.Ask(Console.ReadLine(), "");
}


```


