#nullable disable


namespace caluireMobile._0.Models.Dtos
{
    public class TraductionDtoIn
    {
        public TraductionDtoIn()
        {
        }
        public int IdTraduction { get; set; }
        public string Clef { get; set; }
        public string Langue { get; set; }
        public string Valeur { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
    }

    public class TraductionDtoOut
    {
        public TraductionDtoOut()
        {
        }

        public string Clef { get; set; }
        public string Langue { get; set; }
        public string Valeur { get; set; }
        // Ajoutez d'autres propriétés selon vos besoins
    }
}