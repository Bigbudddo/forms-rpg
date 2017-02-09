using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WinFormsRPG.Interfaces;

namespace WinFormsRPG.States {

    public class EmptyState : BaseState {

        public override void Draw() {
            if (BackBuffer != null) {
                using (var g = Graphics.FromImage(BackBuffer)) {
                    Font f = new Font("Times New Roman", 12.0f);

                    g.Clear(Color.CornflowerBlue);
                    g.DrawString("Empty State!", f, Brushes.Black, 10, 10);
                }
            }
        }
    }
}
