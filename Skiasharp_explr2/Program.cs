
using System.Reflection.Metadata.Ecma335;
using SkiaSharp;

namespace SkiaSharpExplr;

class Boid
{
    public float centerX { get; set; }
    public float centerY { get; set; }
    public float vx { get; set; }
    public float vy { get; set; }
}
class Program
{


    static readonly List<Boid> boids = [];

    public static void InitBoids()
    {
        Random random = new();

        for (int i = 0; i < 150; i++)
        {
            boids.Add(new Boid() { centerX = random.Next(30, 610), centerY = random.Next(30, 610), vx = random.Next(-5, 5), vy = random.Next(-5, 5) });
        }
    }
    public static double Distance(Boid b1, Boid b2)
    {
        return Math.Sqrt((b2.centerX - b1.centerX) * (b2.centerX - b1.centerX) + (b2.centerY - b1.centerY) * (b2.centerY - b1.centerY));
    }

    public static void AvoidOthers(Boid b)
    {
        float moveX = 0, moveY = 0;
        foreach (var otherBoid in boids)
        {
            if (otherBoid != b && Distance(b, otherBoid) < 50)
            {
                moveX += b.centerX - otherBoid.centerX;
                moveY += b.centerY - otherBoid.centerY;
            }
        }
        b.vx += moveX * 0.001f;
        b.vy += moveY * 0.001f;
    }


    public static void FlyTOwardsCenter(Boid b)
    {
        float centerX = 0, centerY = 0;
        int numneighbour = 0;
        foreach (var otherBoid in boids)
        {
            double d = Distance(b, otherBoid);
            if (d < 300)
            {
                numneighbour++;
                centerX += otherBoid.centerX;
                centerY += otherBoid.centerY;
            }
        }

        if (numneighbour > 0)
        {
            centerX /= numneighbour;
            centerY /= numneighbour;
            b.vx += (float)((centerX - b.centerX) * 0.005);
            b.vy += (float)((centerY - b.centerY) * 0.005);
        }

    }

    public static void AlignBoids(Boid b)
    {
        float avgVx = 0, avgVy = 0;
        int boidsCnt = 0;

        foreach (var otherBoid in boids)
        {
            if (Distance(otherBoid, b) < 150)
            {
                avgVx += otherBoid.vx;
                avgVy += otherBoid.vy;
                boidsCnt++;
            }
        }
        if (boidsCnt > 0)
        {
            avgVx /= boidsCnt;
            avgVy /= boidsCnt;

            b.vx += avgVx * 0.005f;
            b.vy += avgVy * 0.005f;
        }
    }

    public static void SpeedLimit(Boid b)
    {
        float speedLimit = 15;
        float speed = (float)Math.Sqrt(b.vx * b.vx + b.vy * b.vy);

        if (speed > speedLimit)
        {
            b.vx = b.vx / speed * speedLimit;
            b.vy = b.vy / speed * speedLimit;
        }
    }
    public static void Main(string[] args)
    {
        InitBoids();
        for (int i = 0; i < 1200; i++)
        {
            SKBitmap bmp = new(640, 640);
            using SKCanvas canvas = new(bmp);
            canvas.Clear(SKColor.Parse("#003366"));
            SKPaint paint = new() { Color = SKColors.White, IsAntialias = true };
            foreach (var b in boids)
            {
                FlyTOwardsCenter(b);
                AvoidOthers(b);
                // AlignBoids(b);
                SpeedLimit(b);
                if (b.centerX + b.vx < 200)
                {
                    b.vx++;
                }
                else if (b.centerX + b.vx > 438)
                {
                    b.vx--;
                }
                if (b.centerY + b.vy < 200)
                {
                    b.vy++;
                }
                else if (b.centerY + b.vy > 438)
                {
                    b.vy--;
                }

                b.centerX += b.vx;
                b.centerY += b.vy;

                SKPath path = new();

                double x2, y2, x3, y3, xm, ym, x1 = b.centerX, y1 = b.centerY, h = 20d;
                double s = 2 * h / Math.Sqrt(3);
                double theta = Math.Atan2(b.vy,b.vx);
                xm = x1 - (h * Math.Cos(theta));
                ym = y1 + (h * Math.Sin(theta));

                x2 = xm + (s * Math.Cos(theta - 90) / 2);
                y2 = ym - (s * Math.Sin(theta - 90) / 2);

                x3 = xm + (s * Math.Cos(90 + theta) / 2);
                y3 = ym - (s * Math.Sin(90 + theta) / 2);

                path.MoveTo((float)x1, (float)y1);

                path.LineTo((float)x2, (float)y2);
                path.LineTo((float)x3, (float)y3);

                path.Close();

                canvas.DrawPath(path, paint);
            }
            string filePath;
            if (i < 10)
            {
                filePath = $"/home/dnyaneshwar/C#/Skiasharp_explr2/boids/quickstart000{i}.jpg";
            }
            else if (i < 100)
            {
                filePath = $"/home/dnyaneshwar/C#/Skiasharp_explr2/boids/quickstart00{i}.jpg";
            }
            else if (i < 1000)
            {
                filePath = $"/home/dnyaneshwar/C#/Skiasharp_explr2/boids/quickstart0{i}.jpg";
            }
            else
            {
                filePath = $"/home/dnyaneshwar/C#/Skiasharp_explr2/boids/quickstart{i}.jpg";
            }
            SKFileWStream fs = new(filePath);
            bmp.Encode(fs, SKEncodedImageFormat.Jpeg, quality: 100);
        }
    }
}