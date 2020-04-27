using System;
using System.Drawing;
using System.Threading;
using Comet.Skia;
using CoreBoy.gpu;
using SkiaSharp;

namespace CoreBoy {
	public class ScreenView : SkiaView, IDisplay {
		public ScreenView ()
		{
			MyApp.SetDisplay (this);
		}
		public static readonly int DisplayWidth = 160;
		public static readonly int DisplayHeight = 144;
		public static int DisplayLength = DisplayWidth * DisplayHeight;

		public static readonly SKColor [] Colors = {  0xe6f8da, 0x99c886, 0x437969, 0x051f2a };

		private readonly SKBitmap bitmap = new SKBitmap (DisplayWidth, DisplayHeight);
		private int currentPixel;

		public bool Enabled { get; set; }

		public event FrameProducedEventHandler OnFrameProduced;

		public override SizeF GetIntrinsicSize (SizeF availableSize)
		{
			var width = Math.Min (availableSize.Height, availableSize.Width);

			return new SizeF (width, width);
		}


		public void PutDmgPixel (int color)
		{
			var pixel = currentPixel++;
			var x = pixel % DisplayWidth;
			var y = pixel / DisplayWidth - 1;

			bitmap.SetPixel (x, y, Colors [color]);

			currentPixel = currentPixel % DisplayLength;
		}
		int maxR;
		public void PutColorPixel (int gbcRgb)
		{
			var r = ((gbcRgb >> 0) &0x1f) << 3;
			var g = ((gbcRgb >> 5) & 0x1f) << 3; 
			var b = ((gbcRgb >> 10) & 0x1f) << 3;
			maxR = Math.Max (r, maxR);
			var pixel = currentPixel++;
			var x = pixel % DisplayWidth;
			var y = pixel / DisplayWidth;
			y += 1;
			bitmap.SetPixel (x, y,
				new SKColor((byte)r, (byte)g, (byte)b));
			currentPixel = currentPixel % DisplayLength;
		}

		public override void Draw (SKCanvas canvas, RectangleF dirtyRect)
		{
			var vScale = dirtyRect.Height / DisplayHeight;
			var hScale = dirtyRect.Width / DisplayWidth;
			var scale = Math.Min (vScale, hScale);
			canvas.Scale (scale);
			canvas.Clear (SKColors.White);
			canvas.DrawBitmap (bitmap, new SKPoint ());
		}

		public void RequestRefresh ()
		{
			this.Invalidate ();
		}

		public void Run (CancellationToken token)
		{
			
		}

		public void WaitForRefresh ()
		{

		}
	}
}
