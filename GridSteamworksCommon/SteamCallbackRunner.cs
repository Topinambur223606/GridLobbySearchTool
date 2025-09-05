using Steamworks;
using System;
using System.Threading;

namespace GridSteamworksCommon
{
    public class SteamCallbackRunner : IDisposable
    {
        private readonly ManualResetEvent mre = new(false);
        private readonly Thread callbackThread;
        private volatile int subscribersCount;
        private bool isRunning = true;

        public SteamCallbackRunner()
        {
            callbackThread = new Thread(RunThreadBody);
            callbackThread.Start();
        }

        public void WaitForRunOnce()
        {
            if (!isRunning)
            {
                return;
            }
            Interlocked.Increment(ref subscribersCount);
            try
            {
                mre.Reset();
                mre.WaitOne();
            }
            finally
            {
                Interlocked.Decrement(ref subscribersCount);
            }
        }

        private void RunThreadBody()
        {
            while (isRunning)
            {
                if (subscribersCount > 0)
                {
                    SteamAPI.RunCallbacks();
                    mre.Set();
                }
                Thread.Sleep(50);
            }
        }

        public void Dispose()
        {
            isRunning = false;
            callbackThread.Join();
            mre.Set();
            mre.Dispose();
        }
    }

}
