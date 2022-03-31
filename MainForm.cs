using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using NAudio.Wave;

namespace NoiseGenerator
{
    public partial class MainForm : Form
    {
        private WaveOut waveOut;
        private NoiseSampleProvider noiseSampleProvider;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (waveOut == null)
            {
                noiseSampleProvider = new NoiseSampleProvider();
                waveOut = new WaveOut(WaveCallbackInfo.ExistingWindow(Handle));
                waveOut.Init(noiseSampleProvider);
                waveOut.Play();
            }

            SetGain((double)barVolume.Value / barVolume.Maximum);
            SetFrequency((double)barFrequency.Value / barFrequency.Maximum);
        }

        private void SetGain(double gain)
        {
            lblVolume.Text = "Volume (" + gain.ToString("0.00") + ")";
            noiseSampleProvider.SetGain(gain);
        }

        private void SetFrequency(double frequency)
        {
            lblFrequency.Text = "Frequency (" + frequency.ToString("0.00") + ")";
            noiseSampleProvider.SetFrequency(frequency);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Dispose();
                waveOut = null;
            }
        }

        private void barVolume_Scroll(object sender, EventArgs e)
        {
            SetGain((double)barVolume.Value / barVolume.Maximum);
        }

        private void barFrequency_Scroll(object sender, EventArgs e)
        {
            SetFrequency((double)barFrequency.Value / barFrequency.Maximum);
        }



        private class NoiseSampleProvider : ISampleProvider
        {
            private static WaveFormat format = WaveFormat.CreateIeeeFloatWaveFormat(48000, 1);

            private Random random;
            private double gain;
            private BiQuadFilter filter;

            public NoiseSampleProvider()
            {
                random = new Random();
                gain = 0;
                filter = new BiQuadFilter(format.SampleRate);
            }

            public void SetGain(double gain)
            {
                this.gain = 10 * gain;
            }

            public void SetFrequency(double frequency)
            {
                filter.SetLowPassFilter((float)(0.1 * frequency * format.SampleRate), 1F);
            }

            public int Read(float[] buffer, int offset, int count)
            {
                for (var i = 0; i < count; i++)
                {
                    buffer[offset + i] = (float)(gain * (random.NextDouble() - 0.5));
                }

                filter.Process(buffer, offset, count);

                return count;
            }

            public WaveFormat WaveFormat => format;
        }



        private class BiQuadFilter
        {
            private static readonly float resonancePeakOffset = (float)(1 - 1 / Math.Sqrt(2));

            private int sampleRate;

            private float a0;
            private float a1;
            private float a2;
            private float a3;
            private float a4;

            private float x1;
            private float x2;
            private float y1;
            private float y2;

            public BiQuadFilter(int sampleRate)
            {
                this.sampleRate = sampleRate;
            }

            public void ClearBuffer()
            {
                x1 = 0;
                x2 = 0;
                y1 = 0;
                y2 = 0;
            }

            public void SetLowPassFilter(float cutoffFrequency, float resonance)
            {
                // This equation gives the Q value which makes the desired resonance peak.
                // The error of the resultant peak height is less than 3%.
                var q = resonance - resonancePeakOffset / (1 + 6 * (resonance - 1));

                var w = 2 * Math.PI * cutoffFrequency / sampleRate;
                var cosw = Math.Cos(w);
                var alpha = Math.Sin(w) / (2 * q);

                var b0 = (1 - cosw) / 2;
                var b1 = 1 - cosw;
                var b2 = (1 - cosw) / 2;
                var a0 = 1 + alpha;
                var a1 = -2 * cosw;
                var a2 = 1 - alpha;

                SetCoefficients((float)a0, (float)a1, (float)a2, (float)b0, (float)b1, (float)b2);
            }

            public void Process(float[] buffer, int offset, int count)
            {
                for (var i = 0; i < count; i++)
                {
                    var t = offset + i;

                    var input = buffer[t];
                    var output = a0 * input + a1 * x1 + a2 * x2 - a3 * y1 - a4 * y2;

                    x2 = x1;
                    x1 = input;
                    y2 = y1;
                    y1 = output;

                    buffer[t] = output;
                }
            }

            private void SetCoefficients(float a0, float a1, float a2, float b0, float b1, float b2)
            {
                this.a0 = b0 / a0;
                this.a1 = b1 / a0;
                this.a2 = b2 / a0;
                this.a3 = a1 / a0;
                this.a4 = a2 / a0;
            }
        }
    }
}
