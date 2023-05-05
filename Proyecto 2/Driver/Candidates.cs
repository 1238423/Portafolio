namespace Blockchain.Models
{
    public struct CandidatePresident
    {
        public Guid Id {  get; set; }
        public string Name { get; set; }
        public string Partido { get; set; }
        public string VicePresident { get; set; }
    }
    public struct CandidateDeputy
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Partido { get; set; }
        public string Departamento { get; set; }
    }
}
