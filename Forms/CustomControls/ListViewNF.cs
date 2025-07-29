// Decompiled with JetBrains decompiler
// Type: MR6100Demo.ListViewNF
// Assembly: MR6100Demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1873F71C-3ADE-4CD3-9129-535384741D4F
// Assembly location: Z:\zaaferani\Desktop\book gate\MR6100Demo.exe

using System.Windows.Forms;

namespace MR6100Demo
{
    internal class ListViewNF : ListView
    {
        public ListViewNF()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        protected override void OnNotifyMessage(Message m)
        {
            if (m.Msg == 20)
                return;
            base.OnNotifyMessage(m);
        }
    }
}