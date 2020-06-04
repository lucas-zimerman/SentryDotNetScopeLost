using Xamarin.Forms;
using Sentry;
using Prism.Events;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using System.Threading.Tasks;

namespace SentryDotNetScopeLost
{
    [AutoRegisterForNavigation]
    public partial class App : PrismApplication
    {
        public static IEventAggregator EventAggregator { get; private set; }
        public App(IPlatformInitializer initializer = null) : base(initializer)
        {

        }
        protected override void OnInitialized()
        {
            InitializeComponent();
            EventAggregator  = Container.Resolve<IEventAggregator>();
            SentrySdk.Init(new SentryOptions()
            {
                Dsn = new Dsn(""),
                Environment = "Dev",
                Release = "1.2.3.4"
            });
            SentrySdk.ConfigureScope(scope =>
            {
                scope.SetTag("a", "1");
                scope.SetTag("b", "1");
                scope.User.Id = "1234";
                scope.User.Username = "lucas";
                scope.User.Email = "a@a.com";
                scope.Contexts.OperatingSystem.Name = "ANDROID";
            });
            SentrySdk.CaptureMessage("App.xaml.cs");
            new Task(async () =>
            {
                await Task.Delay(1000);
                EventAggregator.GetEvent<PubSubEvent>().Publish();

            }).Start();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
