using System.Reflection;

namespace Ollix.Infrastructure.Data;

public class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}

