using System.Drawing;

string filePath = $@"C:\Users\Coditas\Documents\Assignment04Aug\PaintImage\";
string fileName = "house.jpg";
Bitmap creatingImage = new Bitmap(1000, 1000);
Graphics gfx = Graphics.FromImage(creatingImage);
gfx.FillEllipse(Brushes.Teal, 0, 0, 1000, 1000);
gfx.FillEllipse(Brushes.White, 100, 100, 800, 800);
gfx.FillEllipse(Brushes.Teal, 200, 200, 600, 600);
gfx.FillEllipse(Brushes.White, 300, 300, 400, 400);
gfx.FillEllipse(Brushes.Teal, 400, 400, 200, 200);
creatingImage.Save($"{filePath}{fileName}");

static void ChangeExtenstion(string filePath, string fileName)
{
    Path.ChangeExtension(filePath + fileName, ".png");
    File.Copy($@"C:\Users\Coditas\Documents\Assignment04Aug\PaintImage\house.jpg", @"C:\Users\Coditas\Documents\TargertFolder\house.png");
}
ChangeExtenstion(filePath, fileName);
