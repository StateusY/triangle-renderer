using System.Runtime.InteropServices.Marshalling;
using System.Threading.Tasks.Sources;
using Rasterizer.Types;
namespace Rasterizer
{
    class Rasterizer
    {
        public static void CreateTestImage()
        {
            const int width = 64;
            const int height = 64;
            float3[,] image = new float3[width, height];

            float2 a = new(0.2f * width, 0.2f * height);
            float2 b = new(0.7f * width, 0.4f * height);
            float2 c = new(0.4f * width, 0.8f * height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    float2 p = new(x, y);
                    bool inside = Maths.PointInTriangle(a, b, c, p);
                    if (inside) image[x, y] = new float3(0, 0, 1);
                }
            }

            WriteImageToFile(image, "art");
        }

        
        static void WriteImageToFile(float3[,] image, string name)
        {
            using BinaryWriter writer = new(File.Open((name + ".bmp"), FileMode.Create));
            uint width = (uint)image.GetLength(0);
            uint height = (uint)image.GetLength(1);
            uint fileHeaderSize = 14;
            uint infoHeaderSize = 40;
            uint pixelDataSize = width * height * 4;
            uint fileSize = fileHeaderSize + infoHeaderSize + pixelDataSize;

            // Headers
            writer.Write("BM"u8.ToArray());
            writer.Write(fileSize);
            writer.Write((uint)0);  // Reserved
            writer.Write(fileHeaderSize + infoHeaderSize);  // Pixel data offset

            // DIB header
            writer.Write(infoHeaderSize);        // Header size
            writer.Write((int)width);            // Image width
            writer.Write((int)(height));        // Image height (negative = top-down)
            writer.Write((ushort)1);             // Planes
            writer.Write((ushort)32);            // Bits per pixel
            writer.Write((uint)0);               // Compression (none)
            writer.Write(pixelDataSize);         // Image size
            writer.Write((int)0);                // X pixels per meter (ignored)
            writer.Write((int)0);                // Y pixels per meter (ignored)
            writer.Write((uint)0);               // Colors in color table
            writer.Write((uint)0);               // Important color count

            // Pixel data
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    float3 col = image[x, y];
                    writer.Write((byte)(col.b * 255)); // Blue
                    writer.Write((byte)(col.g * 255)); // Green
                    writer.Write((byte)(col.r * 255)); // Red
                    writer.Write((byte)255);           // Alpha (fully opaque)
                }
            }
        }
    }
}