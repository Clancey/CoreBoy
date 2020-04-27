using System;
using Comet;
using Comet.Skia;

namespace CoreBoy {
	public class GameButton : SKButton, IControlState {
		public GameButton (
			Binding<string> text = null,
			Action<ControlState> action = null) : base (text,null)
		{
			StateChanged = action;
		}

		public GameButton (
			Func<string> text,
			Action<ControlState> action = null) : base ((Binding<string>)text, null)
		{
			StateChanged = action;
		}

		public ControlState CurrentState { get; set; }
		public Action<ControlState> StateChanged { get; private set; }
	}
}
