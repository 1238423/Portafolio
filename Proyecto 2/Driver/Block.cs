namespace Blockchain.Models
{
    public class Block
    {
        public Guid? _id {  get; set; }
        public string Dpi { get; set; } 
        public Guid Presidente { get; set; }
        public Guid Diputado { get; set;}
        public DateTime minted { get; set;}

        public Guid? next { get; set; } 
        public Guid? previous { get; set; }

        public string node { get; set; }
    }
}
