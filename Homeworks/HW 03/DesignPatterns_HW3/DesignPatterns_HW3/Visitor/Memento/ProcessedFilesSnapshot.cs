using DesignPatterns_HW3.FileSystem;
using System.Collections.Immutable;

namespace DesignPatterns_HW3.Visitor.Memento
{
    public class ProcessedFilesSnapshot
    {
        public ProcessedFilesSnapshot(IEnumerable<string> visited, IFileSystemEntity root)
        {
            Visited = visited.ToImmutableHashSet();
            Root = root;
        }

        public ImmutableHashSet<string> Visited { get; }

        public IFileSystemEntity Root { get; }
    }
}
