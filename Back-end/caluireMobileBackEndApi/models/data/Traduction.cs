﻿using System;
using System.Collections.Generic;

namespace caluireMobile.models.data;

public partial class Traduction
{
    public int IdTraduction { get; set; }

    public string? Clef { get; set; }

    public string? Langue { get; set; }

    public string? Valeur { get; set; }
}
