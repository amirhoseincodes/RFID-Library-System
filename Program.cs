// Decompiled with JetBrains decompiler
// Type: MR6100Demo.Program
// Assembly: MR6100Demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1873F71C-3ADE-4CD3-9129-535384741D4F
// Assembly location: Z:\zaaferani\Desktop\book gate\MR6100Demo.exe

using System;
using System.Windows.Forms;

namespace MR6100Demo
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new mainForm());
    }
  }
}
