using System;
using System.Collections.Generic;

namespace Spark.EquipTests.Desktop.Models;

/// <summary>
/// Параметр теста
/// </summary>
public partial class Parameter
{
    public int ParameterId { get; set; }

    public int TestId { get; set; }

    public string ParameterName { get; set; } = null!;

    public decimal RequiredValue { get; set; }

    public decimal MeasuredValue { get; set; }

    public virtual Test Test { get; set; } = null!;
}
