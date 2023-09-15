﻿using Synopsis.Models.Partners;

namespace Colibri.Models.Partners;

public class PartnersGroupedCollection
{
    public IEnumerable<Partner>? MediaPartners { get; init; }
    public IEnumerable<Partner>? Partners { get; init; }

}