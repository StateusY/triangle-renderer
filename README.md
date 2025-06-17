# triangle-renderer
Just a quick touch into the wonderful world of rendering.

Tried to follow Sebastian Lague's [Software Rasterizer](https://youtu.be/yyJ-hdISgnw?list=PLFt_AvWsXl0ehjAfLFsp1PGaatzAwo0u0K) but got a bit lost :P
I learned a lot about rendering and BMP file export stuff.

To run, open the repo in VS Code or another editor and run ``dotnet run`` (you might need to install dotnet)
And then open the art.bmp file - that is the output.

Lines 14, 15, and 16 control the corners of the triangle. Edit the float coefficient as the positions are relative to the size of the image. (IE, .2f * width = 20% from the left side) (also y is inverted)
Lines 10 and 11 control the size of the image.
