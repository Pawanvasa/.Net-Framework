using System.Drawing;
Image image = Image.FromFile(@"C:\Users\Coditas\Documents\Assignment04Aug\img7.jpg");
byte[] ImageToByteArray(Image imageIn)
{
    using (var ms = new MemoryStream())
    {
        imageIn.Save(ms, imageIn.RawFormat);
        return ms.ToArray();
    }
}
Image byteArrayToImage(byte[] byteArrayIn)
{
    MemoryStream ms = new MemoryStream(byteArrayIn);
    Image returnImage = Image.FromStream(ms);
    return returnImage;
}
byte[] arr = ImageToByteArray(image);
Image reCreated = byteArrayToImage(arr);
reCreated.Save(@"C:\Users\Coditas\Documents\Assignment04Aug\BytesToImage\byteToImg.jpg");
void toPrintByteArray()
{
    foreach (var bytes in arr)
    {
        Console.WriteLine(bytes);
    }
}
toPrintByteArray();    