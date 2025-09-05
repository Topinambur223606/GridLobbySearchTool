using Steamworks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace GridSteamworksCommon
{
    public class SteamDataContinuousQuery<T>(Func<SteamAPICall_t> makeCallFunc, SteamCallbackRunner runner) : IEnumerable<T>
    {
        private readonly Func<SteamAPICall_t> makeCallFunc = makeCallFunc;
        private readonly SteamCallbackRunner runner = runner;

        private class SteamDataQueryEnumerator : IEnumerator<T>, IEnumerator
        {
            private readonly SteamDataContinuousQuery<T> q;
            private CallResult<T> callback;
            private volatile bool complete;
            private bool failed;
            private DateTime callbackExecutedAt;

            public SteamDataQueryEnumerator(SteamDataContinuousQuery<T> q)
            {
                this.q = q;
                CreateCallback();
            }

            private void CreateCallback()
            {
                callback?.Dispose();
                callback = CallResult<T>.Create(CallbackBody);
            }

            private T current;
            void CallbackBody(T obj, bool failed)
            {
                callbackExecutedAt = DateTime.Now;
                this.failed = failed;
                current = obj;
                complete = true;
            }

            public object Current => current;
            T IEnumerator<T>.Current => current;

            public bool MoveNext()
            {
                var now = DateTime.Now;

                complete = false;
                var sw = new Stopwatch();
                do
                {
                    var callId = q.makeCallFunc();
                    callback.Set(callId);
                    sw.Restart();
                    do
                    {
                        if (sw.Elapsed.TotalSeconds > 2)
                        {
                            Debug.WriteLine($"Restarting query for {typeof(T).Name}");
                            break;
                        }
                        q.runner.WaitForRunOnce();
                    }
                    while (!complete);
                } while (!complete);

                return !failed;
            }

            public void Reset()
            {
                current = default;
            }

            public void Dispose()
            {
                callback.Dispose();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new SteamDataQueryEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }

}
