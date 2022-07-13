namespace Facade;



interface IFile { }

class VideoFile : IFile
{
    public VideoFile(string fileName) { }
}


class BaseCompressionCodec { }

class OggCompressionCodec : BaseCompressionCodec { }

class MPEG4CompressionCodec : BaseCompressionCodec { }



class CodecFactory
{
    public string Extract(IFile file)
    {
        return "Extract";
    }
}



class BitrateReader
{
    public static string Read(string filename, string sourceCodec)
    {
        return "Read";
    }

    public static string Convert(string filename, BaseCompressionCodec codec)
    {
        return "Convert";
    }
}


class AudioMixer
{
    public string Fix(string result)
    {
        return "Fix";
    }
}





class VideoConverterFacade
{
    public IFile Convert(string filename, string format)
    {
        IFile file = new VideoFile(filename);

        string sourceCodec = new CodecFactory().Extract(file);


        BaseCompressionCodec destinationCodec;

        if (format == "mp4")
            destinationCodec = new MPEG4CompressionCodec();
        else
            destinationCodec = new OggCompressionCodec();


        string buffer = BitrateReader.Read(filename, sourceCodec);

        string result = BitrateReader.Convert(buffer, destinationCodec);

        result = (new AudioMixer()).Fix(result);

        return new VideoFile(result);
    }
}


class Program
{
    static void Main()
    {
        VideoConverterFacade facade = new();
        facade.Convert("filename", "mp4");

    }
}