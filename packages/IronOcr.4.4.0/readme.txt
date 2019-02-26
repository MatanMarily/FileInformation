IronOCR - The OCR library for .Net

The IronOCR library reads text from images, scans and pdfs.   It also detects and decodes barcodes and QR codes.
'Image to text' and 'PDF to Text' functionality  is added to Desktop, Console and Web applications in about 5 minuets.
It supports over 20 international languages

Code Examples: http://ironsoftware.com/csharp/ocr/
Object Reference: http://ironsoftware.com/csharp/ocr/docs/
Nuget:  https://www.nuget.org/packages/IronOcr/
International Language Packs: https://www.nuget.org/packages?q=IronOcr.Languages

C# Code Example (Getting Started):
/*****************************/
var Ocr = new IronOcr.AutoOcr();
var Result = Ocr.Read(@"C:\path\to\image.png");
Console.WriteLine(Result.Text);



C# Code Example (Kitchen Sink):
/*****************************/
var Ocr = new IronOcr.AdvancedOcr()
{
    CleanBackgroundNoise = true,
    EnhanceContrast = true,
    EnhanceResolution = true,
    Language =  IronOcr.Languages.English.OcrLanguagePack,
    Strategy = IronOcr.AdvancedOcr.OcrStrategy.Advanced,
    ColorSpace = AdvancedOcr.OcrColorSpace.Color,
    DetectWhiteTextOnDarkBackgrounds = true,
    InputImageType = AdvancedOcr.InputTypes.AutoDetect,
    RotateAndStraighten = true,
    ReadBarCodes = true,
    ColorDepth =4
};

var testDocument = @"C:\path\to\scan.pdf";
var Results = Ocr.Read(testDocument);
Console.WriteLine(Results.Text);
Console.WriteLine("Barcodes:" + String.Join(",", Results.Barcodes.Select(b => b.Value)));
