
namespace BoidsAlgorithm;
static class BoidsAlgo{

    static readonly List<Boid> boids = [];

    public static float[] InitBoids()
    {
        List<float> triangles = [];
        Random random = new();
        for (int i = 0; i < 100; i++)
        {
            boids.Add(new Boid() { CenterX = random.NextDouble(), CenterY = random.NextDouble(), Vx = random.NextDouble()*0.005, Vy = random.NextDouble()*0.005});
        }

        foreach (Boid b in boids)
        {
            double x2, y2, x3, y3, xm, ym, x1 = b.CenterX, y1 = b.CenterY, h = 0.05f;
            double s = 2 * h / Math.Sqrt(3);
            double theta = Math.Atan2(b.Vy, b.Vx);
            xm = x1 - (h * Math.Cos(theta));
            ym = y1 + (h * Math.Sin(theta));

            x2 = xm + (s * Math.Cos(theta - 90) / 2);
            y2 = ym - (s * Math.Sin(theta - 90) / 2);

            x3 = xm + (s * Math.Cos(90 + theta) / 2);
            y3 = ym - (s * Math.Sin(90 + theta) / 2);
            triangles.Add((float)b.CenterX);
            triangles.Add((float)b.CenterY);
            triangles.Add(0f);
            triangles.Add((float)x2);
            triangles.Add((float)y2);
            triangles.Add(0f);
            triangles.Add((float)x3);
            triangles.Add((float)y3);
            triangles.Add(0f);
        }

        System.Console.WriteLine($"{triangles.Count} {boids.Count}");
        return [.. triangles];

    }

    public static double Distance(Boid b1, Boid b2)
    {
        return Math.Sqrt((b2.CenterX - b1.CenterX) * (b2.CenterX - b1.CenterX) + (b2.CenterY - b1.CenterY) * (b2.CenterY - b1.CenterY));
    }

    public static void FlyTOwardsCenter(Boid b)
    {
        double centerX = 0, centerY = 0;
        int numneighbour = 0;
        foreach (var otherBoid in boids)
        {
            double d = Distance(b, otherBoid);
            if (d < 0.5)
            {
                numneighbour++;
                centerX += otherBoid.CenterX;
                centerY += otherBoid.CenterY;
            }
        }

        if (numneighbour > 0)
        {
            centerX /= numneighbour;
            centerY /= numneighbour;
            b.Vx += (float)((centerX - b.CenterX) * 0.005);
            b.Vy += (float)((centerY - b.CenterY) * 0.005);
        }

    }

    public static void AvoidOthers(Boid b)
    {
        double moveX = 0, moveY = 0;
        foreach (var otherBoid in boids)
        {
            if (otherBoid != b && Distance(b, otherBoid) < 0.05)
            {
                moveX += b.CenterX - otherBoid.CenterX;
                moveY += b.CenterY - otherBoid.CenterY;
            }
        }
        b.Vx += moveX * 0.001f;
        b.Vy += moveY * 0.001f;
    }

    public static void AlignBoids(Boid b)
    {
        double avgVx = 0, avgVy = 0;
        int boidsCnt = 0;

        foreach (var otherBoid in boids)
        {
            if (Distance(otherBoid, b) < 0.5)
            {
                avgVx += otherBoid.Vx;
                avgVy += otherBoid.Vy;
                boidsCnt++;
            }
        }
        if (boidsCnt > 0)
        {
            avgVx /= boidsCnt;
            avgVy /= boidsCnt;

            b.Vx += avgVx * 0.005f;
            b.Vy += avgVy * 0.005f;
        }
    }

    public static void SpeedLimit(Boid b)
    {
        float speedLimit = 0.05f;
        float speed = (float)Math.Sqrt(b.Vx * b.Vx + b.Vy * b.Vy);

        if (speed > speedLimit)
        {
            b.Vx = b.Vx / speed * speedLimit;
            b.Vy = b.Vy / speed * speedLimit;
        }
    }

    public static float[] UpdateBoids()
    {
        List<float> triangles = [];
        foreach (var b in boids)
        {
            FlyTOwardsCenter(b);
            // AvoidOthers(b);
            AlignBoids(b);
            // SpeedLimit(b);
            if (b.CenterX + b.Vx < -0.8)
            {
                b.Vx+=0.01;
            }
            else if (b.CenterX + b.Vx > 0.8)
            {
                b.Vx-=0.01;
            }
            if (b.CenterY + b.Vy < -0.8)
            {
                b.Vy+=0.01;
            }
            else if (b.CenterY + b.Vy > 0.8)
            {
                b.Vy-=0.01;
            }

            b.CenterX += b.Vx;
            b.CenterY += b.Vy;

            double x2, y2, x3, y3, xm, ym, x1 = b.CenterX, y1 = b.CenterY, h = 0.05f;
            double s = 2 * h / Math.Sqrt(3);
            double theta = Math.Atan2(b.Vy, b.Vx);
            xm = x1 - (h * Math.Cos(theta));
            ym = y1 + (h * Math.Sin(theta));

            x2 = xm + (s * Math.Cos(theta - 90) / 2);
            y2 = ym - (s * Math.Sin(theta - 90) / 2);

            x3 = xm + (s * Math.Cos(90 + theta) / 2);
            y3 = ym - (s * Math.Sin(90 + theta) / 2);

            triangles.Add((float)b.CenterX);
            triangles.Add((float)b.CenterY);
            triangles.Add(0f);
            triangles.Add((float)x2);
            triangles.Add((float)y2);
            triangles.Add(0f);
            triangles.Add((float)x3);
            triangles.Add((float)y3);
            triangles.Add(0f);
        }
        return [.. triangles];
    }

}