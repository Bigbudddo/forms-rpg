using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsRPG.Interfaces {

    public interface IState {

        Bitmap BackBuffer { get; }
        bool StateFinished { get; }

        void Update(object sender, EventArgs e);
        void Input(object sender, KeyEventArgs e);
        void Draw();
        void Render(object sender, PaintEventArgs e);
        void Buffer(int width, int height);
        void OnEnter();
        void OnExit();
    }
}
