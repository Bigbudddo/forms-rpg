using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WinFormsRPG.Interfaces;

namespace WinFormsRPG.Core {

    public class StateStack {

        public Form Controller { get; private set; }
        public int ClientWidth { get; set; }
        public int ClientHeight { get; set; }

        public Bitmap BackBuffer {
            get {
                IState top = mStack.Peek();
                return top.BackBuffer;
            }
        }

        Dictionary<string, IState> mStates = new Dictionary<string, IState>();
        Stack<IState> mStack = new Stack<IState>();

        public StateStack(Form controller, int width, int height, Dictionary<string, IState> states) {
            Controller = controller;
            ClientWidth = width;
            ClientHeight = height;
            mStates = states;
        }

        public void Update(object sender, EventArgs e) {
            IState top = mStack.Peek();
            top.Update(sender, e);
            top.Draw();
            Controller.Invalidate();

            if (top.StateFinished) {
                Pop();
                Buffer(sender, e);
            }
        }

        public void Input(object sender, KeyEventArgs e) {
            IState top = mStack.Peek();
            top.Input(sender, e);
        }

        public void Buffer(object sender, EventArgs e) {
            IState top = mStack.Peek();
            top.Buffer(Controller.ClientSize.Width, Controller.ClientSize.Height);
        }

        public void Render(object sender, PaintEventArgs e) {
            IState top = mStack.Peek();
            top.Render(sender, e);
        }

        public void Push(string name) {
            IState state = mStates[name];
            mStack.Push(state);
        }

        public IState Pop() {
            return mStack.Pop();
        }
    }
}
