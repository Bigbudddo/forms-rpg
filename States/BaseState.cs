using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WinFormsRPG.Interfaces;

namespace WinFormsRPG.States {

    public class BaseState : IState {

        public Bitmap BackBuffer { get; set; }


        public virtual void OnEnter() {

        }

        public virtual void OnExit() {

        }

        public virtual void Update(object sender, EventArgs e) {
            
        }

        public virtual void Draw() {
            if (BackBuffer != null) {
                using (var g = Graphics.FromImage(BackBuffer)) {
                    g.Clear(Color.CornflowerBlue);
                }
            }
        }

        public virtual void Render(object sender, PaintEventArgs e) {
            if (BackBuffer != null) {
                e.Graphics.DrawImageUnscaled(BackBuffer, Point.Empty);
            }
        }
    }
}
