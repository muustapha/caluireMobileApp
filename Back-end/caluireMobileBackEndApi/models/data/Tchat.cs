﻿using System;
using System.Collections.Generic;

namespace caluireMobile.models.data;

public partial class Tchat
{
    public int IdClient { get; set; }

    public int IdEmploye { get; set; }

    public string? NomUtilisateur { get; set; }

    public string? SocketId { get; set; }
}
