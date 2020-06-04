using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Work;

namespace SentryDotNetScopeLost.Droid
{
    public class SyncWorker : Worker
    {
        public SyncWorker(Context context, WorkerParameters workerParameters) : base(context, workerParameters)
        {
        }
        public override Result DoWork()
        {
            Sentry.SentrySdk.CaptureMessage("Worker Test");
            return null;
        }
    }
}