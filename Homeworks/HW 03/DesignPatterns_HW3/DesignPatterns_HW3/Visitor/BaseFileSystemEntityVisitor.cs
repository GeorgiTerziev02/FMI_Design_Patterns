
namespace DesignPatterns_HW3.Visitor
{
    public abstract class BaseFileSystemEntityVisitor : IFileSystemEntityVisitor
    {
        private readonly HashSet<string> _visitedEntities = new();

        public void Visit(File file)
        {
            if(!_visitedEntities.Contains(file.RelativePath))
            {
                return;
            }

            _visitedEntities.Add(file.RelativePath);
        }

        public void Visit(Directory directory)
        {
            if(!_visitedEntities.Contains(directory.RelativePath))
            {
                return;
            }

            _visitedEntities.Add(directory.RelativePath);
        }
    }
}
