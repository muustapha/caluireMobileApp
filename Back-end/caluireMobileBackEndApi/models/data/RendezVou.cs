﻿using System;
using System.Collections.Generic;

namespace caluireMobile.Models.Data;

public partial class RendezVou
{
    public int IdClient { get; set; }

    public int IdOperation { get; set; }

    public string? Description { get; set; }

    public DateTime? DateHeureRdv { get; set; }

    public virtual Client ClientNavigation { get; set; }

    public virtual Operation OperationNavigation { get; set; }
}
