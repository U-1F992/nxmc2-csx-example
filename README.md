# おためしNX Macro Controller C#スクリプト

## プロジェクト作成

```
mkdir nxmc2-csx-example
cd nxmc2-csx-example

mkdir nxmc2-csx-example
cd nxmc2-csx-example
dotnet script init

mv .\.vscode\ ..\
mv .\omnisharp.json ..\
```

> [dotnet-script](https://github.com/dotnet-script/dotnet-script)は`C# Dev Kit`と競合する[^1]。VS Codeではワークスペースの`dotnet.server.useOmnisharp`を`true`にすることと、`C# Dev Kit`を無効化する対応が必要。

[^1]: https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp#how-to-use-omnisharp

必要に応じてシンボリックリンクを張る。

```
sudo cmd

mklink NxInterface.dll "C:\Program Files (x86)\NX Macro Controller\NxInterface.dll"
mklink OpenCvSharp.dll "C:\Program Files (x86)\NX Macro Controller\OpenCvSharp.dll"
mklink OpenCvSharp.Extensions.dll "C:\Program Files (x86)\NX Macro Controller\OpenCvSharp.Extensions.dll"
```

```csharp
#r "NxInterface.dll"
#r "OpenCvSharp.dll"
#r "OpenCvSharp.Extensions.dll"

using NxInterface;
using OpenCvSharp;
using OpenCvSharp.Extensions;
```

`ファイル > マクロの新規作成`で`..\nxmc2-csx-example.nxc`を作成する。同階層の`nxmc2-csx-example`ディレクトリ内がリソースとして読み込まれる。

```
nxmc2-csx-example
├── .vscode
│   └── launch.json
├── omnisharp.json
├── nxmc2-csx-example
│   ├── NxInterface.dll -> ...
│   ├── OpenCvSharp.Extensions.dll -> ...
│   ├── OpenCvSharp.dll -> ...
│   └── main.csx
└── nxmc2-csx-example.nxc
```

## メモ

### 全般

`using System`必要

`System.Console.WriteLine()`は`ログ`タブに出力される

```csharp
Console.WriteLine(Environment.Version);

// 4.0.30319.42000
```

`System.String[] args`が暗黙的に渡されているみたい

- `CallCsx(R"main.csx", "hoge", 42)`なら`"hoge"`と`"42"`
- `Var fuga = ""` `CallCsx(R"main.csx", Ref:fuga)`とすると`args[0]`に値を返せる
- ない`args`に触ると落ちる
- NXでは数のように扱う場合も、返せるのはあくまで数字`args[0] = "5";`

### 操作

`NxInterface.NxCommand`以下にいろいろありそう

↑補完効かせられたのでこれ頼りでなんとか書く
