using Comet;
using Comet.iOS;
using Foundation;
using UIKit;

namespace CoreBoy.iOS {
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register ("AppDelegate")]
	public class AppDelegate : CometAppDelegate {
		// class-level declarations

		public override UIWindow Window {
			get;
			set;
		}

		UIWindow window;

		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{

#if DEBUG
			Comet.Reload.Init ();
#endif
			Comet.Skia.UI.Init ();

			return base.FinishedLaunching (application, launchOptions);
		}

		protected override CometApp CreateApp () => new MyApp (NSBundle.MainBundle.PathForResource("Mario","gbc" ));
	}
}

