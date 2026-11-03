using System;
using System.Collections.Generic;
using System.Text;

namespace ProductCatalog;

/// <summary>
/// The IPriced interface indicates that each class implementing it
/// must have Name and Price properties.
/// </summary>
public interface IPriced
{
    string Name { get; }
    double Price { get; }
}
