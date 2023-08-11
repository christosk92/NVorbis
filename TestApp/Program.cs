using NVorbis;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using NAudio.Vorbis;
using NAudio.Wave;
using TestApp.Convenience;

namespace TestApp
{
    static class Program
    {
        const string OGG_FILE = "ifeelyou.ogg";
        //const string OGG_FILE = @"..\TestFiles\2test.ogg";

        static async Task Main()
        {
            var fs = File.OpenRead(OGG_FILE);
            //using (var fwdStream = new ForwardOnlyStream(fs))
            var vorbRead = new VorbisWaveReader(fs, false);
            var waveout = new WaveOutEvent();
            waveout.Init(vorbRead);
            waveout.Play();

            int iteration = 0;
            while (waveout.PlaybackState != PlaybackState.Stopped)
            {
                if (iteration == 2)
                {
                    var time = vorbRead.TotalTime;
                    vorbRead.CurrentTime = vorbRead.TotalTime / 2;
                }

                iteration++;
                await Task.Delay(1000);
            }
        }
    }
}