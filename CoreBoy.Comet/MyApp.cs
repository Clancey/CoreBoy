using System;
using System.Threading;
using Comet;
using CoreBoy.gpu;
using CoreBoy.gui;

namespace CoreBoy {
	public class MyApp : CometApp {
		public static void SetDisplay(IDisplay display)
		{
			Emulator.Stop ();
			Emulator.Display = display;
			Emulator.Run ();
		}
		public static Emulator Emulator { get; private set; }
		static MyApp()
		{
			
		}
		public MyApp (string romPath)
		{
			Emulator = new Emulator (new GameboyOptions { Rom = romPath });
			Body = () => new MainPage ();
		}
		protected override void OnInit ()
		{
			base.OnInit ();
			Emulator?.Run ();
		}
	}
}
