using System;
using SkiaSharp;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "/home/dnyaneshwar/C#/Skiasharp_explr/download.jpeg";    // Path to the image you want to edit
        string outputPath = "/home/dnyaneshwar/C#/Skiasharp_explr/download.jpeg"; // Path to save the edited image

        // Load the image
        using (var inputStream = System.IO.File.OpenRead(inputPath))
        using (var skBitmap = SKBitmap.Decode(inputStream))
        {
            // Create a new canvas for drawing
            using (var surface = SKSurface.Create(new SKImageInfo(skBitmap.Width, skBitmap.Height)))
            {
                var canvas = surface.Canvas;

                // Draw the original image onto the canvas
                canvas.DrawBitmap(skBitmap, 0, 0);

                // Example: Draw text onto the image
                using (var paint = new SKPaint
                {
                    Color = SKColors.Red,
                    TextSize = 40,
                    IsAntialias = true
                })
                {
                    canvas.DrawText("Hello, SkiaSharp!", 50, 50, paint);
                }

                // Save the edited image
                using (var image = surface.Snapshot())
                using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                using (var outputStream = System.IO.File.OpenWrite(outputPath))
                {
                    data.SaveTo(outputStream);
                }
            }
        }

        Console.WriteLine("Image edited and saved successfully!");
    }
}
