namespace RoyalCode.Yasamen.Demos.Wasm.Models;

public class DistributionCenter
{
    public Guid Id { get; set; }

    public string Number { get; set; }
    
    public string Name { get; set; }
}

public class Warehouse
{
    public Guid Id { get; set; }
    
    public string Number { get; set; }
    
    public string Description { get; set; }
    
    public DistributionCenter DistributionCenter { get; set; }
}

public class Area
{
    public Guid Id { get; set; }
    
    public string Number { get; set; }
    
    public string Name { get; set; }

    public Warehouse Warehouse { get; set; }
}

public class Address
{
    public Guid Id { get; set; }
    
    public string Number { get; set; }

    public Area Area { get; set; }
}

public class WarehouseItem
{
    public Address Address { get; set; }

    public Sku Sku { get; set; }
    
    public decimal Quantitiy { get; set; }
}

public class Product
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
}

public class Sku
{
    public Guid Id { get; set; }
    
    public Product Product { get; set; }
    
    public StorageUnit Unit { get; set; }
}

public class StorageUnit
{
    public Guid Id { get; set; }
    
    public string Description { get; set; }
}

public class WarehouseDto
{
    public Guid AreaId { get; set; }
}