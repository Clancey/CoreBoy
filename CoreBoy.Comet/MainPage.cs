using System;
using Comet;
using Comet.Skia;
using SkiaSharp;


namespace CoreBoy {


	public class MainPage : View, controller.IController {
		public MainPage ()
		{
			MyApp.Emulator.Controller = this;
		}

		[Body]
		View body () => new ZStack
		{
			new VStack {
				new View().Frame(25,25),
				new ScreenView{
					OnDraw = (canvas, rect) => {
						canvas.DrawRect(rect.ToSKRect(), new SKPaint{Color = SKColors.Blue });
					},
				},
				new Spacer(),
				new HStack {
					new VStack {
						CreateGameButton("Up",controller.Button.Up),
						new HStack {
							CreateGameButton("Left",controller.Button.Left),
							CreateGameButton("Right",controller.Button.Right),
						},
						CreateGameButton("Down",controller.Button.Down),
					}.Background(Color.DimGrey),
					new Spacer(),
					new HStack {
						CreateGameButton("A",controller.Button.A).Background(Color.DimGrey),
						new View().Frame(10,6),
						CreateGameButton("B",controller.Button.B).Background(Color.DimGrey),
						new View().Frame(6,6),
					},
				}.Background(Color.Transparent),
				new HStack {
					CreateGameButton("Select",controller.Button.Select),
					CreateGameButton("Start",controller.Button.Start),
				},
				new Spacer(),
			}
		}.Background (new Comet.Color (1, 229 / 255f, 36f / 255));
		controller.IButtonListener listener;
		public void SetButtonListener (controller.IButtonListener listener) =>
			this.listener = listener;

		View CreateGameButton (string title, controller.Button button) =>
			new GameButton (title, (state) => {
				if (state == ControlState.Pressed)
					listener.OnButtonPress (button);
				else if (state == ControlState.Default)
					listener.OnButtonRelease (button);
			});
	}
}
