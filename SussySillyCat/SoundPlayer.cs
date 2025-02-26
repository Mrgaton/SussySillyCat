using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

public static class RawAudioPlayer
{
    // Minimal WaveFormat class (PCM only) based on WAVEFORMATEX.
    [StructLayout(LayoutKind.Sequential)]
    public class WaveFormat
    {
        public short wFormatTag = 1; // PCM
        public short nChannels;
        public int nSamplesPerSec;
        public int nAvgBytesPerSec;
        public short nBlockAlign;
        public short wBitsPerSample;
        public short cbSize; // No extra data

        public WaveFormat(int sampleRate, short bits, short channels)
        {
            nChannels = channels;
            nSamplesPerSec = sampleRate;
            wBitsPerSample = bits;
            nBlockAlign = (short)(channels * (bits / 8));
            nAvgBytesPerSec = sampleRate * nBlockAlign;
            cbSize = 0;
        }
    }

    // Wave header structure for our buffer.
    [StructLayout(LayoutKind.Sequential)]
    public struct WaveHdr
    {
        public IntPtr lpData;       // Pointer to the buffer.
        public int dwBufferLength;  // Size of the buffer.
        public int dwBytesRecorded; // Used for input only.
        public IntPtr dwUser;       // User data.
        public int dwFlags;         // Flags (set by the device driver).
        public int dwLoops;         // Loop control counter.
        public IntPtr lpNext;       // Reserved.
        public IntPtr reserved;     // Reserved.
    }

    // P/Invoke declarations from winmm.dll.
    [DllImport("winmm.dll")]
    public static extern int waveOutOpen(out IntPtr hWaveOut, int uDeviceID,
        WaveFormat lpFormat, IntPtr dwCallback, IntPtr dwInstance, int dwFlags);

    [DllImport("winmm.dll")]
    public static extern int waveOutPrepareHeader(IntPtr hWaveOut,
        ref WaveHdr lpWaveOutHdr, int uSize);

    [DllImport("winmm.dll")]
    public static extern int waveOutWrite(IntPtr hWaveOut,
        ref WaveHdr lpWaveOutHdr, int uSize);

    [DllImport("winmm.dll")]
    public static extern int waveOutUnprepareHeader(IntPtr hWaveOut,
        ref WaveHdr lpWaveOutHdr, int uSize);

    [DllImport("winmm.dll")]
    public static extern int waveOutClose(IntPtr hWaveOut);
    public static void PlayRawPCMData(byte[] pcmData, int sampleRate, short channels, short bits)
    {
        // Create the wave format.
        WaveFormat format = new WaveFormat(sampleRate, bits, channels);

        // Open the default audio device.
        IntPtr hWaveOut;
        int result = waveOutOpen(out hWaveOut, -1, format, IntPtr.Zero, IntPtr.Zero, 0);
        if (result != 0)
            throw new Exception("Error opening audio device.");

        // Calculate playback duration.
        int totalSamples = pcmData.Length / (channels * (bits / 8));
        int durationMs = (int)((totalSamples / (double)sampleRate) * 1000);

        // Pin the PCM buffer so it doesn't get moved by the GC.
        GCHandle handle = GCHandle.Alloc(pcmData, GCHandleType.Pinned);
        try
        {
            WaveHdr header = new WaveHdr
            {
                lpData = handle.AddrOfPinnedObject(),
                dwBufferLength = pcmData.Length,
                dwFlags = 0,
                dwLoops = 0
            };

            int headerSize = Marshal.SizeOf(typeof(WaveHdr));
            result = waveOutPrepareHeader(hWaveOut, ref header, headerSize);
            if (result != 0)
                throw new Exception("Error preparing header.");

            result = waveOutWrite(hWaveOut, ref header, headerSize);
            if (result != 0)
                throw new Exception("Error writing audio.");

            // Wait for the audio to finish playing.
            Thread.Sleep(durationMs);

            waveOutUnprepareHeader(hWaveOut, ref header, headerSize);
        }
        finally
        {
            waveOutClose(hWaveOut);
            if (handle.IsAllocated)
                handle.Free();
        }
    }
    /// <summary>
    /// Plays a sine wave with the specified frequency (in Hz) and duration (in seconds).
    /// </summary>
    /// <param name="frequency">Frequency of the sine wave in Hz.</param>
    /// <param name="durationSeconds">Duration to play the sound in seconds.</param>
    /// <param name="sampleRate">Samples per second (default 44100 Hz).</param>
    public static void PlaySineWave(double frequency, int durationSeconds, int sampleRate = 44100)
    {
        const short bits = 16;
        const short channels = 1;

        // Create the WaveFormat.
        WaveFormat format = new WaveFormat(sampleRate, bits, channels);

        // Open the default audio device (using -1 for default).
        IntPtr hWaveOut;
        int result = waveOutOpen(out hWaveOut, -1, format, IntPtr.Zero, IntPtr.Zero, 0);
        if (result != 0)
        {
            throw new Exception("Error opening audio device.");
        }

        // Calculate total samples and allocate buffer.
        int totalSamples = sampleRate * durationSeconds;
        int bufferSize = totalSamples * channels * (bits / 8);
        byte[] buffer = new byte[bufferSize];

        // Generate the sine wave samples.
        double amplitude = 32760; // Maximum amplitude for 16-bit audio (near max)
        for (int i = 0; i < totalSamples; i++)
        {
            short sample = (short)(amplitude * Math.Sin((2 * Math.PI * frequency * i) / sampleRate));
            buffer[i * 2] = (byte)(sample & 0xFF);            // Low-order byte
            buffer[i * 2 + 1] = (byte)((sample >> 8) & 0xFF);   // High-order byte
        }

        // Pin the buffer in memory so that the unmanaged code can access it.
        GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
        try
        {
            WaveHdr header = new WaveHdr
            {
                lpData = handle.AddrOfPinnedObject(),
                dwBufferLength = bufferSize,
                dwFlags = 0,
                dwLoops = 0
            };

            int headerSize = Marshal.SizeOf(typeof(WaveHdr));
            result = waveOutPrepareHeader(hWaveOut, ref header, headerSize);
            if (result != 0)
            {
                throw new Exception("Error preparing header.");
            }

            // Write the audio buffer to the device.
            result = waveOutWrite(hWaveOut, ref header, headerSize);
            if (result != 0)
            {
                throw new Exception("Error writing audio.");
            }

            // Wait for playback to complete.
            Thread.Sleep(durationSeconds * 1000);

            // Unprepare the header after playback.
            waveOutUnprepareHeader(hWaveOut, ref header, headerSize);
        }
        finally
        {
            // Always close the device and free the pinned buffer.
            waveOutClose(hWaveOut);
            if (handle.IsAllocated)
                handle.Free();
        }
    }
}
