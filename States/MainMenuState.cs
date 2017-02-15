using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsRPG.States {
    public class MainMenuState : BaseState {

        private SoundPlayer _AudioManager;
        private bool _MainMenuSelectionAnimDown = true;
        private int _MainMenuSelection = 0;
        private int _MainMenuSelectionOpacity = 255;
        private int _MainMenuSelectionOpacityMin = 128;
        private int _MainMenuSelectionOpacityMax = 255;
        private int _MainMenuSelectionAnimTimer = 0;
        private int _MainMenuSelectionAnimWait = 5;
        private string _AudioClipSelectPath = @"Audio/UI/select.wav";
        private string _AudioClipClickPath = @"Audio/UI/click.wav";
        private string[] _MainMenuItems = new string[] { "New Game", "Load Game", "Options", "Quit" };

        public MainMenuState() : base() {
        
        }

        public override void Update(object sender, EventArgs e) {
            // Menu Selection Animation Controller
            _MainMenuSelectionAnimTimer++;
            if (_MainMenuSelectionAnimTimer > _MainMenuSelectionAnimWait) {
                _MainMenuSelectionAnimTimer = 0;
                
                if (_MainMenuSelectionAnimDown) {
                    _MainMenuSelectionOpacity -= 10;

                    if (_MainMenuSelectionOpacity <= _MainMenuSelectionOpacityMin) {
                        _MainMenuSelectionAnimDown = false;
                    }
                }
                else {
                    _MainMenuSelectionOpacity += 10;

                    if (_MainMenuSelectionOpacity >= _MainMenuSelectionOpacityMax) {
                        _MainMenuSelectionAnimDown = true;
                    }
                }
            }
        }

        public override void Input(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down) {
                _AudioManager = new SoundPlayer(_AudioClipSelectPath);
                _AudioManager.Play();
            }

            if (e.KeyCode == Keys.Up) {
                _MainMenuSelection--;
                if (_MainMenuSelection < 0) {
                    _MainMenuSelection = _MainMenuItems.Length - 1;
                }
            }

            if (e.KeyCode == Keys.Down) {
                _MainMenuSelection++;
                if(_MainMenuSelection >= _MainMenuItems.Length) {
                    _MainMenuSelection = 0;
                }
            }
        }

        public override void Draw() {
            if (this.BackBuffer != null) {
                using (var g = Graphics.FromImage(this.BackBuffer)) {
                    Font f = new Font(this.fontCollection.Families.First(), 18.0f);
                    g.Clear(Color.CornflowerBlue);
                    // Draw the Menu!
                    int x = this.BackBuffer.Width / 2;
                    int y = this.BackBuffer.Height / 2;

                    for (int i = 0; i < _MainMenuItems.Length; i++) {
                        Brush b = Brushes.Black;
                        if (i == _MainMenuSelection) {
                            b = new SolidBrush(Color.FromArgb(_MainMenuSelectionOpacity, Color.Silver));
                        }

                        g.DrawString(_MainMenuItems[i], f, b, x, y);
                        y += 25;
                    }
                }
            }
        }
    }
}
