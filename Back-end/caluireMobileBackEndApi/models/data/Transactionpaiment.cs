using System;
using System.Collections.Generic;

namespace caluireMobile.models.data;

public partial class Transactionpaiment
{
    public int IdTransactionPaiment { get; set; }

    public decimal? Montant { get; set; }

    public DateTime? DateTransaction { get; set; }

    public string? Status { get; set; }

    public string? MethodePayement { get; set; }

    public int IdOperation { get; set; }
}
