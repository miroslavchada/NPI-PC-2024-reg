using Timer = System.Threading.Timer;

namespace Semafor {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        public enum SemaforState {
            Red,
            TurningGreen,
            Green,
            TurningRed
        }

        int _ticksRemaining = 1;
        public SemaforState state = SemaforState.TurningRed;

        bool yellowOn;

        private void timerNormal_Tick(object sender, EventArgs e) {
            _ticksRemaining--;

            // Pøehazování stavù semaforu
            switch (state) {
                case SemaforState.Red:
                    if (_ticksRemaining == 0) {
                        state = SemaforState.TurningGreen;
                        _ticksRemaining = 4;
                        pbSLYellow.BackgroundImage = Properties.Resources.SLYellowOn;
                        ChangeToState(SemaforState.TurningGreen);
                    }
                    break;
                case SemaforState.TurningGreen:
                    if (_ticksRemaining == 0) {
                        state = SemaforState.Green;
                        _ticksRemaining = 12;
                        ChangeToState(SemaforState.Green);
                    }
                    break;
                case SemaforState.Green:
                    if (_ticksRemaining == 0) {
                        state = SemaforState.TurningRed;
                        _ticksRemaining = 6;
                        ChangeToState(SemaforState.TurningRed);
                    }
                    break;
                case SemaforState.TurningRed:
                    if (_ticksRemaining == 0) {
                        state = SemaforState.Red;
                        _ticksRemaining = 12;
                        ChangeToState(SemaforState.Red);
                    }
                    break;
            }

            lbCountdown.Text = _ticksRemaining.ToString();
        }

        // Zmìna barev na semaforu
        private void ChangeToState(SemaforState state)
        {
            switch (state)
            {
                case SemaforState.Red:
                    pbSLRed.BackgroundImage = Properties.Resources.SLRedOn;
                    pbSLYellow.BackgroundImage = Properties.Resources.SLYellowOff;
                    pbSLGreen.BackgroundImage = Properties.Resources.SLGreenOff;
                    break;
                case SemaforState.TurningGreen:
                    pbSLRed.BackgroundImage = Properties.Resources.SLRedOn;
                    pbSLYellow.BackgroundImage = Properties.Resources.SLYellowOn;
                    pbSLGreen.BackgroundImage = Properties.Resources.SLGreenOff;
                    break;
                case SemaforState.Green:
                    pbSLRed.BackgroundImage = Properties.Resources.SLRedOff;
                    pbSLYellow.BackgroundImage = Properties.Resources.SLYellowOff;
                    pbSLGreen.BackgroundImage = Properties.Resources.SLGreenOn;
                    break;
                case SemaforState.TurningRed:
                    pbSLRed.BackgroundImage = Properties.Resources.SLRedOff;
                    pbSLYellow.BackgroundImage = Properties.Resources.SLYellowOn;
                    pbSLGreen.BackgroundImage = Properties.Resources.SLGreenOff;
                    break;
            }
        }

        // Timer pro blikání žlutého svìtla
        private void timerStandby_Tick(object sender, EventArgs e)
        {
            pbSLYellow.BackgroundImage = yellowOn ? Properties.Resources.SLYellowOn : Properties.Resources.SLYellowOff;
            yellowOn = !yellowOn;
        }

        private void btSwitch_Click(object sender, EventArgs e) {
            // Prohozeni stavu semaforu
            timerNormal.Enabled = !timerNormal.Enabled;
            lbCountdown.Visible = timerNormal.Enabled;

            // Reset barev semaforu
            pbSLRed.BackgroundImage = Properties.Resources.SLRedOff;
            pbSLYellow.BackgroundImage = Properties.Resources.SLYellowOff;
            pbSLGreen.BackgroundImage = Properties.Resources.SLGreenOff;

            timerStandby.Enabled = !timerStandby.Enabled;
            if (!timerStandby.Enabled)  {
                ChangeToState(state);
                btSwitch.Text = "Vypnout";
            }
            else {
                yellowOn = true;
                btSwitch.Text = "Zapnout";
            }
        }
    }
}
