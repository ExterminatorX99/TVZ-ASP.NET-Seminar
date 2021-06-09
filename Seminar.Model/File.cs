namespace Seminar.Model
{
    public class File
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public virtual string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}
