﻿using System.Runtime.Serialization;

namespace Empresas.Domain.Enum;

public enum EPorte
{
    [EnumMember(Value = "Pequena")]
    Pequena = 0,
    [EnumMember(Value = "Media")]
    Media = 1,
    [EnumMember(Value = "Grande")]
    Grande = 2
}
