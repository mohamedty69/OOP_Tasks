using System;
using System.Collections.Generic;

namespace API_CRUD.Data;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Sku { get; set; } = null!;
}
