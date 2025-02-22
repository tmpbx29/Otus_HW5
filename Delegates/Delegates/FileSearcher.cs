namespace Delegates
{
    public class FileSearcher
    {
        public event EventHandler<FileArgs> FileFound;

        private bool _cancelRequested = false;

        public void Search(string directory)
        {
            _cancelRequested = false;
            SearchDirectory(directory);
        }

        private void SearchDirectory(string directory)
        {
            if (_cancelRequested) return;
            
            foreach (var file in Directory.EnumerateFiles(directory))
            {
                if (_cancelRequested) break;

                var args = new FileArgs(file);
                FileFound?.Invoke(this, args);
                    
                if (args.Cancel)
                {
                    _cancelRequested = true;
                    break;
                }
            }

            if (!_cancelRequested)
            {
                foreach (var subDir in Directory.EnumerateDirectories(directory))
                {
                    SearchDirectory(subDir);
                    if (_cancelRequested) break;
                }
            }
        }
    }
}
