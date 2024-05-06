using DesignPatterns_HW3.ChecksuCalculator;
using DesignPatterns_HW3.Common;
using DesignPatterns_HW3.FileSystem;
using DesignPatterns_HW3.FileSystemProvider;
using DesignPatterns_HW3.Observer;
using DesignPatterns_HW3.Visitor.Memento;

namespace DesignPatterns_HW3.Visitor
{
    public class HashStreamWriterVisitor : BaseObservableStreamWriter, IFileSystemEntityMementoVisitor
    {
        // No multiple inheritance
        private readonly HashSet<string> _visitedEntities = new();
        private IFileSystemEntity? _root = null;

        private readonly IChecksumCalculator _checksumCalculator;
        private readonly IFileSystemProvider _fileSystemProvider;

        public HashStreamWriterVisitor(
            Stream outputStream,
            IChecksumCalculator checksumCalculator,
            IFileSystemProvider fileSystemProvider
            ) : base(outputStream) 
        {
            _checksumCalculator = checksumCalculator;
            _fileSystemProvider = fileSystemProvider;
        }

        /// <summary>
        /// On request for stop => set to true
        /// When is becomes false => it is ready to take a snapshot
        /// </summary>
        protected bool Stopping { get; private set; } = false;

        public bool Stopped { get; private set; } = false;

        public override void Attach(IObserver observer)
        {
            _checksumCalculator.Attach(observer);
            base.Attach(observer);
        }

        public void Visit(File file)
        {
            // if the root is file, we don't need to set
            // it also does not bother us for pausing logic
            if (_visitedEntities.Contains(file.RelativePath))
            {
                Notify(this, new FileMessage(file.RelativePath, file.Size, true));
                return;
            }

            _visitedEntities.Add(file.RelativePath);

            Notify(this, new FileMessage(file.RelativePath, file.Size));
            try
            {
                using var stream = _fileSystemProvider.OpenFile(file.RelativePath, FileMode.Open);
                var checksum = _checksumCalculator.Calculate(stream);
                streamWriter.WriteLine();
                streamWriter.WriteLine($"Checksum - {checksum}");
            }
            catch (Exception ex)
            {
                streamWriter.WriteLine($"Error accessing file {ex.Message}");
            }
        }

        public void Visit(Directory directory)
        {
            if(_root == null)
            {
                _root = directory;
            }

            if (_visitedEntities.Contains(directory.RelativePath))
            {
                CheckIfFinished(directory);
                return;
            }

            _visitedEntities.Add(directory.RelativePath);

            Notify(this, new FileMessage(directory.RelativePath, directory.Size));
            foreach (var file in directory.Children)
            {
                file.Accept(this);
                if(Stopping)
                {
                    _visitedEntities.Remove(directory.RelativePath);
                    // if we are at the root, this is the last step of the visiting
                    CheckIfFinished(directory);
                    return;
                }
            }

            // operation is done
            CheckIfFinished(directory);
        }

        private void CheckIfFinished(Directory directory)
        {
            if(directory == _root)
            {
                Stopping = false;
                Stopped = true;
            }
        }

        // Maybe move this inside visit methods, when we reach the root again, we can reset the visited entities
        public void Reset()
        {
            _visitedEntities.Clear();
        }

        // Should be called only when Stopped is true and stopping is false
        public ProcessedFilesSnapshot GetSnapshot()
        {
            return new ProcessedFilesSnapshot(_visitedEntities, _root);
        }

        public void Restore(ProcessedFilesSnapshot snapshot)
        {
            _visitedEntities.Clear();
            _visitedEntities.UnionWith(snapshot.Visited);
            _root = snapshot.Root;
            Stopped = false;
            _root.Accept(this);
        }

        // Meant to be called while the visitor is operating
        public void Pause()
        {
            Stopping = true;
            Stopped = true;
        }
    }
}
