using System;
using System.Collections.Generic;

namespace caluireMobile.Models.Data;

public partial class Traiter
{
    public int IdOperation { get; set; }

    public int IdProduit { get; set; }

    public virtual Operation OperationNavigation { get; set; }

    public virtual Produit ProduitNavigation { get; set; }
}
