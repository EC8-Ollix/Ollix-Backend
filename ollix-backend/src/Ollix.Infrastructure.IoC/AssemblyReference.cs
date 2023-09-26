using System.Reflection;

namespace Ollix.Infrastructure.IoC;

public class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}