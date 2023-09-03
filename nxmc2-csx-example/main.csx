#r "NxInterface.dll"
#r "OpenCvSharp.dll"
#r "OpenCvSharp.Extensions.dll"

using NxInterface;
using OpenCvSharp;
using OpenCvSharp.Extensions;

using System;

Console.WriteLine(args[0]);
args[0] = "5";

Console.WriteLine(Environment.Version);

NxCommand.Press(NxCommand.Button.A);
NxCommand.SendLineNotify("hoge");