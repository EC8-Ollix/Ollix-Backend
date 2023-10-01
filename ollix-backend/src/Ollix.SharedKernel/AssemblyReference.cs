using System.Reflection;

namespace Ollix.SharedKernel;

public class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
