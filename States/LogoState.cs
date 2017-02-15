using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsRPG.States {

    public class LogoState : BaseState {

        private Bitmap _displayLogo;
        private int _displayLoadingAnimWait = 10;
        private int _displayLoadingAnimTotal = 0;
        private string _displayLoading = "WinForms RPG.{0}";
        private string _displayLoadingAnim = "";

        public LogoState() : base() {
            _displayLogo = Properties.Resources.banner_center;
        }

        public override void Update(object sender, EventArgs e) {
            // Create a '...' pattern animation
            _displayLoadingAnimTotal++;
            if (_displayLoadingAnimTotal >= _displayLoadingAnimWait) {
                _displayLoadingAnimTotal = 0;
                _displayLoadingAnim += ".";
                if (_displayLoadingAnim.Length > 4) {
                    _displayLoadingAnim = "";
                }
            }
        }

        public override void Input(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.StateFinished = true;
            }
        }

        public override void Draw() {
            if (this.BackBuffer != null) {
                using (var g = Graphics.FromImage(BackBuffer)) {
                    g.Clear(Color.White);
                    g.DrawImage(_displayLogo, 0, 0, BackBuffer.Width, BackBuffer.Height);
                    // Draw animation
                    Font f = new Font(this.fontCollection.Families.First(), 12.0f);
                    var text = String.Format(_displayLoading, _displayLoadingAnim);
                    int x = BackBuffer.Width - 200;
                    int y = BackBuffer.Height - 40;
                    g.DrawString(text, f, Brushes.Black, x, y);
                }
            }
        }
    }
}
