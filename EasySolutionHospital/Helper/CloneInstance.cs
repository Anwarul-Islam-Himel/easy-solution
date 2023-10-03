using System.Runtime.Serialization;

namespace EasySolutionHospital.Helper
{
    public class CloneInstance
    {
        public static T Clone<T>(T input)
        {
            using var stream = new MemoryStream();

            var serializer = new DataContractSerializer(typeof(T));
            serializer.WriteObject(stream, input);
            stream.Position = 0;

            return (T)serializer.ReadObject(stream);
        }
    }
}
