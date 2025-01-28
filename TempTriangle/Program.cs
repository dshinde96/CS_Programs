using SkiaSharp;
using System;
namespace temp;
class Program
{
    public static void Main(string[] args)
    {
        for (int i = 0; i < 12; i++)
        {
            SKBitmap bmp = new(640, 640);
            using SKCanvas canvas = new(bmp);
            canvas.Clear(SKColor.Parse("#003366"));

            SKPaint paint = new()
            {
                Color = SKColors.White,
                IsAntialias = true,     
            };
            SKPath path = new();

            double x2, y2, x3, y3, xm, ym, x1 = 100d, y1 = 100d, h = 20d;
            double s = 2 * h / Math.Sqrt(3);
            double theta = (i*30)*(Math.PI/180);
            xm = x1 - (h * Math.Cos(theta));
            ym = y1 + (h * Math.Sin(theta));

            x2 = xm + (s * Math.Cos(theta - 90) / 2);
            y2 = ym - (s * Math.Sin(theta - 90) / 2);

            x3 = xm + (s * Math.Cos(90 + theta) / 2);
            y3 = ym - (s * Math.Sin(90 + theta) / 2);

            // Console.WriteLine($"{x1} {y1}\n{x2} {y2}\n{x3} {y3}\n{xm} {ym}\n {Math.Tan(theta)} {s} {theta * 180 / Math.PI} {Math.Round(Math.Cos(theta), 2)}");

            path.MoveTo((float)x1, (float)y1);

            path.LineTo((float)x2, (float)y2);
            path.LineTo((float)x3, (float)y3);

            path.Close();

            canvas.DrawPath(path, paint);

            SKFileWStream fs = new($"temp{i}.jpg");
            bmp.Encode(fs, SKEncodedImageFormat.Jpeg, quality: 100);
        }
        var theta1=Math.Atan2(1,1);
        System.Console.WriteLine($"{Math.Tan(theta1)}");
    }
}