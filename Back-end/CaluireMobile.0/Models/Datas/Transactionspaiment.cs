using System;
using System.Collections.Generic;

namespace CaluireMobile._0.Models.Datas;

public partial class Transactionspaiment
{
    public int IdTransactionPaiment { get; set; }

    public decimal? Montant { get; set; }

    public DateTime? DateTransaction { get; set; }

    public string? Status { get; set; }

    public string? MethodePayement { get; set; }

    public int IdOperation { get; set; }

    public virtual Operation Operation { get; set; } = null!;
}
