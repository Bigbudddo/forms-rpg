using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WinFormsRPG.Core;
using WinFormsRPG.Interfaces;
using WinFormsRPG.States;

namespace WinFormsRPG {
    public partial class MainScreen : Form {

        private StateStack _GameStack;
        private Timer _GameTimer;

        public MainScreen() {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

            Dictionary<string, IState> states = new Dictionary<string, IState>() {
                { "MainMenu", new MainMenuState() },
                { "Logo", new LogoState() }
            };
            _GameStack = new StateStack(this, ClientSize.Width, ClientSize.Height, states);
            _GameStack.Push("MainMenu");
            _GameStack.Push("Logo");

            _GameTimer = new Timer();
            _GameTimer.Interval = 10;
            _GameTimer.Tick += new EventHandler(_GameStack.Update);
            _GameTimer.Start();

            ResizeEnd += new EventHandler(_GameStack.Buffer);
            Load += new EventHandler(_GameStack.Buffer);
            KeyDown += new KeyEventHandler(_GameStack.Input);
            Paint += new PaintEventHandler(_GameStack.Render);
        }
    }
}
