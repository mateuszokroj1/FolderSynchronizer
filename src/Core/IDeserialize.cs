using System.IO;

namespace FolderSynchronizer
{
    public interface IDeserialize<out Toutput>
    {
        Toutput Deserialize(Stream inputStream);
    }
}
